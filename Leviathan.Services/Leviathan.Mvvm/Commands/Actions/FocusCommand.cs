using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class FocusCommand : SimpleCommand<SettingsViewModel>
    {
        public FocusCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.CurrentMode = "LaunchFocusMode";

                return Task.CompletedTask;
            };
        }
    }
}