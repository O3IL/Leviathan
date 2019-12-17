using System;
using Windows.UI.Xaml.Controls;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.ViewModels;
using Leviathan.Mvvm.Views;
using Leviathan.UI.Common;
using Leviathan.UI.Common.Theme;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Leviathan.UI.Controls
{
    public sealed partial class FindAndReplaceView : UserControl
    {
        private DocumentViewModel _documentViewModel;
        public IVisualThemeSelector VTSelector => VisualThemeSelector.Current;

        public SettingsViewModel Settings => App.Settings;

        public LeviathanCommands Commands => App.Commands;

        public IFindAndReplaceView ViewModel => DocumentViewModel?.FindAndReplaceViewModel;
        
        public DocumentViewModel DocumentViewModel
        {
            get => _documentViewModel;
            set
            {
                if (_documentViewModel == value || value == null) return;

                _documentViewModel = value;

                DataContext = _documentViewModel.FindAndReplaceViewModel;

                App.Controller.AddView(ViewModel);
            }
        }

        public FindAndReplaceView()
        {
            this.InitializeComponent();

            if (ViewModel != null)
            {
                DataContext = ViewModel;
            }
        }

    }
}
