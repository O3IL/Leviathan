using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ShowMenusCommand : SimpleCommand<SettingsViewModel>
    {
        public ShowMenusCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.CurrentMode = "LaunchClassicMode";

                return Task.CompletedTask;
            };
        }
    }
}