using Windows.UI.Xaml.Controls;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.UI.Common.Theme;
using Leviathan.Mvvm.Commands;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Leviathan.UI.Common.Dialogs
{
    public sealed partial class GoToLine : ContentDialog
    {
        public IVisualThemeSelector VTSelector => VisualThemeSelector.Current;
        public LeviathanCommands Commands { get; }
        public GoToLine()
        {
            this.InitializeComponent();
        }
    }
}
