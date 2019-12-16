using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class ColorCommand : SimpleCommand<DocumentViewModel>
    {
        public ColorCommand()
        {
            Executioner = viewModel =>
            {
                if (viewModel == null) return Task.CompletedTask;

                viewModel.Document.Selection.CharacterFormat.ForegroundColor = viewModel.FontColor;
                viewModel.OnPropertyChanged(nameof(viewModel.RtfText));

                return Task.CompletedTask;
            };
        }
    }
}