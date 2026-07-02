/// <reference path="API.js" />
/// <reference path="UI.js" />
/// <reference path="Common.js" />
/// <reference path="PluginHandler.js" />
/// <reference path="jquery-3.6.0.min.js" />
/// <reference path="knockout-3.5.1.js" />
/// <reference path="knockout.quickmap.js" />

/* eslint eqeqeq: "off", curly: "error", "no-extra-parens": "off", max-params: "off" */
/* eslint-disable require-atomic-updates */
/* eslint-disable sonarjs/no-this-assignment */
/* global API,UI,PluginHandler,ko */

"use strict";

let viewModels = {};
let userPermissions = [];
let Features = {};
let remoteLogin = {
    isRemote: false,
    isViaADS: false,
    instanceName: "",
    instanceId: "",
    APIBase: "",
    APIToken: "",
    callback: null,
    closeRemote: null,
    targetURL: null,
    queryPopstate: function () { return window.location.pathname; }
};
let fullLoadRequired = false;

$(function () {
    localStorage.restartState = "none";
    if (checkMobileLogin()) { return; }
    if (checkADSLogin()) { return; }
    init();
    setupServiceWorker();
});

async function setupServiceWorker() {
    if ('serviceWorker' in navigator && document.location.protocol === "https:") {
        try {
            await navigator.serviceWorker.register('/ServiceWorker.js', { scope: './' });
            console.log("ServiceWorker registered OK");
        }
        catch (ex) {
            console.log("ServiceWorker failed to register: ", ex);
        }
    }
}

function checkADSLogin() {
    let parts = window.location.pathname.split("/").filter(Boolean);
    const isRemote = (parts[0] == "remote" || parts[0] == "instance") && parts.length > 1;
    const remote = isRemote ? parts[1] : getParamValue("remote") || getParamValue("instance");

    if (remote == null) { return false; }

    if (parent == window) {
        if (!isRemote) { UI.NavigateTo("/remote/" + remote); }
        UI.SetRootPopstate(["remote", remote]);
        const pathname = window.location.origin;
        const APIBase = pathname + "/API/ADSModule/Servers/" + remote;
        API.SetAPIBase(APIBase, remote);
        remoteLogin.isViaADS = true;
        return false;
    }
    else {
        parent.NotifyRemoteReady(remote);
        $("#ADSLoginWaiting, #loginSpinner").show();
        remoteLogin.isRemote = true;
        return true;
    }
}

function performADSLogin(id, user, token, instanceName, APIToken, closeRemote, caption, targetURL, connectViaTarget, callback, imageURL, notifyPopstate, rootPopstate, queryPopstate) {
    if (API.GetSessionID() !== "") {
        callback(true, 10, "");
        return;
    }
    const pathname = connectViaTarget ? targetURL.href : window.location.origin;
    remoteLogin.instanceId = id;
    remoteLogin.instanceName = instanceName;
    remoteLogin.APIBase = pathname + "/API/ADSModule/Servers/" + id;
    remoteLogin.callback = callback; //function (success, result, resultReason)
    remoteLogin.APIToken = APIToken;
    remoteLogin.closeRemote = closeRemote;
    remoteLogin.caption = caption;
    remoteLogin.targetURL = targetURL;
    remoteLogin.imageURL = imageURL;
    remoteLogin.queryPopstate = queryPopstate;
    UI.SetNotifyPopstate(notifyPopstate, rootPopstate);
    UI.SetupADSUI(closeRemote, imageURL);
    asyncADSLogin(id, user, token);
}

function notifyPopstateChange(url) {
    UI.NavigateTo(url, true);
}

async function asyncADSLogin(id, user, token) {
    API.SetAPIBase(remoteLogin.APIBase, id);
    await init();
    API.ClearSessionId();
    API.Core.Login(user, "", token, false, loginCallback);
}

let previousPwLen = 0;

function checkPasswordAutofill() {
    const len = $("#loginPasswordField").val().length;

    if (len > previousPwLen + 5) {
        login();
    }
    else {
        previousPwLen = len;
    }
}

function clearCacheAndReload() {
    if ('caches' in window) {
        caches.keys().then(async (names) => {
            for (const name of names) {
                await caches.delete(name)
            };
        });
    }

    location.reload(true);
}

async function init() {
    if (getParamValue("tx") == "1") { Locale.SetTranslatorMode(true); }
    await Locale.AutoLoadLocale(getParamValue("lang"));

    ko.onError = BindError;

    $("#loginForm #loginButton").on("click", login);
    $("#loginForm input").enterPressed(login);
    $("#forgotLogin").on("click", forgotLogin);
    $("#loginLogo").on("dblclick", clearCacheAndReload);

    if (navigator.credentials === undefined) { $("#secureLoginButton").hide(); }
    else { $("#loginForm #secureLoginButton").on("click", getWebauthnLoginToken); }
    $("#oidcLoginButton").hide().on("click", doOIDCLogin);

    const APISetupResult = await API.SetupAsync(NetworkFailing, DisplayDefaultError, NetworkRecovering);

    if (!APISetupResult) {
        if (remoteLogin.isRemote) {
            console.log(`Unable to manage instance ${remoteLogin.instanceName} - Failed to setup API.`);
            const result = await UI.ShowModalAsync("Instance Unavailable", `The instance ${remoteLogin.instanceName} is either not running, or not currently available. Check that it is running, and if it fails to restart - check it's logs.`, UI.Icons.Exclamation, UI.OKActionOnly);
            if (result) {
                remoteLogin.closeRemote();
            }
        }
        else {
            UI.ShowModalAsync("AMP backend not available", `AMP was unable to reach its backend at ${document.location}\n\nThis probably means that AMP is not running and you are currently looking at a cached page. Please check that AMP is running. This page will refresh automatically in 5 seconds.`, UI.Icons.Exclamation, []);
            setTimeout(function () { location.reload(); }, 5000);
        }
        return false;
    }

    UI.SetCommandButtonsCallback(handleCommandButton);
    UI.SetConsoleEnterCallback(consoleSend);
    $("#consoleLineEntry").on("keydown", consoleKeyDown);

    setWizardCallback("viewUserInfo", viewUserClose, null);
    setWizardCallback("tab_changepassword", changePassword, null);
    setWizardCallback("createUser", () => viewModels.ampUserList.submitCreateUser(), null);

    if (UI.GetIsMobile() && !remoteLogin.isRemote) {
        $(window).on('hashchange', hashChange);
        $("#loginPasswordField").change(checkPasswordAutofill);
    }

    $("#changepw_newpwd").change(gradePassword).keyup(gradePassword);

    SetupViewmodels();

    await APIready(APISetupResult);
}

async function forgotLogin() {
    //Do nothing, yet.
}

function BindError(error) {
    UI.ShowModalAsync("Data Binding Failure", "Client-side databinding failed. If you've just upgraded AMP then you should first try clearing your browser cache.", UI.Icons.Exclamation, UI.OKActionOnly, null, null, error);
    throw error;
}

function SetupViewmodels() {
    viewModels.ampUserList = new AMPUserListVM();
    viewModels.roles = new PermissionManagementVM();
    viewModels.settings = new SettingsVM();
    viewModels.schedule = new ScheduleVM();
    viewModels.support = new DiagnosticsVM();
    viewModels.userinfo = new UserInfoVM();
    viewModels.search = new SearchAreaVM();
    viewModels.search.registerSearchProvider(SettingsSearchProvider);
    viewModels.search.registerSearchProvider(DocumentationSearchProvider);
    viewModels.search.registerSearchProvider(VideoTutorialsSearchProvider);
    viewModels.search.registerSearchProvider(UsersSearchProvider);
    viewModels.search.registerSearchProvider(RolesSearchProvider);
    viewModels.appUsers = new UserListVM();
    viewModels.audit = new AuditLogVM();
    viewModels.ampSessions = new SessionManagementVM();

    for (const binding of Object.keys(viewModels)) {
        const viewModel = viewModels[binding];
        RegisterViewmodel(viewModel);
    }
}

function RegisterViewmodel(viewModel, name) {
    const vmName = name || viewModel.constructor.name;
    const context = `[data-viewmodel=${vmName}]`;

    for (const view of $(context)) {
        try {
            viewModel.element = view;
            UI.ApplyVMBinding(viewModel, view);
        }
        catch (e) {
            UI.ShowModalAsync("Data Binding Failure", `An error occurred while registering the viewmodel binding for ${vmName} - If you've just updated AMP you should empty your browser cache and refresh the page.`, UI.Icons.Error, UI.OKActionOnly, null, null, e.message);
            break;
        }
    }
}

async function APIready(success) {
    if (!success) {
        if (remoteLogin.callback != null) {
            remoteLogin.callback(false, 1000, "API failed to initialise.");
        }

        return;
    }

    const moduleInfo = await API.Core.GetModuleInfoAsync();
    fullLoadRequired = moduleInfo.RequiresFullLoad;
    UI.SetModuleInfo(moduleInfo.Name, moduleInfo.AppName, moduleInfo.Author, moduleInfo.SupportsSleep, moduleInfo.AMPVersion, moduleInfo.Timestamp, moduleInfo.BuildSpec, moduleInfo.Branding, moduleInfo.EndpointURI, moduleInfo.PrimaryEndpoint, moduleInfo.IsRemoteInstance, moduleInfo.InstanceName, moduleInfo.FriendlyName);
    viewModels.support.updateFrom(moduleInfo);

    if (!moduleInfo.AllowRememberMe) {
        $("#loginForm label[class=checkbox]").hide();
        $("#secureLoginButton").hide();
    }

    if (moduleInfo.IsOIDCEnabled) {
        $("#oidcLoginButton").show();
        const code = getParamValue("code");
        const state = getParamValue("state");
        const oidcReturnUri = document.location.origin + document.location.pathname;
        if (code != null) {
            UI.LoginWaiting(true);
            API.Core.OIDCLogin(code, state, oidcReturnUri, null, loginCallback);
            //Update the URL in the titlebar to not have the querystring
            history.pushState(null, "", window.location.pathname);
            return;
        }
        if (!moduleInfo.LocalLoginEnabled) {
            const url = await API.Core.GetOIDCLoginURLAsync(oidcReturnUri);
            if (url == null) {
                return;
            }
            document.location = url;
            return;
        }
    }

    if (remoteLogin.isRemote === true) {
        return;
    }

    if (localStorage.webauthnUsername != null && localStorage.webauthnUsername != "") {
        getWebauthnLoginToken(localStorage.webauthnUsername);
    }
    else if (localStorage.SavedToken != null && localStorage.SavedToken != "") {
        UI.LoginWaiting(true);
        loginFromToken();
    }
    else if (moduleInfo.IsOIDCEnabled && localStorage.oidcUsername != null && localStorage.oidcUsername != "") {
        UI.LoginWaiting(true);
        const oidcReturnUri = document.location.origin + document.location.pathname;
        const url = await API.Core.GetOIDCLoginURLAsync(oidcReturnUri);
        if (url != null) {
            document.location = url;
            return;
        }
        UI.AssetsLoaded();
    }
    else {
        UI.AssetsLoaded();
    }
}

function NetworkFailing() {
    $("#modalLoader").show();
    UI.ShowModalAsync("Reconnecting", "Your connection to the AMP backend was lost. AMP will attempt to reestablish a connection.\n\nIf you chose to have your password remembered, you will be logged in automatically without interruption.", UI.Icons.Exclamation, []);
}

function NetworkRecovering() {
    $("#modalLoader").hide();
    UI.HideModal();
}

function DisplayDefaultError(module, method, data, error) {
    if (error.HelpLink == "" || error.HelpLink == null) {
        UI.ShowModalAsync(error.Title, { text: error.Message, subtitle: `Thrown by the '${module}' plugin while performing the '${method}' method.` }, UI.Icons.Exclamation, UI.OKActionOnly, "", "", error.StackTrace);
    }
    else {
        UI.ShowModalAsync(error.Title, { text: error.Message, subtitle: `Thrown by the '${module}' plugin while performing the '${method}' method.` }, UI.Icons.Exclamation, UI.OKActionOnly, "Get help for this issue", error.HelpLink, null);
    }
}

let selectedUserId = "";
let selectedUserName = "";

