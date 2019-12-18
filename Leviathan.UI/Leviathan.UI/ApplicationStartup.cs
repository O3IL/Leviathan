using Windows.UI.Xaml;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Leviathan.Mvc;
using Leviathan.Mvvm;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.Commands.Actions;
using Leviathan.Mvvm.Commands.Clipboard;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.ViewModels;
using Leviathan.Mvvm.Views;
using Leviathan.UI.Common;
using Leviathan.UI.Common.Dialogs;
using Leviathan.UI.Common.Theme;

namespace Leviathan.UI
{
    public class ApplicationStartup
    {
        public static void ConfigureServices(IServiceCollection services)
        {
            services.AddSingleton<PasteCommand, PasteCommand>();
            services.AddTransient<AskToSave, AskToSave>();
            services.AddSingleton(provider => new LeviathanCommands(provider.GetService<PasteCommand>()));
            services.AddTransient<DocumentViewModel, DocumentViewModel>();
            services.AddTransient<IFindAndReplaceView, FindAndReplaceViewModel>();
            services.AddSingleton<SettingsViewModel, SettingsViewModel>();
            services.AddSingleton<DefaultTextForegroundColor, DefaultTextForegroundColor>();
            services.AddSingleton(_ => Application.Current as IApplication);
            services.AddSingleton<ApplicationController, ApplicationController>();
            services.AddSingleton<IVisualThemeSelector, VisualThemeSelector>();
            services.AddSingleton<MainPage, MainPage>();

            // Add additional services here.
        }

        public static void Configure(IConfigurationBuilder configuration)
        {
            // Add additional configuration here.
        }
    }
}
