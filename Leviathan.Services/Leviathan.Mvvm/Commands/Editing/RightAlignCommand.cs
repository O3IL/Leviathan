using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class RightAlignCommand : SimpleCommand<DocumentViewModel>
    {
        public RightAlignCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Right;
                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}