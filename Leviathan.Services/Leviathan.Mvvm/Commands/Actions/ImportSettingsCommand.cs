using System.Threading.Tasks;
using Leviathan.Mvvm.ViewModels;


namespace Leviathan.Mvvm.Commands.Actions
{
    public class ImportSettingsCommand : SimpleCommand<SettingsViewModel>
    {
        public ImportSettingsCommand()
        {
            Executioner = async settings =>
            {
                //open settings page
                await settings.ImportSettings();
            };
        }
    }
}