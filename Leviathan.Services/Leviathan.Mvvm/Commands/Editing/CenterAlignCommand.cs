using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class CenterAlignCommand : SimpleCommand<DocumentViewModel>
    {
        public CenterAlignCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.Document.Selection.ParagraphFormat.Alignment = ParagraphAlignment.Center;

                viewModel.OnPropertyChanged(nameof(viewModel.Text));

                return Task.CompletedTask;
            };
        }
    }
}