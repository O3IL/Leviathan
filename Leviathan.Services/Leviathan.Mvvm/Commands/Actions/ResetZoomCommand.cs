using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class ResetZoomCommand : SimpleCommand<DocumentViewModel>
    {
        public ResetZoomCommand()
        {
            Executioner = viewModel =>
            {
                viewModel.ScaleValue = 1f;

                return Task.CompletedTask;
            };
        }
    }
}