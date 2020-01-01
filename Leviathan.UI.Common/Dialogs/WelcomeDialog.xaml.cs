using Windows.UI.Xaml.Controls;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.ViewModels;
using Leviathan.UI.Common.Theme;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Leviathan.UI.Common.Dialogs
{
    public sealed partial class WelcomeDialog
    {
        public IVisualThemeSelector VtSelector => VisualThemeSelector.Current;
        public LeviathanCommands Commands { get; }

        public WelcomeDialog()
        {
            this.InitializeComponent();
        }

        private void CmdClose_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Hide();
        }
    }
}
