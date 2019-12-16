﻿using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ShowCommandBarCommand : SimpleCommand<SettingsViewModel>
    {
        public ShowCommandBarCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.CurrentMode = "LaunchDefaultMode";

                return Task.CompletedTask;
            };
        }
    }
    public class ShowFontsCommand : SimpleCommand<SettingsViewModel>
    {
        public ShowFontsCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.ShowSettings = true;
                settings.ShowSettingsTab = SettingsViewModel.SettingsTabs.Fonts;

                return Task.CompletedTask;
            };
        }
    }

}