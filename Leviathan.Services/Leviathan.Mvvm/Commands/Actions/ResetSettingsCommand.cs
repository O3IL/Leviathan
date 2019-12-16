using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ResetSettingsCommand : SimpleCommand<SettingsViewModel>
    {
        public ResetSettingsCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.ResetSettings();

                return Task.CompletedTask;
            };
        }
    }
}