async function userActionCallback() {
    const e = $(this);
    const method = e.data("method");
    const module = e.data("module");
    if (method === null || module === null) { return; }

    if (module == "GenericModule") {
        if (!userHasPermission("Core.AppManagement.SendConsoleInput")) {
            return;
        }
        const message = method.replace("${Name}", selectedUserId).replace("${Id}", selectedUserId);
        API.Core.SendConsoleMessage(message);
        return;
    }

    const result = await API[module][method + "Async"](selectedUserId, null);

    if (result != null && !result.Status) {
        UI.ShowModalAsync("Could not complete action.", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
    }
}

function viewUserClose() {
    UI.ShowUserInfo(null, null, null, null);
}

let consoleSendHistory = [];
let consoleSendHistoryIndex = 0;
let originalInput = "";

function consoleKeyDown(e) {
    switch (e.keyCode) {
        case 38: //up arrow
            e.preventDefault();
            if (consoleSendHistoryIndex == consoleSendHistory.length) {
                originalInput = $("#consoleLineEntry").val();
            }
            consoleSendHistoryIndex--;
            if (consoleSendHistoryIndex < 0) { consoleSendHistoryIndex = 0; }
            $("#consoleLineEntry").val(consoleSendHistory[consoleSendHistoryIndex]);
            break;
        case 40: //down arrow
            e.preventDefault();
            consoleSendHistoryIndex++;
            if (consoleSendHistoryIndex >= consoleSendHistory.length) {
                consoleSendHistoryIndex = consoleSendHistory.length;
                $("#consoleLineEntry").val(originalInput);
            }
            else {
                $("#consoleLineEntry").val(consoleSendHistory[consoleSendHistoryIndex]);
            }
            break;
    }
}

function consoleSend() {
    const text = $("#consoleLineEntry").val();
    API.Core.SendConsoleMessage(text, null);
    $("#consoleLineEntry").val("");

    if (UI.GetIsMobile()) {
        $("#consoleLineEntry").blur();
    }

    if (consoleSendHistory.length == 0 || (consoleSendHistory.length > 0 && consoleSendHistory.at(-1) != text)) {
        consoleSendHistory.push(text);
        consoleSendHistoryIndex = consoleSendHistory.length;
    }
    originalInput = "";
}

async function handleCommandButton() {
    const e = $(this);
    const method = e.data("method");
    const module = e.data("module");
    if (method === null || module === null) { return; }
    const result = await API[module][method + "Async"]();

    if (result != null && !result.Status && result.State != 100) {
        UI.ShowModalAsync("Could not complete action.", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
    }

    UI.wait2sec(e);
}

function checkMobileLogin() {
    const token = getParamValue("authtoken");
    const user = getParamValue("user");

    if (token != null) {
        localStorage.SavedToken = token;
        localStorage.SavedUsername = user;
        window.location = window.location.origin;
        return true;
    }
}

async function requestMobileLogin() {
    const result = await API.Core.GetRemoteLoginTokenAsync("Pre-authorized mobile login", true);
    const URI = window.location.origin + "/?authtoken=" + result + "&user=" + localStorage.SavedUsername;
    const ImageURI = "https://chart.googleapis.com/chart?cht=qr&chs=300&chl=" + encodeURIComponent(URI) + "&chld=L|1";
    $("#mobileLoginQR").attr("src", ImageURI);
    UI.ShowWizard("#tab_mobileLogin");
}

async function serviceLogin() {
    const name = await UI.PromptAsync("Service Login Request", "Please enter a name for this login request for future reference.");
    if (name == null) { return; }

    const result = await API.Core.GetRemoteLoginTokenAsync(name, false);
    const token = localStorage.SavedUsername + ":" + result;
    UI.ShowModalAsync("Your Login Token", "This token cannot be shown to you again. Please keep it safe as any user with it has all the permissions of your account", UI.Icons.Info, UI.OKActionOnly, null, null, token);
}

function loginFromToken() {
    API.Core.Login(localStorage.SavedUsername || "", "", localStorage.SavedToken, true, loginCallback);
}

function midSessionLogin() {
    if (localStorage.SavedToken != "") {
        API.Core.Login(localStorage.SavedUsername || "", "", localStorage.SavedToken, true, midSessionLoginCallback);
    }
    else {
        location.reload();
    }
}

function userHasPermission(permNode) { return evaluatePermission(permNode, userPermissions); }

function updatePermissionVisibility() {
    $("[data-permission]").each(function (n, e) {
        const thisEl = $(this);
        const perm = thisEl.attr("data-permission");

        if (perm === null || perm === "") { return; } //acts like 'continue'

        if (!userHasPermission(perm)) {
            thisEl.hide();
        }
    });
}

async function midSessionLoginCallback(result, success, permissions, sessionID, rememberMeToken, userInfo) {
    if (!success) {
        location.reload();
        return;
    }

    $("#modalLoader").hide();
    userPermissions = permissions;
    updatePermissionVisibility();
    localStorage.SavedToken = rememberMeToken;
    localStorage.SavedUsername = userInfo.Username;
    UI.HideModal();
    API.ResetBadNetwork();
    await API.SetSessionIDAsync(sessionID);
    API.Core.GetSettingsSpec(getSettingsCallback);

}

function login() {
    const form = getForm("#loginForm");

    if (form.username != "" || form.password != "") {
        API.Core.Login(form.username, form.password, "", form.rememberme, loginCallback);
        UI.LoginWaiting();
    }

    return false;
}

async function doOIDCLogin() {
    const oidcReturnUri = document.location.origin + document.location.pathname;
    const url = await API.Core.GetOIDCLoginURLAsync(oidcReturnUri);
    if (url == null) { return; }
    document.location = url;
}

async function logout() {
    const result = await UI.ShowModalAsync("Confirm Logout", { text: "Are you sure you want to logout?", subtitle: "This will remove your 'remember me' token for this browser." }, UI.Icons.Question, [
        new UI.ModalAction("Logout", true, "bgRed"),
        new UI.ModalAction("Cancel", false)
    ]);

    if (result === true) {
        doLogout();
    }
}

async function doLogout() {
    const isOIDC = viewModels.userinfo.isOIDCUser();
    const oidcReturnUri = document.location.origin + document.location.pathname;
    const logoutUrl = isOIDC ? (await API.Core.GetOIDCLogoutUrlAsync(localStorage.SavedToken, oidcReturnUri)) : null;

    API.Core.Logout();
    UI.Logout();
    localStorage.SavedToken = "";
    localStorage.SavedUsername = "";
    localStorage.webauthnUsername = "";
    localStorage.oidcUsername = "";

    if (!isOIDC || logoutUrl == null) {
        location.reload();
    }
    else {
        document.location = logoutUrl;
    }
}

function showPasswordChange(userInfo) {
    resetWizardHandlers();
    $("#mainBody").show();
    $(".bodyTab").hide();
    $("#tab_changepassword").css("left", "0");
    $("#changepw_showusername").text(userInfo.Username);
    UI.ShowWizard("#tab_changepassword");
}

async function show2FAChallenge(form, result) {
    const twoFactorCode = await TwoFactorPrompt("log in");

    if (twoFactorCode == null) {
        UI.LoginFailed(result);
        return;
    }

    API.Core.Login(form.username, form.password, twoFactorCode, form.rememberme, loginCallback);
}

async function doTwoFactorSetup(form, result) {
    await UI.ShowModalAsync("Two factor setup required", "The server administrator has required that two factor authentication is enabled for all accounts. You will now be directed to setup two factor authentication, after which you will need to request an additonal code to login with.", UI.Icons.Info, UI.OKActionOnly);
    const twoFactorSetupResult = await setupTwoFactor(form.username, form.password);
    if (twoFactorSetupResult) {
        API.Core.Login(form.username, form.password, "", form.rememberme, loginCallback);
    }
    else {
        UI.LoginFailed(result);
    }
}

async function checkVersionMismatch(moduleInfo) {
    localStorage.LastAMPVersion = moduleInfo.AMPVersion;
    localStorage.LastAMPBuild = moduleInfo.AMPBuild;

    const scriptAMPVersion = document.getElementById("scriptAMPmain");
    if (scriptAMPVersion?.src) {
        const urlParams = new URLSearchParams(scriptAMPVersion.src.split('?')[1]);
        const versionParam = urlParams.get('v');
        if (versionParam !== moduleInfo.APIVersion) {
            await UI.ShowModalAsync("AMP Version Mismatch", `The AMP frontend that has been loaded (v${versionParam}) does not match the backend (v${moduleInfo.APIVersion}). Please clear your browser cache (or force reload with CTRL+F5) as well as any upstream proxy caches.`, UI.Icons.Exclamation, UI.OKActionOnly);
            UI.LoginFailed(-999, "User action required.");
            return true;
        }
    }

    return false;
}

async function loginCallback(result, success, permissions, sessionID, rememberMeToken, userInfo, resultReason, data) {
    const form = getForm("#loginForm");

    if (!success) {
        if (remoteLogin.callback != null) {
            remoteLogin.callback(success, result, resultReason);
            return;
        }

        switch (result) {
            case 0:
            case 1:
            case 2:
            case 30:
            case 50:
                localStorage.SavedToken = "";
                UI.LoginFailed(result, resultReason);
                break;
            case 5: // User is locked to a single instance
                await redirectUserToInstance();
                break;
            case 20: //Password change required
                showPasswordChange(userInfo);
                break;
            case 40: //Two-factor challenge
                await show2FAChallenge(form, result);
                break;
            case 45: //Two-factor setup required
                await doTwoFactorSetup(form, result);
                break;
            case 150: //OIDC user attempted local login
                localStorage.SavedToken = "";
                await UI.ShowModalAsync("OIDC Account", "This account uses OIDC authentication and cannot log in with a password. Please use the OIDC login button instead.", UI.Icons.Info, UI.OKActionOnly);
                UI.LoginFailed(result, resultReason);
                break;
            default:
                if (resultReason != null) {
                    UI.ShowModalAsync("Authentication System Failure (code " + result + ")", "Reason: " + resultReason, UI.Icons.Exclamation, UI.OKActionOnly);
                }
                localStorage.SavedToken = "";
                UI.LoginFailed(result, resultReason);
                break;
        }

        return;
    }

    (fullLoadRequired ? UI.LoginBusy : UI.LoginSuccess)(remoteLogin.isRemote);

    form.username = "";
    form.password = "";
    setForm("#loginForm", form);

    $("#changepw_showusername").text(userInfo.Username);
    if (!remoteLogin.isRemote) {
        localStorage.SavedToken = rememberMeToken;
        localStorage.SavedUsername = userInfo.Username;
        if (userInfo.IsOIDCUser) {
            localStorage.oidcUsername = userInfo.Username;
        }
    }
    userPermissions = permissions;
    viewModels.userinfo.update(userInfo);

    await API.SetSessionIDAsync(sessionID);
    const moduleInfo = await API.Core.GetModuleInfoAsync();

    if (moduleInfo.Analytics) {
        loadAnalytics(false, moduleInfo.AnalyticsTag);
    }
    else {
        window.plausible = function () { } //Do nothing.
    }

    const AMPHasBeenUpdated = localStorage.LastAMPVersion != null && localStorage.LastAMPBuild != null && (localStorage.LastAMPVersion != moduleInfo.AMPVersion || localStorage.LastAMPBuild != moduleInfo.AMPBuild) && !remoteLogin.isRemote;
    if (AMPHasBeenUpdated) {
        handlePostUpgrade(moduleInfo);
        return;
    }
    else if (!remoteLogin.isRemote && await checkVersionMismatch(moduleInfo)) {
        return;
    }

    UI.SetModuleInfo(moduleInfo.Name, moduleInfo.AppName, moduleInfo.Author, moduleInfo.SupportsSleep, moduleInfo.AMPVersion, moduleInfo.Timestamp, moduleInfo.BuildSpec, moduleInfo.Branding, moduleInfo.EndpointURI, moduleInfo.PrimaryEndpoint);
    viewModels.support.updateFrom(moduleInfo);

    PluginHandler.SetFeatures(moduleInfo.FeatureSet);

    if (remoteLogin.callback != null) {
        remoteLogin.callback(true, result, resultReason);
    }

    $(".bodyTab").hide();
    $("#tab_status").show();
    await Promise.allSettled(moduleInfo.LoadedPlugins.map(p => PluginHandler.LoadPluginAsync(p)));
    await pluginsLoaded();
    if (fullLoadRequired || remoteLogin.isRemote) { UI.LoginSuccess(remoteLogin.isRemote); }

    async function redirectUserToInstance() {
        if (data != null && data != "") {
            UI.ShowModalAsync("Redirecting", "This user belongs to another instance. You are being redirected to the correct instance where you may login again.", UI.Icons.Info, []);
            await sleepAsync(1000);
            document.location.href = "/remote/" + data;
        }
        else {
            UI.LoginFailed(result, resultReason);
        }
    }
}

function handlePostUpgrade(moduleInfo) {
    plausible("CompleteUpgrade", { props: { oldVersion: localStorage.LastAMPVersion, newVersion: moduleInfo.AMPVersion, oldBuild: localStorage.LastAMPBuild, newBuild: moduleInfo.AMPBuild } });
    localStorage.LastAMPVersion = moduleInfo.AMPVersion;
    localStorage.LastAMPBuild = moduleInfo.AMPBuild;
    $("#modalLoader").show();
    UI.ShowModalAsync("AMP has been updated", "AMP needs to empty your browser cache for this page to apply an update, please wait a moment...", UI.Icons.Exclamation, []);
    setTimeout(clearCacheAndReload, 2000);
}

function loadAnalytics(eventsOnly, tag) {
    const eventsScript = document.createElement("script");
    eventsScript.defer = true;
    eventsScript.src = "https://metrics.c7rs.com/js/s.tagged-events.local.js";
    eventsScript.dataset.domain = (tag || "").trim() == "" ? "amp.cubecoders.com" : tag;
    eventsScript.type = "text/javascript";
    document.getElementsByTagName('head')[0].appendChild(eventsScript);

    window.plausible = window.plausible || function () {
        window.plausible.q = window.plausible.q || [];
        window.plausible.q.push(arguments)
    }

    if (eventsOnly === true) { return; }

    const analyticsScript = document.createElement("script");
    analyticsScript.async = true;
    analyticsScript.defer = true;
    analyticsScript.src = "https://metrics.c7rs.com/js/s.local.js";
    analyticsScript.dataset.domain = "amp.cubecoders.com";
    analyticsScript.type = "text/javascript";
    document.getElementsByTagName('head')[0].appendChild(analyticsScript);
}

async function pluginsLoaded() {
    resetWizardHandlers();


    await setupCalls([
        { method: API.Core.GetUpdatesAsync, callback: getUpdatesCallback },
        { method: API.Core.GetUserActionsSpecAsync, callback: getActionCallback },
        { method: API.Core.GetSettingsSpecAsync, callback: getSettingsCallback },
        { method: API.Core.GetUserListAsync, callback: viewModels.appUsers.update },
        { method: API.Core.GetScheduleDataAsync, callback: ScheduleDataCallback, permission: "Core.Scheduler.ViewSchedule" }
    ]);

    postInit();
}

async function postInit() {
    viewModels.support.checkForUpdates();
    PluginHandler.RunPluginsPostAMPInit();
    let wsEnabled = false;
    let pollingStarted = false;

    function startPolling() {
        if (pollingStarted) { return; }
        pollingStarted = true;
        const updatePollInterval = 1000;
        API.Core.GetUpdates.setInterval(updatePollInterval, getUpdatesCallback, updatesFailedCallback);
    }

    if (currentSettings["Core.Webserver.EnableWebSockets"].value() === true) {
        try {
            await API.EnableWebsockets(processPushedMessage, startPolling);
            wsEnabled = API.WebsocketsEnabled();
            const tasks = await API.Core.GetTasksAsync();
            UI.UpdateNotifications(tasks);
        }
        catch {
            //Do nothing
        }
    }
    if (!wsEnabled) {
        startPolling();
    }
    updatePermissionVisibility();
    UI.InitialViewchange();
}

function AuditLogVM() {
    const self = this;
    this.entries = ko.observableArray(); //of AuditLogEntryVM()
    this.firstSeenTimestamp = null;
    this.entriesPerPage = 30;
    this.before = null;
    this.searchQuery = ko.observable();

    this.refresh = async function (advance) {
        if (self.before == null || !advance) {
            self.entries.removeAll();
            self.before = null;
        }

        const data = await API.Core.GetAuditLogEntriesAsync(self.before, self.entriesPerPage);

        if (data.length > 0) {
            const newEntries = ko.quickmap.to(AuditLogEntryVM, data);
            ko.utils.arrayPushAll(self.entries, newEntries);

            if (advance) {
                self.before = data[data.length - 1].Timestamp;
            }
        }
    };

    this.search = async function () {
        self.entries.removeAll();

        const data = await API.Core.SearchAuditLogEntries(self.searchQuery, self.before, self.entriesPerPage);

        if (data.length > 0) {
            const newEntries = ko.quickmap.to(AuditLogEntryVM, data);
            ko.utils.arrayPushAll(self.entries, newEntries);
        }
    };

    this.clearSearch = function () {
        self.searchQuery("");
        self.refresh();
    };

    this.reset = () => self.refresh(false);
    this.advance = () => self.refresh(true);
}

function formatDate(date) {
    const now = new Date();
    const year = date.getFullYear();
    const sameYear = year === now.getFullYear();

    const options = {
        month: 'short',
        day: 'numeric',
        hour: '2-digit',
        minute: '2-digit'
    };

    if (!sameYear) {
        options.year = 'numeric';
    }

    return date.toLocaleString('en-US', options);
}

function AuditLogEntryVM() {
    this.Category = "";
    this.Id = "";
    this.Message = "";
    this.Source = "";
    this.Timestamp = ko.observable("");
    this.DisplayTime = ko.computed(() => formatDate(parseDate(this.Timestamp())));
    this.User = "";
}

async function setupTwoFactor(username, password) {
    const twoFactorResult = await API.Core.EnableTwoFactorAsync(username, password);

    if (twoFactorResult.Status === false) {
        await UI.ShowModalAsync("Failed to setup two-factor authentication", twoFactorResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        return false;
    }

    const confirmTwoFactorPIN = await UI.PromptAsync("Confirm 2FA Code", "Please register your authenticator using the QR code shown, then generate and enter a code to complete setup. Alternatively, you may use the following setup code: \n\n" + twoFactorResult.Result.ManualKey, null, "twoFactorInput", null, twoFactorResult.Result.Url);
    if (confirmTwoFactorPIN == null) { return false; }

    const confirmTwoFactorResult = await API.Core.ConfirmTwoFactorSetupAsync(username, confirmTwoFactorPIN);
    if (confirmTwoFactorResult.Status) {
        await UI.ShowModalAsync("Two-factor setup successful", "Two factor authentication is now enabled for your account, and will apply next time you login.", UI.Icons.Info, UI.OKActionOnly);
        return true;
    }
    else {
        await UI.ShowModalAsync("Two-factor setup failed", confirmTwoFactorResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        return false;
    }
}

function tryatob(data) {
    try {
        return atob(data);
    }
    catch {
        return [];
    }
}

async function getWebauthnLoginToken(username) {

    let form = {};
    if (username == null || typeof (username) !== "string") {
        form = getForm("#loginForm");

        if (form.username == "") {
            await UI.LoginFailed(-110, "");
            return false;
        }
        username = form.username;
    }

    await UI.LoginWaiting();
    const credInfo = await API.Core.GetWebauthnCredentialIDsAsync(username);

    if (credInfo.Ids.length === 0) {
        await UI.LoginFailed(-120, "The server returned no credential IDs");
        return;
    }

    const challenge = Uint8Array.from(credInfo.Challenge, c => c.codePointAt(0));

    const rpId = location.hostname;
    const allowCredentials = credInfo.Ids.map((e) => (
        {
            id: Uint8Array.from(tryatob(e), c => c.codePointAt(0)),
            type: "public-key",
        }
    )).filter(c => c.id.length > 0);
    const options = { challenge, allowCredentials, rpId, userVerification: "preferred", timeout: 60000 };
    try {
        const credential = await navigator.credentials.get({ publicKey: options });
        const signature = btoa(String.fromCharCode.apply(null, new Uint8Array(credential.response.signature)));
        const authenticatorData = btoa(String.fromCharCode.apply(null, new Uint8Array(credential.response.authenticatorData)));
        const clientDataJSON = btoa(String.fromCharCode.apply(null, new Uint8Array(credential.response.clientDataJSON)));
        const loginObject = { signature, authenticatorData, clientDataJSON };
        const loginEncoded = btoa(JSON.stringify(loginObject));

        if (form?.rememberme) {
            localStorage.webauthnUsername = username;
        }

        API.Core.Login(username, "", loginEncoded, false, loginCallback);
    }
    catch {
        await UI.LoginFailed(-100, "");
    }
}

async function TwoFactorPrompt(action = "perform this action") {
    const displayAction = action;
    const twoFactorPIN = await UI.PromptAsync("Confirm 2FA Code", `Please use your authenticator to request a token to ${displayAction}.`, null, "twoFactorInput", null, "Images/TwoFAPrompt.png");
    return twoFactorPIN;
}

function WebauthnCredentialSummary() {
    const self = this;
    this.ID = ko.observable(0);
    this.Description = ko.observable("");
    this.CreatedUTC = ko.observable("");
    this.LastUsedUTC = ko.observable("");
    this._displayCreatedUTC = ko.computed(() => {
        const createDate = parseDate(this.CreatedUTC());
        if (createDate.getFullYear() == 1970) {
            return "";
        }
        return createDate.toLocaleString();
    });
    this._displayLastUsedUTC = ko.computed(() => {
        const usedDate = parseDate(this.LastUsedUTC());
        if (usedDate.getFullYear() == 1970) {
            return "Never Used";
        }
        return usedDate.toLocaleString();
    });
    this._revoke = async function () {
        const promptResult = await UI.ShowModalAsync("Confirm Revoke", "Are you sure you want to revoke this credential? You will not be able to use this token to log in after revoking it.", UI.Icons.Question, [
            new UI.ModalAction("Revoke Credential", true, "bgRed", true),
            new UI.ModalAction("Keep Credential", false, "bgGreen", true),
        ]);

        if (promptResult !== true) { return; }

        const result = await API.Core.RevokeWebauthnCredentialAsync(self.ID());
        if (result.Status) {
            await UI.ShowModalAsync("Revoke Successful", "The credential has been revoked.", UI.Icons.Info, UI.OKActionOnly);
            await self._vm.getWebauthnTokens();
        }
        else {
            await UI.ShowModalAsync("Revoke Failed", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };
    this._vm = null;
}

function UserInfoVM() {
    const self = this;
    this.username = ko.observable("");
    this.gravatarHash = ko.observable("");
    this.imageSmallURI = ko.computed(() => `https://gravatar.com/avatar/${this.gravatarHash()}?d=mp&r=g&s=128`);
    this.imageLargeURI = ko.computed(() => `https://gravatar.com/avatar/${this.gravatarHash()}?d=mp&r=g&s=256`);
    this.emailAddress = ko.observable("");
    this.isTwoFactor = ko.observable(false);
    this.newPubkey = ko.observable("");
    this.oldPassword = ko.observable("");
    this.newPassword = ko.observable("");
    this.confirmPassword = ko.observable("");
    this.isLDAPUser = ko.observable(false);
    this.isOIDCUser = ko.observable(false);
    this.passwordGrade = ko.computed(() => getPasswordGrade(this.newPassword()));
    this.passwordGradeClass = ko.computed(() => getGradeAsColorClass(this.passwordGrade()));
    this.passwordGradeWidth = ko.computed(() => (this.passwordGrade() * 28) + "px");
    this.webauthnCredentials = ko.observableArray(); // of WebauthnCredentialSummary
    this.savePubKey = async function () {
        //Extract just the Base64 part of the key after the ssh-rsa part
        const pubKey = self.newPubkey().split(" ")[1];
        const updatePubkeyResult = await API.Core.UpdatePublicKeyAsync(pubKey);
        if (updatePubkeyResult.Status === true) {
            await UI.ShowModalAsync("Public key updated", "Your ssh public key has been updated successfuly.", UI.Icons.Info, UI.OKActionOnly);
        }
        else {
            await UI.ShowModalAsync("Failed to change details", "Your details could not be changed: " + updatePubkeyResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    };
    this.updateDetails = async function () {
        let twoFACode = "";
        if (self.isTwoFactor()) {
            twoFACode = await TwoFactorPrompt("change your account details");
        }

        const updateInfoResult = await API.Core.UpdateAccountInfoAsync(self.emailAddress, twoFACode);
        if (updateInfoResult.Status === true) {
            await UI.ShowModalAsync("Details Changed", "Your details were changed successfuly. You will need to log out and back in again for them to take effect.", UI.Icons.Info, UI.OKActionOnly);
        }
        else {
            await UI.ShowModalAsync("Failed to change details", "Your details could not be changed: " + updateInfoResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    };
    this.enableTwoFactor = async function () {
        const existingPassword = await UI.PromptAsync("Confirm Password", "Please confirm your password to enable two-factor authentication", "", "", "password");
        if (existingPassword == null) { return; }
        if (await setupTwoFactor(self.username, existingPassword) === true) {
            self.isTwoFactor(true);
        }
    };
    this.disableTwoFactor = async function () {
        const existingPassword = await UI.PromptAsync("Confirm Password", "Please confirm your password to disable two-factor authentication", "", "", "password");
        const confirmTwoFactorPIN = await TwoFactorPrompt("disable two-factor authentication");
        const disableTwoFactoResult = await API.Core.DisableTwoFactorAsync(existingPassword, confirmTwoFactorPIN);

        if (disableTwoFactoResult.Status === true) {
            await UI.ShowModalAsync("Two factor authentication has been disabled", "Two factor authentication has been disabled for your account, and will apply next time you login.", UI.Icons.Exclamation, UI.OKActionOnly);
        }
        else {
            await UI.ShowModalAsync("Unable to disable 2FA", disableTwoFactoResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }

    };
    this.showWebauthnSetup = navigator.credentials !== undefined;
    this.manageWebauthnTokens = async function () {
        await self.getWebauthnTokens();
        if (self.webauthnCredentials().length === 0) {
            await UI.ShowModalAsync("No Webauthn Tokens", "You do not have any Webauthn tokens registered to manage.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }
        UI.ShowWizard("#tab_userinfo_tokens");
    };
    this.getWebauthnTokens = async function () {
        const tokens = await API.Core.GetWebauthnCredentialSummariesAsync();
        self.webauthnCredentials.removeAll();
        const mapped = ko.quickmap.to(WebauthnCredentialSummary, tokens, false, { _vm: self });
        ko.utils.arrayPushAll(self.webauthnCredentials, mapped);
    };
    this.closeWebauthnManage = function () {
        UI.HideWizard("#tab_userinfo_tokens");
    };
    this.setupWebauthn = async function () {
        const tokenDescription = await UI.PromptAsync("Token Description (Optional)", "Please enter a description for this security method, such as the type of device you're using (E.g. Yubikey, Fingerprint, etc). Leave blank for no description.", "");
        if (tokenDescription == null) { return; }

        const challengeResponse = await API.Core.GetWebauthnChallengeAsync();
        const challenge = Uint8Array.from(challengeResponse.Result, c => c.codePointAt(0))
        const publicKeyCredParams = [{ type: "public-key", alg: -7 }];//, { type: "public-key", alg: -257 }]; //RS256 and ES256
        const options = {
            challenge,
            rp: { name: "CubeCoders AMP - " + location.hostname, id: location.hostname },
            user: { id: new TextEncoder("utf-8").encode(viewModels.userinfo.username()), name: viewModels.userinfo.username(), displayName: viewModels.userinfo.username() },
            pubKeyCredParams: publicKeyCredParams,
            timeout: 60000,
            attestation: "direct"
        }
        const credential = await navigator.credentials.create({ publicKey: options });
        const atte = btoa(String.fromCharCode.apply(null, new Uint8Array(credential.response.attestationObject)));
        const cdata = btoa(String.fromCharCode.apply(null, new Uint8Array(credential.response.clientDataJSON)));
        const registerResult = await API.Core.WebauthnRegisterAsync(atte, cdata, tokenDescription);
        if (registerResult.Status === true) {
            localStorage.webauthnUsername = viewModels.userinfo.username();
            await UI.ShowModalAsync("Webauthn Registered", "Webauthn has been registered for your account, and will apply next time you login.", UI.Icons.Info, UI.OKActionOnly);
            return true;
        }
        else {
            await UI.ShowModalAsync("Unable to register Webauthn", registerResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };
    this.changePassword = async function () {
        let twoFACode = "";
        if (self.isTwoFactor()) {
            twoFACode = await TwoFactorPrompt("change your login details");
        }

        if (self.newPassword() != self.confirmPassword()) {
            await UI.ShowModalAsync("Failed to change password", "Your confirmed password does not match the original", UI.Icons.Info, UI.OKActionOnly);
            return;
        }

        const changePasswordResult = await API.Core.ChangeUserPasswordAsync(self.username, self.oldPassword, self.newPassword, twoFACode);
        if (changePasswordResult.Status === true) {
            await UI.ShowModalAsync("Password Changed", "Your password was changed successfuly.", UI.Icons.Info, UI.OKActionOnly);

            self.oldPassword("");
            self.newPassword("");
            self.confirmPassword("");
        }
        else {
            await UI.ShowModalAsync("Failed to change password", changePasswordResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    };
    this.mobileLogin = requestMobileLogin;
    this.serviceLogin = serviceLogin;
    this.logout = logout;
    this.update = function (userInfo) {
        self.username(userInfo.Username);
        self.gravatarHash(userInfo.GravatarHash);
        self.isTwoFactor(userInfo.IsTwoFactorEnabled);
        self.emailAddress(userInfo.EmailAddress || "");
        self.isLDAPUser(userInfo.IsLDAPUser);
        self.isOIDCUser(userInfo.IsOIDCUser);
    };
}

function resetWizardHandlers() {
    $("[data-wizard]").off("click");
    $("[data-wizard]").click(handleWizardStep);
}

async function setupCalls(data) {
    const promises = data.map(entry => {
        if (entry.permission !== undefined && !userHasPermission(entry.permission)) {
            return Promise.resolve(null); // Skips processing without affecting other operations
        }

        // Return a new promise for each entry method call
        return new Promise((resolve, reject) => {
            entry.method().then(result => {
                entry.callback(result);
                resolve(result);
            }).catch(ex => {
                console.log("Exception setting up initial requests: " + ex.toString());
                reject(ex);
            });
        });
    });

    // Wait for all promises to settle
    await Promise.allSettled(promises);
}

function AMPUserListVM() {
    const self = this;
    this.users = ko.observableArray(); //of AMPUserVM
    this.currentUser = ko.observable(null); //of AMPUserVM
    this.editUser = ko.observable(null); //of EditAMPUserVM
    this._isLoaded = false;
    this.oidcEnabled = ko.observable(false);

    this.newUsername = ko.observable("");
    this.newIsOIDCUser = ko.observable(false);
    this.newOIDCSub = ko.observable("");

    this.createUser = function () {
        self.newUsername("");
        self.newIsOIDCUser(false);
        self.newOIDCSub("");
        UI.ShowWizard("#tab_createUser");
    };

    this.submitCreateUser = async function () {
        const username = self.newUsername().trim();
        if (username === "") { return; }
        await UI.HideWizard();
        await API.Core.CreateUserAsync(username, self.newIsOIDCUser(), self.newOIDCSub().trim());
        viewModels.ampUserList.refresh();
    };

    this.currentUser.subscribe(async (newvalue) => {
        await newvalue?.refresh();
    });

    this.load = async function () {
        if (self._isLoaded) { return; }
        await self.refresh();
    };

    this.refresh = async function () {
        const result = await API.Core.GetAMPUsersSummaryAsync();
        self.users.removeAll();
        const userVMs = result.map(user => new AMPUserVM(self, user.Id, user.Username, user.GravatarHash, user.LastLogin, user.Disabled));
        ko.utils.arrayPushAll(self.users, userVMs);
        self._isLoaded = true;
    };
}

async function RequestDeleteUser(user) {
    const promptResult = await UI.PromptAsync(
        "Confirm User Deletion",
        { text: "Are you sure you wish to delete this user? This operation cannot be undone. Please enter username to confirm deletion.", subtitle: user },
    );

    if (promptResult === user) {
        const deleteUserResult = await API.Core.DeleteUserAsync(user);

        if (deleteUserResult.Status) {
            viewModels.ampUserList.refresh();
        }
        else {
            UI.ShowModalAsync("User deletion failed", "This user cannot be deleted at this time. " + deleteUserResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    }
    else if (promptResult != null) {
        UI.ShowModalAsync("User deletion failed", "Confirmation prompt did not match username.", UI.Icons.Info, UI.OKActionOnly);
    }
}

function RoleMembershipVM(roleId, name, color, user) {
    const self = this;
    this.ID = roleId;
    this.Name = name;
    this.Color = color;
    this.User = ko.observable(user);
    this.IsMember = ko.computed(function () {
        const userRoles = self.User().Roles();

        for (const roleId of userRoles) {
            if (roleId == self.ID) {
                return true;
            }
        }

        return false;
    });
    this.IsReadOnly = ko.computed(() => self.User().IsOIDCUser());

    this.Toggle = async function () {
        if (self.IsReadOnly()) { return; }
        const currentValue = self.IsMember();
        const updateRoleResult = await API.Core.SetAMPUserRoleMembershipAsync(self.User().ID(), self.ID, !currentValue);

        if (updateRoleResult.Status === true) {
            await self.User()._mgr.refresh();
        }
        else {
            UI.ShowModalAsync("Unable to update role membership", updateRoleResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };
}

function EditAMPUserVM(mgr) {
    const self = this;
    this._mgr = mgr;
    this.ID = ko.observable();
    this.Name = ko.observable();
    this.EmailAddress = ko.observable();
    this.Disabled = ko.observable();
    this.Password = ko.observable();
    this.Password2 = ko.observable();
    this.LastLogin = ko.observable();
    this.PasswordExpires = ko.observable();
    this.IsSuperUser = ko.observable();
    this.GravatarHash = ko.observable();
    this.GravatarImageUri = ko.computed(() => `https://gravatar.com/avatar/${this.GravatarHash()}?d=mp&r=g&s=128`);
    this.CannotChangePassword = ko.observable();
    this.MustChangePassword = ko.observable();
    this.Roles = ko.observableArray(); //of GUID
    this.LastLoginTimestamp = ko.computed(() => (this.LastLogin() == null) ? "Never" : parseDate(this.LastLogin()).getTimestamp());
    this.RoleMembership = ko.observableArray(); //of RoleMembershipVM
    this.DefaultGroupId = ko.observable();
    this.IsLDAPUser = ko.observable(false);
    this.IsOIDCUser = ko.observable(false);
    this.OIDCSub = ko.observable("");

    this.passwordGrade = ko.computed(() => getPasswordGrade(self.Password()));
    this.passwordGradeClass = ko.computed(() => getGradeAsColorClass(self.passwordGrade()));
    this.passwordGradeWidth = ko.computed(() => (this.passwordGrade() * 28) + "px");

    this._update = async function () {
        self.RoleMembership.removeAll();
        await viewModels.roles.load();
        const roles = viewModels.roles.roles();
        ko.utils.arrayPushAll(self.RoleMembership, roles.filter(r => !r.IsDefault).map(role => new RoleMembershipVM(role.Id, role.Name, "#fff", self)));
    };

    this.editPermissions = async function () {
        const roleData = await API.Core.GetRoleAsync(self.ID);

        if (roleData != null) {
            $("a[href='#tab_rolemanagement']").click();
            const newRole = new PermissionRoleVM(roleData.Name, roleData.ID, roleData.Description, roleData.Permissions, roleData.Members, roleData.IsDefault, roleData.IsInstanceSpecific, roleData.DisableEdits, roleData.IsCommonRole, viewModels.roles);
            newRole.IsHidden(true);
            newRole.Click();
            newRole.OverrideShow();
        }
        else {
            UI.ShowModalAsync("Permission data unavailable.", "There is no single-user role matching this users ID. If you have upgraded from a previous version of AMP you will need to re-create this user.", UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.saveChanges = async function (e) {
        const updateResult = await API.Core.UpdateUserInfoAsync(self.Name, self.Disabled, self.PasswordExpires, self.CannotChangePassword, self.MustChangePassword, self.EmailAddress);

        if (updateResult.Status) {
            UI.CreateLocalAnnouncement("✅ Details changed successfully ", "This users settings have been updated and will take effect the next time this user logs in.", false, true);
            viewModels.ampUserList.refresh();
        }
        else {
            UI.ShowModalAsync("Unable to update user.", updateResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly, null, null);
        }
    };

    this.saveOIDCSub = async function () {
        const result = await API.Core.UpdateOIDCSubAsync(self.Name(), self.OIDCSub());
        if (result.Status) {
            UI.CreateLocalAnnouncement("✅ OIDC Subject updated", "The OIDC subject has been updated. This will take effect on the user's next login.", false, true);
        } else {
            UI.ShowModalAsync("Unable to update OIDC subject", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.deleteUser = function () {
        const user = this.Name();
        RequestDeleteUser(user);
    };

    this.convertToOIDC = async function () {
        const oidcSub = await UI.PromptAsync(
            "Convert to OIDC",
            { text: `This will convert '${self.Name()}' to an OIDC-authenticated account. The user's password will be cleared and they will only be able to log in via the OIDC provider.`, subtitle: "Optionally enter the user's OIDC Subject (sub) claim. If left blank it will be populated automatically on first login." },
            ""
        );

        if (oidcSub === null) { return; }

        const result = await API.Core.ConvertUserToOIDCAsync(self.Name(), oidcSub);
        if (result.Status) {
            await UI.ShowModalAsync("Conversion Successful", `${self.Name()} is now configured as an OIDC user.`, UI.Icons.Info, UI.OKActionOnly);
            await self._mgr.refresh();
        } else {
            UI.ShowModalAsync("Conversion Failed", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.revertFromOIDC = async function () {
        const promptResult = await UI.ShowModalAsync(
            "Revert to Local Authentication",
            { text: `This will revert '${self.Name()}' back to local (password-based) authentication. Their OIDC link will be removed and their password will be cleared.`, subtitle: "An administrator will need to set a new password for this user before they can log in again." },
            UI.Icons.Exclamation,
            [
                new UI.ModalAction("Revert to Local Auth", true, "bgRed"),
                new UI.ModalAction("Cancel", false)
            ]
        );

        if (promptResult !== true) { return; }

        const result = await API.Core.RevertUserFromOIDCAsync(self.Name());
        if (result.Status) {
            await UI.ShowModalAsync("Revert Successful", `${self.Name()} has been reverted to local authentication. A password reset is required before they can log in.`, UI.Icons.Info, UI.OKActionOnly);
            await self._mgr.refresh();
        } else {
            UI.ShowModalAsync("Revert Failed", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }
    };

    this.changePassword = async function () {
        if (this.Password() != this.Password2()) {
            UI.ShowModalAsync("Passwords do not match", "The two passwords you have entered do not match. Please re-enter and try again.", UI.Icons.Info, UI.OKActionOnly);
            return;
        }
        const passwordChangeResult = await API.Core.ResetUserPasswordAsync(this.Name, this.Password);
        if (passwordChangeResult.Status) {
            UI.ShowModalAsync("Password changed successfully", "This users password has been updated and will take effect the next time this user logs in.", UI.Icons.Info, UI.OKActionOnly);
            viewModels.ampUserList.refresh();
        }
        else {
            UI.ShowModalAsync("Password change failed", "This users password could not be changed. " + passwordChangeResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    };

    this.timesDangerClicked = 0;
    this.clickDanger = function () {
        self.timesDangerClicked++;
        if (self.timesDangerClicked > 4) {
            self.timesDangerClicked = 0;
            window.open("https://www.youtube.com/watch?v=siwpn14IE7E", "_blank");
        }
    };

    setTimeout(() => {
        this.EmailAddress.subscribe(this.saveChanges);
        this.Disabled.subscribe(self.saveChanges);
        this.PasswordExpires.subscribe(this.saveChanges);
        this.CannotChangePassword.subscribe(this.saveChanges);
        this.MustChangePassword.subscribe(this.saveChanges);
    }, 500);
}

function AMPUserVM(mgr, id, username, gravatarHash, lastLogin, disabled) {
    const self = this;
    this._mgr = mgr;
    this.id = id;
    this.username = username;
    this.gravatar = `https://gravatar.com/avatar/${gravatarHash}?d=mp&r=g&s=128`;
    this.lastLoginTimestamp = parseDate(lastLogin).getTimestamp();
    this.disabled = disabled;
    //Active / Inactive, Never Logged In / Logged In: 00:00:00
    this.userShortDesc = ko.computed(() => { return (this.disabled ? "Inactive" : "Active") + ", " + (lastLogin == null ? "Never Logged In" : "Logged In " + this.lastLoginTimestamp); });
    this.selected = ko.observable(false);
    this.click = async function () {
        const current = self._mgr.currentUser();
        if (current != null) { current.selected(false); }
        self.selected(true);
        self._mgr.currentUser(self);
    };
    this.refresh = async function () {
        const userInfo = await API.Core.GetAMPUserInfoAsync(self.username);
        const vm = new EditAMPUserVM(self);
        ko.quickmap.map(vm, userInfo);
        await vm._update();
        self._mgr.editUser(vm);
    };
}

let currentSettings = {};
let suppressSettingUpdates = true;

function GetSetting(node) {
    const vm = currentSettings[node];
    if (vm != undefined) {
        return vm.value();
    }
    return null;
}

function SettingsVM() {
    this.categories = ko.observableArray(); //of SettingCategoryVM
    this.currentCategory = ko.observable();
}

function replaceWithNonBreakingSpace(input) {
    const andIndex = input.indexOf(" and ");
    if (andIndex === -1) return input;

    const beforeAnd = input.substring(0, andIndex).trim();
    const afterAnd = input.substring(andIndex + 5).trim(); // 5 because " and " is 5 characters long

    if (beforeAnd.length <= afterAnd.length) {
        return beforeAnd + "\u00A0and " + afterAnd;
    } else {
        return beforeAnd + " and\u00A0" + afterAnd;
    }
}

function SettingSubcategoryVM(name, category, settings) {
    const regex = /^([^:]+)(?::(.*?))?(?::(.*))?$/;
    const [, displayName, icon = 'extension', order = 1] = regex.exec(name) || [];

    const self = this;
    this.name = name;
    this.displayName = replaceWithNonBreakingSpace(displayName);
    this.icon = icon;
    this.order = Number.parseInt(order);
    this.category = category;
    this.active = ko.observable(false);
    this.click = function () {
        self.category.subcategories().map(s => s.active(false));
        self.category.currentSubcategory(self);
        self.active(true);
        self.populate();
        UI.ApplyDescriptionLinks(`#${self.category.tabName()} .settingDescription`);
    };
    this.settingsData = settings.sort((a, b) => { return a.order - b.order; });
    this.settings = ko.observableArray();
    this.loaded = false;
    this.populate = async function () {
        suppressSettingUpdates = true;
        if (!self.loaded) {
            ko.utils.arrayPushAll(self.settings, self.settingsData);
            self.loaded = true;
        }

        await Promise.all(self.settings().map(e => e.populate()));
        suppressSettingUpdates = false;
    };
}

function GetIconName(name) {
    const iconNames = {
        "Backups": "database",
        "Branding": "branding_watermark",
        "External Services": "linked_services",
        "File Manager": "draft",
        "Instance Deployment": "deployed_code",
        "Security and Privacy": "policy",
        "Updates": "system_update_alt",
        "System Settings": "settings",
        "Server Settings": "tune",
        "Gameplay": "joystick",
        "Gameplay Settings": "joystick",
        "Game Settings": "joystick",
    };

    return iconNames.hasOwnProperty(name) ? iconNames[name] : "extension";
}

function SettingCategoryVM(name, category) {
    const self = this;

    this.name = ko.observable(name);
    this.category = category;
    this.settingData = [];
    this.settings = ko.observableArray(); //of SettingVMs
    this.tabName = ko.computed(() => "tab_settings_loaded_" + self.name().replaceAll(/(?:[\s'?!])|(?::\w+$)/g, ''), this);
    this.loaded = false;
    this.icon = GetIconName(name);
    this.subcategories = ko.observableArray(); //of SettingSubcategoryVM
    this.currentSubcategory = ko.observable();
    this.click = function () {
        self.populate();
        viewModels.settings.currentCategory(self);
    };
    this.populate = async function () {
        if (self.loaded) {
            return;
        }

        const groupedSettings = self.settingData.groupBy(s => s.subcategory);
        const subcatVMs = Object.keys(groupedSettings).map(g =>
            new SettingSubcategoryVM(g, self, groupedSettings[g])).sort((a, b) => { return a.order - b.order; });
        ko.utils.arrayPushAll(self.subcategories, subcatVMs);
        self.subcategories()[0].click();

        self.loaded = true;
    };
    this.setActiveSubcategory = function (name) {
        this.subcategories().find(s => s.name == name)?.click();
    };
}

function SettingVM(setting, categoryVM) {
    const self = this;
    const properValue = (setting.InputType == "checkbox") ? parseBool(setting.CurrentValue) : setting.CurrentValue;
    this.originalInputType = setting.InputType;
    this.category = categoryVM;
    this.keywords = setting.Keywords;
    this.subcategory = setting.Subcategory;
    this.order = setting.Order;
    this.node = setting.Node;
    this.tag = setting.Tag;
    this.name = Locale.l(setting.Name);
    this.description = Locale.l(setting.Description);
    this.settingType = setting.ValType;
    this.inputType = ko.computed(() => self.originalInputType != "UserPassword" || GetSetting("Core.Security.AllowUserPasswords") ? self.originalInputType : "RandomPassword");
    this.value = ko.observable(properValue);
    this.clearValue = function () { self.value(""); };
    this.selectedValue = ko.observable(null); //For use when value is list/enumerable.
    this.enumValues = ko.observableArray() //of SettingOptionVM
    this.updating = ko.observable(false);
    this.actions = setting.Actions.map((action) => new SettingActionVM(action.Module, action.Method, action.Caption, action.Argument, action.IsClientSide));
    this.visible = ko.observable(self.inputType() !== "HIDDEN");
    this.isComplexType = false;
    this.newKVPkey = ko.observable("");
    this.newKVPvalue = ko.observable("");
    this.provisionSpec = setting.ReadOnlyProvision;
    this.definedReadOnly = setting.ReadOnlyProvision || setting.ReadOnly || false;
    this.disabled = ko.observable(false);
    this.isReadOnly = ko.computed(() => this.definedReadOnly || this.disabled());
    this.deferred = setting.EnumValuesAreDeferred;
    this.deferredListLoaded = false;
    this.isHighlighted = ko.observable(false);
    this.tooltipVisible = ko.observable(false);
    this.tooltipText = ko.observable(setting.RequiresRestart ? "Setting applies after restart" : "Setting Saved");
    this.tooltipIcon = setting.RequiresRestart ? "replay" : "check_circle"
    this.tooltipClass = ko.observable(setting.InputType == "checkbox" ? "tooltiptext tooltiphigher tooltipright" : "tooltiptext");
    this.placeholder = setting.Placeholder;
    this.suffix = setting.Suffix;
    this.minValue = setting.MinValue || null;
    this.maxValue = setting.MaxValue || null;
    this.maxLength = setting.MaxLength || -1;
    this.attributes = setting.Attributes;
    this.keyEnumOptions = this.attributes?.KeyEnumValues
        ? Object.entries(this.attributes.KeyEnumValues)
            .map(([value, name]) => ({ value, name }))
            .sort((a, b) => a.name.localeCompare(b.name))
        : null;
    this.nodePickerVisible = ko.observable(false);
    this.nodePickerFilter = ko.observable("");
    this.nodePickerHighlight = ko.observable(-1);
    this.nodePickerFiltered = ko.computed(() => {
        if (!self.keyEnumOptions) { return []; }
        const filter = self.nodePickerFilter().toLocaleLowerCase();
        if (filter.length === 0) { return self.keyEnumOptions; }
        return self.keyEnumOptions.filter(o =>
            o.name.toLocaleLowerCase().includes(filter) ||
            o.value.toLocaleLowerCase().includes(filter)
        );
    });
    this.nodePickerSelectItem = function (item) {
        self.newKVPkey(item.value);
        self.nodePickerVisible(false);
        self.nodePickerFilter("");
        self.nodePickerHighlight(-1);
    };
    this.nodePickerInputEvent = function (_, e) {
        const val = self.newKVPkey();
        self.nodePickerFilter(val);
        self.nodePickerHighlight(-1);
        if (self.keyEnumOptions) { self.nodePickerVisible(true); }
        return true;
    };
    this.nodePickerFocusEvent = function (_, e) {
        if (self.keyEnumOptions) {
            self.nodePickerFilter(self.newKVPkey());
            self.nodePickerVisible(true);
        }
        return true;
    };
    this.nodePickerKeydown = function (_, e) {
        if (!self.nodePickerVisible()) { return true; }
        const items = self.nodePickerFiltered();
        let idx = self.nodePickerHighlight();
        if (e.key === "ArrowDown") {
            self.nodePickerHighlight(Math.min(idx + 1, items.length - 1));
            return false;
        } else if (e.key === "ArrowUp") {
            self.nodePickerHighlight(Math.max(idx - 1, 0));
            return false;
        } else if (e.key === "Enter" && idx >= 0 && items[idx]) {
            self.nodePickerSelectItem(items[idx]);
            return false;
        } else if (e.key === "Escape") {
            self.nodePickerVisible(false);
            self.nodePickerHighlight(-1);
            return false;
        }
        return true;
    };
    this.requiresRestart = setting.RequiresRestart;
    this.required = setting.Required;
    this.hasWarning = ko.computed(() => self.required && (self.value() == "" || self.value() == null));
    this.el = ko.observable(null);
    this.pwInput = ko.observable(self.value());
    this.showPwGrade = ko.computed(() => self.inputType() == "UserPassword" ? self.value() != self.pwInput() : false);
    this.passwordGrade = ko.computed(() => self.inputType() == "UserPassword" ? getPasswordGrade(self.pwInput()) : 0);
    this.passwordGradeClass = ko.computed(() => self.inputType() == "UserPassword" ? getGradeAsColorClass(self.passwordGrade()) : "");
    this.passwordGradeWidth = ko.computed(() => (this.passwordGrade() * 28) + "px");
    this.showNodes = ko.computed(() => UI.ShowDevNodes());
    this.doubleWidth = false;
    this.bulkEditMode = ko.observable(false);
    this.bulkValue = ko.observable("");
    this.updateEnumValues = function (valueObject) {
        this.enumValues.removeAll();
        ko.utils.arrayPushAll(this.enumValues, Object.keys(valueObject).map(enumValue => new SettingOptionVM(valueObject[enumValue], enumValue)));
    };

    if (setting.ValType === "Enum" || setting.ValType === "Combo" || setting.ValType == "Radio") {
        this.updateEnumValues(setting.EnumValues);
    }
    else if (setting.ValType.startsWith("Dictionary<")) {
        const kvpList = Object.keys(setting.CurrentValue).map(key => ({ Key: key, Value: setting.CurrentValue[key] }));
        this.value = ko.observableArray(kvpList);
        this.isComplexType = true;
        this.doubleWidth = true;
    }
    else if (setting.ValType.startsWith("List<")) {
        this.value = ko.observableArray(setting.CurrentValue);
        this.isComplexType = true;
    }

    this.oldValue = this.value;

    this.showTooltip = async function () {
        self.tooltipVisible(true);
        await sleepAsync(3000);
        self.tooltipVisible(false);
    }

    this.addValue = async function () {
        const newValue = await UI.PromptAsync("Enter a new value", self.Description);
        if (newValue != null) {
            self.value.push(newValue);
        }
    };

    this.removeValue = function () {
        if (self.selectedValue() != null) {
            self.value.remove(self.selectedValue());
            self.selectedValue(null);
        }
    };

    this.updatePassword = function () {
        if (getPasswordGrade(self.pwInput()) < 3) {
            UI.ShowModalAsync("Password too weak", "The supplied password is too weak. It must contain a minimum of 8 characters, mixed-case letters, digits, and non-alphanumeric characters. Consider using 'Generate Password'", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }

        if (!('clipboard' in navigator)) {
            UI.ShowModalAsync("Feature Unavailable", "Using this feature requires that you are accessing AMP over HTTPS or via localhost.", UI.Icons.Info, UI.OKActionOnly);
            return;
        }

        self.value(self.pwInput());
        self.tooltipClass("tooltiptext tooltipleft");
        self.tooltipText("Password updated");
    };

    this.generateRandomPassword = function () {
        let newValue = generateSecurePassword(12);

        if (self.maxLength > 0 && self.maxLength < newValue.length) {
            newValue = newValue.slice(0, self.maxLength);
        }
        if ('clipboard' in navigator) {
            self.value(newValue);
            self.tooltipClass("tooltiptext tooltipleft");
            navigator.clipboard.writeText(self.value());
            self.tooltipText("New password copied to clipboard");

            if (self.inputType() == "UserPassword") {
                self.pwInput(newValue);
            }
        }
        //--TEMPORARY HTTPS BYPASS FOR ENTERPRISE CLIENTS ONLY--
        else if (PluginHandler.HasFeature("CommercialUsage")) {
            self.value(newValue);
            self.tooltipClass("tooltiptext tooltipleft");
            const $temp = $("<input>");
            $("body").append($temp);
            $temp.val(self.value()).select();
            document.execCommand("copy");
            $temp.remove();
            self.tooltipText("New password copied to clipboard");

            if (self.inputType == "UserPassword") {
                self.pwInput(newValue);
            }

        }
        else {
            UI.ShowModalAsync("Feature Unavailable", "Using this feature requires that you are accessing AMP over HTTPS or via localhost.", UI.Icons.Info, UI.OKActionOnly);
        }
    };

    this.getTypedValue = function (newValue) {
        //Look at the type of self.value() and based on that type, cooerce newValue into it so we're properly left with a boolean/integer/string
        const currentValue = self.value();
        if (currentValue == null) { return newValue; }

        const type = typeof currentValue;
        switch (type) {
            case "boolean":
                return parseBool(newValue);
            case "number":
                return Number.parseInt(newValue);
            case "string":
                return newValue.toString();
            default:
                return newValue;
        }
    };

    this.setTypedValue = function (newValue) {
        const typedValue = self.getTypedValue(newValue);
        self.value(typedValue);
    };

    this.clearPassword = function () {
        self.value("");
        self.tooltipClass("tooltiptext")
        self.tooltipText("Password Cleared");
    };

    this.moveValueUp = function () {
        const existingPosition = self.value.indexOf(self.selectedValue());
        if (existingPosition == 0) { return; }
        const existingValue = self.selectedValue();
        self.value.remove(self.selectedValue());
        self.value.splice(existingPosition - 1, 0, existingValue);
        self.selectedValue(existingValue);
    };

    this.moveValueDown = function () {
        const existingPosition = self.value.indexOf(self.selectedValue());
        const existingValue = self.selectedValue();
        self.value.remove(self.selectedValue());
        self.value.splice(existingPosition + 1, 0, existingValue);
        self.selectedValue(existingValue);
    };

    this.bulkEdit = function () {
        if (self.settingType.startsWith("List<")) {
            if (self.bulkEditMode()) {
                self.value(self.bulkValue().trim().split("\n"));
            }
            else {
                self.bulkValue(self.value().join("\n"));
            }
        }
        else if (self.bulkEditMode()) {
            suppressSettingUpdates = true;
            const currentValue = self.value();
            self.value([]);
            suppressSettingUpdates = false;
            self.value(currentValue);
        }

        self.bulkEditMode(!self.bulkEditMode());
    }

    this.removeKVP = function () {
        this.oldValue = self.value().slice(0);
        self.value.remove(this);
    };

    this.addKVP = function () {
        this.oldValue = self.value().slice(0);
        let newRow = { Key: self.newKVPkey(), Value: self.newKVPvalue() };

        if (newRow.Key == "") {
            UI.ShowModalAsync("Missing key", "You must specify a key", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }

        const existing = self.value();

        for (const element of existing) {
            if (element.Key == newRow.Key) {
                UI.ShowModalAsync("Duplicate Key", "An item with this key already exists.", UI.Icons.Exclamation, UI.OKActionOnly);
                return;
            }
        }

        self.value.push(newRow);
        self.newKVPkey("");
        self.newKVPvalue("");
    };

    this.setupSubscription = function () {
        self.value.subscribe(async function (newValue) {
            if (suppressSettingUpdates || newValue === undefined) { return; }
            if (newValue == self.oldValue && !Array.isArray(newValue)) { return; }

            self.updating(true);

            let useValue = self.value();

            if (self.settingType.startsWith("Dictionary<")) {
                let kvp = self.value();
                useValue = kvp.reduce((acc, { Key, Value }) => {
                    acc[Key] = Value;
                    return acc;
                }, {});
            }

            newValue = self.isComplexType ? JSON.stringify(useValue) : useValue;

            if (self.inputType == "checkbox") {
                self.tooltipClass("tooltiptext tooltiphigher " + (newValue ? "tooltipfarright" : "tooltipright"));
            }

            const result = await API.Core.SetConfigAsync(self.node, newValue);

            if (result.Status === false) {
                UI.ShowModalAsync("Unable to change setting value", `Could not change ${self.name} - ${result.Reason}`, UI.Icons.Exclamation, UI.OKActionOnly);
                suppressSettingUpdates = true;
                self.value(self.oldValue);
                suppressSettingUpdates = false;
            }
            else {
                self.oldValue = useValue;
                PluginHandler.NotifyPluginSettingChanged(self.node, newValue);
                self.showTooltip();
            }

            if (self.requiresRestart) {
                const restartPromptResult = await UI.ShowModalAsync("Restart Required", "Changes to this setting will not take effect until this AMP instance is restarted. Would you like to restart now?", UI.Icons.Info, [new UI.ModalAction("Keep Running", false, "bgGreen"), new UI.ModalAction("Restart Now", true, "bgRed")]);
                if (restartPromptResult) { viewModels.support.restartAMP(); }
            }

            await sleepAsync(1000);
            self.updating(false);

        }, self);

        self.visible.subscribe(function () {
            if (!self.visible() || suppressSettingUpdates) { return; }
            self.category.click();
        });
    };

    this.refreshValues = async function () {
        console.log(`Refreshing setting values for ${self.node}`);
        const result = await API.Core.GetSettingValuesAsync(self.node, !self.deferred);
        this.updateEnumValues(result);
    };

    this.populate = function () {
        if (self.deferred && !self.deferredListLoaded && self.visible()) {
            self.deferredListLoaded = true;
            self.refreshValues();
        }
    };

    this.highlight = async function () {
        self.category.tabvm.click();
        self.category.setActiveSubcategory(self.subcategory);
        self.el().scrollIntoView({ behavior: "smooth", block: "end", inline: "nearest" });
        self.isHighlighted(true);
        await sleepAsync(2000);
        self.isHighlighted(false);
    };
}

function SettingOptionVM(displayName, value) {
    this.name = displayName;
    this.value = value;
}

function SettingActionVM(module, method, caption, argument, isClientSide) {
    const self = this;
    this.module = module;
    this.method = method;
    this.caption = caption;
    this.argument = argument;
    this.isClientside = isClientSide;

    this.click = async function () {
        if (self.isClientside) {
            if (!(self.module in Features)) { UI.ShowModalAsync("Bad inline action", `No such module ${self.module} is loaded.`, UI.Icons.Exclamation, UI.OKActionOnly); return; }
            if (!(self.method in Features[self.module])) { UI.ShowModalAsync("Bad inline action", `No such method ${self.method} is declared as a feature by ${self.module}.`, UI.Icons.Exclamation, UI.OKActionOnly); return; }

            Features[self.module][self.method](self.argument);
            return;
        }

        let result = null;
        if (self.argument == null || self.argument == "") {
            result = await API[module][method + "Async"]();
        }
        else {
            result = await API[module][method + "Async"](argument);
        }

        if (result?.Status !== undefined) {
            if (result.Status !== true) {
                UI.ShowModalAsync("Task Failed", `${self.caption} failed : ${result.Reason}`, UI.Icons.Exclamation, UI.OKActionOnly);
            }
        }
    };
}

function setSettingVisibility(node, state) {
    let setting = currentSettings[node];
    if (setting != undefined) {
        setting.visible(state);
        setting.populate();
    }
}

function setSettingDisabled(node, state) {
    let setting = currentSettings[node];
    if (setting != undefined) {
        setting.disabled(state);
    }
}

let settingsLoaded = false;

async function getSettingsCallback(result) {
    if (settingsLoaded) { return; }
    settingsLoaded = true;

    currentSettings = {};

    const vm = viewModels.settings;
    vm.categories.removeAll();

    suppressSettingUpdates = true;

    const categoryVMs = Object.keys(result).map((category) => {
        const settings = result[category];

        const ignore = (settings === undefined || settings.length === 0);

        const categoryVM = new SettingCategoryVM(category);

        const settingVMs = settings.map((setting) => {
            if (!userHasPermission("Settings." + setting.Node)) {
                setting.InputType = "HIDDEN";
            }

            const settingSpec = new SettingVM(setting, categoryVM);

            settingSpec.setupSubscription();

            currentSettings[setting.Node] = settingSpec;

            if (!setting.ReadOnly && setting.InputType !== "HIDDEN") {
                return settingSpec;
            }

            return null;
        }).filter(v => v != null);

        categoryVM.settingData = settingVMs;

        if (!ignore && settingVMs.length > 0) {
            categoryVM.tabvm = UI.AddSettingsTab(categoryVM.name(), `#${categoryVM.tabName()}, #tab_settings`, categoryVM.icon, categoryVM.click, 0);
            return categoryVM;
        }

        return null;
    }).filter(v => v != null);;

    ko.utils.arrayPushAll(vm.categories, categoryVMs);

    UI.ApplyDescriptionLinks();

    for (let categorySettings of Object.values(result)) {
        for (let categorySetting of categorySettings) {
            PluginHandler.NotifyPluginSettingChanged(categorySetting.Node, categorySetting.CurrentValue);
        }
    }

    suppressSettingUpdates = false;

    let safeModeNode = currentSettings["Core.AMP.SafeMode"];

    if (safeModeNode != undefined && safeModeNode.value() === true) {
        UI.ShowModalAsync("Safe Mode Enabled", "AMP is running in safe mode. No plugins have been loaded except those required by the loaded module, and the schedule is not loaded. Note that modifying the schedule in Safe Mode will cause your previous schedule to be erased.", UI.Icons.Exclamation, UI.OKActionOnly);
    }


    UI.ShowDevNodes(currentSettings["Core.Monitoring.ShowDevInfo"].value());
    currentSettings["Core.Monitoring.ShowDevInfo"].value.subscribe((newvalue) => { UI.ShowDevNodes(newvalue); });
    currentSettings["Core.AMP.Theme"].value.subscribe((newvalue) => {
        setTimeout(() => { $("#themeLink").attr("href", "/theme?" + Date.now()); }, 250);
    });
    viewModels.schedule.settingsAvailable(true);
}

function getActionCallback(result) {
    UI.PopulateUserActions(result, userActionCallback);
}

function SessionManagementVM() {
    const self = this;
    this.sessions = ko.observableArray(); //of AMPSessionVM
    this.refresh = async function () {
        const sessions = await API.Core.GetActiveAMPSessionsAsync();
        const newEntries = ko.quickmap.to(AMPSessionVM, sessions, false, { vm: self });
        self.sessions.removeAll();
        ko.utils.arrayPushAll(self.sessions, newEntries);
    };
    this.selectedSession = ko.observable(null);
    this.endSession = async function () {

    };
}

function AMPSessionVM() {
    const self = this;
    this.selected = ko.observable(false);
    this.Username = ko.observable("");
    this.StartTime = ko.observable("");
    this.LastActivity = ko.observable("");
    this.Source = ko.observable("");
    this.SessionType = ko.observable("");
    this.SessionTypeIcon = () => `icon icons_${self.SessionType().toLowerCase()}`;
    this.DisplayStartTime = ko.computed(() => parseDate(self.StartTime()).toLocaleString());
    this.DisplayLastActivity = ko.computed(() => parseDate(self.LastActivity()).toLocaleString());
    this.vm = null;
    this.click = function () {
        const current = self.vm.selectedSession();
        if (current != null) { current.selected(false); }
        self.vm.selectedSession(self);
        self.selected(true);
    };
}

let prevState = -1; //Not a valid value, forces a update.

function UserListVM() {
    const self = this;
    this.users = ko.observableArray(); //of AppUserVM
    this.selectedUser = ko.observable(); //of AppUserVM
    this.update = function (newUserList) {
        for (const existingUserId of Object.keys(newUserList)) {
            const existing = ko.utils.arrayFirst(self.users(), (u) => u.id == existingUserId);
            if (existing != null) { continue; }

            const newUserVM = new AppUserVM(newUserList[existingUserId], existingUserId, self);
            self.users.push(newUserVM);
        }

        for (const existingUser of self.users()) {
            const stillExists = newUserList[existingUser.id] !== undefined;
            if (!stillExists) {
                self.users.remove(existingUser);
            }
        }
    };
    this.refresh = async function () {
        const data = await API.Core.GetUserListAsync();
        self.update(data);
    };
}

function ColorLuminance(hex) {

    // validate hex string
    hex = String(hex).replaceAll(/[^0-9a-f]/gi, '');
    if (hex.length < 6) {
        hex = hex[0] + hex[0] + hex[1] + hex[1] + hex[2] + hex[2];
    }
    // convert to decimal and change luminosity
    let rgb = "#";
    for (let i = 0; i < 3; i++) {
        const n = Number.parseInt(hex.substring(i * 2, i * 2 + 2), 16);
        const c = Math.round((n / 2) + 127).toString(16);
        rgb += ("00" + c).substring(c.length);
    }

    return rgb;
}

function hashCode(str) {
    let hash = 0;
    for (let i = 0; i < str.length; i++) {
        hash = str.codePointAt(i) + ((hash << 5) - hash);
    }
    return hash;
}

function intToRGB(i) {
    return ((i >> 24) & 0xFF).toString(16) +
        ((i >> 16) & 0xFF).toString(16) +
        ((i >> 8) & 0xFF).toString(16);
}

function AppUserVM(name, id, vm) {

    /* jshint bitwise: false */
    const self = this;
    this.name = name;
    this.id = id;
    this.userColor = ColorLuminance(intToRGB(hashCode(name)).pad(6));
    this.vm = vm;
    this.click = function () {
        UI.ShowUserInfo(self.name, self.id, null, null);
        UI.ShowWizard("#tab_console_userinfo");

        selectedUserId = self.id;
        selectedUserName = self.name;

        API.Core.GetUserInfo(id, function (Name, Id, SessionId, IPAddress, JoinTime) {
            UI.ShowUserInfo(Name, Id, IPAddress, JoinTime);
        });
    };
}

function getUpdatesCallback(data) {
    if (data?.StackTrace !== undefined && API.GetBadNetworkState()) {
        midSessionLogin();
        return;
    }

    UI.UpdateDisplayMetrics(data.Status.Metrics, data.Status.Uptime);
    processState(data.Status.State);
    viewModels.support.updatePorts(data.Ports);

    if (!API.WebsocketsEnabled()) {
        UI.UpdateNotifications(data.Tasks);
        UI.AddConsoleEntries(data.ConsoleEntries);
        for (const message of data.Messages) {
            processPushedMessage(message);
        }
    }
}

function processState(newState) {
    if (newState !== prevState) {
        prevState = newState;
        UI.UpdateState(newState);
        viewModels.support.appState(newState);
        if (newState == 100 || newState == 80) //Failed
        {
            PluginHandler.NotifyPluginFailureState(newState);
        }
    }
}

function processPushedMessage(message) {
    if (message.Source == "Core" || message.Source == "GSMyAdmin") {
        handleNotify(message.Message, message.Parameters);
        return;
    }
    PluginHandler.NotifyPluginMessage(message.Source, message.Message, message.Parameters);
}

function updatesFailedCallback(module, method, data, error) {
    API.Core.GetUpdates.clearInterval();
    midSessionLogin();
}

function handleNotify(message, data) {
    switch (message) {
        case "schedulemodified":
            refreshSchedule();
            break;
        case "sessionslistchanged":
            viewModels.ampSessions.refresh();
            break;
        case "userlistchanged":
            viewModels.appUsers.refresh();
            break;
        case "enumrefresh":
            {
                suppressSettingUpdates = true;
                const settingSpec = currentSettings[data.node];
                settingSpec?.updateEnumValues(data.newValues);
                suppressSettingUpdates = false;
                break;
            }
        case "settingValueUpdate":
            {
                suppressSettingUpdates = true;
                const settingSpec = currentSettings[data.node];
                if (settingSpec) {
                    settingSpec.value(data.newValue);
                    settingSpec.oldValue = data.newValue;
                }
                suppressSettingUpdates = false;
                break;
            }
        case "ConsoleEntry":
            UI.AddConsoleEntries([data]);
            break;
        case "refreshTask":
            UI.UpdateNotifications([data], true);
            break;
        case "removeTask":
            UI.RemoveNotification(data);
            break;
        case "Metrics":
            UI.UpdateDisplayMetrics(data.Metrics, data.Uptime);
            processState(data.State);
            viewModels.support.updatePorts(data.Ports);
            break;
        case "PermissionsNodeCacheInvalidated":
            viewModels.roles.refresh();
            viewModels.ampUserList.refresh();
            break;
        default:
            console.log(`Unknown message ${message}`);
            break;
    }
}

////////////////////////////////
// Merlin
////////////////////////////////

let oldHash = "";

function setHash(value) {
    oldHash = value;
    location.hash = value;
}

function hashChange(e) {
    if (location.hash == "" && oldHash != "") {
        UI.HideWizard();
    }
}

let wizardCallbacks = {};

function setWizardCallback(wizName, callback, reset, tab, cancelCallback) {
    wizardCallbacks[wizName] = {};
    wizardCallbacks[wizName].callback = callback;
    wizardCallbacks[wizName].reset = reset || null;
    wizardCallbacks[wizName].tab = tab || null;
    wizardCallbacks[wizName].cancelCallback = cancelCallback || null;
    $("#" + wizName).find("form").submit(function (event) {
        event.preventDefault();
        event.stopPropagation();

        try {
            UI.HideWizard();
            callback();
        }
        catch {
            //Do nothing
        }

        return false;
    });
}

async function handleWizardStep(event) {
    event.preventDefault();
    event.stopPropagation();

    const wizData = $(this).data();
    const wizName = wizData.wizardname;

    switch (wizData.wizard) {
        case "show":
            if (wizardCallbacks[wizName] == undefined) {
                UI.ShowModalAsync("Invalid Wizard", `No such wizard ${wizName} has been defined.`, UI.Icons.Exclamation, UI.OKActionOnly);
                return;
            }

            if (wizardCallbacks[wizName]?.reset != null) {
                wizardCallbacks[wizName].reset();
            }

            UI.ShowWizard("#" + wizData.wizardtab);
            break;
        case "finish":
            if (wizardCallbacks[wizName]?.callback != null) {
                wizardCallbacks[wizName].callback();
            }
            await UI.HideWizard();
            break;
        case "cancel":
            await UI.HideWizard();
            if (wizardCallbacks[wizName]?.cancelCallback != null) {
                wizardCallbacks[wizName].cancelCallback();
            }
            break;
        case "next":
            UI.SwapWizard("#" + wizData.wizardtab);
            break;
    }
}

////////////////////////////////
// Scheduling
////////////////////////////////

let eventTriggers = [];
let popTriggers = [];
let popTriggerIds = {};
let methods = [];
let methodIds = {};

function TriggerSegmentVM(n, text, selected) {
    const self = this;
    this.index = n;
    this.selected = ko.observable(selected || false);
    this.toggle = function () { self.selected(!self.selected()); };
    this.text = text;
}

function padLeft2(input) {
    const str = "" + input;
    const pad = "00";
    const ans = pad.substring(0, pad.length - str.length) + str;
    return ans;
}

function ScheduleVM() {
    const self = this;
    this.newTriggerType = ko.observable(-1);

    this.availableTriggers = ko.observableArray(); //of ScheduleTriggerVM();
    this.populatedTriggers = ko.observableArray(); //of ScheduleTriggerVM();

    this.selectedTrigger = ko.observable(); //of ScheduleTriggerVM();
    this.newTriggerEvent = ko.observable(); //of ScheduleTriggerVM();
    this.newTriggerName = ko.observable("Every 5 minutes");
    this.newSimpleTriggerType = ko.observable(0); //0: Once per week, 10: Once per day, 20: Every X hours, 30: Every X minutes, 40: Once per month on the Xth day, 50: Once per month on the first (day).
    this.editTriggerId = ko.observable("");
    this.editing = ko.observable(false);

    this.availableMethods = ko.observableArray(); //of ScheduleTaskVM();
    this.selectedTask = ko.observable(); //of ScheduleTaskVM();
    this.editingTask = ko.observable(); //of ScheduleTriggerTaskVM();
    this.selectedField = null;
    this.setSelected = function (el) { self.selectedField = el; };
    this.insertParam = (name) => self.selectedField.insertAtCaret(`{@${name}}`).focus();

    this.newTriggerMonths = ko.observableArray(); //of TriggerSegmentVM();
    this.newTriggerDays = ko.observableArray(); //of TriggerSegmentVM();
    this.newTriggerHours = ko.observableArray(); //of TriggerSegmentVM();
    this.newTriggerMinutes = ko.observableArray(); //of TriggerSegmentVM();
    this.newTriggerDaysOfMonth = ko.observableArray(); //of TriggerSegmentVM();

    this.simpleWeekday = ko.observable(0);
    this.simpleHours = ko.observable(0);
    this.simpleMinutes = ko.observable(0);
    this.simpleIntervalHours = ko.observable(1);
    this.simpleIntervalMinutes = ko.observable(1);
    this.simpleIntervalDayOfMonth = ko.observable(1);
    this.simpleNthDayOf = ko.observable(0);

    this.settingsAvailable = ko.observable(false);
    this.serverTimezone = ko.computed(() => self.settingsAvailable() ? currentSettings["Core.AMP.SchedulerTimezoneId"]?.value() || "UTC" : "");

    this.resetNewTriggerFields = function (empty) {
        self.newTriggerMonths.removeAll();
        self.newTriggerDays.removeAll();
        self.newTriggerHours.removeAll();
        self.newTriggerMinutes.removeAll();
        self.newTriggerDaysOfMonth.removeAll();

        for (let i = 0; i < Locale.MonthsOfYear.length; i++) {
            self.newTriggerMonths.push(new TriggerSegmentVM(i, Locale.MonthsOfYear[i], !empty));
        }

        for (let i = 0; i < Locale.DaysOfWeek.length; i++) {
            self.newTriggerDays.push(new TriggerSegmentVM(i, Locale.DaysOfWeek[i], !empty));
        }

        for (let i = 0; i < 24; i++) {
            self.newTriggerHours.push(new TriggerSegmentVM(i, i.pad(), !empty));
        }

        for (let i = 0; i < 60; i++) {
            self.newTriggerMinutes.push(new TriggerSegmentVM(i, i.pad(), !empty && i % 5 == 0));
        }

        for (let i = 1; i <= 31; i++) {
            self.newTriggerDaysOfMonth.push(new TriggerSegmentVM(i, i.pad(), !empty));
        }
    };

    this.backButton = function () { self.newTriggerType(-1); };

    this.getNewIntervalTriggerInfo = function () {
        let result = { months: [], days: [], hours: [], minutes: [], daysOfMonth: [] };
        for (const m of self.newTriggerMonths()) { if (m.selected()) { result.months.push(m.index); } }
        for (const m of self.newTriggerDays()) { if (m.selected()) { result.days.push(m.index); } }
        for (const m of self.newTriggerHours()) { if (m.selected()) { result.hours.push(m.index); } }
        for (const m of self.newTriggerMinutes()) { if (m.selected()) { result.minutes.push(m.index); } }
        for (const m of self.newTriggerDaysOfMonth()) { if (m.selected()) { result.daysOfMonth.push(m.index); } }
        return result;
    };

    this.populateIntervalTriggerInfo = function (data) {
        for (const m of data.MatchMonths.values()) { self.newTriggerMonths()[m].selected(true); }
        for (const m of data.MatchDays.values()) { self.newTriggerDays()[m].selected(true); }
        for (const m of data.MatchHours.values()) { self.newTriggerHours()[m].selected(true); }
        for (const m of data.MatchMinutes.values()) { self.newTriggerMinutes()[m].selected(true); }
        for (const m of data.MatchDaysOfMonth.values()) { self.newTriggerDaysOfMonth()[m - 1].selected(true); }
    };

    this.addNewTrigger = function () {
        self.newTriggerType(-1);
        self.resetNewTriggerFields();
        self.editing(false);
        UI.ShowWizard("#tab_schedule_newTrigger");
    };

    this.hideWizard = function () {
        UI.HideWizard();
    };

    this.editTimeTrigger = async function (id, description) {
        self.resetNewTriggerFields(true);
        const data = await API.Core.GetTimeIntervalTriggerAsync(id);
        self.populateIntervalTriggerInfo(data);
        self.newTriggerType(10);
        self.newTriggerName(description);
        self.editTriggerId(id);
        self.editing(true);
        UI.ShowWizard("#tab_schedule_newTrigger");
    }

    this.addTrigger = async function () {
        let data = null;
        const triggerType = Number.parseInt(self.newTriggerType());
        const nths = ["first", "second", "third", "fourth", "fifth"];
        switch (triggerType) {
            case 0:
                data = self.newTriggerEvent().Id();
                await API.Core.AddEventTriggerAsync(data);
                break;
            case 10:
                data = self.getNewIntervalTriggerInfo();

                if (data.months.length == 0 || data.days.length == 0 || data.hours.length == 0 || data.minutes.length == 0) {
                    UI.ShowModalAsync("Invalid Schedule", "You must have at least one segment selected for each time component.", UI.Icons.Exclamation, UI.OKActionOnly);
                    return;
                }

                if (this.editing()) {
                    await API.Core.EditIntervalTriggerAsync(self.editTriggerId(), data.months, data.days, data.hours, data.minutes, data.daysOfMonth, self.newTriggerName());
                }
                else {
                    await API.Core.AddIntervalTriggerAsync(data.months, data.days, data.hours, data.minutes, data.daysOfMonth, self.newTriggerName());
                }
                break;
            case 15:
                {
                    const simpleType = Number.parseInt(self.newSimpleTriggerType());
                    const intervalMinutes = Number.parseInt(self.simpleIntervalMinutes());
                    const intervalHours = Number.parseInt(self.simpleIntervalHours());
                    const intervalDOM = Number.parseInt(self.simpleIntervalDayOfMonth());
                    let hours = [];
                    let minutes = [];
                    let daysOfMonth = [];
                    let description = "";

                    switch (simpleType) {
                        case 0:
                        case 10:
                            hours.push(Number.parseInt(self.simpleHours()));
                            minutes.push(Number.parseInt(self.simpleMinutes()));
                            description = `Every ${simpleType == 0 ? Locale.LongDaysOfWeek[Number.parseInt(self.simpleWeekday())] : "day"} at ${padLeft2(self.simpleHours())}:${padLeft2(self.simpleMinutes())}`;
                            break;
                        case 20:
                            description = `Every ${intervalHours} hours`;
                            for (let h = 0; h < 24; h++) { if (h % intervalHours == 0) { hours.push(h); } }
                            minutes.push(0);
                            break;
                        case 30:
                            description = `Every ${intervalMinutes} minutes`;
                            for (let i = 0; i < 24; i++) { hours.push(i); }
                            for (let m = 0; m < 60; m++) { if (m % intervalMinutes == 0) { minutes.push(m); } }
                            break;
                        case 40:
                            {
                                const dayOfMonth = $("#scheduleSimpleDayOfMonth").children()[intervalDOM - 1].innerText;
                                description = `On the ${dayOfMonth} of each month at ${padLeft2(self.simpleHours())}:${padLeft2(self.simpleMinutes())}`;
                                hours.push(Number.parseInt(self.simpleHours()));
                                minutes.push(Number.parseInt(self.simpleMinutes()));
                                daysOfMonth.push(intervalDOM);
                                break;
                            }
                        case 50:
                            {
                                description = `On the ${nths[Number.parseInt(self.simpleNthDayOf())]} ${Locale.LongDaysOfWeek[Number.parseInt(self.simpleWeekday())]} of each month at ${padLeft2(self.simpleHours())}:${padLeft2(self.simpleMinutes())}`;
                                hours.push(Number.parseInt(self.simpleHours()));
                                minutes.push(Number.parseInt(self.simpleMinutes()));
                                const offset = Number.parseInt(self.simpleNthDayOf()) * 7;
                                daysOfMonth.push(offset + 1, offset + 2, offset + 3, offset + 4, offset + 5, offset + 6, offset + 7);
                                break;
                            }
                    }

                    data = {
                        months: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11],
                        days: simpleType == 0 || simpleType == 50 ? [Number.parseInt(self.simpleWeekday())] : [0, 1, 2, 3, 4, 5, 6],
                        hours: hours,
                        minutes: minutes,
                        daysOfMonth: daysOfMonth,
                    };

                    await API.Core.AddIntervalTriggerAsync(data.months, data.days, data.hours, data.minutes, data.daysOfMonth, description);
                    break;
                }
        }
        refreshSchedule();
        UI.HideWizard();
    };

    this.addEditTask = async function () {
        UI.HideWizard();

        const trigId = self.selectedTrigger().Id();
        const taskId = self.editing() ? self.editingTask().Id() : self.selectedTask().Id();
        const consumes = self.editing() ? self.editingTask().Consumes() : self.selectedTask().Consumes();

        let params = {};

        for (const param of consumes) {
            params[param.Param()] = param.InputType == "checkbox" ? param.Value().toString().toLowerCase() : param.Value();
        }

        if (self.editing()) {
            await API.Core.EditTaskAsync(trigId, taskId, params);
        } else {
            await API.Core.AddTaskAsync(trigId, taskId, params);
        }

        self.editing(false);
        refreshSchedule();
    };

    self.resetNewTriggerFields();
}

const globalScheduleParameterMappingsSource = {
    InstanceName: { Description: "The name of the instance" },
    InstanceId: { Description: "The unique instance ID" },
    Uptime: { Description: "Current uptime (human readable form)" },
    UptimeTotalMinutes: { Description: "Uptime in minutes" },
    State: { Description: "Current state" },
    StartTime: { Description: "When the instance started" },
    ApplicationName: { Description: "Name of the application" },
    RAMUsage: { Description: "RAM usage (MB)" },
    CPUUsage: { Description: "CPU usage (%)" },
    MaxUsers: { Description: "Configured max users" },
    UserCount: { Description: "Current user count" },
    TriggerId: { Description: "The ID of the originating trigger" },
    TriggerName: { Description: "The name of the originating trigger." }
};

const globalScheduleParameterMappings = Object.entries(globalScheduleParameterMappingsSource)
    .map(([key, { Description }]) => {
        return new ScheduleTriggerVariableVM(key, Locale.l(Description));
    });

function describeUtcTime(date) {
    if (!date) {
        return "Never";
    }

    const now = new Date();
    const diffMs = now.getTime() - date.getTime();
    const diffSec = diffMs / 1000;

    if (diffSec < 60) {
        return "Just now";
    }

    const diffMin = diffSec / 60;
    if (diffMin < 2) {
        return "A minute ago";
    }
    if (diffMin < 6) {
        return `${Math.round(diffMin)} minutes ago`;
    }
    if (diffMin < 60) {
        const rounded = Math.round(diffMin / 5) * 5;
        return `${rounded} minutes ago`;
    }

    const diffHr = diffMin / 60;
    if (diffHr < 24) {
        const rounded = Math.round(diffHr);
        return `${rounded} hour${rounded !== 1 ? "s" : ""} ago`;
    }

    const diffDay = diffHr / 24;
    if (diffDay < 30) {
        const rounded = Math.round(diffDay);
        return `${rounded} day${rounded !== 1 ? "s" : ""} ago`;
    }

    const diffMonth = diffDay / 30;
    if (diffMonth < 12) {
        const rounded = Math.round(diffMonth);
        return `${rounded} month${rounded !== 1 ? "s" : ""} ago`;
    }

    return "A really long time ago";
}

function ScheduleTriggerVM(Id, Description, Type, EnabledState, Emits) {
    const self = this;
    this.Id = ko.observable(Id);
    this.Description = ko.observable(Description);
    this.Type = Type;
    this.Emits = ko.observableArray(Emits || []); //of ScheduleParameterMappingVM();
    this.GlobalMappings = globalScheduleParameterMappings;
    this.Tasks = ko.observableArray(); //of ScheduleTriggerTaskVM();
    this.EnabledState = ko.observable(EnabledState);
    this.EnabledToggle = ko.observable((EnabledState & 1) > 0);
    this.Restricted = ko.observable((EnabledState & 64) > 0);
    this.Delete = async function () {
        const result = await UI.ShowModalAsync("Confirm trigger deletion", {
            text: "Are you sure you wish to delete this trigger? Any tasks associated with it will also be deleted. This action cannot be undone.",
            subtitle: this.Description()
        }, UI.Icons.Exclamation, [
            new UI.ModalAction("Remove Trigger", true, "bgRed"),
            new UI.ModalAction("Cancel", false)]);

        if (result) {
            await API.Core.DeleteTriggerAsync(self.Id);
            refreshSchedule();
        }
    };
    this.AddTask = function () {
        viewModels.schedule.editing(false);
        viewModels.schedule.selectedTrigger(self);
        UI.ShowWizard("#tab_schedule_newTask");
    };
    this.Edit = function () {
        viewModels.schedule.editTimeTrigger(self.Id(), self.Description());
    }
    this.RunNow = function () {
        API.Core.RunEventTriggerImmediately(self.Id());
    };
    this.IsEditable = Type == "TimeIntervalTrigger";
    this.EnabledToggle.subscribe(async (newValue) => {
        await API.Core.SetTriggerEnabled(self.Id, newValue);
    });
}

function ScheduleTaskVM(Id, Name, Description, DisplayFormat, Consumes) {
    this.Id = ko.observable(Id);
    this.Description = ko.observable(Description);
    this.Name = ko.observable(Name);
    this.Consumes = ko.observableArray(Consumes || []); //of ScheduleParameterMappingVM();
    this.DisplayFormat = DisplayFormat;
}

function ScheduleTriggerVariableVM(Name, Description) {
    this.Name = Name;
    this.Description = Description;
}

function ScheduleTriggerTaskVM(Id, TriggerId, Description, Order, EnabledState, LastExecuteError, LastErrorReason, TriggerVM) {
    const self = this;
    this.Id = ko.observable(Id);
    this.TriggerId = ko.observable(TriggerId);
    this.TriggerVM = TriggerVM;
    this.Name = ko.observable("");
    this.EnabledState = ko.observable(EnabledState);
    this.Description = ko.observable(Description);
    this.LastExecuteError = ko.observable(LastExecuteError);
    this.LastErrorReason = ko.observable(LastErrorReason);
    this.ParameterMappings = ko.observableArray(); //of ScheduleParameterMappingVM();
    this.Consumes = this.ParameterMappings;
    this.Order = ko.observable(Order);
    this.FormattedDisplay = ko.observable("");
    this.Delete = async function () {
        const result = await UI.ShowModalAsync("Confirm task deletion", {
            text: "Are you sure you wish to delete this task? This action cannot be undone.",
            subtitle: this.Description()
        }, UI.Icons.Exclamation, [
            new UI.ModalAction("Remove Task", true, "bgRed"),
            new UI.ModalAction("Cancel", false)]);

        if (result) {
            await API.Core.DeleteTaskAsync(self.TriggerId, self.Id);
            refreshSchedule();
        }
    };
    this.MoveUp = function () {
        API.Core.ChangeTaskOrder(self.TriggerId, self.Id, self.Order() - 15);
    };
    this.MoveDown = function () {
        API.Core.ChangeTaskOrder(self.TriggerId, self.Id, self.Order() + 15);
    };
    this.DismissWarning = function () {
        API.Core.ChangeTaskOrder(self.TriggerId, self.Id, self.Order());
    };
    this.Edit = function () {
        viewModels.schedule.editing(true);
        viewModels.schedule.selectedTrigger(self.TriggerVM);
        viewModels.schedule.editingTask(self);
        UI.ShowWizard("#tab_schedule_newTask");
    };
}

function ScheduleParameterMappingVM(Param, Value, Description, ValueType, InputType, EnumValues) {
    const self = this;
    this.Param = ko.observable(Param);
    this.DisplayName = ko.observable(Param.deCamelCase());
    this.Description = ko.observable(Description);
    this.Value = ko.observable(InputType === "checkbox" ? Value === undefined ? false : Value?.toString().toLowerCase() === "true" : Value);
    this.ValueType = ValueType;
    this.InputType = InputType;
    this.enumValues = ko.observableArray(); //of SettingOptionVM
    this.enumDisplayValues = EnumValues;
    this.displayValue = ko.computed(() => self.InputType == "Enum" && self.enumDisplayValues != null ? self.enumDisplayValues[self.Value()]?.deCamelCase() ?? self.Value() : self.Value());

    if (InputType == "Enum") {
        for (const enumValue of Object.keys(EnumValues)) {
            self.enumValues.push(new SettingOptionVM(EnumValues[enumValue].deCamelCase(), enumValue));
        }
    }
}

function ScheduleDataCallback(result) {
    eventTriggers = result.AvailableTriggers;
    popTriggers = result.PopulatedTriggers;
    popTriggerIds = {};
    methods = result.AvailableMethods;
    const vm = viewModels.schedule;

    if (result?.AvailableTriggers == null) { return; }

    vm.availableTriggers.removeAll();
    vm.availableMethods.removeAll();
    vm.populatedTriggers.removeAll();

    ko.utils.arrayPushAll(vm.availableTriggers, result.AvailableTriggers.map(t =>
        new ScheduleTriggerVM(t.Id, t.Description, null, t.EnabledState, t.Emits.map(e =>
            new ScheduleTriggerVariableVM(e)))
    ));

    result.AvailableMethods.sort((a, b) => { a.Category = a.hasOwnProperty("Category") ? a.Category : ""; b.Category = b.hasOwnProperty("Category") ? b.Category : ""; return a.Category.localeCompare(b.Category) || a.Description.localeCompare(b.Description); });

    ko.utils.arrayPushAll(vm.availableMethods, result.AvailableMethods.map(m =>
        new ScheduleTaskVM(m.Id, m.Name, m.hasOwnProperty("Category") ? m.Category + " - " + m.Description : m.Description, m.DisplayFormat, m.Consumes.map(c =>
            new ScheduleParameterMappingVM(c.Name, "", c.Description, c.ValueType, c.InputType, c.EnumValues)))
    ));


    popTriggerIds = result.PopulatedTriggers.reduce((acc, trig) => {
        acc[trig.Id] = trig;
        return acc;
    }, {});

    methodIds = result.AvailableMethods.reduce((acc, method) => {
        acc[method.Id] = method;
        return acc;
    }, {});

    let attention = false;

    for (const trigger of result.PopulatedTriggers) {
        const triggerVM = new ScheduleTriggerVM(trigger.Id, trigger.Description, trigger.TriggerType, trigger.EnabledState);

        ko.utils.arrayPushAll(triggerVM.Emits, trigger.Emits.map(m => new ScheduleTriggerVariableVM(m)));

        for (const task of trigger.Tasks) {
            const taskInfo = methodIds[task.TaskMethodName];

            if (taskInfo == null) { continue; }

            const displayName = taskInfo.hasOwnProperty("Category") ? taskInfo.Category + " - " + taskInfo.Description : taskInfo.Description;
            let taskVM = new ScheduleTriggerTaskVM(task.Id, trigger.Id, displayName, task.Order, task.EnabledState, task.LastExecuteError, task.LastErrorReason, triggerVM);
            attention |= task.LastExecuteError;

            const originalParamsDef = methodIds[task.TaskMethodName].Consumes;
            const format = methodIds[task.TaskMethodName].DisplayFormat;
            let mappedValues = {};

            for (const paramDef of originalParamsDef) {
                const key = paramDef.Name;
                const value = task.ParameterMapping[key];

                let mvm = new ScheduleParameterMappingVM(key, value, paramDef.Description, paramDef.ValueType, paramDef.InputType, paramDef.EnumValues);
                taskVM.ParameterMappings.push(mvm);
                mappedValues[key] = mvm.displayValue();
            }

            if (format != "" && format != null) {
                taskVM.FormattedDisplay(format.format(mappedValues));
            }

            triggerVM.Tasks.push(taskVM);
        }

        vm.populatedTriggers.push(triggerVM);
        const scheduleTab = UI.GetSideMenuItem("tab_schedule");
        scheduleTab.subtitle(attention ? "Attention Required" : "");
        scheduleTab.extraClass(attention ? "hasWarning" : "");
    }
}

async function refreshSchedule() {
    const result = await API.Core.GetScheduleDataAsync();
    ScheduleDataCallback(result);
}

const commonPasswords = new Set(["redstonehost", "123456", "password", "12345678", "1234", "pussy", "12345", "dragon", "qwerty", "696969", "mustang", "letmein", "baseball", "master", "michael", "football", "shadow", "monkey", "abc123", "pass", "fuckme", "6969", "jordan", "harley", "ranger", "iwantu", "jennifer", "hunter", "fuck", "2000", "test", "batman", "trustno1", "thomas", "tigger", "robert", "access", "love", "buster", "1234567", "soccer", "hockey", "killer", "george", "sexy", "andrew", "charlie", "superman", "asshole", "fuckyou", "dallas", "jessica", "panties", "pepper", "1111", "austin", "william", "daniel", "golfer", "summer", "heather", "hammer", "yankees", "joshua", "maggie", "biteme", "enter", "ashley", "thunder", "cowboy", "silver", "richard", "fucker", "orange", "merlin", "michelle", "corvette", "bigdog", "cheese", "matthew", "121212", "patrick", "martin", "freedom", "ginger", "blowjob", "nicole", "sparky", "yellow", "camaro", "secret", "dick", "falcon", "taylor", "111111", "131313", "123123", "bitch", "hello", "scooter", "please", "porsche", "guitar", "chelsea", "black", "diamond", "nascar", "jackson", "cameron", "654321", "computer", "amanda", "wizard", "xxxxxxxx", "money", "phoenix", "mickey", "bailey", "knight", "iceman", "tigers", "purple", "andrea", "horny", "dakota", "aaaaaa", "player", "sunshine", "morgan", "starwars", "boomer", "cowboys", "edward", "charles", "girls", "booboo", "coffee", "xxxxxx", "bulldog", "ncc1701", "rabbit", "peanut", "john", "johnny", "gandalf", "spanky", "winter", "brandy", "compaq", "carlos", "tennis", "james", "mike", "brandon", "fender", "anthony", "blowme", "ferrari", "cookie", "chicken", "maverick", "chicago", "joseph", "diablo", "sexsex", "hardcore", "666666", "willie", "welcome", "chris", "panther", "yamaha", "justin", "banana", "driver", "marine", "angels", "fishing", "david", "maddog", "hooters", "wilson", "butthead", "dennis", "fucking", "captain", "bigdick", "chester", "smokey", "xavier", "steven", "viking", "snoopy", "blue", "eagles", "winner", "samantha", "house", "miller", "flower", "jack", "firebird", "butter", "united", "turtle", "steelers", "tiffany", "zxcvbn", "tomcat", "golf", "bond007", "bear", "tiger", "doctor", "gateway", "gators", "angel", "junior", "thx1138", "porno", "badboy", "debbie", "spider", "melissa", "booger", "1212", "flyers", "fish", "porn", "matrix", "teens", "scooby", "jason", "walter", "cumshot", "boston", "braves", "yankee", "lover", "barney", "victor", "tucker", "princess", "mercedes", "5150", "doggie", "zzzzzz", "gunner", "horney", "bubba", "2112", "fred", "johnson", "xxxxx", "tits", "member", "boobs", "donald", "bigdaddy", "bronco", "penis", "voyager", "rangers", "birdie", "trouble", "white", "topgun", "bigtits", "bitches", "green", "super", "qazwsx", "magic", "lakers", "rachel", "slayer", "scott", "2222", "asdf", "video", "london", "7777", "marlboro", "srinivas", "internet", "action", "carter", "jasper", "monster", "teresa", "jeremy", "11111111", "bill", "crystal", "peter", "pussies", "cock", "beer", "rocket", "theman", "oliver", "prince", "beach", "amateur", "7777777", "muffin", "redsox", "star", "testing", "shannon", "murphy", "frank", "hannah", "dave", "eagle1", "11111", "mother", "nathan", "raiders", "steve", "forever", "angela", "viper", "ou812", "jake", "lovers", "suckit", "gregory", "buddy", "whatever", "young", "nicholas", "lucky", "helpme", "jackie", "monica", "midnight", "college", "baby", "cunt", "brian", "mark", "startrek", "sierra", "leather", "232323", "4444", "beavis", "bigcock", "happy", "sophie", "ladies", "naughty", "giants", "booty", "blonde", "fucked", "golden", "0", "fire", "sandra", "pookie", "packers", "einstein", "dolphins", "0", "chevy", "winston", "warrior", "sammy", "slut", "8675309", "zxcvbnm", "nipples", "power", "victoria", "asdfgh", "vagina", "toyota", "travis", "hotdog", "paris", "rock", "xxxx", "extreme", "redskins", "erotic", "dirty", "ford", "freddy", "arsenal", "access14", "wolf", "nipple", "iloveyou", "alex", "florida", "eric", "legend", "movie", "success", "rosebud", "jaguar", "great", "cool", "cooper", "1313", "scorpio", "mountain", "madison", "987654", "brazil", "lauren", "japan", "naked", "squirt", "stars", "apple", "alexis", "aaaa", "bonnie", "peaches", "jasmine", "kevin", "matt", "qwertyui", "danielle", "beaver", "4321", "4128", "runner", "swimming", "dolphin", "gordon", "casper", "stupid", "shit", "saturn", "gemini", "apples", "august", "3333", "canada", "blazer", "cumming", "hunting", "kitty", "rainbow", "112233", "arthur", "cream", "calvin", "shaved", "surfer", "samson", "kelly", "paul", "mine", "king", "racing", "5555", "eagle", "hentai", "newyork", "little", "redwings", "smith", "sticky", "cocacola", "animal", "broncos", "private", "skippy", "marvin", "blondes", "enjoy", "girl", "apollo", "parker", "qwert", "time", "sydney", "women", "voodoo", "magnum", "juice", "abgrtyu", "777777", "dreams", "maxwell", "music", "rush2112", "russia", "scorpion", "rebecca", "tester", "mistress", "phantom", "billy", "6666", "albert", "foobar"]);

// Matches getPasswordGrade() in Shared.cs/CryptoHelpers
function getPasswordGrade(password) {
    if (password == null || password.length == 0) { return 0; }

    if (commonPasswords.has(password.toLowerCase())) {
        return 0;
    }

    let grade = 0;

    grade += (password.match(/[A-Z]/)) ? 1 : 0;
    grade += (password.match(/[a-z]/)) ? 1 : 0;
    grade += (password.match(/\d/)) ? 1 : 0;
    grade += (password.match(/[^a-zA-Z\d]/)) ? 1 : 0;
    grade += (password.length < 8) ? -1 : 1;
    grade += (password.length > 10) ? 1 : 0;
    grade += (password.length > 14) ? 1 : 0;

    return grade;
}

function getGradeAsColorClass(grade) {
    if (grade > 5) { return "bgGreen"; }
    if (grade > 3) { return "bgAmber"; }
    return "bgRed";
}

function gradePassword() {
    const pw = $("#changepw_newpwd").val();
    const grade = getPasswordGrade(pw);
    const color = getGradeAsColorClass(grade);
    const width = (28 * grade).toString() + "px";
    $("#passwordGrade").attr("class", color).css("width", width);
    $("#changePasswordBtn").attr("enabled", (grade > 3));
}

async function changePassword() {
    const info = getForm("#changePasswordForm");

    if (info.oldpassword == info.newpassword) {
        await UI.ShowModalAsync("Passwords are the same.", "Your old and new passwords must be different.", UI.Icons.Exclamation, UI.OKActionOnly);
        await UI.ShowWizard("#tab_changepassword");
        return;
    }

    if (info.newpassword != info.confirmpassword) {
        await UI.ShowModalAsync("Passwords don't match.", "Your passwords must match.", UI.Icons.Exclamation, UI.OKActionOnly);
        await UI.ShowWizard("#tab_changepassword");
        return;
    }

    const changePasswordResult = await API.Core.ChangeUserPasswordAsync(info.username, info.oldpassword, info.newpassword, info.changepw2fa);

    if (changePasswordResult.Status) {
        await UI.ShowModalAsync("Password Changed", "Your password has been changed. You will now be logged off.", UI.Icons.Info, UI.OKActionOnly);
        doLogout();
    }
    else {
        await UI.ShowModalAsync("Password Change Failed", changePasswordResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        await UI.ShowWizard("#tab_changepassword");
    }
}

function evaluatePermission(node, permissionList) {
    let result = null;
    if (node == null || node === "") { return true; }
    if (permissionList.length === 0) { return null; }
    let highestSpec = 0;

    for (const perm of permissionList) {
        let effectivePerm = perm;
        let specificity = perm.split(".").length;

        let isNegative = false;

        if (perm.startsWith("-")) {
            effectivePerm = perm.substring(1);
            isNegative = true;
        }

        if (effectivePerm.endsWith(".*")) //Reduce the specicifity of broad permissions by 1 so a more specific node is allowed.
        {
            specificity--;
        }

        const pattern = WildcardToRegex(effectivePerm);
        if (pattern.test(node)) {
            //A permission that is more specific takes priority over one that is less specific.
            //Where two opposing permissions are equally specific, the negative permission takes precedence.
            //So a positive permission must be greater, a negative only need be equal or greater to the
            //most specific permission so far observed.

            if (isNegative && specificity >= highestSpec) {
                highestSpec = specificity;
                result = false;
            }
            else if (specificity > highestSpec) {
                highestSpec = specificity;
                result = true;
            }
        }
    }

    return result;
}

function PermissionManagementVM() {
    const self = this;
    this.currentRole = ko.observable(null);
    this.overrideRole = ko.observable(null);
    this.roles = ko.observableArray(); //of PermissionRoleVM
    this.permissions = ko.observableArray(); //of PermissionsNodeVM
    this.firstRefresh = true;
    this.canCreateTemplates = ko.observable(false);
    this._isLoaded = false;
    this.editingRole = ko.computed(() => this.overrideRole() != null ? this.overrideRole() : this.currentRole());

    this.filter = ko.observable("");

    this.filter.subscribe((newValue) => {
        if (newValue.length > 3) {
            self.setAllExpanded(true);
        }
        else if (newValue.length == 0) {
            self.setAllExpanded(false);
        }
    });

    this.setAllExpanded = function (expanded) {
        for (const child of self.permissions()) {
            child.setAllExpanded(expanded);
        }
    };

    this.hasPermission = function (node) {
        const editingRole = self.editingRole();

        if (editingRole == null) { return null; }

        const perms = editingRole.Permissions();
        return evaluatePermission(node, perms);
    };

    this.refresh = async function () {
        await this.refreshSpec();
        await this.refreshRoles();
        self._isLoaded = true;
    };

    this.load = async function () {
        if (self._isLoaded) {
            return;
        }
        await self.refresh();
        self.canCreateTemplates(PluginHandler.HasFeature("SharedRoles") && userHasPermission("Core.RoleManagement.CreateCommonRoles"));
    };

    this.refreshSpec = async function () {
        const MgrVM = self;
        const result = await API.Core.GetPermissionsSpecAsync();

        self.permissions.removeAll();
        if (result == null || result.length == 0) { return; }

        ko.utils.arrayPushAll(self.permissions, result.map(child => new PermissionsNodeVM(child.Node, child.Name, child.DisplayName, child.Description, child.Children, null, MgrVM)));
    };

    this.refreshRoles = async function () {
        const MgrVM = self;
        const result = await API.Core.GetRoleDataAsync();

        self.roles.removeAll();
        if (result == null || !Array.isArray(result) || result.length == 0) { return; }

        ko.utils.arrayPushAll(self.roles, result.filter(r => !r.Hidden).map(roleData => new PermissionRoleVM(roleData.Name, roleData.ID, roleData.Description, roleData.Permissions, roleData.Members, roleData.IsDefault, roleData.IsInstanceSpecific, roleData.DisableEdits, roleData.IsCommonRole, MgrVM)));

        if (self.firstRefresh && self.roles().length > 0) {
            self.currentRole(self.roles()[0]);
            self.overrideRole(null);
            self.firstRefresh = false;
        }
    };

    this.createRole = async function () {
        const newName = await UI.PromptAsync("Create new role", "Enter your name for your new role");
        if (newName == null) { return; }

        await API.Core.CreateRoleAsync(newName);
        self.refresh();
    };

    this.createTemplateRole = async function () {
        const newName = await UI.PromptAsync("Create new template role", "Enter your name for your new template role. Permissions in this role will be common across all instances.");
        if (newName == null) { return; }

        const result = await API.Core.CreateRoleAsync(newName, true);
        if (result.Status) {
            self.refresh();
        }
        else {
            UI.ShowModalAsync("Unable to create role", result.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
        }

    };
}

function PermissionUserVM(ID, Name) {
    this.ID = ID;
    this.Name = Name;
}

function PermissionRoleVM(Name, ID, Description, Permissions, Members, IsDefault, IsInstanceSpecific, DisableEdits, IsCommonRole, MgrVM) {
    const self = this;
    this.Name = Name;
    this.Id = ID;
    this.IsDefault = IsDefault;
    this.IsInstanceSpecific = IsInstanceSpecific;
    this.DisableEdits = DisableEdits;
    this.IsCommonRole = IsCommonRole;
    this.IsHidden = ko.observable();
    this.Description = Description;
    this.Permissions = ko.observableArray(Permissions);
    this.Members = ko.observableArray(); //of PermissionUserVM
    this._mgr = MgrVM;
    this.selected = ko.observable(false);
    this.DisplayRoleType = ko.pureComputed(() => {
        if (self.IsInstanceSpecific) { return "Instance Specific Role"; }
        else if (self.ReadOnly) { return "Read Only Role"; }
        else if (!self.IsInstanceSpecific && !self.IsCommonRole) { return "Global Role"; }
        else if (self.IsCommonRole) { return "Template Role"; }
        else if (self.IsDefault) { return "Default Role"; }
        else { return "Role"; }
    });
    this.Icon = ko.pureComputed(() => {
        if (!self.IsInstanceSpecific && !self.IsCommonRole) { return "public"; }
        else if (self.IsCommonRole) { return "app_registration"; }
        else { return "groups"; }
    });
    this.Click = function () {
        const current = self._mgr.currentRole();
        if (current != null) { current.selected(false); }
        self._mgr.overrideRole(null);
        self._mgr.currentRole(self);
        self.selected(true);
    };
    this.OverrideShow = function () {
        self._mgr.overrideRole(self);
    };
    this.deleteRole = async function () {
        const promptResult = await UI.ShowModalAsync(
            "Confirm User Deletion",
            { text: "Are you sure you wish to delete this role? This operation cannot be undone.", subtitle: self.Name },
            UI.Icons.Exclamation,
            [
                new UI.ModalAction("Delete Role", true, "bgRed"),
                new UI.ModalAction("Do not delete", false)
            ]
        );

        if (promptResult !== true) { return; }

        const deleteRoleResult = await API.Core.DeleteRoleAsync(self.Id);

        if (deleteRoleResult.Status) {
            await self._mgr.refreshRoles();
            const first = self._mgr.roles().first();
            self._mgr.currentRole(first);
        }
        else {
            UI.ShowModalAsync("Role deletion failed", "This role cannot be deleted at this time. " + deleteRoleResult.Reason, UI.Icons.Info, UI.OKActionOnly);
        }
    };
}

function PermissionsNodeVM(Node, Name, DisplayName, Desc, Children, Parent, MgrVM) {
    const self = this;
    this._mgr = MgrVM;
    this.Node = Node;
    this.Name = Name;
    this.DisplayName = DisplayName;
    this.Description = Desc || "";
    this.Parent = Parent;
    this.HasPermission = ko.computed(() => self._mgr.hasPermission(self.Node));
    this.Children = ko.observableArray();
    this.Expanded = ko.observable(false);
    this.Toggle = function () {
        this.Expanded(!this.Expanded());
    };
    this.setAllExpanded = function (expanded) {
        self.Expanded(expanded);
        for (const child of self.Children()) {
            child.setAllExpanded(expanded);
        }
    };
    this.Height = ko.computed(() => self.Expanded() ? self.Children().reduce((sum, child) => sum + child.Height(), 48) : 48);
    this.FilterVisible = ko.computed(() => {
        const filter = self._mgr.filter();
        if (!filter || filter.length === 0) return true;
        if (self.Name.toLowerCase().includes(filter.toLowerCase()) ||
            self.DisplayName.toLowerCase().includes(filter.toLowerCase()) ||
            self.Description.toLowerCase().includes(filter.toLowerCase()) ||
            self.Node.toLowerCase().includes(filter.toLowerCase())) { return true; }

        for (const child of self.Children()) {
            if (child.FilterVisible()) {
                return true;
            }
        }
        return false;
    });

    if (Children != null && Children.length > 0) {
        ko.utils.arrayPushAll(self.Children, Children.map(child => new PermissionsNodeVM(child.Node, child.Name, child.DisplayName, child.Description, child.Children, self, MgrVM)));
        this.Node = this.Node != "" ? this.Node + ".*" : this.Node;
    }

    this.NodeSegments = self.Node.split(/(?<=\.)/);

    this.CanExpand = (Children != null && Children.length > 0);

    this.Click = async function () {
        let newValue = null;
        const existingValue = self.HasPermission();

        const cycleValue = (self.Parent?.HasPermission() == null) ? null : false;

        switch (existingValue) {
            case true: newValue = cycleValue; break;
            case false: newValue = true; break;
            case null: newValue = false; break;
        }

        const isSensitive = ["Core.*", "Core.UserManagement.*", "Core.RoleManagement.*"].contains(self.Node);
        if (newValue && isSensitive) {
            const warnResult = await UI.ShowModalAsync("Sensitive Permission Warning", "Turning on this parent permission will enable other child permissions that are security sensitive, and could allow a user to change their own permissions or the permissions of other users. Review the child permissions carefully before continuing.", UI.Icons.Exclamation, [
                new UI.ModalAction("Continue", true, "bgRed"),
                new UI.ModalAction("Cancel", false)
            ]);
            if (!warnResult) {
                return;
            }
        }

        const roleId = self._mgr.editingRole().Id;
        const updateResult = await API.Core.SetAMPRolePermissionAsync(roleId, self.Node, newValue);
        if (!updateResult.Status) {
            UI.ShowModalAsync("Unable to update permission", updateResult.Reason, UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }
        const newPermissions = await API.Core.GetAMPRolePermissionsAsync(roleId);
        const perms = self._mgr.editingRole().Permissions;
        perms.removeAll();
        ko.utils.arrayPushAll(perms, newPermissions);
    };
}

function KeyValuePairVM(key, value) {
    this.key = key;
    this.value = value;
}

function TicketCategoryVM(id, title, caption, articleLink, articleTitle) {
    const self = this;
    this.title = title;
    this.caption = caption;
    this.articleLink = articleLink;
    this.articleTitle = articleTitle;
    this.isOther = false;
    this.category = "tech-support";
    this.tags = "";
    this.special = "";
    this.id = id;

    this.asOther = function () {
        self.isOther = true;
        return this;
    };

    this.asCategory = function (category) {
        this.category = category;
        return this;
    };

    this.asSpecial = function (special) {
        this.special = special;
        return this;
    }
}

function countOccurrences(input, pair) {
    let count = 0;
    let index = 0;

    while ((index = input.indexOf(pair, index)) !== -1) {
        count++;
        index++;
    }

    return count;
}

function NewTicketVM(parent) {
    const self = this;
    this.availableCategories = ko.observableArray([
        new TicketCategoryVM(10, "Startup Issue", "Difficulties starting the application (crashes, stalls)"),
        new TicketCategoryVM(20, "Update Failure", "Failures to update or install the application for the first time").asCategory("tech-support/installation"),
        new TicketCategoryVM(30, "Connectivity Problem", "Difficulties connecting to the running application", "https://discourse.cubecoders.com/docs?topic=2290", "Diagnosing Connectivity Issues"),
        new TicketCategoryVM(40, "Configuration", "For issues surrounding configuring the server to behave in a particular way").asCategory("questions"),
        new TicketCategoryVM(50, "Customization", "Queries about modding, custom content or other modifications to the server").asCategory("questions"),
        new TicketCategoryVM(60, "Other", "Something else that doesn't fit into any other category").asOther(),
    ]);
    this.connectivityCategories = ko.observableArray([
        new TicketCategoryVM(10, "How to connect", "I'm unsure how connect my application to the server"),
        new TicketCategoryVM(20, "Where to connect", "I don't know what address I'm supposed to connect to"),
        new TicketCategoryVM(30, "Port Forwarding", "I'm not sure what ports need forwarding or how to configure port forwarding"),
        new TicketCategoryVM(40, "Connection Failure", "Everything appears to be set up correctly but I'm unable to connect to the application"),
        new TicketCategoryVM(50, "Something Else", "Some other issue connecting to the application")
    ]);
    this.selectedCategory = ko.observable(null);
    this.selectedSubcategory = ko.observable(null);
    this.shortDescription = ko.observable("");
    this.tryingToDo = ko.observable("");
    this.steps = ko.observableArray();
    this.longProblemDescription = ko.observable("");
    this.includeConsoleOutput = ko.observable(false);
    this.showADSwarning = ko.pureComputed(() => parent.module() == "ADSModule");
    this.stepsFormatted = function () {
        let result = "";
        for (const step of self.steps()) {
            result += " * " + step + "\n";
        }
        return result;
    };

    this.getLastNConsoleEntries = function (n) {
        const entries = $('.consoleContents').slice(-n); // Select the last N .consoleEntry elements
        const result = [];

        entries.each(function () {
            const name = $(this).parent().find('.consoleName:first').text(); // Find the first .consoleName in the parent
            const entry = $(this).text(); // Get the text of the .consoleEntry
            result.push({ name, entry }); // Push the object to the result array
        });

        return result;
    };

    this.isLikelyValidText = function (input) {

        if (!input || input.length < 10) {
            return false;
        }

        let spaceCount = input.split(' ').length - 1;
        if (spaceCount * 15 < input.length) {
            return false;
        }

        let upperInput = input.toLowerCase();
        let pairs = ["in", "er", "es", "ng", "ti", "re", "te", "ed", "on", "at", "st", "an", "en", "le", "ri", "ra", "al", "li", "ar", "is"];
        let pairCount = pairs.reduce((count, pair) => count + countOccurrences(upperInput, pair), 0);

        return (pairCount * 20) >= input.length;
    };

    this.addStep = async function () {
        const newStep = await UI.PromptAsync("Add Step", "Enter the next step in the process");
        if (newStep == null || newStep.trim() == "") { return; }
        if (!self.isLikelyValidText(newStep)) {
            await UI.ShowModalAsync("Invalid Step", "The step you entered is too short or does not appear to be valid. Please enter a longer step or one that contains more words.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }
        //Make sure there's no duplicate steps or that start with the exact same 5 characters (silently skip)
        if (self.steps().some(s => s == newStep || s.startsWith(newStep.substring(0, 5)))) {
            await UI.ShowModalAsync("Duplicate Step", "The step you entered appears to be a duplicate of an existing step. Please enter a different step.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }

        self.steps.push(newStep);
    };

    this.removeStep = function (step) {
        self.steps.remove(step);
    };

    this.clear = function () {
        self.selectedCategory(null);
        self.shortDescription("");
        self.tryingToDo("");
        self.steps([]);
        self.longProblemDescription("");
    };

    this.clearCategory = function () {
        self.selectedCategory(null);
        self.selectedSubcategory(null);
    };

    this.close = function () {
        self.clear();
        UI.HideWizard("#tab_diagnostics_newTicket");
    };

    this.allStepsAreTheSame = ko.computed(() => self.steps().length > 0 && self.steps().every(s => s == self.steps()[0]));
    this.isValid = ko.computed(() => self.selectedCategory() != null && self.shortDescription().match(/^(\s*\S+\s*){4,10}$/) != null && (!self.selectedCategory().isOther || self.tryingToDo().length > 0) && self.steps().length > 2 && self.longProblemDescription().length > 0);

    this.createTicket = async function () {
        if (!self.isValid()) { return; }

        if (this.allStepsAreTheSame()) {
            UI.ShowModalAsync("Insufficient detail", "All of the steps you have entered are the same. Please provide more detail in the steps. You should start with creating the instance, what things you have changed, what you're expecting to happen and what actually happened.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }

        if (this.shortDescription() == this.longProblemDescription()) {
            UI.ShowModalAsync("Insufficient detail", "The short and descriptions are the same. It is important that you provide a detailed description of the problem to recieve proper assistance.", UI.Icons.Exclamation, UI.OKActionOnly);
            return;
        }

        if (this.longProblemDescription().contains("error") || this.steps().some(s => s.contains("error")) || this.tryingToDo().contains("error") || this.shortDescription().contains("error")) {
            const detailResult = await UI.ShowModalAsync("Confirm sufficient detail", "Your post mentions an error. Please ensure you have included the full error message, including any stack trace or other information that may be relevant. Include it as shown verbatim.", UI.Icons.Exclamation, [
                new UI.ModalAction("I have included the full error message", true, "bgGreen"),
                new UI.ModalAction("Go back and edit post", false, "bgRed")
            ]);
            if (!detailResult) { return; }
        }

        const vm = self;
        const category = self.selectedCategory().title;
        const data = await API.Core.GetDiagnosticsInfoAsync();
        const appName = data["Module Application"];
        const isDocker = data["Virtualization"] == "Docker" || data["Virtualization"] == "Podman";
        const tagsSuffix = data["Virtualization"] == "Docker" ? ",docker" : data["Virtualization"] == "Podman" ? ",podman" : "";
        const entries = self.getLastNConsoleEntries(20).map(e => `${e.name ? e.name + ':' : ''}${e.entry}`).join('\n');
        const log = self.includeConsoleOutput() ? `\nConsole Output\n--\n\`\`\`${entries}\`\`\`` : "";
        const taskLiteral = !self.selectedCategory().isOther ? "" : `
Task
--
${vm.tryingToDo()}
`;
        const postLiteral = `System Information
---

|Field|Value|
|-|-|
|Operating System|${data["OS"]} - ${data["Platform"]} on ${data["System Type"]}|
|Product|${data["Application Name"]} '${data["Codename"]}' v${data["Application Version"]} (${data["Release Stream"]})|
|Virtualization|${data["Virtualization"]}|
|Application|${appName}|
|Module|${data["Module"]}|
|Running in Container|${isDocker ? 'Yes' : 'No'}|
|Current State|${parent.appStateName()}|
${taskLiteral}
Problem Description
---

Issue
--
${vm.longProblemDescription()}

Reproduction Steps
--
${vm.stepsFormatted()}
${log}
`;
        const postTitle = !self.selectedCategory().isOther ? `${category} with ${appName} - ${vm.shortDescription()}` : `${appName} - ${vm.shortDescription()}`;
        const finalURL = `https://discourse.cubecoders.com/new-topic?title=${encodeURIComponent(postTitle)}&body=${encodeURIComponent(postLiteral)}&category=tech-support&tags=ticket,${data["OS"].toLowerCase() + tagsSuffix}`
        window.open(finalURL, "_blank");
        self.close();
    };
}

function PortInfoVM() {
    const self = this;
    this.Port = ko.observable(0);
    this.Protocol = ko.observable(0);
    //ProtocolName is 0 for TCP, 1 for UDP, 2 for Both
    this.ProtocolName = ko.computed(() => {
        switch (self.Protocol()) {
            case 0: return "TCP";
            case 1: return "UDP";
            case 2: return Locale.l("Both");
        }
    });
    this.Name = ko.observable("");
    this.Listening = ko.observable(false);
    this.Range = ko.observable(1);
    this.MinListening = ko.observable(0);
    this.ListeningCount = ko.observable(0);
    this.IsRange = ko.computed(() => self.Range() > 1);
    this.PortDisplay = ko.computed(() => self.IsRange() ? (self.Port() + "-" + (self.Port() + self.Range() - 1)) : self.Port());
    this.EffectiveThreshold = ko.computed(() => {
        const range = Math.max(1, self.Range());
        return self.MinListening() > 0 ? Math.min(self.MinListening(), range) : range;
    });
    this.IsDelayedOpen = ko.observable(false);
    this.ShowDelayOpen = ko.computed(() => self.IsDelayedOpen() && viewModels.support.appState() == 20)
    this.ListeningColor = ko.computed(() => {
        if (self.ShowDelayOpen()) { return "bgAmber"; }
        if (self.IsRange()) {
            const cnt = self.ListeningCount();
            const threshold = self.EffectiveThreshold();
            if (cnt >= threshold) { return "bgGreen"; }
            if (cnt > 0) { return "bgAmber"; }
            return viewModels.support.appState() == 20 ? "bgRed" : "bgGray";
        }
        return self.Listening() ? "bgGreen" : viewModels.support.appState() == 20 ? "bgRed" : "bgGray";
    });
    this.Caption = ko.computed(() => {
        if (self.ShowDelayOpen()) { return Locale.l("Waiting"); }
        if (self.IsRange()) {
            const cnt = self.ListeningCount();
            const range = Math.max(1, self.Range());
            const threshold = self.EffectiveThreshold();
            const suffix = " (" + cnt + "/" + range + (self.MinListening() > 0 ? ", " + Locale.l("need") + " " + threshold : "") + ")";
            if (cnt >= threshold) { return Locale.l("Listening") + suffix; }
            if (cnt > 0) { return Locale.l("Partial") + suffix; }
            return Locale.l("Not Listening") + suffix;
        }
        return Locale.l(self.Listening() ? "Listening" : "Not Listening");
    });
    this.Icon = ko.computed(() => {
        if (self.ShowDelayOpen()) { return "pending"; }
        if (self.IsRange()) {
            const cnt = self.ListeningCount();
            const threshold = self.EffectiveThreshold();
            if (cnt >= threshold) { return "check_circle"; }
            if (cnt > 0) { return "pending"; }
            return "block";
        }
        return self.Listening() ? "check_circle" : "block";
    });
}

function DiagnosticsVM() {
    const self = this;

    this.branded = ko.observable(false);
    this.newTicketUrl = ko.observable("");
    this.supportUrl = ko.observable("");
    this.brandName = ko.observable("");
    this.brandLogo = ko.observable("");
    this.brandURL = ko.observable("");
    this.supportText = ko.observable("");
    this.updateNoticeAdded = false;
    this.upgradePending = ko.observable(false);
    this.upgradeReleaseNotesURL = "";
    this.upgradeVersion = ko.observable("");
    this.upgradeBuild = ko.observable("");
    this.upgradePatchOnly = ko.observable("");
    this.installedVersion = ko.observable("");
    this.installedBuild = ko.observable("");
    this.apiVersion = ko.observable(new Version());
    this.toolsVersion = ko.observable("");
    this.compatVersion = ko.computed(function () { return self.apiVersion().toString(3); });
    this.buildDate = ko.observable("");
    this.buildSpec = ko.observable("");
    this.versionCodename = ko.observable("");
    this.dataLoaded = false;
    this.module = ko.observable("");
    this.instanceId = ko.observable("");
    this.displayBaseURI = ko.observable("");
    this.basePort = ko.observable(0);
    this.isADS = ko.computed(() => self.module() == "ADSModule");
    this.newTicket = new NewTicketVM(this);
    this.primaryEndpoint = ko.observable("");
    this.primaryEndpointURL = ko.observable("");
    this.primaryPort = ko.observable(0);
    this.extraServerInfo = ko.observableArray(); //of KeyValuePairVM
    this.appState = ko.observable("0");
    this.ports = ko.observableArray(); //of PortInfoVM
    this.appName = ko.observable("");
    this.oidcEnabled = ko.observable(false);
    this.updatePorts = function (portInfo) {
        //For each Port in portInfo Check if ports() contains a PortInfoVM with the same name, if so, update it, otherwise add it
        //then remove any PortInfoVMs in ports() that are not in portInfo
        if (portInfo == null) { return; }
        let newPorts = [];
        portInfo = portInfo.slice().sort((a, b) => a.Port - b.Port);
        for (let port of portInfo) {
            let existing = self.ports().find(x => x.Port() == port.Port);
            if (existing != null) {
                existing.Name(port.Name);
                existing.Protocol(port.Protocol);
                existing.Listening(port.Listening);
                existing.Range(port.Range || 1);
                existing.MinListening(port.MinListening || 0);
                existing.ListeningCount(port.ListeningCount || 0);
                newPorts.push(existing);
            } else {
                let portVMs = ko.quickmap.to(PortInfoVM, port);
                newPorts.push(portVMs);
            }
        }
        self.ports(newPorts);
    }

    const applicationState = {
        '-1': 'Undefined',
        '0': 'Stopped',
        '5': 'PreStart',
        '7': 'Configuring',
        '10': 'Starting',
        '20': 'Ready',
        '30': 'Restarting',
        '40': 'Stopping',
        '45': 'PreparingForSleep',
        '50': 'Sleeping',
        '60': 'Waiting',
        '70': 'Installing',
        '75': 'Updating',
        '80': 'AwaitingUserInput',
        '100': 'Failed',
        '200': 'Suspended',
        '250': 'Maintenance',
        '999': 'Indeterminate',
    };

    this.appStateName = ko.computed(() => Locale.l(applicationState[self.appState().toString()]));

    this.showNewTicket = function () {
        self.newTicket.clear();
        plausible("StartOpenTicket")
        UI.ShowWizard("#tab_diagnostics_newTicket");
    };

    this.getDisplayHost = function () {
        if (self.displayBaseURI() != "" && self.displayBaseURI() != null) {
            try {
                const uri = new URL(self.displayBaseURI());
                return uri.host;
            }
            catch {
                //Do nothing, fall through to below.
            }
        };
        const useHost = remoteLogin.isRemote && remoteLogin.targetURL.hostname != "localhost" ? remoteLogin.targetURL.hostname : document.location.hostname;
        return useHost;
    };

    this.getDisplayURL = function (protocol, port) {
        const base = self.displayBaseURI();
        if (base == null || base == "") { return ""; }
        if (port == null || port == "") { return base; }
        try {
            let uri = new URL(base);
            uri.protocol = protocol;
            uri.port = port;
            return uri.toString();
        }
        catch {
            return "";
        }
    };

    this.versionTitle = ko.computed(function () {
        return `v${self.installedVersion()}, built ${self.buildDate()}`;
    });

    this.createTicket = function () {
        if (self.newTicketUrl() != "" && !self.newTicketUrl().contains("example.com")) {
            window.open(self.newTicketUrl(), "_blank");
            return;
        }

        self.showNewTicket();
    };

    this.updateFrom = function (info) {
        self.installedVersion(info.AMPVersion);
        self.installedBuild(info.AMPBuild);
        self.apiVersion(Version.parse(info.APIVersion || info.AMPVersion));
        self.buildDate(info.Timestamp);
        self.buildSpec(info.BuildSpec);
        self.versionCodename(info.VersionCodename || "Development");
        self.branded(info.Branding.DisplayBranding);
        self.brandLogo(info.Branding.LogoURL);
        self.brandURL(info.Branding.URL);
        self.brandName(info.Branding.CompanyName);
        self.newTicketUrl(info.Branding.SubmitTicketURL);
        self.supportUrl(info.Branding.SupportURL);
        self.supportText(info.Branding.SupportText);
        self.module(info.ModuleName);
        self.appName(info.AppName);
        self.instanceId(info.InstanceId);
        self.displayBaseURI(info.DisplayBaseURI);
        self.toolsVersion(info.ToolsVersion);
        self.basePort(info.BasePort);
        self.oidcEnabled(info.IsOIDCEnabled);
        if (viewModels.ampUserList) { viewModels.ampUserList.oidcEnabled(info.IsOIDCEnabled); }
        self.primaryEndpoint(info.PrimaryEndpoint.replace(/localhost|127\.0\.0\.1|0\.0\.0\.0|::|\[::\]/, viewModels.support.getDisplayHost()));
        self.primaryEndpointURL(info.EndpointURI.replace(/localhost|127\.0\.0\.1|0\.0\.0\.0|::|\[::\]/, viewModels.support.getDisplayHost()));
    };

    this.diaginfo = ko.observableArray(); //of KeyValuePairVM
    this.diagdata = {};
    this.reportsUrl = ko.observable(); //string
    this.restartAvailable = ko.observable(false);
    this.upgradeAvailable = ko.observable(false);
    this.copyToClipboard = async function () {

        const data = await API.Core.GetDiagnosticsInfoAsync();
        const appName = data["Module Application"];
        const isContainer = data["Virtualization"] == "Docker" || data["Virtualization"] == "Podman";
        const obj = {
            "Operating System": `${data["OS"]} - ${data["Platform"]} on ${data["System Type"]}`,
            "Product": `${data["Application Name"]} '${data["Codename"]}' v${data["Application Version"]} (${data["Release Stream"]})`,
            "Virtualization": data["Virtualization"],
            "Application": appName,
            "Module": data["Module"],
            "Running in Container": isContainer ? `Yes: ${data["Virtualization"]}` : 'No',
            "Current State": self.appStateName()
        };
        if ('clipboard' in navigator) {
            navigator.clipboard.writeText("```\n" + createTable(obj) + "```\n");
        }
    };
    this.copyPrimaryEndpointToClipboard = function () {
        navigator.clipboard.writeText(self.primaryEndpoint());
    };
    this.canCopyToClipboard = ('clipboard' in navigator);

    this.showReports = function () { window.open(self.reportsUrl(), "_blank"); };
    this.showDiscord = function () { window.open("https://discord.gg/cubecoders", "_blank"); };
    this.showSupportBoard = function () { window.open("https://support.cubecoders.com?utm_source=ampsupporttab", "_blank"); };

    this.restartAMP = async function () {
        const result = await UI.ShowModalAsync("Confirm Restart", `Restarting this instance may take up to a minute. ${self.isADS() ? "You will not be able to log into any instances that depend on this ADS instance." : "The game server running within this instance will be shut down."}`, UI.Icons.Exclamation,
            [
                new UI.ModalAction("Keep Running", false, "bgGreen"),
                new UI.ModalAction("Restart Now", true, "bgRed")
            ]);
        if (!result) { return; }
        API.Core.GetUpdates.clearInterval();
        API.Core.RestartAMP();

        if (remoteLogin.isRemote) {
            remoteLogin.closeRemote();
        }
        else {
            plausible("RestartAMP");
            $("#modalLoader").show();
            localStorage.restartState = "restart";
            UI.ShowModalAsync("Restarting", "AMP is now restarting...", UI.Icons.Exclamation, []);
            setTimeout(clearCacheAndReload, 7500);
            delete (localStorage.LastAMPVersion);
        }
    };
    this.upgradeAMP = async function () {
        if (!self.dataLoaded) {
            await self.refresh();
        }

        if (!self.upgradeAvailable()) {
            UI.ShowModalAsync("Automatic update unavailable", "AMP is unable to update itself in its current configuration. Please manually update AMP to the latest version.", UI.Icons.Exclamation, UI.OKActionOnly, "Support article: Upgrading AMP", "https://wiki.cubecoders.com/How-to-update-AMP-to-the-latest-version");
            return;
        }

        const message = (self.isADS() ?
            "This will update AMP's Application Deployment Service (ADS). Your game servers will keep running, but you will not be able to manage any instances until the upgrade is complete." :
            "This will update AMP. The game server running within this instance will be shut down during the upgrade process if it is running.")
            + "\n\nPlease allow up to 5 minutes for the update to complete. This instance will restart automatically once the update has completed.";

        const result = await UI.ShowModalAsync("Confirm Upgrade", message, UI.Icons.Exclamation,
            [
                new UI.ModalAction("Keep Running", false, "bgGreen"),
                new UI.ModalAction("Shut Down and Upgrade", true, "bgRed")
            ]);
        if (!result) { return; }
        API.Core.GetUpdates.clearInterval();
        API.Core.UpgradeAMP();

        if (remoteLogin.isRemote) {
            remoteLogin.closeRemote();
        }
        else {
            plausible("UpgradeAMP");
            $("#modalLoader").show();
            localStorage.restartState = "upgrade";
            UI.ShowModalAsync("Upgrading", "AMP is now upgrading to the latest version...", UI.Icons.Exclamation, []);
            setTimeout(clearCacheAndReload, 7500);
            delete (localStorage.LastAMPVersion);
        }
    };

    this.refresh = async function () {
        const data = await API.Core.GetDiagnosticsInfoAsync();
        self.reportsUrl("https://appreport.cubecoders.com/AppReportEntries/ByInstance/" + data["InstanceID"]);
        self.restartAvailable(userHasPermission("Core.Special.RestartAMP"));
        self.upgradeAvailable(userHasPermission("Core.Special.UpgradeAMP"));
        self.diaginfo.removeAll();
        self.diagdata = data;
        for (let key of Object.keys(data)) {
            const kvp = new KeyValuePairVM(key, data[key]);
            self.diaginfo.push(kvp);
        }

        if (!self.dataLoaded) {
            //this was the first time
            const OSCheck = data.Platform.match(/^(Red Hat|Windows Server|\w+)(?:\sLinux|\sServer|\sStream)?[\s\w()]*?([\d.]+)/);
            if (OSCheck) {
                const distro = OSCheck[1];
                const version = Version.parse(OSCheck[2]);

                const minimumVersions = {
                    "Ubuntu": "20.04",
                    "Debian": "10",
                    "CentOS": "8",
                    "Rocky": "8",
                    "Red Hat": "8",
                    "Windows Server": "2016",
                    "Windows": "10"
                };

                if (minimumVersions[distro] && version.olderThan(minimumVersions[distro])) {
                    UI.ShowModalAsync("Support for your OS is ending", `You are currently running ${distro} ${OSCheck[2]}. Support for this platform will be ending soon to allow AMP to support newer systems. Please upgrade to ${distro} ${minimumVersions[distro]} or later as soon as possible as AMP will stop working on older systems due to a change in dependencies.`, UI.Icons.Exclamation, UI.OKActionOnly, "End-of-support announcements for Linux and Windows Versions", "https://discourse.cubecoders.com/t/end-of-support-announcements-for-linux-and-windows-versions/3620?utm_source=AMPVerNotice");
                }
            }
        }

        self.dataLoaded = true;
    };

    this.checkForUpdates = async function () {
        if (!userHasPermission("Core.Special.UpdateAMPInstance")) { return; }

        const updateInfo = await API.Core.GetUpdateInfoAsync();
        self.upgradePending(updateInfo.UpdateAvailable);
        self.upgradeVersion(updateInfo.Version);
        self.upgradeBuild(updateInfo.Build);
        self.upgradePatchOnly(updateInfo.PatchOnly);
        self.upgradeReleaseNotesURL = updateInfo.ReleaseNotesURL;
        self.toolsVersion(updateInfo.ToolsVersion);

        if (self.upgradePending() && !self.updateNoticeAdded) {
            self.updateNoticeAdded = true;
            const message = updateInfo.PatchOnly ? `Patch Available - ${updateInfo.Build}` : `Update Available - ${updateInfo.Version}`;
            const sideMenuItem = UI.GetSideMenuItem("tab_support");
            sideMenuItem.subtitle(message);
            sideMenuItem.extraClass("hasNotice info");
            sideMenuItem.image("system_update_alt");
        }

        self.refresh();
    };

    this.showReleaseNotes = function () {
        window.open(`${self.upgradeReleaseNotesURL}?utm_source=AMPUpdateNotice`);
    };
}

function SearchAreaVM() {
    const self = this;

    this.providers = [];
    this.query = ko.observable("");
    this.results = ko.observableArray(); //of SearchResultCategoryVM
    this.resultsVisible = ko.observable(false);
    this.searchWaitVisible = ko.observable(false);
    this.registerSearchProvider = function (callback) { self.providers.push(callback); };
    Features.Search = { RegisterSearchProvider: this.registerSearchProvider };

    this.timeout = null;

    this.queryChanged = function (query) {
        self.searchWaitVisible(true);
        self.resultsVisible(false);

        if (query.length < 3) { return; }

        if (self.timeout != null) {
            clearTimeout(self.timeout);
        }

        self.timeout = setTimeout(self.updateSearchResults, 250);
    };

    this.supportSearch = function () {
        window.open("https://discourse.cubecoders.com/search?q=" + encodeURI(self.query()) + "&utm_source=ampsearch&utm_term=" + encodeURI(self.query()), "_blank");
    };

    this.kbSearch = function () {
        window.open("https://discourse.cubecoders.com/docs?search=" + encodeURI(self.query()) + "&utm_source=ampsearch&utm_term=" + encodeURI(self.query()), "_blank");
    };

    this.updateSearchResults = async function () {
        self.searchWaitVisible(false);
        self.results.removeAll();
        self.resultsVisible(true);

        const query = self.query().toLocaleLowerCase();

        for (const provider of self.providers) {
            const result = await provider(query);
            if (result?.items()?.length > 0) {
                self.results.push(result);
            }
        }

        self.results.sort(function (left, right) { return right.calcAverageScore() - left.calcAverageScore() });
    };

    this.query.subscribe(self.queryChanged);
}

function SearchResultCategoryVM(name, description, icon = "") {
    const self = this;
    this.name = Locale.l(name);
    this.description = Locale.l(description);
    this.icon = icon;
    this.items = ko.observableArray(); //of SearchResultVM

    this.calcAverageScore = function () {
        if (self.items().length == 0) { return 0; }
        let total = 0;
        for (const item of self.items()) {
            total += item.confidence;
        }
        return total / self.items().length;
    };
}

function SearchResultVM(title, description, source, confidence, meta, click, imageURI) {
    const self = this;
    this.title = title;
    this.description = description;
    this.source = source;
    this.confidence = confidence;
    this.meta = meta;
    this.clickCallback = click;
    this.imageURI = imageURI;
    this.click = function () {
        const originalQuery = viewModels.search.query();
        plausible("ClickSearchResult", { props: { title: title, query: originalQuery } });
        viewModels.search.resultsVisible(false);
        viewModels.search.query("");
        if (self.clickCallback != null) { self.clickCallback(self, originalQuery); }

        if (self.openURI != null) {
            window.open(self.openURI, "_blank");
        }
    };
}

function findMatches(strings, query, limit) {
    const commonWords = new Set(['in', 'is', 'an', 'to', 'and', 'or', 'for', 'on', 'from', 'my', 'how', 'i', 'a', 'do']);

    // Filter out common words from the query
    const filteredQuery = query.toLowerCase().split(' ').filter(word => !commonWords.has(word));

    // Calculate partial matches for each string
    const matches = strings.map(string => {
        const words = string.toLowerCase().split(' ').filter(word => !commonWords.has(word));
        const numMatches = words.filter(word => filteredQuery.some(queryWord => word.includes(queryWord))).length;
        return { string, numMatches };
    });

    // Sort matches based on number of common words in descending order
    matches.sort((a, b) => b.numMatches - a.numMatches);

    // Filter matches by the given limit
    if (limit && limit < matches.length) {
        matches.splice(limit);
    }

    // Return the matched strings
    return matches.map(match => match.string);
}

function DocumentationSearchProvider(query) {
    const ArticleData = { "How do I change where AMP stores instance data?": "1821", "AArch64 \\ ARM64 Compatibility": "1870", "How to update AMP to the latest version": "2297", "About the Knowledge Base category": "1802", "Forge Frequently Asked Questions": "2982", "S3 Backup Configuration": "3241", "ARK: Survival Evolved - FAQ": "2896", "Barotrauma Guide": "3952", "ARK: Survival Evolved - Clustering": "2897", "Creativerse Guide": "3971", "American Truck Simulator / Euro Truck Simulator 2 Guide": "3790", "Arma 3 (Generic) Guide": "3475", "DayZ Server Guide": "3454", "ARK: Survival Evolved Guide": "3322", "Foundry Virtual Tabletop Guide": "3951", "3rd Party AMP plugins and bots list": "2231", "Configuring AMP for Enterprise or Network Usage": "1830", "Diagnosing AMP/Application startup issues": "2289", "Diagnosing Connectivity Issues": "2290", "Configuring AMP to use Docker for instances": "1957", "Information submitted in AMP error reports": "2298", "Editions Comparison Sheet": "2247", "AMP Instance Manager command line reference": "2249", "How to import an existing Minecraft server into AMP": "1822", "Setting up secure HTTP with AMP": "2305", "Reset your AMP login details": "3349", "ARK: Survival Evolved - Adding mods to the server": "2232", "How to uninstall AMP": "2273", "How to connect to AMP remotely": "3731", "How (not) to ask for help": "3717", "Setting up URL Rewrite Reverse Proxy for AMP and IIS": "2306", "AMP Dependencies - Java": "3648", "Using AMP on Oracle Cloud": "2307", "The Forest - Enable Admin/Cheats": "2983", "CubeCoders HelperBot Discord Commands": "2693", "How to change backup locations": "2783", "ICARUS Client Guide": "2551", "TeamSpeak 3 Guide": "2536", "GetAMP Unattended Installations": "2294", "Portal Knights Guide": "2457", "Impostor (Among Us) Guide": "2455", "Unreal Tournament 2004 Guide": "2453", "Unreal Tournament 99 Guide": "2452", "Missing some templates when creating an instance": "2314", "Pavlov VR Guide": "2204", "AMP Screenshot Gallery": "2250", "Installing AMP on Linode": "2300", "Managing user permissions in AMP": "2301", "Cloud Provider Support": "2283", "Configuring FTP in AMP": "2286", "Migrating from McMyAdmin 2 to AMP": "2302", "Why is AMP asking for my Steam login details?": "2310", "Using LDAP authentication with AMP": "2309", "Using Caddy with AMP": "2308", "Reconfiguring the Auth Server URL": "2303", "Information submitted in AMP metrics reports": "2299", "Honeypot Usernames": "2296", "Installing AMP and Wordpress together": "2295", "Feature set comparison: AMP vs other panels": "2293", "Enterprise ADS Callback Endpoints": "2292", "Discord Netiquette 101": "2291", "Using AMP themes": "2288", "Configuring SSH Key authentication for your AMP user": "2287", "Configuring ‘hidepid’ for Linux systems": "2285", "Web interface doesn’t load remotely on CentOS": "2284", "Backup Exclusions": "2282", "AMP systemd script (Linux)": "2281", "Remote instance access modes": "2268", "AMP specific initialisms and acronyms": "2251", "AMP Exit Code Details": "2248", "AMP Deployment Overlays": "2246", "ADS Deployment Modes": "2245", "About Community contributed Configurations": "2230", "I’ve installed AMP for the first time on Linux, but it’s not accepting my login details": "1817", "Assetto Corsa Competizione Guide": "2197", "Carrier Command 2 Guide": "2202", "Killing Floor 2 Workshop Mods Guide": "2203", "Wreckfest Guide": "2201", "Longvinter Guide": "2200", "Broke Protocol Guide": "2199", "Vintage Story Guide": "2198", "Assetto Corsa Guide": "2196", "Using RCON Passthru mode to access RCON with a static password": "1829", "How do I change which Java version AMP uses?": "1825", "How to change between different AMP release streams": "1814", "AMP Dependencies - Git": "1803", "AMP Release Streams": "1812", "How do I connect to AMP via SFTP to move files around?": "1823", "Where does AMP store its data?": "1820", "Supported Applications Compatibility": "1828", "Something not working on Windows? Try the following:": "241" };

    const vm = new SearchResultCategoryVM("Documentation", "Information about using/configuring AMP", "help");

    const matches = findMatches(Object.keys(ArticleData), query, 5);

    for (const title of matches) {
        if (title.toLocaleLowerCase().contains(query)) {
            const resultVM = new SearchResultVM(title, "AMP Documentation", "", 50, ArticleData[title], ShowDocumentationPage);
            vm.items.push(resultVM);
        }
    }

    if (vm.items().length == 0) { return null; }

    return vm;
}

function VideoTutorialsSearchProvider(query) {
    const tutorials = { "ECRXQ_gbpmk": "Creating a Minecraft: Java Edition server in AMP", "4DQzwuwt0SU": "Creating a Valheim Server in AMP", "Un7WVi_5x78": "Creating a Satisfactory server in AMP", "8ydg5SjxKGc": "Quick Guides: Backups Tutorial" };

    const vm = new SearchResultCategoryVM("Video Tutorials", "Visual guides to using and configuring AMP", "movie");

    for (const key of Object.keys(tutorials)) {
        const title = tutorials[key];
        if (title.toLocaleLowerCase().contains(query)) {
            const resultVM = new SearchResultVM(title, "AMP Video Tutorials", "", 60, key, ShowVideoTutorial, `https://i.ytimg.com/vi/${key}/hqdefault.jpg`);
            vm.items.push(resultVM);
        }
    }

    if (vm.items().length == 0) { return null; }

    return vm;
}

function ShowVideoTutorial(result) {
    const targetURL = `https://www.youtube.com/watch?v=${result.meta}`
    plausible("WatchVideo", { props: { url: targetURL } });
    window.open(targetURL);
}

function ShowDocumentationPage(result) {
    window.open(`https://discourse.cubecoders.com/docs?topic=${result.meta}&utm_source=ampdocs&utm_term=${encodeURI(result.title)}`);
}

function getMatchingEnumSetting(setting, val) {
    for (let opt of setting.enumValues()) {
        if (opt.name.toLocaleLowerCase().contains(val)) { return opt.name; }
        if (opt.value.toLocaleLowerCase().contains(val)) { return opt.value; }
    }

    return null;
}

function SettingsSearchProvider(query) {

    const vm = new SearchResultCategoryVM("Settings", "AMP settings that may be changed by the user. Click on a setting to go to it.");

    for (let setting of Object.values(currentSettings)) {
        const possibleSettingMatch = getMatchingEnumSetting(setting, query);

        if (setting.isReadOnly() || !setting.visible()) { continue; }

        const settingKeywords = setting.keywords || "";
        const settingDescription = setting.description || "";
        if (settingKeywords.toLocaleLowerCase().contains(query) ||
            setting.name.toLocaleLowerCase().contains(query) ||
            settingDescription.toLocaleLowerCase().contains(query) ||
            setting.node.toLocaleLowerCase().contains(query) ||
            possibleSettingMatch != null) {

            const subcat = setting.Subcategory != null && setting.Subcategory != "" ? ` > ${setting.Subcategory.split(":")[0]}` : "";
            let source = `Configuration > ${setting.category.name().split(":")[0]}${subcat} > ${setting.name}`;

            if (possibleSettingMatch != null) {
                source += ` > ${possibleSettingMatch}`;
            }

            const resultVM = new SearchResultVM(setting.name, settingDescription.replaceAll(/\[(.*?)\]\((.*?)\)/g, "$1"), source, 75, null, setting.highlight);
            vm.items.push(resultVM);
            continue;
        }

        const queryWords = query.split(/\s+/).filter(w => w.length > 0);
        const nameDesc = (setting.name + " " + settingDescription).toLocaleLowerCase();
        const numberOfWordsInQueryContainedInNameOrDescription = queryWords.filter(word => nameDesc.includes(word)).length;

        if (numberOfWordsInQueryContainedInNameOrDescription >= 2) {
            const score = numberOfWordsInQueryContainedInNameOrDescription * 25;
            const subcat = setting.Subcategory != null && setting.Subcategory != "" ? ` > ${setting.Subcategory.split(":")[0]}` : "";
            let source = `Configuration > ${setting.category.name().split(":")[0]}${subcat} > ${setting.name}`;
            const resultVM = new SearchResultVM(setting.name, settingDescription.replaceAll(/\[(.*?)\]\((.*?)\)/g, "$1"), source, score, null, setting.highlight);
            vm.items.push(resultVM);
        }
    }

    if (vm.items().length == 0) { return null; }

    return vm;
}

async function UsersSearchProvider(query) {
    const vm = new SearchResultCategoryVM("Users", "Login users for AMP", "person");

    await viewModels.ampUserList.load();

    for (let user of viewModels.ampUserList.users()) {
        if (user.username.toLocaleLowerCase().contains(query)) {
            const resultVM = new SearchResultVM(user.username, "", "Configuration > User Management > " + user.username, 100, user, () => {
                UI.GetSideMenuItem("tab_settings").children().find(c => c.tab() == "#tab_usermanagement").click();
                user.click();
            });
            vm.items.push(resultVM);
        }
    };

    return vm;
}

async function RolesSearchProvider(query) {
    const vm = new SearchResultCategoryVM("Roles", "Roles for AMP", "group");

    await viewModels.roles.load();

    for (let role of viewModels.roles.roles()) {
        if (role.Name.toLocaleLowerCase().contains(query)) {
            const resultVM = new SearchResultVM(role.Name, role.Description, "Configuration > Role Management > " + role.Name, 100, role, () => {
                UI.GetSideMenuItem("tab_settings").children().find(c => c.tab() == "#tab_rolemanagement").click();
                role.Click();
            });
            vm.items.push(resultVM);
        }
    };

    return vm;
}

// Close any open kvpNodePicker overlays when clicking outside of them
document.addEventListener("mousedown", function (e) {
    if (!e.target.closest(".kvpNodePickerWrap")) {
        document.querySelectorAll(".kvpNodePicker").forEach(el => {
            const vm = ko.contextFor(el)?.$data;
            if (vm?.nodePickerVisible) { vm.nodePickerVisible(false); }
        });
    }
});
