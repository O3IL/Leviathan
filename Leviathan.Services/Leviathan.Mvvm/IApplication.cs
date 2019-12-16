using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm
{
    public interface IApplication
    {
        DocumentViewModel CurrentViewModel { get; }
    }
}