/// <reference path="..\..\GSMyAdmin\WebRoot\Scripts\UI.js" />
/// <reference path="..\..\GSMyAdmin\WebRoot\Scripts\API.js" />
/// <reference path="..\..\GSMyAdmin\WebRoot\Scripts\Common.js" />
/// <reference path="..\..\GSMyAdmin\WebRoot\Scripts\PluginHandler.js" />
/// <reference path="..\..\GSMyAdmin\WebRoot\Scripts\knockout-3.5.1.js" />

/* eslint eqeqeq: 0, curly: "error", "no-extra-parens": "off"  */
/* global API,UI,PluginHandler,ko,ace */
const self = this;

this.plugin = {
    PreInit: function () {
        //Called prior to the plugins initialisation, before the tabs are loaded.
        //This method must not invoke any module/plugin specific API calls.
    },

    PostInit: function () {
        if (!userHasPermission("FileManager.FileManager.BrowseFiles")) { return; }

        //The tabs have been loaded. You should wire up any event handlers here.
        PluginHandler.LoadPluginExternalScript("FileManagerPlugin", "ace/ace.js", setupEditor);
        $("#fileManagerClose").off("click").on("click", editorClose);
        $("#fileManagerSave").off("click").on("click", editorSave);
        $("#fileManagerReload").off("click").on("click", editorReload);
        $("#tab_FileManagerPlugin_FileInfoPopup").off("click").on("click", function () { UI.HideWizard(); });
        $(window).off("beforeunload").on("beforeunload", queryExit);
        $(window).off("resize").on("resize", updateFMSize);
        $("#editorFilename").hide();
    },

    AMPDataLoaded: function () {
        if (remoteLogin.isRemote === true) {
            const baseFM = (GetSetting("FileManagerPlugin.FileManager.BasePath") ?? "").replace(/^(\.\/)?(.+?)\/?$/, "$2");
            FMFastModeBasePath += `${remoteLogin.APIToken}/__VDS__${remoteLogin.instanceName}/${baseFM}`;
            initialBasePath = "";
            if (listingVM !== null) {
                listingVM.workingDirectory(initialBasePath);
            }
        }
        else {
            FMFastModeBasePath = API.GetSessionID();
        }
    },

    Reset: function () {
        $("#aceLoadScript").remove();
    }
};

this.tabs = [
    {
        File: "FileManager.html",
        ExternalTab: false,
        ShortName: "FileManager",
        Name: "File Manager",
        Icon: "draft",
        RequiredPermission: "FileManager.FileManager.BrowseFiles",
        Click: initFileListing,
        BodyClass: "noPaddingTab",
        Order: 10,
        PopHandler: handlePopstate,
    },
    {
        File: "FileInfoPopup.html",
        ExternalTab: false,
        ShortName: "FileInfoPopup",
        Name: "FileInfoPopup",
        IsWizard: true
    },
    {
        File: "TargetDirectoryPopup.html",
        ExternalTab: false,
        ShortName: "TargetDirectoryPopup",
        Name: "Target Directory",
        IsWizard: true
    },
    {
        File: "SelectFilePopup.html",
        ExternalTab: false,
        ShortName: "SelectFilePopup",
        Name: "Select File",
        IsWizard: true
    },
    {
        File: "SFTPConnectPopup.html",
        ExternalTab: false,
        ShortName: "SFTPConnectPopup",
        Name: "Connect to SFTP",
        IsWizard: true
    }
];

this.stylesheet = "CSS/Stylesheet.css";    //Styles for tab-specific styles

this.features = {
    RegisterContextMenuHandler: function (extension, title, callback) {
        CustomContextHandlers[extension] = new ContextHandlerVM(title, callback);
    },
    RegisterPostUploadHandler: function (extension, callback) {
        PostUploadHandlers[extension] = callback;
    },
    OpenDirectory: async function (directoryPath) {
        $("a[href='#tab_FileManagerPlugin_FileManager']").click();
        await sleepAsync(500);
        listingVM.workingDirectory(directoryPath);
    },
    OpenFile: function (filepath) { },
    RegisterControlledFile: function (filepath, canImport, importCallback, customMessage) {
        ControlledFiles[filepath] = {
            canImport: canImport,
            importCallback: importCallback,
            message: Locale.l(customMessage) || Locale.l("This file is controlled by AMP. Your changes may be overwritten. Edit this file's settings via the configuration menu.")
        };
    },
};

function ContextHandlerVM(title, callback) {
    this.title = title;
    this.callback = callback;
}

let CustomContextHandlers = {}; //Dictionary of ContextHandlerVM
let PostUploadHandlers = {}; //KVP of String:Function
let ControlledFiles = {};

let FMFastModeBasePath = "";
let initialBasePath = "";

//#region File Editor

let editArea = null;

const editModes = {
    bat: "batchfile",
    coffee: "coffee",
    cs: "csharp",
    css: "css",
    cpp: "c_cpp",
    cxx: "c_cpp",
    conf: "plain_text",
    config: "plain_text",
    cfg: "plain_text",
    kvp: "ini",
    go: "golang",
    html: "html",
    ini: "ini",
    class: "java",
    js: "javascript",
    json: "json",
    less: "less",
    log: "plain_text",
    lua: "lua",
    makefile: "makefile",
    md: "plain_text",
    pl: "perl",
    php: "php",
    ps1: "powershell",
    py: "python",
    sh: "sh",
    sql: "sql",
    ts: "typescript",
    toml: "toml",
    txt: "plain_text",
    xml: "xml",
    yaml: "yaml",
    yml: "yaml"
};

let editJob = null;
let ignoreMakeDirty = false;
let documentDirty = false;

function updateFMSize() {
    if ($("#tab_FileManagerPlugin_FileManager").is(":visible")) {
        const height = $("#fileManagerHeader").height() + "px";
        $("#fileManagerList").css("top", height);
    }
}

async function setupEditor() {
    if (!ace) { console.log("Ace isn't loaded! Can't init editor."); return; }

    if (document.getElementById("editor") === undefined) { return; }
    editArea = ace.edit("editor");
    editArea.setTheme("ace/theme/ambiance");
    editArea.renderer.setScrollMargin(0, 100);
    editArea.setShowPrintMargin(false);
    editArea.setShowInvisibles(true);
    editArea.getSession().setMode("ace/mode/plain_text");
    editArea.getSession().setUseSoftTabs(true);
    editArea.setOptions({ wrap: 5000, indentedSoftWrap: true, enableAutoIndent: true, wrapBehavioursEnabled: true });
    editArea.getSession().on("change", makeDirty);
    $(window).on("keydown", handleShortcuts);
    $("#tab_FileManagerPlugin_FileManager").on("dragover", dragOver);
    $("#tab_FileManagerPlugin_FileManager").on("dragenter", dragEnter);
    $("body").on("mouseleave", dragLeave);
    $("#tab_FileManagerPlugin_FileManager").on("drop", dragDrop);
}

