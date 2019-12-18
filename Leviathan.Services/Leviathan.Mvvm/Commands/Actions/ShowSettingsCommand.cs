using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ShowSettingsCommand : SimpleCommand<SettingsViewModel>
    {
        public ShowSettingsCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.ShowSettings = !settings.ShowSettings;

                return Task.CompletedTask;
            };
        }
    }
}