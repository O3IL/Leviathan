using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class ZoomInCommand : SimpleCommand<DocumentViewModel>
    {
        public ZoomInCommand()
        {
            Executioner = viewModel =>
            {
                if (viewModel.ScaleValue <= 4)
                {
                    viewModel.ScaleValue += 0.1f;
                }

                return Task.CompletedTask;
            };
        }
    }
}