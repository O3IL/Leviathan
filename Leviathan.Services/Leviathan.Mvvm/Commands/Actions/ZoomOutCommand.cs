using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class ZoomOutCommand : SimpleCommand<DocumentViewModel>
    {
        public ZoomOutCommand()
        {
            Executioner = viewModel =>
            {
                if (viewModel.ScaleValue >= 0.5)
                {
                    viewModel.ScaleValue -= 0.1f;
                }

                return Task.CompletedTask;
            };
        }
    }
}