using System.ComponentModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Leviathan.Mvvm.ViewModels;
using Leviathan.UI.Common;
using Leviathan.Mvvm.Commands;
using Microsoft.Extensions.DependencyInjection;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.Views;
using Leviathan.UI.Common.Theme;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Leviathan.UI.Controls
{
    public sealed partial class MenuBar : UserControl
    {
        public IVisualThemeSelector VTSelector => VisualThemeSelector.Current;

        public SettingsViewModel Settings => App.Settings;

        public LeviathanCommands Commands => App.Commands;

        public DocumentViewModel ViewModel
        {
            get => DataContext as DocumentViewModel;
            set
            {
                if (value == null || DataContext == value) return;

                DataContext = value;
            }
        }

        public MenuBar()
        {
            this.InitializeComponent();

            Settings.PropertyChanged += SettingsOnPropertyChanged;
        }

        private void SettingsOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case nameof(SettingsViewModel.CurrentMode):
                    Bindings.Update();
                    break;
            }
        }
    }
}
