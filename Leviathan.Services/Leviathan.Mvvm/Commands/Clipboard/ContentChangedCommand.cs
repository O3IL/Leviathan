using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Clipboard
{
    class ContentChangedCommand : SimpleCommand<DocumentViewModel>
    {
        public ContentChangedCommand()
        {
            CanExecuteEvaluator = viewModel => viewModel.SelectedText.Length > 0;

            Executioner = async viewModel =>
            {
                //send the selected text to the clipboard
                DataPackageView clipboardContent = Windows.ApplicationModel.DataTransfer.Clipboard.GetContent();
                var dataPackage = new DataPackage();
                dataPackage.SetText(await clipboardContent.GetTextAsync());
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
                Windows.ApplicationModel.DataTransfer.Clipboard.Flush();
            };
        }
    }
}
