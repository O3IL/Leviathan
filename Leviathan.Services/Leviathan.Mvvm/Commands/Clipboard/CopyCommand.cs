using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Clipboard
{

    public class CopyCommand : SimpleCommand<DocumentViewModel>
    {
        public CopyCommand()
        {
            CanExecuteEvaluator = viewModel => viewModel.SelectedText.Length > 0;

            Executioner = viewModel =>
            {
                //send the selected text to the clipboard
                var dataPackage = new DataPackage {RequestedOperation = DataPackageOperation.Copy};
                dataPackage.SetText(viewModel.SelectedText);
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
                Windows.ApplicationModel.DataTransfer.Clipboard.Flush();

                return Task.CompletedTask;
            };
        }
    }

    public class DeleteCommand : SimpleCommand<DocumentViewModel>
    {
        public DeleteCommand()
        {
            CanExecuteEvaluator = viewModel => viewModel.SelectedText.Length > 0;

            Executioner = viewModel =>
            {
                //send the selected text to the clipboard
                viewModel.SelectedText = string.Empty;

                return Task.CompletedTask;
            };
        }
    }
}