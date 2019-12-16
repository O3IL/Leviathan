using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class UnderlineCommand : SimpleCommand<DocumentViewModel>
    {
        public UnderlineCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.BeginUndoGroup();
                //set the selected text to be bold if not already
                //if the text is already bold it will make it regular
                var selectedText = viewModel.Document.Selection;
                if (selectedText != null)
                {
                    var charFormatting = selectedText.CharacterFormat;
                    if (charFormatting.Underline == UnderlineType.None)
                        charFormatting.Underline = UnderlineType.Single;
                    else
                        charFormatting.Underline = UnderlineType.None;
                    selectedText.CharacterFormat = charFormatting;
                }

                viewModel.Document.EndUndoGroup();

                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}