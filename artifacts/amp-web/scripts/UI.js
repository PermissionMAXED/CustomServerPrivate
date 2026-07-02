/// <reference path="jquery-3.6.0.min.js" />
/// <reference path="knockout-3.5.1.js" />
/// <reference path="Locale.js" />
/// <reference path="Common.js" />

/* eslint eqeqeq: "off", curly: "error", "no-extra-parens": "off" */
/* global Locale, ko */

const UI = (function () {
    "use strict";

    const intervals = { UpdateGraph: 0 };

    $.fn.enterPressed = function (callback) {
        this.on("keydown", function (event) {
            if (event.key === "Enter") {
                event.preventDefault();
                callback(event);
            }
        });
        return this;
    };

    let sideVisible = false;
    let mobileUI = false;
    let loggedIn = false;

    let scrollConsole = true;
    let notificationRemovedCallbacks = [];
    let popstateRoot = [];
    let popstateHandlers = {};
    let popstateCallback = function (_) { /* NOOP */ };
    let customConsoleHandler = function (_) { return false; };
    let lastEntrySource = "";
    let lastEntryTimestamp = "";
    let lastEntryDay = new Date().getDay();
    let lastConsoleEntry = null;
    let lastConsoleContents = null;
    let statusVM = null;
    let initialTab = null;

    let sideMenuVM = new SideMenuViewModel();
    let userProfileMenuVM = null;
    let configMenusVM = null;
    let notificationsVM = null;

    function SideMenuEntryVM(title, tab, image, postClick, order, small, requiredPermission, extraClass, navigateOverride = null)
    {
        const regex = /^([^:]+)(?::(.*?))?$/;
        const [, displayName, icon = image, itemOrder] = regex.exec(title) || [];

        const self = this;
        this.title = ko.observable(Locale.l(displayName));
        this.shortName = displayName.replaceAll(/ and .+$|[\s'!?]|\(.+?\)/g, '').toLowerCase();
        this.tab = ko.observable(tab);
        this.image = ko.observable(icon);
        this.children = ko.observableArray();
        this.selected = ko.observable(false);
        this.postClick = postClick || $.noop;
        this.expanded = ko.observable(false);
        this.parent = ko.observable(null);
        this.order = itemOrder || order || 10;
        this.small = small || false;
        this.requiredPermission = requiredPermission || "";
        this.visible = ko.observable(true);
        this.extraClass = ko.observable(extraClass || "");
        this.disabled = ko.observable(false);
        this.bodyElement = null;
        this.subtitle = ko.observable("");
        this.subtitleIcon = ko.observable("warning");
        this.navigateOverride = navigateOverride;

        this.children.subscribe(function (changes) {
            for (const change of changes)
            {
                change.parent(self);
            }
        });

        this.addChild = function (child) {
            self.children.push(child);
        };

        this.click = function (d, e) {
            if (e != undefined) { e.stopPropagation(); }

            if (self.disabled()) { return; }

            const previous = sideMenuVM.selectedMenu();
            if (previous != null) { previous.selected(false); }
            self.selected(true);

            $("#tabTitle").text(self.title());

            if (self.children().length > 0) {
                self.expanded(!self.expanded());
                $("#sideMenu").toggleClass("childOpen");
                $("#sideMenuContainer").toggleClass("childOpen");
            }
            else {
                sideMenuVM.selectedMenu(self);
                const url = self.parent() == null ? "/" + self.shortName : `/${self.parent().shortName}/${self.shortName}`;

                if (e != undefined) {
                    UI.NavigateTo(self.navigateOverride ?? url);
                }

                if (previous != null) {
                    $(previous.tab()).hide();
                    $(self.tab()).show();
                    self.postClick();
                }

                if (self.parent() == null) {
                    hideSide();
                }
            }

            return false;
        };

        this.hide = function () {
            self.selected(false);
            self.expanded(false);
            sideMenuVM.selectedMenu(null);
        };
    }

    function SideMenuViewModel()
    {
        this.sideMenuData = ko.observableArray();
        this.selectedMenu = ko.observable(null);
        this.showADSUI = ko.observable(false);
        this.closeRemote = null;
        this.imageURL = ko.observable("");
    }

    function consoleEntryViewModel() {
        const self = this;
        this.Timestamp = ko.observable("");
        this.Source = ko.observable("");
        this.SourceId = ko.observable("");
        this.Contents = ko.observable("");
        this.sourceClicked = function () { };
        this.style = ko.computed(function () {
            if (/warning|failure/i.test(self.Contents)) { return "color:orange"; }
            if (/error|exception/i.test(self.Contents)) { return "color:red"; }
            if (/success/i.test(self.Contents)) { return "color:green"; }
        });
        this.previousEntry = null;
    }

    function setupMenuSwipe() {
        if (!UI.GetIsMobile()) { return; }

        document.addEventListener('swiped-left', hideSide);
        document.addEventListener('swiped-right', showSide);
    }

    function setupEvents() {
        $("#navToggle").on("click", sideMenuToggle);
        $("#consoleUsers").on("click", ".consoleUserEntry", consoleUserClicked);
        $(window).on("resize", windowResized);

        $("#sideMenuContainer").show(); //Show and hide the side menu, or the size calculation doesn't work.
        $("#sideMenuContainer").hide();

        configMenusVM = new SideMenuEntryVM("Configuration", "#tab_settings", "manufacturing");
        configMenusVM.children.push(
            new SideMenuEntryVM("User Management", "#tab_usermanagement", "manage_accounts", () => viewModels.ampUserList.refresh(), 0, true, "Core.UserManagement.ViewUserInfo"),
            new SideMenuEntryVM("Role Management", "#tab_rolemanagement", "groups", () => viewModels.roles.load(), 0, true, "Core.RoleManagement.ViewRoles"),
            new SideMenuEntryVM("Active Sessions", "#tab_activesessions", "user_attributes", () => viewModels.ampSessions.refresh(), 0, true, "Core.UserManagement.ViewActiveSessions"),
            new SideMenuEntryVM("Event Log", "#tab_auditlog", "browse_activity", () => viewModels.audit.reset(), 0, true, "Core.AuditLog.ViewAuditLog")
        );

        statusVM = new SideMenuEntryVM("Status", "#tab_status", "monitor_heart");
        sideMenuVM.sideMenuData.push(
            statusVM,
            new SideMenuEntryVM("Console", "#tab_console", "terminal", function () {
                const consoleContainer = $("#consoleArea");
                $(consoleContainer[0]).scrollTop(consoleContainer[0].scrollHeight);
            }, 0, false, "Core.AppManagement.ReadConsole"),
            new SideMenuEntryVM("Schedule", "#tab_schedule", "calendar_month", null, 0, false, "Core.Scheduler.ViewSchedule"),
            configMenusVM,
            new SideMenuEntryVM("Support and Updates", "#tab_support", "support", () => viewModels.support.refresh(), 999, false, "Core.Special.Diagnostics", "updateNotice")
        );

        userProfileMenuVM = new SideMenuEntryVM("User Profile", "#tab_currentuser");

        $("#userInfo").on("click", userProfileMenuVM.click);

        UI.ApplyVMBinding(sideMenuVM, document.getElementById("sideMenu"));

        notificationsVM = new NotificationsVM();
        UI.ApplyVMBinding(notificationsVM, document.getElementById("notificationContainer"));

        UI.ApplyVMBinding(metricsInfo, document.getElementById("AMP_Core_MetricsDisplay"));
        UI.ApplyVMBinding(metricsInfo, document.getElementById("AMP_Core_PrimaryTask"));
        UI.ApplyVMBinding(metricsInfo, document.getElementById("AMP_Core_ServerStatus"));
        UI.ApplyVMBinding(metricsInfo, document.getElementById("AMP_Core_ConsoleButtons"));
        UI.ApplyVMBinding(metricsInfo, document.getElementById("AMP_Core_ConsoleStatus"));

        initialTab = statusVM;
        initialTab.click();

        UI.RegisterPopstateHandler("configuration", configPopstate);
        window.addEventListener('popstate', handlePopstate);
    }

    const isMobileView = () => $("#navToggle").css("display") !== "none";

    function handlePopstate(event) {
        if (!event.state) { 
            sideMenuVM.sideMenuData()[0].click();
            return; 
        }
        viewChange(event.state.page);
    }

    function viewChange(url, withCallback = false) {
        let parts = url.split("/").filter(Boolean).splice(popstateRoot.length);
        if (parts.length == 0) { return; }

        const handler = parts[0].toLowerCase();
        sideMenuVM.sideMenuData().find(m => m.expanded())?.expanded(false);
        const topLevel = sideMenuVM.sideMenuData().find(m => m.shortName == handler);
        if (topLevel != null) { topLevel.click(); }

        if (popstateHandlers.hasOwnProperty(handler)) {
            popstateHandlers[handler](topLevel, parts);
        }
    }

    function configPopstate(topLevel, parts) {
        if (parts.length < 2) { return; }
        const catName = parts[1].toLowerCase();
        topLevel.expanded(true);
        topLevel.children().find(c => c.shortName == catName)?.click();
    }

    function windowResized() {
        mobileUI = isMobileView();

        $(".multiMenuContainer").trigger("mouseleave");

        if (mobileUI && sideVisible) {
            $("#sideMenuPresenter").stop(); //Interrupt any pending animations.
        }
    }

    function consoleUserClicked(event) {
        if (event.which === 1) //left
        {
            if (!event.ctrlKey) {
                $(".consoleUserEntry .selected").removeClass("selected");
            }

            $(this).addClass("selected");
        }
    }

    function sideMenuToggle(event) {
        if (event != undefined) {
            event.stopPropagation();
        }

        if (sideVisible) {
            hideSide();
        } else {
            showSide();
        }
    }

    function hideSide() {
        sideVisible = false;
        const sm = $("#sideMenuContainer, .subMenuWell.appear");
        sm.removeClass("appear");
        $("#mainBody").removeClass("appear");
        sideMenuVM.sideMenuData().find(m => m.expanded())?.expanded(false);
        $("#sideMenu").removeClass("childOpen");
        $("#sideMenuContainer").removeClass("childOpen");
    }

    function showSide() {
        sideVisible = true;
        const sm = $("#sideMenuContainer");
        sm.show();
        $("#mainBody").addClass("appear");
        sm.addClass("appear");
    }

    function arrayToSeries(input) {
        let output = [];
        for (let i = 0; i < input.length; i++) {
            output.push([i, input[i]]);
        }
        return output;
    }

    const metricsInfo = new MetricsDisplayVM();

    function MetricsDisplayVM() {
        const self = this;
        this.metrics = ko.observableArray(); //of MetricVM
        this.metricsVMs = {};
        this.endpointURI = ko.observable("");
        this.primaryEndpoint = ko.observable("");
        this.uptime = ko.observable("");
        this.state = ko.observable(0);
        this.update = function (Metrics, Uptime) {
            if (Uptime != null) { self.uptime(Uptime); }
            for (const key in Metrics) {
                const metric = Metrics[key];
                if (self.metricsVMs[key] === undefined) {
                    const newMetricVM = new MetricVM(key, metric);
                    self.metricsVMs[key] = newMetricVM;
                    self.metrics.push(newMetricVM);
                    newMetricVM.setup();
                }
                else {
                    self.metricsVMs[key].append(metric);
                }
            }
        };
        this.stateText = ko.computed(() => stateText(self.state()) + (self.state() == 20 ? ` Uptime: ${self.uptime()}` : ''));
        this.stateColor = ko.computed(() => stateColor(self.state()));
        this.stateColorClass = ko.computed(() => stateColorClass(self.state()));
        this.stateIcon = ko.computed(() => stateIcon(self.state()));
        this.primaryTask = ko.observable(null); //of NotificationVM
        this.openTicket = function () { viewModels.support.showNewTicket(); };
        this.showOpenTicket = ko.computed(() => {
            return (typeof (userHasPermission) !== "undefined" && userHasPermission("Core.Special.Diagnostics") && currentSettings['GSMyAdmin.GSMyAdminSettings.ShowHelpOnStatus'].value());
        });
    }

    function stateColorClass(state) {
        switch (state) {
            case 10:
            case 30:
                return "bgAmber";
            case -1:
            case 5:
            case 7:
            case 60:
            case 70:
            case 75:
            case 80:
                return "bgBlue"
            case 20:
            case 50:
            case 999:
                return "bgGreen";
            case 0:
            case 40:
            case 100:
            case 200:
            case 250:
            default:
                return "bgRed";
        }
    }

    function stateColor(state) {
        switch (state) {
            case 5:
            case 7:
            case 10:
            case 30:
            case 45:
            case 60:
            case 70:
            case 75:
            case 80:
                return "orange";
            case 999:
            case 50:
            case 20: return "green";
            default: return "red";
        }
    }

    function stateIcon(state) {
        switch (state) {
            case -1:
            case 10:
            case 30:
            case 5:
            case 7:
            case 60:
            case 70:
            case 75:
                return "manufacturing"
            case 20:
            case 999:
                return "play_circle";
            case 45:
            case 50:
                return "bedtime";
            case 0:
            case 40:
                return "stop_circle";
            case 80:
                return "help";
            case 100:
            case 200:
            case 250:
            default:
                return "error";
        }
    }

    function stateText(state) {
        switch (state) {
            case -1: return "Undefined";
            case 0: return "Stopped";
            case 5: return "Preparing to start";
            case 7: return "Performing pre-start configuration"
            case 10: return "Starting";
            case 20: return "Running";
            case 30: return "Preparing to restart";
            case 40: return "Stopping";
            case 45: return "Preparing to sleep";
            case 50: return "Sleeping, available for users";
            case 60: return "Waiting for external service";
            case 70: return "Installing components";
            case 75: return "Updating";
            case 80: return "Waiting for user input";
            case 100: return "Unable to run";
            case 200: return "Suspended";
            case 250: return "Offline for maintainence";
            case 999: return "Services Running";
            default: return `unknown (${state})`;
        }
    }

    function MetricVM(name, metric) {
        const self = this;
        this.name = name;
        this.color = metric.Color;
        this.color2 = metric.Color2 || metric.Color;
        this.color3 = metric.Color3 || "#000";
        this.backgroundGradient = `linear-gradient(to bottom, ${self.color}, ${self.color2})`;
        this.history = [];
        this.series = () => arrayToSeries(self.history);
        this.isSetup = false;
        this.graph = null;
        this.displayValue = ko.observable("");
        this.lastPercent = ko.observable(0);
        this.dashOffset = ko.observable(0);
        this.elementId = "Core_Metrics_" + this.name.replaceAll(/\W/g, "");
        this.shortMetricName = this.name.replaceAll(/\W/g, "");

        this.append = function (newValue) {
            if (self.history.length > maxGraphPoints) {
                self.history.splice(0, 1);
            }

            self.history.push(newValue.Percent);
            self.lastPercent(newValue.Percent);
            self.dashOffset(400 - (newValue.Percent * 2));

            if (newValue.Units === "%") {
                self.displayValue(newValue.RawValue + "%");
            }
            else if (newValue.Units === "MB" && (newValue.RawValue > 1023 || newValue.MaxValue > 1023)) {
                self.displayValue((newValue.RawValue / 1024).toFixed(2) + " / " + (newValue.MaxValue / 1024).toFixed(2) + " GB");
            }
            else
            {
                self.displayValue(newValue.RawValue + " / " + newValue.MaxValue + newValue.Units);
            }

            if (self.graph != null) {
                self.graph.setData([self.series()]);
                self.graph.draw();
            }
        };

        this.setup = function () {
            if (self.isSetup || !statusVM.visible() || !loggedIn) { return; }
            UI.FastUIInit();

            for (let i = 0; i < maxGraphPoints; i++) {
                self.history.push(0);
            }

            const options = {
                canvas: true,
                grid: {
                    borderWidth: 1,
                    color: "rgba(255,255,255,0.2)",
                    minBorderMargin: 0,
                    margin: {
                        top: 0,
                        right: 0,
                        bottom: 0,
                        left: 0
                    }
                },
                series: {
                    lines: {
                        show: true,
                        fill: true
                    },
                    points: {
                        show: false
                    }
                },
                xaxis: {
                    show: false,
                    reserveSpace: false
                },
                yaxis: {
                    min: 0,
                    max: 100,
                    ticks: 4,
                    fill: true,
                    reserveSpace: false,
                    labelWidth: 0,
                    show: true,
                    tickFormatter: () => ""
                },
                colors: [self.color]
            };

            try {
                self.graph = $.plot("#" + this.elementId, [self.series()], options);
                self.isSetup = true;
            }
            catch {
                self.isSetup = false;
            }
        };
    }

    $(function () {
        window.scrollTo(0, 1);
        setupEvents();
    });

    const nullFunc = function () { /**/ };

    const maxGraphPoints = 60;
    let userClickCallback = nullFunc;

    function getLoginText(loginResult) {
        switch (loginResult) {
            case 0:
                return { title: "Login Failed", message: "Invalid Username or password" };
            case 1:
                return { title: "Token Rejected", message: "Full login required" };
            case 2:
                return { title: "Login Required", message: "Standard login required" };
            case 3:
                return { title: "SSO Failure", message: "Error handling SSO login request: " };
            case 5:
                return { title: "Permission Denied", message: "This user does not have permission to access this instance. Please ensure that this user has the 'Manage Instance' permission within ADS for this instance." };
            case 6:
                return { title: "Instance Suspended", message: "This instance has been suspended. Only system administrators can manage it at this time." };
            case 10:
                return { title: "Empty Response", message: " " };
            case 20:
                return { title: "Password Change Needed", message: "Password change required" };
            case 25:
                return { title: "Account Unavailable", message: "Account Disabled or Awaiting Approval - Contact System Administrator" };
            case 30:
                return { title: "Rate Limited", message: "Rate limited due to excessive login attempts - try again later" };
            case 40:
                return { title: "2FA Required", message: "Two-Factor Login Required" };
            case 45:
                return { title: "2FA Setup Needed", message: "Two-Factor Setup Required" };
            case 50:
                return { title: "2FA Failed", message: "Two-Factor Login Failed" };
            case 100:
                return { title: "Auth Disabled", message: "Authentication passthru is disabled on the controller" };
            case 110:
                return { title: "Auth Rejected", message: "The authentication passthru request was rejected by the controller" };
            case 150:
                return { title: "Auth Rejected", message: "This account uses OIDC authentication and cannot log in with a password. Please use the OIDC login button instead." };
            case 500:
                return { title: "Server Unreachable", message: "Login server unreachable. Check logs for more information." };
            case 1000:
                return { title: "Instance Unavailable", message: "Specified instance unavailable, check ADS log." };
            case -100:
                return { title: "Token Missing", message: "No recognised token was provided." };
            case -110:
                return { title: "Username Needed", message: "Web auth token requires a username to be entered." };
            case -120:
                return { title: "Web Auth Unavailable", message: "Web auth is not available." };
            case -999: 
                return { title: "Version Mismatch", message: "Cache clear required." };
            default:
                return { title: "Unknown Reason", message: `Unknown Reason (${loginResult})` };
        }
    }

    function NotificationsVM() {
        const self = this;
        this.Notifications = ko.observableArray(); //of NotificationVM
        this.Visible = ko.observable(false);
        this.Collapsed = ko.observable(false);
        this.ToggleCollapsed = function () { self.Collapsed(!self.Collapsed()); };
        this.UpdateBodyBottom = function () {
            if (UI.GetIsMobile()) {
                const targetHeight = self.Visible() > 0 ? $("#notificationContainer").height() : 0;
                $("#mainBody").css("bottom", targetHeight + "px");
            }
        }
        this.DismissAllVisible = ko.computed(() => self.Notifications().some(s => s.State() == 3));
        this.DismissAll = async function () {
            const dismissResult = await UI.ShowModalAsync("Dismiss all tasks", "Are you sure you want to dismiss all failed tasks?", UI.Icons.Question, [new UI.ModalAction("Dismiss All", true, "bgRed"), UI.CancelAction("bgGreen")]);
            if (dismissResult === true) {
                await API.Core.DismissAllTasksAsync();
            }
        };
        this.Update = function (newData, noRemove) {
            for (let task of newData) {
                if (task.HideFromUI) { continue; }
                let existing = ko.utils.arrayFirst(self.Notifications(), (notif) => notif.Id == task.Id);
                if (existing != null) {
                    existing.Update(task);
                    continue;
                }
                
                const newTaskVM = new NotificationVM(task);
                self.Notifications.push(newTaskVM);
            }

            self.UpdateBodyBottom();

            if (noRemove === true) { return; }
            for (const existingTask of self.Notifications()) {
                if (existingTask.IsLocalTask) { continue; }
                const checkStillExists = ko.utils.arrayFirst(newData, (notif) => notif.Id == existingTask.Id);
                if (checkStillExists == null) {
                    console.log(`Removing task ${existingTask.Id} - No longer in remote store`);
                    self.Notifications.remove(existingTask);
                    API.NotifyTaskComplete(existingTask.Id);
                    for (const f of notificationRemovedCallbacks) {
                        f(existingTask.id);
                    }
                }
            }
        };
        this.Remove = function (id) {
            const existingTask = ko.utils.arrayFirst(self.Notifications(), (notif) => notif.Id == id);
            if (existingTask != null) {
                console.log(`Removing task ${existingTask.Id} - Explicit Removal`);
                if (existingTask.IsPrimaryTask()) { metricsInfo.primaryTask(null); }
                self.Notifications.remove(existingTask);
                API.NotifyTaskComplete(existingTask.Id);
                for (const f of notificationRemovedCallbacks) {
                    f(existingTask.id);
                }
            }
        };
        this.BeforeRemove = async function (elem, index, item) {
            if (elem.nodeType !== 1) { return; }

            const el = $(elem);
            if (item.Actions().length == 0) {
                await sleepAsync(1000);
            }

            const h = el.height();
            el.css("height", h + "px");
            el.css("opacity", 0);

            await sleepAsync(250);

            el.css("overflow", "hidden");
            el.css("height", "0px");
            el.css("padding", 0);

            await sleepAsync(300);

            el.remove();
            self.Visible(self.Notifications().length != 0);
            self.UpdateBodyBottom();
        };
    }

    function NotificationVM(task, local, actions) {
        const self = this;
        notificationsVM.Visible(true);
        this.ErrorShown = false;
        this.IsLocalTask = local || false;
        this.Id = task.Id;
        this.Name = ko.observable(task.Name);
        this.Description = ko.observable(task.Description);
        this.IsCancellable = ko.observable(task.IsCancellable);
        this.ProgressPercent = ko.observable(task.ProgressPercent);
        this.IsIndeterminate = ko.observable(task.IsIndeterminate);
        this.IsPrimaryTask = ko.observable(task.IsPrimaryTask);
        this.State = ko.observable(task.State);
        this.StateMessage = ko.observable(task.StateMessage);
        this.Speed = ko.observable(task.Speed);
        this.URL = ko.observable(task.SupportURL);
        this.URLTitle = ko.observable(task.SupportTitle);
        this.Actions = ko.observableArray(actions || []); //of UI.ModalAction
        this.LocalCancelCallback = null;
        this.Cancel = async function () {
            if (!self.IsCancellable()) {
                await UI.ShowModalAsync("Task cannot be cancelled.", "This task does not support cancellation.", UI.Icons.Exclamation, UI.OKActionOnly);
            }

            const cancelPrompt = await UI.ShowModalAsync("Are you sure you want to cancel this task?", self.Name(), UI.Icons.Question, [
                new UI.ModalAction("Cancel Task", true, "bgRed"),
                new UI.ModalAction("Continue Task", false, "bgGreen")
            ]);

            if (cancelPrompt !== true) { return; } 

            if (self.IsLocalTask) {
                self.LocalCancelCallback(self);
                UI.RemoveLocalNotification(self.Id);
            }
            else
            {
                API.Core.CancelTask(self.Id);
            }
        };
        this.Update = function (updatedTask) {
            self.Name(updatedTask.Name);
            self.Description(updatedTask.Description);
            self.ProgressPercent(updatedTask.ProgressPercent);
            self.IsCancellable(updatedTask.IsCancellable);
            self.IsIndeterminate(updatedTask.IsIndeterminate);
            self.IsPrimaryTask(updatedTask.IsPrimaryTask);
            self.State(updatedTask.State);
            self.StateMessage(updatedTask.StateMessage);
            self.Speed(updatedTask.Speed);
            self.URL(updatedTask.SupportURL);
            self.URLTitle(updatedTask.SupportTitle);
            if (!self.ErrorShown && updatedTask.State === 3) {
                self.ErrorShown = true;
                self.ShowError();
            }
        };
        this.Dismiss = async function () {
            await API.Core.DismissTaskAsync(self.Id);
        };
        this.ShowError = async function () {
            await UI.ShowModalAsync("Unable to complete task", { text: `This task could not be completed: ${self.Name()} - ${self.Description()} - State: ${self.State()}.`, subtitle: self.StateMessage() }, UI.Icons.Exclamation, UI.OKActionOnly, self.URLTitle(), self.URL());
            await API.Core.DismissTaskAsync(self.Id);
        };

        if (task.IsPrimaryTask) {
            metricsInfo.primaryTask(self);
        }
    }

    let lastLocalNotificationId = -100;

    const UIObject = {
        _alert: function (message)
        {
            alert(message);
        },
        ShowDevNodes: ko.observable(false),
        RegisterPopstateHandler: function (name, handler) {
            popstateHandlers[name] = handler;
        },
        InitialViewchange: function () {
            viewChange(remoteLogin?.queryPopstate() ?? window.location.pathname);
        },
        NavigateTo: function(url, andDisplay = false) {
            const finalUrl = popstateRoot.length == 0 ? url : `/${popstateRoot.join("/")}${url}`;
            const useUrl = remoteLogin.isRemote ? url : finalUrl;
            history.pushState({ page: useUrl}, "", useUrl);
            let parts = url.split("/").filter(Boolean);
            popstateCallback(popstateRoot.concat(parts));
            if (andDisplay) { viewChange(finalUrl); }
        },
        SetNotifyPopstate: function (callback, root) {
            popstateCallback = callback;
            popstateRoot = root;
        },
        SetRootPopstate: function (root) {
            popstateRoot = root;
        },
        RootViewchange: function (newUrl) {
            viewChange(newUrl);
        },
        GetSettingNodeElement: function(node)
        {
            return $("[data-settingnode='" + node + "']").closest(".settingContainer");
        },
        PopulateUserActions: function(result, userActionCallback)
        {
            const buttonArea = $("#userContentsButtonsArea");
            buttonArea.empty();

            for (const moduleName of Object.keys(result)) {
                const methods = result[moduleName];

                for (const method of Object.keys(methods)) {
                    const description = methods[method];

                    const newButton = $("<button/>", { text: description, "data-module": moduleName, "data-method": method });
                    newButton.on("click", userActionCallback);
                    buttonArea.append(newButton);
                }
            }
        },

        ApplyVMBinding: function (viewModel, elementOrId) {
            const el = typeof elementOrId === 'string' ? document.getElementById(elementOrId) : elementOrId;
            if (ko.dataFor(el)) {
                console.log(`Duplicate VM binding using ${viewModel.constructor.name}`);
                return;
            }
            ko.applyBindings(viewModel, el);
        },

        ApplyDescriptionLinks: function(selector)
        {
            $(selector || ".settingDescription").each(function () {
                const descEl = $(this);
                const descHtml = descEl.html();
                const rx = /\[(.+?)\]\(((?:http|setting).+?)\)/g;
                descEl.html(descHtml.replaceAll(rx, "<a href='$2'>$1</a>"));
                descEl.children("a").attr("target", "_new");
                descEl.children("a").on("click", UIObject.HandleClickedURL);
            });
        },

        HandleClickedURL: function (event) {
            event?.preventDefault();
            const originalURL = $(this).attr("href");
            const testurl = new URL(originalURL.replace("sftp:", "https:"));
            const url = new URL(originalURL);
            if (url.protocol === "setting:") {
                currentSettings[url.pathname].highlight();
                return false;
            }
            if (url.protocol == "steam:") {
                window.open(url, "_blank");
                return true;
            }
            if (url.protocol == "sftp:" && testurl.hostname == window.location.hostname) {
                window.open(url, "_blank");
                return true;
            }
            if (url.host == "cubecoders.com" || url.host.endsWith(".cubecoders.com") || url.host.endsWith(".c7rs.com") || url.host == window.location.host) {
                window.open(url, "_blank");
                return true;
            }
            else {
                (async function () {
                    const UrlPrompt = await UI.ShowModalAsync("Third-party Warning", url.host + Locale.l(" is a third party resource. Neither the AMP software itself, nor CubeCoders are responsible for the quality or accuracy of information at this location."), UI.Icons.Exclamation, [new UI.ModalAction("Open Website", true, "bgAmber"), new UI.ModalAction("Cancel", false)]);
                    if (UrlPrompt === true) {
                        window.open(url, "_blank");
                    }
                })();
                return false;
            }
        },

        AssetsLoaded: async function () {
            $("#loginContainer").css("opacity", 1);
            await $("#loginSpinner").fadeOut().promise();
            await $("#loginForm").css("opacity", "1").promise();
            await $("#loginSplash").fadeIn().promise();
            $("#loginForm input[name=username]").focus();
        },

        AddSideMenuItem: function (title, tab, image, click, order, isDefault) {
            const newTab = new SideMenuEntryVM(title, tab, image, click, order);
            sideMenuVM.sideMenuData.push(newTab);
            sideMenuVM.sideMenuData.sort(function (left, right) {
                return (left.order - right.order);
            });
            if (isDefault) {
                initialTab = newTab;
                newTab.click();
            }
            return newTab;
        },

        GetSideMenuItem: function (tabName) {
            return sideMenuVM.sideMenuData().find(vm => vm.tab() == "#" + tabName);
        },

        SetupADSUI: function (closeRemote, imageURL) {
            sideMenuVM.showADSUI(true);
            sideMenuVM.imageURL(imageURL);
            sideMenuVM.closeRemote = closeRemote;
            const newTab = new SideMenuEntryVM("Return to Instances", "", "back_to_tab", closeRemote, 0, false, null, "padBottom", "/instances");
            sideMenuVM.sideMenuData.unshift(newTab);
            $(".menuTitle").first().hide();
        },

        HideStatusTab: function () {
            statusVM.visible(false);
            sideMenuVM.sideMenuData().first().click();
        },

        AddSettingsTab: function (title, tab, image, onclick, order) {
            const vm = new SideMenuEntryVM(title, tab, image, onclick, order, true);
            configMenusVM.children.push(vm);
            return vm;
        },

        SetModuleInfo: function (Name, AppName, Author, SupportsSleep, _AMPVersion, _Timestamp, BuildSpec, Branding, EndpointURI, PrimaryEndpoint, IsRemoteInstance, InstanceName, FriendlyName) {
            $(".ModuleName").text(Name);
            $(".AppName").text(AppName);
            $(".ModuleAuthor").text(Author);

            if (!SupportsSleep) {
                $("#sleepButton").remove();
            }

            if (!BuildSpec.includes("Mainline") && BuildSpec != "") {
                $("#releaseSpec").text(BuildSpec + " Build");
            }

            if (Branding.DisplayBranding === true) {
                if (Branding.LogoURL != "") { $("#loginLogo img").attr("src", Branding.LogoURL); }
                if (Branding.BackgroundURL != "") { $("body").css("background-image", `url(${Branding.BackgroundURL})`); }
                if (Branding.PageTitle != "") { $("title").text(Branding.PageTitle); }
                if (Branding.ForgotPasswordURL != "") { $("#forgotLogin").attr("href", Branding.ForgotPasswordURL); }
                
                $("#loginWelcome").text(Branding.WelcomeMessage);
                if (Branding.SplashFrameURL != "") {
                    $("#loginBrandContents").attr("src", Branding.SplashFrameURL).show();
                }
            }

            if (EndpointURI != "") {
                if (remoteLogin.isRemote && EndpointURI.includes("0.0.0.0")) {
                    EndpointURI = EndpointURI.replace("0.0.0.0", remoteLogin.targetURL.hostname);
                }

                metricsInfo.endpointURI(EndpointURI);
            }

            if (PrimaryEndpoint != "") {
                if (remoteLogin.isRemote && PrimaryEndpoint.includes("0.0.0.0")) {
                    PrimaryEndpoint = PrimaryEndpoint.replace("0.0.0.0", remoteLogin.targetURL.hostname);
                }

                metricsInfo.primaryEndpoint(PrimaryEndpoint);
            }

            if (IsRemoteInstance && !remoteLogin.isRemote) {
                const caption = `${FriendlyName} (${InstanceName})`;
                $("title").text("AMP - " + caption);
                $("#tabCaption").text(caption);
                $("#tabInfo").addClass("remoteInfo");
            }
        },

        LoginWaiting: async function (fast = false) {
            if (fast) {
                $("#loginForm, #loginContainer").css("transition", "none");
                $("#loginContainer").css("opacity", "1");
                $("#loginSpinner").show();
            }
            else
            {
                $("#loginSpinner").fadeIn();
            }
            $("#loginForm").css("opacity", "0");
            
        },

        LoginFailed: async function (loginResult, resultReason) {
            const loginMsg = getLoginText(loginResult);
            const title = Locale.l(loginMsg.title);
            const message = Locale.l(loginMsg.message)

            await sleepAsync(250);
            await $("#loginSpinner").fadeOut().promise();

            $("#loginFailureReason").text(title);
            $("#loginFailureDetails").text(`${message} ${resultReason}`);
            $("#loginFailure").addClass("opaque");

            if (loginResult == 30) {
                //Rate Limited
                $("#loginHelperLink").show();
            }
            else if (loginResult == 25) {
                //Account disabled

            }
            $("#loginForm").fadeIn().css("opacity", "1");
            $("#sideMenuContainer, #mainBody, #responsiveHelpers, #barTop, #userInfo").hide();
        },

        GetLoginText: getLoginText,

        FastUIInit: function () {
            $("#mainBody, #tab_status, #barTop").show();
            $("#topSearchBox, #tabInfo").css("display", "inline-block");
            if (remoteLogin.isRemote) {
                $("#tabCaption").text(remoteLogin.caption);
                $("#tabInfo").addClass("remoteInfo");
            }
            else {
                $("#userInfo").show();
            }
            windowResized();
        },

        LoginSuccess: async function (fastMode) {
            setupMenuSwipe();

            if (fastMode) {
                $("#loginContainer, #loginSplash").hide();
                initialTab.click();
                $("#sideMenuContainer, #mainBody, #responsiveHelpers, #barTop").show();
                if (remoteLogin.isRemote) {
                    $("#tabCaption").text(remoteLogin.caption);
                    $("#tabInfo").addClass("remoteInfo");
                }
                else {
                    $("#userInfo").show();
                }
            }
            else {
                $("#loginContainer").fadeOut();
                $("#loginSplash").hide();
                initialTab.click();
                $("#sideMenuContainer, #mainBody, #responsiveHelpers, #barTop").fadeIn();
                if (remoteLogin.isRemote) {
                    $("#tabCaption").text(remoteLogin.caption);
                    $("#tabInfo").addClass("remoteInfo");
                }
                else {
                    $("#userInfo").fadeIn();
                }
            }

            $("#topSearchBox, #tabInfo").css("display", "inline-block");
            windowResized();
            UI.InitialViewchange();
            const consoleContainer = document.getElementById("consoleArea");
            consoleContainer.addEventListener("copy", (e) => {
                const sel = window.getSelection();
                if (!sel || sel.isCollapsed) { return; }
                if (!consoleContainer.contains(sel.anchorNode)) { return; }

                const text = sel.toString();

                if (!text.includes("\n")) { return; }

                e.preventDefault();
                e.clipboardData.setData(
                    "text/plain",
                    "```vbnet\n" + text + "\n```"
                );
            });
            loggedIn = true;
        },

        LoginBusy: async function (fastMode) {
            if (fastMode) {
                $(".loginBusy").show();
            }
            else {
                $(".loginBusy").fadeIn();
            }
        },

        Logout: function ()
        {
            loggedIn = false;
            clearInterval(intervals.UpdateGraph);
            $("#loginFailureReason, #loginFailureDetail").text(" ");
            $("#loginFailure").hide();
            $("#loginContainer, #loginSplash").fadeIn();
            $("#sideMenuContainer, #mainBody, #responsiveHelpers, #tabTitle, #topSearchBox").fadeOut();
        },

        UpdateState: function (state) {
            metricsInfo.state(state);
            $("[data-showstates]").each(function () {
                const e = $(this);

                const perm = e.attr("data-permission");

                if (perm != null && perm !== "" && !userHasPermission(perm)) {
                    e.hide();
                    return;
                }

                const states = e.data("showstates").toString();
                if (states === undefined) { return; }

                if (states.split(",").includes(state.toString())) {
                    e.show(); return;
                }

                e.hide();
            });
        },

        ShowActionNotificationAsync: function (title, description, actions) {
            const p = new Promise(function (resolve) {
                const notificationId = UI.CreateLocalNotification(title, description, actions);
                for (const action of actions) {
                    action.callback = resolve;
                    action.notificationId = notificationId;
                }
            });
            return p;
        },

        //For creating notifications in the particular session rather than globally. File transfers etc...
        CreateLocalNotification: function(title, description, actions, state, cancelCallback)
        {
            const task = {
                Id: lastLocalNotificationId,
                Name: title,
                Description: description,
                ProgressPercent: 0,
                State: state == undefined ? -1 : state,
                IsCancellable: cancelCallback != null
            };
            const localTask = new NotificationVM(task, true, actions);

            if (cancelCallback != null) {
                localTask.LocalCancelCallback = cancelCallback;
            }

            notificationsVM.Notifications.push(localTask);
            lastLocalNotificationId--;

            return task.Id;
        },

        CreateLocalAnnouncement: function (title, description, allowDismiss, autoDismiss) {
            const task = {
                Id: lastLocalNotificationId,
                Name: title,
                Description: description,
                ProgressPercent: 0,
                State: 100,
                IsCancellable: allowDismiss,
                IsIndeterminate: true,
            }
            const dissmissAct = new UI.ModalAction("Dismiss", true, "bgGreen");
            const actions = allowDismiss ? [dissmissAct] : [];
            const localTask = new NotificationVM(task, true, actions);
            localTask.LocalCancelCallback = () => UI.RemoveLocalNotification(task.Id);
            dissmissAct.callback = localTask.LocalCancelCallback;

            notificationsVM.Notifications.push(localTask);
            lastLocalNotificationId--;

            if (autoDismiss === true) {
                setTimeout(() => {
                    UI.RemoveLocalNotification(task.Id);
                }, 2000);
            }

            return task.Id;
        },

        UpdateLocalNotification: function(id, percent, indeterminate, speed)
        {
            const existing = ko.utils.arrayFirst(notificationsVM.Notifications(), (notif) => notif.Id == id);
            if (!existing?.IsLocalTask) { return; }
            existing.ProgressPercent(percent);
            existing.IsIndeterminate(indeterminate);
            existing.Speed(speed);
        },

        RemoveLocalNotification: function(id)
        {
            const existing = ko.utils.arrayFirst(notificationsVM.Notifications(), (notif) => notif.Id == id);
            if (!existing?.IsLocalTask) { return; }
            notificationsVM.Notifications.remove(existing);
        },

        UpdateNotifications: (notifications, noRemove) => notificationsVM.Update(notifications, noRemove),
        RemoveNotification: (id) => notificationsVM.Remove(id),

        AddNotificationRemovedCallback: function (f) {
            notificationRemovedCallbacks.push(f);
        },

        Icons: { None: "none", Question: "url(/Images/SemiQues.png)", Exclamation: "url(/Images/SemiEscl.png)", Info: "url(/Images/SemiInfo.png)" },
        OKActionOnly: [],
        OKAction: () => new UI.ModalAction("OK", true, "bgGreen", true),
        CancelAction: (cssClass) => new UI.ModalAction("Cancel", false, cssClass || "", true),

        ModalAction: function (text, value, cssClass, autoClose) {
            const self = this;
            this.autoClose = autoClose !== undefined ? autoClose : true;
            this.callback = null;
            this.text = Locale.l(text);
            this.value = value;
            this.notificationId = 0;
            this.click = async function () {
                if (self.autoClose === true) {
                    if (self.notificationId != 0) {
                        UI.RemoveLocalNotification(self.notificationId);
                    }
                    else {
                        await UI.HideModalAsync();
                    }
                }
                self.callback(self.value);
            };
            this.cssClass = cssClass || "";
        },

        PromptAsync: async function (title, text, existingValue, inputClass, inputFieldType, imageURI) {
            const OKAction = new UI.ModalAction("OK", true, "bgGreen");

            //If existingValue is a string, use that. If it's an object - use the 'text' property of that object and select the first 'sellength' characters
            const valueToUse = typeof existingValue === "string" ? existingValue : (existingValue?.text || "");

            $("#modalPromptInput")
                .val(valueToUse)
                .attr("type", inputFieldType || "text")
                .enterPressed(OKAction.click)
                .show();

            if (existingValue?.hasOwnProperty("selLength")) {
                $("#modalPromptInput")[0].setSelectionRange(0, existingValue.selLength);
            }

            if (imageURI != null) {
                $("#modalImage").attr("src", imageURI).show();
            }

            if (inputClass != null && inputClass != "") {
                $("#modalPromptInput").attr("class", inputClass);
                $(".modalcontents").attr("class", inputClass);
            }

            const modalResult = await UI.ShowModalAsync(title, text, UI.Icons.Question, [
                OKAction,
                new UI.ModalAction("Cancel", false)
            ]);

            $("#modalPromptInput").off("keydown");

            if (inputClass != null && inputClass != "") {
                $("#modalPromptInput").removeClass(inputClass);
                $(".modalcontents").removeClass(inputClass);
            }

            if (imageURI != null) {
                $("#modalImage").attr("src", "").hide();
            }

            return modalResult === true ? $("#modalPromptInput").val() : null;
        },

        ShowModalAsync: function (title, text, icon, actions, linkTitle, linkURL, advancedDetails) {
            $("#modaltitle").text(Locale.GetLocaleMessage(title));

            if (typeof (text) === "object") {
                $("#modalmessage").text(Locale.GetLocaleMessage(text.text));
                $("#modalsubtitle").text(Locale.GetLocaleMessage(text.subtitle));
            } else {
                $("#modalmessage").text(text || "");
                $("#modalsubtitle").text("");
            }

            $("#mainModal").css("background-image", icon);

            const buttonsArea = $("#mainModal .modalbuttons");
            buttonsArea.empty();

            if (linkTitle == null) {
                $("#relatedLinkArea").hide();
            }
            else {
                $("#relatedLinkA").attr("href", linkURL).attr("title", linkTitle).text(linkTitle);
                $("#relatedLinkArea").show();
            }

            if (advancedDetails == null || advancedDetails == undefined) {
                $("#modalAdvanced").hide();
            }
            else {
                $("#modalAdvancedText").text(advancedDetails);
                $("#modalAdvanced").show();
            }            

            const p = new Promise(function (resolve) {
                for (const action of actions) {
                    action.callback = resolve;
                    const newButton = $("<button>", { "class": (action.cssClass || "") }).append(
                        $("<span>", { text: Locale.GetLocaleMessage(action.text) })
                    );
                    newButton.on("click", action.click);
                    buttonsArea.append(newButton);
                }

                if (actions.length > 0) { buttonsArea.show(); } else { buttonsArea.hide(); }
                $("#mainModal").fadeIn();
                $("#mainModal .modalpanel").addClass("visible");
                $("#modalPromptInput").focus();
            });

            return p;
        },

        HideModal: function () {
            $("#modalPromptInput").hide();
            $("#mainModal .modalpanel").removeClass("visible");
            $("#mainModal").fadeOut();
        },

        HideModalAsync: function () {
            $("#modalPromptInput").hide();
            $("#mainModal .modalpanel").removeClass("visible");
            return $("#mainModal").fadeOut().promise();
        },

        UpdateDisplayMetrics: function (Metrics, Uptime) {
            metricsInfo.update(Metrics, Uptime);
        },

        SetCustomConsoleMessageProcesssor: function (callback)
        {
            customConsoleHandler = callback;
        },

        AddConsoleEntries: function (entries) {
            const consoleContainer = $("#consoleArea");
            const maxLines = 1000;

            if ($("#consoleArea .consoleHistoryNote").length === 0) {
                const noteEntry = $("<div>", { "class": "consoleEntry consoleHistoryNote" });
                const noteContents = $("<pre>", { "class": "consoleContents" });
                noteContents.append(
                    $("<div>", {
                        text: `⚠ Only the last ${maxLines} lines are shown here. Check the log file for full history.`,
                        style: "color: gray; font-style: italic;"
                    })
                );
                noteEntry.append(noteContents);
                $("#consoleArea").append(noteEntry);
            }

            if (entries.length === 0) { return; }

            for (const entry of entries) {
                const entryTimestamp = parseDate(entry.Timestamp);
                let needsNewTimestamp = false;

                if (lastEntryDay != entryTimestamp.getDay()) {
                    lastEntryDay = entryTimestamp.getDay();

                    let tsEntryDiv = $("<div>", { "class": "consoleEntry" });
                    let timestampDiv = $("<div>", { "class": "consoleTimestamp", text: entryTimestamp.toLocaleDateString() });
                    let emptyNameDiv = $("<div>", { "class": "consoleName" , text: " "});
                    tsEntryDiv.append(timestampDiv);
                    tsEntryDiv.append(emptyNameDiv);
                    consoleContainer.append(tsEntryDiv);
                }

                ///HACKY CODE THAT SHOULD BE REPLACED WITH SOMETHING BETTER
                ///Provides user-links to usernames mentioned in text.
                let availableNames = {};
                let nameData = {};

                $(".consoleUserEntry").each(function (i, e) {
                    const name = $(e).data("name").toString();
                    const id = $(e).data("id");
                    availableNames[name.toLowerCase()] = name;
                    nameData[name] = {};
                    nameData[name].id = id;
                    nameData[name].color = $(e).css("color");
                });
                ///END HACKY CODE

                if (lastConsoleEntry == null || entry.Source != lastEntrySource) {
                    let entryDiv = $("<div>", { "class": "consoleEntry" });
                    let sourceDiv = $("<div>", { "class": "consoleName", text: entry.Source, 'data-name': entry.Source, 'data-id': entry.SourceId });
                    sourceDiv.on("click", userClickCallback);
                    needsNewTimestamp = true;

                    if (nameData[entry.Source] != undefined) {
                        sourceDiv.css("color", nameData[entry.Source].color);
                    }

                    lastConsoleEntry = entryDiv;
                    lastEntrySource = entry.Source;

                    entryDiv.append(sourceDiv);
                    consoleContainer.append(entryDiv);
                }

                let style = "";
                if (/warning|failure/i.test(entry.Contents)) { style = "color:orange"; }
                if (/error|exception/i.test(entry.Contents)) { style = "color:red"; }
                if (/success/i.test(entry.Contents)) { style = "color:green"; }

                let contentsDiv = $("<div>", { text: entry.Contents, style: style });

                if (!customConsoleHandler(contentsDiv)) {
                    let dat = contentsDiv.html();

                    let nameKeys = Object.keys(availableNames);

                    for (let n = 0; n < nameKeys.length; n++) {
                        nameKeys[n] = nameKeys[n].escapeRegExp();
                    }

                    if (nameKeys.length > 0) {
                        const regex = new RegExp("\\b(" + nameKeys.join("|") + ")\\b", "gi");

                        dat = dat.replace(regex, function (s, theWord) {
                            const caseName = availableNames[theWord.toLowerCase()];
                            let el = $("<a>",
                                {
                                    "class": "consoleName",
                                    "data-name": caseName,
                                    "data-id": nameData[caseName].id,
                                    "style": "color:" + nameData[caseName].color,
                                    text: caseName
                                });
                            let asHTML = el.wrap('<div>').parent().html();
                            return asHTML;
                        });
                    }

                    contentsDiv.html(dat);
                }
                else {
                    contentsDiv.style = "";
                }

                contentsDiv.find(".consoleName").on("click", userClickCallback);

                const displayTime = entryTimestamp.get24hTime();

                let timestampDivEntry = $("<div>", { "class": "consoleTimestamp", text: displayTime });
                if (lastEntryTimestamp != displayTime || lastConsoleContents == null || needsNewTimestamp)
                {
                    lastConsoleEntry.append(timestampDivEntry);
                    lastEntryTimestamp = displayTime;

                    lastConsoleContents = $("<pre>", { "class": "consoleContents" });
                    lastConsoleEntry.append(lastConsoleContents);
                }
                lastConsoleContents.append(contentsDiv);
            }

            let allLines = consoleContainer.find(".consoleContents > div")
                .not(".consoleHistoryNote .consoleContents > div");

            if (allLines.length > maxLines) {
                allLines.slice(0, allLines.length - maxLines).remove();
            }

            consoleContainer.children(".consoleEntry").not(".consoleHistoryNote").each(function () {
                if ($(this).find(".consoleContents > div").length === 0) {
                    $(this).remove();
                }
            });

            scrollConsole = (window.getSelection().anchorNode === null || window.getSelection().type === "Caret");

            if (scrollConsole && consoleContainer[0] != undefined) {
                $(consoleContainer[0]).stop();
                $(consoleContainer[0]).animate({ scrollTop: consoleContainer[0].scrollHeight }, { duration: Math.min(50 * entries.length, 500) });
            }
        },

        SetCommandButtonsCallback: (callback) => $("[data-method]").on("click", callback),
        SetConsoleEnterCallback: (callback) => $("#consoleLineEntry").enterPressed(callback),

        SetUserClickCallback: function (callback) {
            userClickCallback = callback;
        },

        ShowPopupMenu: function (wizardTab, e)
        {
            e.preventDefault();
            e.stopPropagation();

            UI.ShowWizard(wizardTab);

            let el = $(wizardTab + " .contextMenu");

            let targetX, targetY;

            if (e) {
                targetY = e.pageY - 48;
                targetX = e.pageX;

                if (targetX + el.width() > $(window).width() - 24) {
                    targetX = $(window).width() - el.width() - 24;
                }

                const bottom = targetY + el.height();
                const d = $(window).height() - bottom - 48;

                if (d < 0) {
                    targetY += (d - 48);
                }
            }
            else {
                targetX = ($(window).width() / 2) - (el.width() / 2);
                targetY = ($(window).height() / 2) - (el.height() / 2);
            }

            el.css("top", targetY + "px");
            el.css("left", targetX + "px");
        },

        ShowWizard: function (baseTab) {
            $(baseTab).fadeIn();
            $(baseTab).children(".wizardContents").first().addClass("wizardVisible");
            return Promise.resolve();
        },

        HideWizard: async function () {
            let wizTab = $(".wizardVisible");
            wizTab.removeClass("wizardVisible");
            await wizTab.parent().fadeOut().promise();
        },

        SwapWizard: async function (newWizPage) {
            let toHide = $(".wizardVisible").first();

            $(newWizPage).addClass("wizardVisible");
            await sleepAsync(500);
            toHide.removeClass("wizardVisible");
        },

        wait2sec: async function (el) {
            $(el).addClass("slideWaiting");
            await sleepAsync(2000);
            $(el).removeClass("slideWaiting");
        },

        GetIsMobile: isMobileView,

        ShowUserInfo: function (Name, ID, IP, DateJoined) {
            $("#tab_console_name").text(Name);
            $("#tab_console_uuid").text(ID);
            $("#tab_console_ip").text(IP);
            if (DateJoined != null) {
                $("#tab_console_join").text(parseDate(DateJoined));
            } else {
                $("#tab_console_join").text();
            }
        }
    };

    UIObject.OKActionOnly = [new UIObject.ModalAction("OK", true, "bgGreen", true)];

    return UIObject;
})();