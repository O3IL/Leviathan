﻿using System.Threading.Tasks;
using Windows.UI.Text;
using Leviathan.Mvvm.ViewModels;
using System;

namespace Leviathan.Mvvm.Commands.Editing
{
    public class UpdateToolbar : SimpleCommand<DocumentViewModel>
    {
        public UpdateToolbar()
        {
            Executioner = viewModel =>
            {
                var selectedText = viewModel.Document.Selection;
                viewModel.SelBold =  Convert.ToBoolean(selectedText.CharacterFormat.Bold);
                viewModel.SelItalic = Convert.ToBoolean(selectedText.CharacterFormat.Italic);
                viewModel.SelUnderline = (selectedText.CharacterFormat.Underline == UnderlineType.Single);
                viewModel.SelStrikethrough = Convert.ToBoolean(selectedText.CharacterFormat.Strikethrough);
                viewModel.SelBullets = (selectedText.ParagraphFormat.ListType == MarkerType.Bullet);
                viewModel.FontColor = selectedText.CharacterFormat.ForegroundColor;
                viewModel.SelCenter = (selectedText.ParagraphFormat.Alignment == ParagraphAlignment.Center);
                viewModel.SelLeft = (selectedText.ParagraphFormat.Alignment == ParagraphAlignment.Left);
                viewModel.SelRight = (selectedText.ParagraphFormat.Alignment == ParagraphAlignment.Right);
                viewModel.SelJustify = (selectedText.ParagraphFormat.Alignment == ParagraphAlignment.Justify);

                return Task.CompletedTask;
            };
        }
    }
}