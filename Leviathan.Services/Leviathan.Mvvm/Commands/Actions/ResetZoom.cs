using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class ResetZoom : SimpleCommand<DocumentViewModel>
    {
        public ResetZoom()
        {
            Executioner = viewModel =>
            {
                viewModel.ScaleValue = 1;

                return Task.CompletedTask;
            };
        }
    }
}