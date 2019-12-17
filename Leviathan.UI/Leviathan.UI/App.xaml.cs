﻿using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Globalization;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Leviathan.Mvc;
using Leviathan.Mvc.Hosting;
using Leviathan.UI.Common;
using Leviathan.Mvvm;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.ViewModels;
using Microsoft.AppCenter.Crashes;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter;
using System.Runtime.InteropServices;


namespace Leviathan.UI
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    // ReSharper disable once ArrangeTypeModifiers
    sealed partial class App : IApplication
    {
        private static SettingsViewModel _settings;
        public static ApplicationHost Host { get; set; }
        public static ApplicationController Controller => Host?.Controller;
        public static IServiceProvider Services => Host?.Services;
        public static SettingsViewModel Settings => _settings ??= Host?.Services.GetService<SettingsViewModel>();

        public static LeviathanCommands Commands => Services.GetService<LeviathanCommands>();

        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            AppCenter.Start("64a87afd-a838-4cd0-a46d-b3ea528dd53d", typeof(Analytics), typeof(Crashes));

            Host = new HostBuilder()
                .ConfigureAppConfiguration(builder =>
                {
                    builder.Properties.Add("Logging:LogLevel:Default", "Debug");
                    builder.Properties.Add("Logging:LogLevel:System", "Information");
                    builder.Properties.Add("Logging:LogLevel:Microsoft", "Information");
                    builder.Properties.Add("Logging:Console:IncludeScopes", true);
                })
                .ConfigureServices(ApplicationStartup.ConfigureServices)
                .ConfigureServices(collection =>
                    {
                        collection.AddSingleton<ResourceDictionary>(provider => this.Resources);
                    })
                .ConfigureLogging(builder =>
                {
                    builder.AddConsole();
                })
                .ConfigureHostConfiguration(ApplicationStartup.Configure)
                .BuildApplicationHost();

            this.InitializeComponent();

            this.Suspending += OnSuspending;

            ApplicationLanguages.PrimaryLanguageOverride = Settings.DefaultLanguage?.ID ?? "en-us";
        }

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used such as when the application is launched to open a specific file.
        /// </summary>
        /// <param name="e">Details about the launch request and process.</param>
        protected override void OnLaunched(LaunchActivatedEventArgs e)
        {
            MainPage mainPage = Window.Current.Content as MainPage;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (mainPage == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                mainPage = Services.GetService<MainPage>();

                if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                }

                if (!Resources.ContainsKey(nameof(LeviathanCommands))) Resources.Add(nameof(LeviathanCommands), Services.GetService<LeviathanCommands>());
                if (!Resources.ContainsKey(nameof(SettingsViewModel))) Resources.Add(nameof(SettingsViewModel), Services.GetService<SettingsViewModel>());

                // Place the frame in the current Window
                Window.Current.Content = mainPage;
            }

            if (e.PrelaunchActivated == false)
            {
                if (mainPage == null)
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    mainPage = Services.GetService<MainPage>();
                }
                // Ensure the current window is active
                Window.Current.Activate();
            }
        }

        protected override void OnFileActivated(FileActivatedEventArgs args)
        {
            MainPage mainPage = null;

            if (Window.Current.Content is MainPage) mainPage = Window.Current.Content as MainPage;

            if (!Resources.ContainsKey(nameof(LeviathanCommands)))
                Resources.Add(nameof(LeviathanCommands), Services.GetService<LeviathanCommands>());
            if (!Resources.ContainsKey(nameof(SettingsViewModel)))
                Resources.Add(nameof(SettingsViewModel), Services.GetService<SettingsViewModel>());

            if (mainPage == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                mainPage = Services.GetService<MainPage>();
            }

            // The number of files received is args.Files.Size
            // The name of the first file is args.Files[0].Name
            if (args.Files.Count > 0 && args.Files[0] != null)
            {
                mainPage.FileToLoad = args.Files[0] as StorageFile;
            }

            Window.Current.Content = mainPage;
            Window.Current.Activate();

        }

        /// <summary>
        /// Invoked when Navigation to a certain page fails
        /// </summary>
        /// <param name="sender">The Frame which failed navigation</param>
        /// <param name="e">Details about the navigation failure</param>
        void OnNavigationFailed(object sender, NavigationFailedEventArgs e)
        {
            throw new Exception("Failed to load Page " + e.SourcePageType.FullName);
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            deferral.Complete();
        }

        public DocumentViewModel CurrentViewModel => Services.GetService<MainPage>().ViewModel;
    }
}