function handlePopstate(_, segments) {
    const newDir = segments.length > 1 ? segments.slice(1).join("/") + "/" : "";
    if (newDir === listingVM.workingDirectory()) {
        listingVM.refresh();
    } else {
        listingVM.workingDirectory(newDir);
    }
}

function queryExit() {
    if (documentDirty) {
        return "You have unsaved changes in the file editor. If you close the page, they will be discarded.";
    }
}

function makeDirty() {
    if (!documentDirty && !ignoreMakeDirty) {
        $("#editorFilenameChanges").fadeIn();
        $("#editorFilename").addClass("dirty");
        documentDirty = true;
    }
}

function makeClean() {
    if (documentDirty === true) {
        $("#editorFilenameChanges").fadeOut();
        $("#editorFilename").removeClass("dirty");
        documentDirty = false;
        editArea.getSession().getUndoManager().markClean();
    }
}

function handleShortcuts(e) {
    if (!e.altKey && (e.ctrlKey || e.metaKey))  //Make sure alt is not pressed, or Polish users will be unhappy! https://medium.com/medium-eng/fa398313d4df
    {
        switch (String.fromCodePoint(e.which).toLowerCase()) {
            case 's':
                editorSave();
                e.preventDefault();
                break;
            case 'r':
                editorReload();
                e.preventDefault();
                break;
        }
    }
}

function setEditorMode(filename) {
    const extension = getFileExtension(filename);
    const newMode = (editModes[extension] != undefined) ? "ace/mode/" + editModes[extension] : "ace/mode/plain_text";
    editArea.getSession().setMode(newMode);
}

function isEditable(filename) {
    const extension = getFileExtension(filename);
    return (editModes[extension] != undefined);
}

function dragEnter(e) {
    e.stopPropagation();
    e.preventDefault();

    $(".uploadOK, .uploadFail").hide();
    $(".uploadArrow").show();

    $("#fileManagerDropNotice").fadeIn();
}

function dragLeave(e) {
    e.stopPropagation();
    e.preventDefault();

    $("#fileManagerDropNotice").fadeOut();
}


function dragOver(e) {
    e.stopPropagation();
    e.preventDefault();

    e.originalEvent.dataTransfer.dropEffect = "copy"; //"none"
}

async function editorSave() {
    if (editJob == null) { return; }

    editJob.jobCompleteAction = makeClean;
    editJob.type = transferType.Upload;
    editJob.data = new Blob([editArea.getValue()], { type: "text/plain" });
    editJob.offset = 0;
    editJob.fileLength = editJob.data.size;

    transferJobQueue.push(editJob);

    await handleNextJob();
}

async function editorReload() {
    if (editJob == null) { return; }

    if (documentDirty) {
        const promptResult = await UI.ShowModalAsync("You have unsaved changes.", "If you reload the document, your changes will be lost. Are you sure you want to do this?", UI.Icons.Exclamation, [
            new UI.ModalAction("Discard Changes", true, "bgRed slideIcon icons_remove"),
            new UI.ModalAction("Continue Editing", false, "bgGreen")
        ]);

        if (promptResult === true) {
            doEditorReload();
        }
    }
    else {
        doEditorReload();
    }
}

function doEditorReload() {
    editJob.jobCompleteAction = jobCompleteAction.Edit;
    editJob.type = transferType.Download;
    editJob.data = "";
    editJob.offset = 0;

    transferJobQueue.push(editJob);

    handleNextJob();
}

async function editorClose() {
    if (documentDirty) {
        const promptResult = await UI.ShowModalAsync("You have unsaved changes.", "If you close the document, your changes will be lost. Are you sure you want to do this?", UI.Icons.Exclamation, [
            new UI.ModalAction("Discard Changes", true, "bgRed slideIcon icons_remove"),
            new UI.ModalAction("Continue Editing", false, "bgGreen")
        ]);

        if (promptResult === true) {
            hideEditor();
        }
    }
    else {
        hideEditor();
    }
}

function showEditor(title) {
    $("#editorFilename").text(title);
    $("#editor, #editorContainer").show();
    $("#editorButtons, #editorFilename").show();
    $("#fileManagerList, #fileManagerInfo").hide();
    if (ControlledFiles.hasOwnProperty(editJob.file)) {
        listingVM.controlledFileInfo(ControlledFiles[editJob.file]);
    }
    listingVM.editorVisible(true);
}

function hideEditor() {
    editJob = null;
    $("#editorButtons, #editorFilename, #editorFilenameChanges").hide();
    $("#fileManagerList, #fileManagerInfo").show();
    $("#editor, #editorContainer").hide();
    listingVM.controlledFileInfo(null);
    listingVM.editorVisible(false);
}

//#endregion

function getFileExtension(filename) {
    let pos = filename.lastIndexOf(".");
    if (pos === -1) { return filename; }

    return filename.slice(++pos);
}

function sendAsync(targetPath, file, onProgressCallback) {
    return new Promise((resolve, reject) => {
        const xhr = new XMLHttpRequest();

        xhr.upload.onprogress = function (e) {
            if (onProgressCallback) {
                onProgressCallback(e.loaded);
            }
        };

        xhr.onload = function () {
            resolve(xhr.response);
        };

        xhr.onerror = function () {
            reject(new Error('An error occurred'));
        };

        xhr.open("POST", targetPath, true);
        xhr.send(file);
    });
}

