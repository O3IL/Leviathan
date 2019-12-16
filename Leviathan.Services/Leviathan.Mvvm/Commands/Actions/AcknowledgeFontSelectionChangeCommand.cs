using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class AcknowledgeFontSelectionChangeCommand : SimpleCommand<SettingsViewModel>
    {
        public AcknowledgeFontSelectionChangeCommand()
        {
            Executioner = settings =>
            {
                //open settings page
                settings.AcknowledgeFontSelectionChange = true;

                return Task.CompletedTask;
            };
        }
    }
}