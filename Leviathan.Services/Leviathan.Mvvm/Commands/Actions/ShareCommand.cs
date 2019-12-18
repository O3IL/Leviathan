using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Actions
{
    public class ShareCommand : SimpleCommand<DocumentViewModel>
    {
        public ShareCommand()
        {
            Executioner = viewModel =>
            {
                DataTransferManager.ShowShareUI();
                return Task.CompletedTask;
            };
        }

    }
}