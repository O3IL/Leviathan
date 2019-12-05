﻿using Windows.UI.Xaml.Controls;
using QuickPad.Mvvm.Commands;
using QuickPad.Mvvm.ViewModels;
using QuickPad.UI.Common.Theme;

// The Content Dialog item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace QuickPad.UI.Common.Dialogs
{
    public sealed partial class WelcomeDialog
    {
        public VisualThemeSelector VisualThemeSelector => VisualThemeSelector.Current;
        public QuickPadCommands Commands { get; }

        public WelcomeDialog(QuickPadCommands commands)
        {
            Commands = commands;
            this.InitializeComponent();
        }
    }
}