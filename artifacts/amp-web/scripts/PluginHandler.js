/// <reference path="UI.js" />
/* eslint eqeqeq: 0, "no-extra-parens": "off" */
/* global UI */

const PluginHandler = (function () {
    "use strict";
    let Plugins = {};
    let PluginList = [];
    let FeatureSet = [];

    let PluginHandlerObject = {
        SetFeatures: (features) => { FeatureSet = features; },
        HasFeature: (feature) => FeatureSet.contains(feature),
        RunPluginsPostAMPInit: function()
        {
            for (const plugin of Object.values(Plugins)) {
                if (!plugin.hasOwnProperty("AMPDataLoaded")) { continue; }
                plugin.AMPDataLoaded(plugin);
            }
        },
        NotifyPluginSettingChanged: function(node, value)
        {
            for (const plugin of Object.values(Plugins)) {
                if (!plugin.hasOwnProperty("SettingChanged")) { continue; }
                plugin.SettingChanged(node, value);
            }
        },
        NotifyPluginFailureState: function(newState)
        {
            for (const plugin of Object.values(Plugins)) {
                if (!plugin.hasOwnProperty("StartupFailure")) { continue; }
                plugin.StartupFailure(newState);
            }
        },
        NotifyPluginMessage: function(source, message, parameters)
        {
            for (const plugin of Object.values(Plugins))
            {
                if (!plugin.hasOwnProperty("PushedMessage")) { continue; }
                plugin.PushedMessage(source, message, parameters);
            }
        },
        GetSearchResults: async function(query)
        {
            let data = [];
            for (const plugin of Object.values(Plugins)) {
                if (!plugin.hasOwnProperty("GetSearchResultsAsync")) { continue; }

                const result = await plugin.GetSearchResultsAsync(query);
                if (result != null)
                {
                    data.push(result);
                }
            }
            return data;
        },
        LoadPluginAsync: async function (pluginName)
        {
            const pluginRoot = `/Plugins/${pluginName}/`;
            const rnd = "?t=" + (0 + Date.now());
            const scriptFile = pluginRoot + "Plugin.js" + rnd;
            //add pluginName to PluginList, don't continue if it's already loaded.
            if (PluginList.contains(pluginName)) {
                console.log(`Plugin ${pluginName} already loaded.`);
                return;
            }
            PluginList.push(pluginName);

            async function scriptLoaded (data) {
                const localPluginName = pluginName;
                console.log(`Running init for ${localPluginName}`);
                data = "'use strict';\n" + data;
                let pluginConstructor = new Function(data);
                let module = null;
                function create() {
                    let constr = new pluginConstructor();
                    return constr;
                }
                try {
                    module = create();
                }
                catch (e) {
                    await UI.ShowModalAsync("Plugin Error", `An error ocurred while loading plugin ${localPluginName}. Startup will continue, but this plugin will not be loaded.`, UI.Icons.Exclamation, UI.OKActionOnly, null, null, `${e.message}\n\n${e.stack}`);
                    return;
                }
                let loadedPlugin = module.plugin;
                let tabs = module.tabs || module.plugin.tabs || [];

                Plugins[pluginName] = loadedPlugin;
                if (loadedPlugin.PreInit !== undefined) {
                    loadedPlugin.PreInit();
                }

                loadedPlugin.name = pluginName;

                if (tabs === undefined) { module.tabs = []; }

                if (module.stylesheet !== undefined && module.stylesheet !== "") {
                    const cssPath = pluginRoot + module.stylesheet;
                    const stylesheet = $("<link/>", { type: "text/css", rel: "stylesheet", href: cssPath + rnd });
                    $("head").append(stylesheet);
                }

                let tabPromises = [];

                for (const tab of tabs) {
                    if (tab.Disabled === true) { continue; }
                    if (tab.RequiredPermission != null && !userHasPermission(tab.RequiredPermission)) { continue; }
                    if (tab.FeatureSet && !FeatureSet.contains(tab.FeatureSet)) { continue; }

                    const tabId = `tab_${pluginName}_${tab.ShortName}`;

                    tab.id = tabId;
                    let bodyTab = $("<div class='bodyTab pluginTabContents' style='display:none;'></div>");
                    bodyTab.attr("id", tabId);

                    if (tab.IsWizard == null || !tab.IsWizard) {
                        tab.vm = UI.AddSideMenuItem(tab.Name, "#" + tabId, tab.Icon, tab.Click || $.noop, tab.Order || 0, tab.IsDefault || false);
                        tab.vm.disabled(true);
                        tab.vm.bodyElement = bodyTab;
                        if (tab.PopHandler != null) {
                            UI.RegisterPopstateHandler(tab.vm.shortName, tab.PopHandler);
                        }
                    }

                    if (tab.IsWizard != null && tab.IsWizard) { bodyTab.addClass("wizardTab"); }
                    if (tab.BodyClass) { bodyTab.addClass(tab.BodyClass); }
                    if (tab.ViewModel) { bodyTab.attr("data-viewmodel", tab.ViewModel); }

                    const loadUrl = (tab.ExternalTab ? tab.File : pluginRoot + tab.File + rnd);

                    if (tab.IsWizard != null && tab.IsWizard) {
                        $("#mainBodyArea").append(bodyTab);
                    }
                    else {
                        //MB: Tabs not loading? Loading in the wrong place? This is probably why!
                        $("#tab_support").after(bodyTab);
                    }

                    tabPromises.push(new Promise(resolve => bodyTab.load(loadUrl, resolve)))
                }

                await Promise.all(tabPromises);

                if (module.features !== undefined)
                {
                    Features[pluginName] = {};
                    for (const feature of Object.keys(module.features)) {
                        Features[pluginName][feature] = module.features[feature];
                    }
                }

                if (loadedPlugin.PostInit !== undefined) {
                    loadedPlugin.PostInit();
                }

                for (const tab of tabs) {
                    Locale.ApplyLocale(`#${tab.id}`);
                    $(`#${tab.id} a`).on("click", UI.HandleClickedURL);
                    tab.vm?.disabled(false);
                }
            }

            const data = await fetch(scriptFile);
            await scriptLoaded(await data.text());
        },
        PluginIsLoaded: (pluginName) =>  Plugins[pluginName] !== undefined,
        LoadPluginExternalScript: function (pluginName, assetPath, callback) {
            const scriptFile = `/Plugins/${pluginName}/${assetPath}`;

            const doc = document, elementType = 'script',
                newEl = doc.createElement(elementType),
                firstScript = doc.getElementsByTagName(elementType)[0];
            newEl.src = scriptFile;
            if (callback) { newEl.addEventListener('load', function (e) { callback(null, e); }, false); }
            firstScript.parentNode.insertBefore(newEl, firstScript);
        },
        LoadPluginExternalScriptAsync: async function (pluginName, assetPath) {
            return new Promise(function (accept) {
                PluginHandlerObject.LoadPluginExternalScript(pluginName, assetPath, accept);
            });
        }
    };

    return PluginHandlerObject;
})();