﻿using System.Threading.Tasks;
using Windows.ApplicationModel.DataTransfer;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Clipboard
{

    public class SearchWithBing : SimpleCommand<DocumentViewModel>
    {
        public SearchWithBing()
        {
            CanExecuteEvaluator = viewModel => viewModel.SelectedText.Length > 0;

            Executioner = async viewModel =>
            {
                await Windows.System.Launcher.LaunchUriAsync(new Uri($"https://www.bing.com/search?q={viewModel.SelectedText}"));
            };
        }
    }
}