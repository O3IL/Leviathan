using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ExportSettingsCommand : SimpleCommand<SettingsViewModel>
    {
        public ExportSettingsCommand()
        {
            Executioner = async settings =>
            {
                //open settings page
                await settings.ExportSettings();
            };
        }
    }
}