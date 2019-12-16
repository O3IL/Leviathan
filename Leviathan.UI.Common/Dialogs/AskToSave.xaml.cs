using Windows.UI.Xaml.Controls;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.ViewModels;
using Leviathan.UI.Common.Theme;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Leviathan.UI.Common.Dialogs
{
    public sealed partial class AskToSave
    {
        private DocumentViewModel _viewModel;
        public IVisualThemeSelector VTSelector => VisualThemeSelector.Current;
        public LeviathanCommands Commands { get; }

        public DocumentViewModel ViewModel
        {
            get => _viewModel;
            set
            {
                if (_viewModel == value) return;

                DataContext = _viewModel = value;
            }
        }

        public AskToSave(LeviathanCommands commands)
        {
            Commands = commands;
            this.InitializeComponent();
        }

        private void AskToSave_OnSecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            
        }
    }
}