async function dragDrop(e) {
    e.stopPropagation();
    e.preventDefault();

    const items = e.originalEvent.dataTransfer.items;
    let hasDirectory = false;

    if (items && items.length > 0) {
        for (const item of items) {
            if (item.webkitGetAsEntry()?.isDirectory) {
                hasDirectory = true;
                break;
            }
        }
    }

    if (hasDirectory) {
        async function traverseDirectory(entry, path = "") {
            return new Promise((resolve) => {
                if (entry.isFile) {
                    entry.file(file => {
                        file.relativePath = path + file.name;
                        resolve([file]);
                    });
                } else if (entry.isDirectory) {
                    const dirReader = entry.createReader();
                    dirReader.readEntries(async entries => {
                        let files = [];
                        for (const ent of entries) {
                            files = files.concat(await traverseDirectory(ent, path + entry.name + "/"));
                        }
                        resolve(files);
                    });
                }
            });
        }
        let allFiles = [];
        for (const item of items) {
            const entry = item.webkitGetAsEntry();
            if (entry) {
                allFiles = allFiles.concat(await traverseDirectory(entry));
            }
        }
        if (allFiles.length === 0) {
            showDropFailAnim();
            UI.ShowModalAsync("Cannot upload folders", "No files found in the dropped folder.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }
        showDropAckAnim();

        let uploadedCount = 0;
        const totalCount = allFiles.length;
        const notificationId = UI.CreateLocalNotification("Folder Upload", `Uploading ${totalCount} files...`, null, 0, null);

        function updateBatchNotification() {
            UI.UpdateLocalNotification(notificationId, Math.floor((uploadedCount / totalCount) * 100), false, `Uploading ${uploadedCount}/${totalCount} files...`);
        }

        const CONCURRENCY = 4;
        let nextIndex = 0;
        let activeUploads = 0;
        let finished = false;
        function startNextUpload() {
            if (finished) return;
            if (nextIndex >= totalCount) {
                if (activeUploads === 0) {
                    finished = true;
                    UI.RemoveLocalNotification(notificationId);
                    listingVM.refresh();
                }
                return;
            }
            const file = allFiles[nextIndex++];
            activeUploads++;
            let job = new FileTransferJob();
            job.path = listingVM.workingDirectory() + (file.relativePath.substring(0, file.relativePath.lastIndexOf("/") + 1) || "");
            job.file = file.name;
            job.fileLength = file.size;
            job.type = transferType.Upload;
            job.offset = 0;
            job.fastMode = false;
            job.cancellable = false;
            job.data = file;
            job.isBatch = true;
            job.jobCompleteAction = function () {
                uploadedCount++;
                updateBatchNotification();
                activeUploads--;
                startNextUpload();
            };
            job.process();

            if (activeUploads < CONCURRENCY && nextIndex < totalCount) {
                startNextUpload();
            }
        }
        updateBatchNotification();

        for (let i = 0; i < CONCURRENCY && i < totalCount; i++) {
            startNextUpload();
        }
        return;
    }

    const files = e.originalEvent.dataTransfer.files;
    for (const file of files) {
        if (file.size === 0 && file.type === "") {
            showDropFailAnim();
            UI.ShowModalAsync("Cannot upload folders", "Please create a zip of your folder and upload that instead.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }
    }
    showDropAckAnim();
    for (const file of files) {
        let job = new FileTransferJob();
        job.path = listingVM.workingDirectory();
        job.file = file.name;
        job.fileLength = file.size;
        job.type = transferType.Upload;
        job.offset = 0;
        job.fastMode = false;
        job.cancellable = true;
        job.data = file;
        transferJobQueue.push(job);
    }
    handleNextJob();
}

async function showDropFailAnim() {
    await $(".uploadArrow").fadeOut(250).promise();
    await $(".uploadFail").fadeIn(500).promise();
    $("#fileManagerDropNotice").fadeOut();
}

async function showDropAckAnim() {
    await $(".uploadArrow").fadeOut(250).promise();
    await $(".uploadOK").fadeIn(500).promise();
    $("#fileManagerDropNotice").fadeOut();
}

//#region File uploads/downloads

const transferType = {
    Upload: "Uploading",
    Download: "Downloading"
};

const jobCompleteAction = {
    None: 0,
    Save: 10,
    Edit: 20,
    Preview: 30,
    Callback: 40
};

const previewableExtensions = ["png", "jpg", "jpeg", "gif", "mp3", "mp4", "ogg", "webm", "flac", "ogv"];

let transferJobQueue = [];
let currentJob = null;
const maxFastModeUploadSize = 256 * 1024 * 1024;

function padLeft2(input) {
    const str = "" + input;
    const pad = "00";
    const ans = pad.substring(0, pad.length - str.length) + str;
    return ans;
}

function secsToTimestamp(secs) {
    secs = Math.floor(secs);
    const mins = Math.floor(secs / 60);
    const dSecs = secs % 60;
    const hours = Math.floor(mins / 60);
    const dMins = mins % 60;
    return padLeft2(hours) + ":" + padLeft2(dMins) + ":" + padLeft2(dSecs);
}

async function downloadFileChunks(filename, job) {
    const CHUNK_SIZE = 1048576; // 1 MB
    let offset = 0;
    let chunks = [];

    async function readChunk(filename, offset) {
        try {
            const response = await API.FileManagerPlugin.ReadFileChunkAsync(filename, offset, CHUNK_SIZE);
            if (!response.Status) {
                throw new Error(response.Reason);
            }
            return response.Result;
        } catch (error) {
            console.error(`Error reading chunk at offset ${offset}:`, error);
            throw error;
        }
    }

    while (true) {
        if (job.cancelled) break;
        try {
            job.offset = offset;
            const chunkBase64 = await readChunk(job.path + filename, offset);
            const chunkData = atob(chunkBase64);
            const byteArray = new Uint8Array(chunkData.length);
            job.updateProgress();

            for (let i = 0; i < chunkData.length; i++) {
                byteArray[i] = chunkData.codePointAt(i);
            }

            chunks.push(byteArray);

            if (byteArray.length < CHUNK_SIZE) {
                // The last chunk has been read
                break;
            }

            offset += CHUNK_SIZE;
        } catch (error) {
            console.error(`Error downloading file ${filename}:`, error);
            throw error;
        }
    }

    if (job.cancelled) return null;
    const blob = new Blob(chunks, { type: "application/octet-stream" });
    return blob;
}

async function sendFileChunks(file, job, concurrentUploads = 1) {
    const CHUNK_SIZE = 512 * 1024; // 512 KB
    const fileSize = file.size;
    const fileName = job.file;
    const chunkCount = Math.max(Math.ceil(fileSize / CHUNK_SIZE), 1);
    console.log(`Uploading file ${file.name}.`);

    function readFileChunk(file, start, end) {
        return new Promise((resolve, reject) => {
            const fileReader = new FileReader();
            fileReader.onload = () => {
                const base64 = fileReader.result.split(',')[1];
                resolve(base64);
            };
            fileReader.onerror = (error) => {
                reject(new Error(error));
            };
            const blob = file.slice(start, end);
            fileReader.readAsDataURL(blob);
        });
    }

    async function sendChunkWithRetry(chunkDataBase64, offset, finalChunk, index) {
        let retryCount = 0;
        while (retryCount <= 5 && !job.cancelled) {
            try {
                job.offset = offset;
                const response = await API.FileManagerPlugin.WriteFileChunkAsync(job.path + fileName, chunkDataBase64, offset, finalChunk);
                job.updateProgress();

                if (!response.Status) {
                    if (!job.cancelled) {
                        UI.ShowModalAsync("Error uploading file", response.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
                    }
                    job.cancelled = true;
                    job.finish();
                    return false;
                }

                console.log(`Chunk ${index || 'Final'} sent successfully.`);
                return true;
            } catch (error) {
                console.error(`Error sending chunk, Attempt ${retryCount + 1}:`, error);

                if (retryCount >= 5) {
                    return false;
                }

                await sleepAsync(retryCount * 1000);
                retryCount++;
            }
        }
        return false;
    }

    async function processChunk(chunkIndex) {
        const start = chunkIndex * CHUNK_SIZE;
        const end = Math.min(start + CHUNK_SIZE, fileSize);
        const chunkDataBase64 = await readFileChunk(file, start, end);
        const offset = start;
        const finalChunk = false;

        const success = await sendChunkWithRetry(chunkDataBase64, offset, finalChunk, chunkIndex);
        if (!success) {
            throw new Error(`Failed to upload chunk at offset ${offset}`);
        }
    }

    const chunkQueue = Array.from({ length: chunkCount - 1 }, (_, index) => index);
    const activeUploads = [];

    // Process all chunks except the last one
    while ((chunkQueue.length > 0 || activeUploads.length > 0) && !job.cancelled) {
        while (activeUploads.length < concurrentUploads && chunkQueue.length > 0 && !job.cancelled) {
            const chunkIndex = chunkQueue.shift();
            const uploadPromise = processChunk(chunkIndex)
                .catch(error => {
                    console.error(`Failed to process chunk ${chunkIndex}:`, error);
                    job.cancelled = true;
                    job.finish();
                })
                .finally(() => {
                    activeUploads.splice(activeUploads.indexOf(uploadPromise), 1);
                });
            activeUploads.push(uploadPromise);
        }

        if (activeUploads.length > 0) {
            await Promise.race(activeUploads);
        }
    }

    if (job.cancelled) {
        await API.FileManagerPlugin.ReleaseFileUploadLockAsync(self.path + self.file);
        console.log(`File upload cancelled.`);
        return;
    }

    // Process the final chunk
    const finalChunkIndex = chunkCount - 1;
    const start = finalChunkIndex * CHUNK_SIZE;
    const end = Math.min(start + CHUNK_SIZE, fileSize);
    const chunkDataBase64 = await readFileChunk(file, start, end);
    const offset = start;
    const finalChunk = true;

    const success = await sendChunkWithRetry(chunkDataBase64, offset, finalChunk);
    if (!success) {
        throw new Error(`Failed to upload final chunk at offset ${offset}`);
    }

    console.log(`All chunks sent successfully.`);
}

async function blobToUTF8String(blob) {
    return new Promise((resolve, reject) => {
        const fileReader = new FileReader();

        fileReader.onload = () => {
            const text = fileReader.result;
            resolve(text);
        };

        fileReader.onerror = (error) => {
            reject(new Error(error));
        };

        fileReader.readAsText(blob, 'utf-8');
    });
}

function FileTransferJob() {
    const self = this;
    this.jobCompleteAction = jobCompleteAction.None;
    this.type = transferType.Download;
    this.data = "";
    this.fileLength = 0;
    this.offset = 0;
    this.path = "";
    this.file = "";
    this.notificationId = -1;
    this.fastMode = false;
    this.webSocketMode = false;
    this.cancelled = false;
    this.startTime = new Date();
    this.progress = function () { return Math.floor((this.offset / this.fileLength) * 100); };
    this.remaining = function () { return this.fileLength - this.offset; };
    this.elapsedSeconds = function () { return (Date.now() - this.startTime) / 1000; };
    this.speed = function () { return Math.floor(this.offset / this.elapsedSeconds()); };
    this.displaySpeed = function () { return getFriendlySize(this.speed()) + "/sec"; };
    this.eta = function () { return this.remaining() / this.speed(); };
    this.displayEta = function () { return "ETA " + secsToTimestamp(this.eta()) + " @" + this.displaySpeed(); };
    this.cancellable = false;
    this.request = null;
    this.callback = null;
    this.afterSave = null;
    this.isBatch = false; // Suppress per-file notification if true
    this.updateProgress = function () {
        if (self.isBatch) return;
        if (self.notificationId == -1) {
            let APIMode = self.webSocketMode && !self.fastMode ? "(WebSocket Mode)" : "(API Mode)";
            self.notificationId = UI.CreateLocalNotification("File Transfer " + ((self.fastMode) ? "(Direct Mode)" : APIMode), self.type + " " + self.file, null, 0, self.cancel);
            UI.UpdateLocalNotification(self.notificationId, 1000);
        }
        let progress = Math.floor((self.offset / self.fileLength) * 100);
        if (progress > 0) {
            let speedMsg = self.displayEta();
            if (transferJobQueue.length > 0) {
                speedMsg += " (" + transferJobQueue.length + " in queue)";
            }
            UI.UpdateLocalNotification(self.notificationId, progress, false, speedMsg);
        }
        if (self.offset >= self.fileLength) {
            self.finish();
        }
    };
    this.finish = function () {
        console.log(`Finishing file transfer job ${self.notificationId} - ${self.file}`);
        clearInterval(self.updateInterval);
        UI.RemoveLocalNotification(self.notificationId);
        currentJob = null;
    };
    this.cancel = async function () {
        self.cancelled = true;
        self.finish();
    }

    this.updateInterval = setInterval(self.updateProgress, 500);

    this.process = async function () {
        try {
            switch (self.type) {
                case transferType.Upload:
                    {
                        await sendFileChunks(self.data, self);
                        self.finish();
                        if (typeof (self.jobCompleteAction) === "function") {
                            self.jobCompleteAction(self);
                        }
                        listingVM.refresh();
                        break;
                    }
                case transferType.Download:
                    {
                        const blob = await downloadFileChunks(self.file, self);
                        self.finish();
                        if (typeof (self.jobCompleteAction) === "function") {
                            self.jobCompleteAction(self);
                            break;
                        }
                        switch (self.jobCompleteAction) {
                            case jobCompleteAction.Save:
                                saveAs(blob, self.file);
                                if (typeof (self.afterSave) === "function") {
                                    await self.afterSave();
                                }
                                break;
                            case jobCompleteAction.Edit:
                                {
                                    const strData = await blobToUTF8String(blob);
                                    editJob = self;
                                    setEditorMode(self.file);
                                    ignoreMakeDirty = true;
                                    editArea.setValue(strData);
                                    ignoreMakeDirty = false;
                                    editArea.clearSelection();
                                    editArea.getSession().setScrollTop(0);
                                    makeClean();
                                    showEditor(self.file);
                                    break;
                                }
                            case jobCompleteAction.Callback:
                                {
                                    const fileStr = await blobToUTF8String(blob);
                                    self.callback(fileStr);
                                    break;
                                }
                        }
                        break;
                    }
            }
        } catch (error) {
            console.error("File transfer job failed:", error);
            UI.ShowModalAsync("File transfer failed", error?.message || "An unknown error occurred.", UI.Icons.Exclamation, UI.OKActionOnly);
            self.finish();
        }

        handleNextJob();
    }
}

async function handleNextJob() {

    if (transferJobQueue.length == 0) {
        return;
    }

    if (currentJob == null) {
        let job = transferJobQueue.shift();
        currentJob = job;
        console.log(`Starting file transfer job ${currentJob.notificationId} - ${currentJob.file}`);
        await sleepAsync(500);
        job.process();
    }
}

function addNewDownloadJob(listing, action, callback, afterSave = null) {
    if (action === jobCompleteAction.Save && !afterSave && currentSettings["FileManagerPlugin.FileManager.FastFileTransfers"].value() === true) {
        const fullPath = `/fetch/${FMFastModeBasePath}/${listingVM.workingDirectory()}${listing.Filename}`;
        window.open(fullPath);
        return;
    }

    let job = new FileTransferJob();
    job.file = listing.Filename;
    job.path = listingVM.workingDirectory();
    job.fileLength = listing.SizeBytes;
    job.type = transferType.Download;
    job.callback = callback;
    job.afterSave = afterSave;
    job.jobCompleteAction = action;

    transferJobQueue.push(job);

    handleNextJob();
}
//#endregion

function getFriendlySize(input) {
    if (input == undefined || input == null || input == "") {
        return "";
    }

    const suffixes = ["B", "KB", "MB", "GB", "TB", "PB"];
    let index = 0;

    while (input > 1024 && index < suffixes.length) {
        input /= 1024;
        index++;
    }

    return `${input.toFixed(2)} ${suffixes[index]}`;
}

let lastListing = [];
let listingVM = null;
let dirVM = null;
let selFileVM = null;
let listingInited = false;

function getDirectoryFromCurrentURL() {
    const parts = window.location.pathname.split("/").filter(s => s.length > 0);
    const fmIdx = parts.findIndex(p => p.toLowerCase() === "filemanager");
    if (fmIdx < 0 || fmIdx >= parts.length - 1) { return ""; }
    return parts.slice(fmIdx + 1).map(decodeURIComponent).join("/") + "/";
}

function initFileListing() {
    updateFMSize();

    if (listingInited === true) { return; }
    listingInited = true;

    listingVM = new FileListVM();
    dirVM = new DirListVM();
    selFileVM = new SelectFileVM();

    const startDir = initialBasePath || getDirectoryFromCurrentURL();
    if (startDir) {
        listingVM.workingDirectory(startDir);
    } else {
        listingVM.refresh();
    }

    UI.ApplyVMBinding(listingVM, document.getElementById("tab_FileManagerPlugin_FileManager"));
    UI.ApplyVMBinding(listingVM, document.getElementById("FMContextMenu"));
    UI.ApplyVMBinding(listingVM, document.getElementById("FMSFTPConnectPopup"));
    UI.ApplyVMBinding(selFileVM, document.getElementById("tab_FileManagerPlugin_SelectFilePopup"));
    UI.ApplyVMBinding(dirVM, document.getElementById("FMTargetDirectoryPopup"));

    window.pickFile = (title, actionText) => new Promise(resolve => selFileVM.show(title, actionText, resolve));
}

function getIcon(listing) {
    if (listing.name == ".trash") { listing.displayName = "Trashed Files"; listing.special = "trash"; return "delete"; }
    if (listing.isVirtual && listing.name.startsWith("Datastore_")) { return "drive_file_move"; }
    if (listing.isVirtual) { return "drive_file_move"; }
    if (listing.isDirectory) { return "folder"; }

    const extension = listing.name.toLowerCase().split(".").last();
    switch (extension) {
        case "zip":
        case "7z":
        case "gz":
        case "bz2":
        case "tar":
            return "folder_zip";
        case "txt":
        case "log":
            return "description";
        default:
            return "draft";
    }
}

function getSubicon(listing)
{
    const extension = listing.name.toLowerCase().split(".").last();

    if (listing.isDirectory) {
        switch (extension) {
            case "licences":
                return "key"
            case "plugins":
                return "extension";
            case "config":
                return "tune";
            case "logs":
            case "amp_logs":
                return "description";
            case "html":
            case "css":
            case "webroot":
                return "public";
            case "images":
                return "photo_camera";
            case "fonts":
                return "text_fields"
            case "backups":
                return "database";
            case "backupExclude":
            case "autoExclude":
                return "toggle_off";
            case "save":
            case "saves":
            case "saved":
                return "save";
            case "bin":
            case "bin64":
            case "binaries":
            case "linux32":
            case "linux64":
            case "win":
            case "win32":
            case "win64":
            case "x86_64":
                return "terminal";
            default:
                return "";
        }
    }

    switch (extension) {
        case "cfg":
        case "conf":
        case "config":
        case "properties":
        case "ini":
        case "json":
        case "yml":
        case "yaml":
        case "toml":
        case "kvp":
            return "tune";
        case "dll":
        case "so":
        case "1":
        case "2":
        case "3":
        case "4":
        case "5":
        case "6":
        case "7":
        case "8":
        case "9":
        case "dylib":
        case "debug":
            return "manufacturing";
        case "exe":
        case "com":
        case "jar":
        case "sh":
        case "out":
        case "cmd":
        case "ps1":
        case "run":
        case "lua":
        case "bat":
        case "go":
        case "x86_64":
            return "terminal";
        case "gif":
        case "jpg":
        case "jpeg":
        case "png":
        case "bmp":
        case "tiff":
        case "svg":
        case "webp":
        case "ico":
            return "photo_camera";
        case "htm":
        case "html":
        case "css":
        case "less":
        case "js":
        case "php":
            return "public";
        case "mp4":
        case "webm":
        case "avi":
            return "movie";
        case "mp3":
        case "wav":
        case "ogg":
        case "flac":
            return "music_note";
        case "ttf":
        case "woff":
        case "woff2":
            return "text_fields";
        case "db":
        case "dat":
        case "mdb":
        case "mdf":
        case "ldf":
        case "sql":
        case "sqlite":
        case "xml":
        case "csv":
        case "assets":
        case "pak":
            return "database";
        case "lock":
            return "lock";
        case "old":
            return "history";
        case "lic":
        case "key":
            return "key"
        default:
            return "";
    }
}

function FileEntryVM(listing, vm) {
    const self = this;

    this.special = "";
    this.created = parseDate(listing.Created)?.getTimestamp() ?? "";
    this.directory = vm.workingDirectory();
    this.downloadable = listing.IsDownloadable;
    this.editable = listing.IsEditable;
    this.excludedFromBackups = ko.observable(listing.IsExcludedFromBackups);
    this.isArchive = listing.IsArchive;
    this.isDirectory = listing.IsDirectory;
    this.isInternal = false;
    this.isVirtual = listing.IsVirtualDirectory;
    this.listing = listing;
    this.modified = parseDate(listing.Modified)?.getTimestamp() ?? "";
    this.name = listing.Filename;
    this.displayName = this.name;
    this.selected = ko.observable(false);
    this.sizeBytes = listing.SizeBytes || 0;

    this.customAction = ko.computed(function () {
        const extension = self.name.toLowerCase().split(".").last();
        if (CustomContextHandlers.hasOwnProperty(extension)) {
            return CustomContextHandlers[extension];
        }
        return null;
    });
    this.invokeCustomAction = function () {
        self.customAction().callback(self);
    };

    this.icon = getIcon(this);
    this.subIcon = getSubicon(this);
    this.pathName = this.isVirtual ? "__VDS__" + this.name : this.name;
    this.fullPath = self.directory + self.pathName;
    this.sizeFriendly = (this.sizeBytes != "" && this.sizeBytes > 0) ? getFriendlySize(this.sizeBytes) : "";
    this.subtitle = this.isVirtual && this.isDirectory ? "Virtual Directory" :
        this.isDirectory ? "Directory" :
            this.sizeFriendly;
    this.vm = vm;

    this.calcmd5 = async function () {
        const result = await API.FileManagerPlugin.CalculateFileMD5SumAsync(self.fullPath);
        if (result.Status) {
            await UI.ShowModalAsync("MD5Sum Result", `Sum for ${self.fullPath}:`, UI.Icons.Info, UI.OKActionOnly, null, null, result.Result);
        }
    };

    this.excludedFromBackups.subscribe(() => {
        self.updateBackupExclusion();
    });
    this.toggleBackupExclusion = function () {
        self.excludedFromBackups(!self.excludedFromBackups());
    };
    this.updateBackupExclusion = async function () {
        const exclude = self.excludedFromBackups();
        const result = await API.FileManagerPlugin.ChangeExclusionAsync(self.fullPath, self.isDirectory, exclude);

        if (result.Status !== true) {
            UI.ShowModalAsync("Unable to toggle backup exclusion", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.click = function () {
        if (self.isDirectory) {
            self.defaultAction();
            return;
        }
        self.selected(true);
        if (vm.selectedEntry() != null) {
            vm.selectedEntry().selected(false);
        }
        vm.selectedEntry(self);
        $("#fileManagerInfo").toggleClass("visible");
    };

    this.doubleClick = function () {
        if (this.editable) {
            this.edit();
        }
        else if (this.downloadable) {
            this.download();
        }

        if (self.isDirectory) {
            self.defaultAction();
        }
    };

    this.defaultAction = function () {
        if (this.isDirectory) {
            if (listingVM._refreshing) { return; }
            vm.selectedEntry(null);

            const currentDirectory = vm.workingDirectory();
            let newDirectory = "";

            if (this.name === "..") {
                const parts = currentDirectory.split("/");
                parts.pop();
                parts.pop();
                newDirectory = parts.join("/");
                if (parts.length > 0) {
                    newDirectory = newDirectory + "/";
                }
            }
            else {
                newDirectory = currentDirectory + self.pathName + "/";
            }

            vm.workingDirectory(newDirectory);
        }
    };

    this.menu = function (data, event) {
        event.preventDefault();
        vm.selectedEntry(this);
        UI.ShowPopupMenu("#tab_FileManagerPlugin_FileInfoPopup", event);
    };

    this.kebab = function (data, event) {
        if (UI.GetIsMobile()) {
            self.menu(data, event);
        }
    };

    this.download = () => addNewDownloadJob(this.listing, jobCompleteAction.Save);

    this.edit = () => addNewDownloadJob(this.listing, jobCompleteAction.Edit);

    this.getContentsAsync = () => new Promise(resolve => addNewDownloadJob(self.listing, jobCompleteAction.Callback, resolve));

    this.copy = function () {
        vm.clipboardFiles.removeAll();
        vm.clipboardFiles.push(this);
    };

    this.paste = pasteFile;

    this.trash = async function () {
        const result = await UI.ShowModalAsync("Move to trash", { text: "Are you sure you want to move the selected item to the trash?", subtitle: this.listing.Filename }, UI.Icons.Exclamation, [
            new UI.ModalAction("Delete Item", true, "bgRed slideIcon icons_remove", true),
            new UI.ModalAction("Cancel", false, "", true)
        ]);

        if (result === true) {
            let deleteResult;

            if (self.isDirectory) {
                deleteResult = await API.FileManagerPlugin.TrashDirectoryAsync(self.fullPath);
            }
            else {
                deleteResult = await API.FileManagerPlugin.TrashFileAsync(self.fullPath);
            }

            if (deleteResult.Status === true) {
                self.vm.refresh();
            }
            else {
                UI.ShowModalAsync(`Failed to trash ${self.isDirectory ? "directory" : "file"}`, deleteResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
            }
        }
    };

    this.emptyTrash = async function () {
        if (self.special !== "trash") { return; }

        const result = await UI.ShowModalAsync("Empty Trash", "Are you sure you want to permanently delete all items from your trash? This operation cannot be undone!", UI.Icons.Exclamation, [
            new UI.ModalAction("Delete Forever", true, "bgRed slideIcon icons_remove", true),
            new UI.ModalAction("Cancel", false, "", true)
        ]);

        if (result === true) {
            const deleteResult = await API.FileManagerPlugin.EmptyTrashAsync(self.fullPath);

            if (deleteResult.Status === true) {
                self.vm.refresh();
            }
            else {
                UI.ShowModalAsync("Failed to empty trash.", deleteResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
            }
        }
    };

    this.downloadFileHere = async function () {
        if (!this.isDirectory) { return; }

        const requestUrl = await UI.PromptAsync("Download file from URL", "Enter URL to download to your server. The URL must be a direct link.");
        if (requestUrl === null) { return; }

        const result = await API.FileManagerPlugin.DownloadFileFromURLTaskAsync(requestUrl, self.fullPath);
        if (result.Status) {
            result.onComplete(vm.refresh);
        }
        else {
            UI.ShowModalAsync("Unable to download file", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.createArchive = async function () {
        if (!this.isDirectory) { return; }
        const result = await API.FileManagerPlugin.CreateArchiveTaskAsync(self.fullPath);
        if (result.Status) {
            result.onComplete(vm.refresh);
        }
        else {
            UI.ShowModalAsync("Unable to create archive", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.extractArchive = async function () {
        if (!this.isArchive) { return; }
        const result = await API.FileManagerPlugin.ExtractArchiveTaskAsync(self.fullPath, vm.workingDirectory);
        if (result.Status) {
            result.onComplete(vm.refresh);
        }
        else {
            UI.ShowModalAsync("Unable to extract archive", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.extractArchiveTo = async function () {
        if (!this.isArchive) { return; }
        await sleepAsync(1000);
        const target = await pickDirectory("Extract Archive To...", "Extract here");
        if (target != null) {
            await API.FileManagerPlugin.ExtractArchiveAsync(self.fullPath, target);
        }
    };

    this.rename = async function () {
        if (this.isDirectory) { self.renameDirectory(); }
        else { self.renameFile(); }
    };

    this.renameDirectory = async function () {
        const newName = await UI.PromptAsync("Rename Directory", "Please enter a new directory name", self.name);

        if (newName === null) { return; }

        const renameResult = await API.FileManagerPlugin.RenameDirectoryAsync(self.fullPath, newName);

        if (renameResult.Status === true) { vm.refresh(); }
        else {
            UI.ShowModalAsync("Failed to rename directory", renameResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.renameFile = async function () {
        const newName = await UI.PromptAsync("Rename File", "Please enter a new filename", { text: self.name, selLength: self.name.lastIndexOf(".") });

        const pos = self.name.lastIndexOf(".");
        if (pos > -1) {
            document.getElementById("modalPromptInput").selectionStart = 0;
            document.getElementById("modalPromptInput").selectionEnd = pos;
        }

        if (newName === null) { return; }

        const renameResult = await API.FileManagerPlugin.RenameFileAsync(self.fullPath, newName);

        if (renameResult.Status === true) { vm.refresh(); }
        else {
            UI.ShowModalAsync("Failed to rename file", renameResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.downloadAsZip = async function () {
        if (!self.isDirectory) return;
        const notificationId = UI.CreateLocalNotification("Zipping Directory", `Preparing ${self.fullPath} for download...`, null, 0);

        try {
            const result = await API.FileManagerPlugin.CreateArchiveTaskAsync(self.fullPath, true);
            if (!result.Status) {
                UI.ShowModalAsync("Download failed", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
                return;
            }

            const archiveName = `${self.name}.zip`;
            const downloadUrl = `/fetch/${FMFastModeBasePath}/${listingVM.workingDirectory()}${archiveName}`;

            const a = document.createElement("a");
            a.href = downloadUrl;
            a.download = archiveName;
            a.style.display = "none";
            document.body.appendChild(a);
            a.dispatchEvent(new MouseEvent("click"));
            document.body.removeChild(a);

            // Give the browser time to start the download before cleaning up
            await sleepAsync(5000);

            try {
                await API.FileManagerPlugin.TrashFileAsync(self.fullPath + ".zip");
            } catch { }

            await vm.refresh();
        } catch (error) {
            console.error("Download as zip failed:", error);
            UI.ShowModalAsync("Download failed", error?.message || "An unknown error occurred.", UI.Icons.Exclamation, UI.OKActionOnly);
        } finally {
            UI.RemoveLocalNotification(notificationId);
        }
    };
}

async function refreshDirectoryEntries(vm, filterFn = null) {
    if (vm._refreshing) return; // Prevent double call
    vm._refreshing = true;

    try {
        let stale;
        do {
            stale = false;
            const requestedDir = vm.workingDirectory();
            const result = await API.FileManagerPlugin.GetDirectoryListingAsync(requestedDir);

            if (vm.workingDirectory() !== requestedDir) {
                stale = true; // Directory changed mid-flight, re-fetch for the new path
                continue;
            }

            vm.entries.removeAll();
            const newData = [];

            if (requestedDir !== "") {
                result.unshift({ Filename: "..", IsDirectory: true, SizeBytes: 0, IsDownloadable: false, Modified: "", IsEditable: false });
            }

            for (const listing of result) {
                if (!filterFn || filterFn(listing)) {
                    newData.push(new FileEntryVM(listing, vm));
                }
            }

            ko.utils.arrayPushAll(vm.entries, newData);

            vm.pathSegments.removeAll();
            const parts = requestedDir.split("/");
            vm.pathSegments.push(new PathSegmentVM("/", "", vm));

            for (let i = 0; i < parts.length - 1; i++) {
                const fullPath = parts.slice(0, i + 1).join("/") + "/";
                vm.pathSegments.push(new PathSegmentVM(parts[i], fullPath, vm));
            }

            if (typeof vm.currentDisplayDirectory === "function" || typeof vm.currentDisplayDirectory === "object") {
                vm.currentDisplayDirectory(parts[0] === "" ? '/ (Root)' : parts[0]);
            }

            if (typeof updateFMSize === "function" && vm === listingVM) {
                updateFMSize();
            }
        } while (stale);
    } finally {
        vm._refreshing = false;
    }
}

function FileListVM() {
    const self = this;
    this.entries = ko.observableArray(); //of fileEntryVM
    this.clipboardFiles = ko.observableArray(); //of fileEntryVM
    this.currentDisplayDirectory = ko.observable("/ (Root)");
    this.workingDirectory = ko.observable("");
    this.workingDirectory.subscribe(function (newValue) {
        UI.NavigateTo(`/filemanager/${newValue}`);
        self.refresh();
    });
    this.menu = function () {
        self.selectedEntry(null);
        UI.ShowPopupMenu("#tab_FileManagerPlugin_FileInfoPopup", event);
    };
    this.selectedEntry = ko.observable(null); //of fileEntryVM
    this.pathSegments = ko.observableArray(); //of pathSegmentVM;
    this.displayMode = ko.observable("standard"); //standard | compact | gridView
    this.setViewStandard = () => self.displayMode("standard");
    this.setViewCompact = () => self.displayMode("compact");
    this.setViewGrid = () => self.displayMode("gridView");
    this.SFTPPort = GetSetting("FileManagerPlugin.SFTP.SFTPPortNumber");
    this.SFTPHost = viewModels.support.getDisplayHost();
    this.SFTPUser = encodeURIComponent(viewModels.userinfo.username());
    this.SFTPURL = ko.computed(function () {
        const SFTPUrl = `sftp://${self.SFTPUser}@${self.SFTPHost}:${self.SFTPPort}/${self.workingDirectory()}`;
        return SFTPUrl;
    });
    this.connectSFTP = function () {
        try {
            window.location = self.SFTPURL();
        }
        catch {
            //Browser might not give us permission. Just ignore it.
        }
    };
    this.SFTPAvailable = ko.computed(() => GetSetting("FileManagerPlugin.SFTP.SFTPEnabled") === true);

    this.showSFTPDialog = function () {
        UI.ShowWizard("#tab_FileManagerPlugin_SFTPConnectPopup");
    };

    this.hideSFTPDialog = function () {
        UI.HideWizard("#tab_FileManagerPlugin_SFTPConnectPopup");
    };

    this.displayMode.subscribe(function (newValue) {
        $("#fileManagerList").removeClass("standard compact gridView");
        $("#fileManagerList").addClass(newValue);
        localStorage.fileManagerView = newValue;
    });

    if (localStorage.fileManagerView != null) {
        this.displayMode(localStorage.fileManagerView);
    }

    this.paste = pasteFile;

    this.createDirectory = async function () {
        const newName = await UI.PromptAsync("New Directory", "Please enter a name for the new directory");
        if (newName != null) {
            const fullDir = self.workingDirectory() + newName;
            const createResult = await API.FileManagerPlugin.CreateDirectoryAsync(fullDir);
            if (createResult.Status !== true) {
                UI.ShowModalAsync("Directory creation failed", "The directory could not be created: " + createResult.Reason, UI.Icons.Info, UI.OKActionOnly);
            }
            else {
                self.refresh();
            }
        }
    };

    this.downloadFileHere = async function () {
        const requestUrl = await UI.PromptAsync("Download file from URL", "Enter URL to download to your server. The URL must be a direct link.");
        if (requestUrl === null) { return; }

        const result = await API.FileManagerPlugin.DownloadFileFromURLTaskAsync(requestUrl, self.workingDirectory());
        if (result.Status) {
            result.onComplete(self.refresh);
        }
        else {
            UI.ShowModalAsync("Unable to download file", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.editorVisible = ko.observable(false);
    this.controlledFileInfo = ko.observable(null);

    this.fileManagerImport = async function () {
        await editorSave();
        self.controlledFileInfo()?.importCallback(listingVM.selectedEntry());
    };

    this.refresh = async function () {
        console.log("File Manager: Refreshing directory %s", self.workingDirectory());
        await refreshDirectoryEntries(self);
    };
}

function DirListVM() {
    const self = this;
    this.callback = null;
    this.entries = ko.observableArray(); //of fileEntryVM
    this.selectedEntries = ko.observableArray(); //of fileEntryVM
    this.ctrlIsDown = ko.observable(false);
    this.selectedEntry = ko.observable(null);
    this.workingDirectory = ko.observable("");
    this.popupTitle = ko.observable("Select Directory");
    this.actionText = ko.observable("Select Directory");
    this.pathSegments = ko.observableArray(); //of pathSegmentVM;

    $(document).on("keydown", function (e) {
        if (e.ctrlKey) {
            self.ctrlIsDown(true);
        }
    });

    $(document).on("keyup", function (e) {
        if (e.ctrlKey) {
            self.ctrlIsDown(false);
        }
    });

    this.workingDirectory.subscribe(function (newValue) {
        self.refresh();
    });
    this.refresh = async function () {
        await refreshDirectoryEntries(self, listing => listing.IsDirectory);
    };
    this.select = function () {
        self.callback(self.workingDirectory());
        UI.HideWizard("#tab_FileManagerPlugin_TargetDirectoryPopup");
    };
    this.cancel = function () {
        self.callback(null);
        UI.HideWizard("#tab_FileManagerPlugin_TargetDirectoryPopup");
    };
    this.show = async function (title, actionText, callback) {
        await self.refresh();
        self.popupTitle(title);
        self.actionText(actionText);
        self.callback = callback;
        self.workingDirectory("");
        UI.ShowWizard("#tab_FileManagerPlugin_TargetDirectoryPopup");
    };
}

function SelectFileVM() {
    const self = this;
    this.callback = null;
    this.entries = ko.observableArray(); //of fileEntryVM
    this.selectedEntry = ko.observable(null);
    this.workingDirectory = ko.observable("");
    this.popupTitle = ko.observable("Select File");
    this.actionText = ko.observable("Select File");
    this.pathSegments = ko.observableArray(); //of pathSegmentVM;
    this.workingDirectory.subscribe(function (newValue) {
        self.refresh();
    });
    this.refresh = async function () {
        await refreshDirectoryEntries(self);
    };
    this.select = function () {
        UI.HideWizard("#tab_FileManagerPlugin_SelectFilePopup");
        self.callback(self.selectedEntry().fullPath);
    };
    this.cancel = function () {
        UI.HideWizard("#tab_FileManagerPlugin_SelectFilePopup");
        self.callback(null);
    };
    this.show = function (title, actionText, callback) {
        self.popupTitle(title);
        self.actionText(actionText);
        self.callback = callback;
        self.workingDirectory("");
        if (self.selectedEntry() != null) {
            self.selectedEntry().selected(false);
        }
        self.selectedEntry(null);
        UI.ShowWizard("#tab_FileManagerPlugin_SelectFilePopup");
    };
}

function pickDirectory(title, actionText) {
    return new Promise(resolve => dirVM.show(title, actionText, resolve));
}

function PathSegmentVM(segmentName, fullPath, vm) {
    this.vm = vm;
    this.name = segmentName;
    this.fullPath = fullPath;
    this.click = function () {
        if (!$("#editor").is(":visible")) {
            vm.workingDirectory(this.fullPath);
            vm.refresh();
        }
    };
}

function pasteFile() {
    if (listingVM.clipboardFiles().length === 0) {
        UI.ShowModalAsync("No files to paste", "You have no files in the clipboard to paste", UI.Icons.Info, UI.OKActionOnly);
        return;
    }

    const listing = listingVM.clipboardFiles()[0];
    const origin = listing.directory + listing.name;
    const target = listingVM.workingDirectory();
    API.FileManagerPlugin.CopyFile(origin, target, listingVM.refresh);
}
