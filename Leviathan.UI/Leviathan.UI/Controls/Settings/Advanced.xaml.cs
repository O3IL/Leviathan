using Leviathan.UI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Leviathan.Mvvm.Commands;
using Leviathan.Mvvm.Models.Theme;
using Leviathan.Mvvm.ViewModels;
using Leviathan.UI.Common.Theme;


// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Leviathan.UI.Controls.Settings
{
    public sealed partial class Advanced : Page
    {
        public IVisualThemeSelector VTSelector => VisualThemeSelector.Current;
        
        public SettingsViewModel Settings { get; } = App.Settings;

        public LeviathanCommands Commands => App.Commands;

        public Advanced()
        {
            this.InitializeComponent();
            DataContext = Settings;
        }
    }
}
