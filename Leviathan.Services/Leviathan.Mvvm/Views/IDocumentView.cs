using System;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.ViewModels;

namespace Leviathan.Mvvm.Views
{
    public interface IDocumentView : IView
    {
        DocumentViewModel ViewModel { get; set; }

        event Action<IDocumentView, LeviathanCommands> Initialize;
        event Func<DocumentViewModel, Task<bool>> ExitApplication;
        event Func<DocumentViewModel, StorageFile, Task> LoadFromFile;
        event Action<RoutedEventArgs> GainedFocus;
    }
}