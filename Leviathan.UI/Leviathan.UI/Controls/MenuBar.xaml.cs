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
using System.Collections.ObjectModel;
using System.Linq;
using System;
using System.Collections.Generic;

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

        List<string> _listSuggestion = null;

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // Only get results when it was a user typing, 
            // otherwise assume the value got filled in by TextMemberPath 
            // or the handler for SuggestionChosen.
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                List<string> _nameList = new List<string>
                {
                    "*row(",
                    "*row+(",
                    "∆List(",
                    "1-Var Stats",
                    "a+bi",
                    "abs(",
                    "and",
                    "angle(",
                    "Ans",
                    "Archive",
                    "Asm(",
                    "AsmComp(",
                    "AsmPrgm",
                    "augment(",
                    "AxesOff",
                    "AxesOn",
                    "Circle(",
                    "Clear Entries",
                    "ClrAllLists",
                    "ClrDraw",
                    "ClrHome",
                    "ClrList",
                    "cumSum(",
                    "DelVar",
                    "dim(",
                    "Disp",
                    "DispGraph",
                    "Else",
                    "End",
                    "expr(",
                    "Fill(",
                    "FnOff",
                    "FnOn",
                    "For(",
                    "fPart(",
                    "gcd(",
                    "Get(",
                    "GetCalc(",
                    "getKey",
                    "Goto",
                    "Horizontal",
                    "If",
                    "imag(",
                    "Input",
                    "inString(",
                    "int(",
                    "iPart(",
                    "Lbl",
                    "length(",
                    "Line(",
                    "max(",
                    "mean(",
                    "Menu(",
                    "min(",
                    "nCr",
                    "not(",
                    "or",
                    "Output(",
                    "Pause",
                    "Plot1(",
                    "Plot2(",
                    "Plot3(",
                    "PlotsOff",
                    "PlotsOn",
                    "prgm",
                    "Prompt",
                    "Pt-Change(",
                    "Pt-Off(",
                    "Pt-On(",
                    "Pxl-Change(",
                    "Pxl-Off(",
                    "Pxl-On(",
                    "pxl-Test(",
                    "rand",
                    "randBin(",
                    "randInt(",
                    "real(",
                    "RecallGDB",
                    "RecallPic",
                    "ref(",
                    "Repeat",
                    "Return",
                    "round(",
                    "row+(",
                    "rowSwap(",
                    "rref(",
                    "Send(",
                    "seq(",
                    "SetUpEditor",
                    "SortA(",
                    "SortD(",
                    "Stop",
                    "StoreGDB",
                    "StorePic",
                    "String►Equ(",
                    "sub(",
                    "sum(",
                    "Text(",
                    "Then",
                    "Trace",
                    "UnArchive",
                    "Vertical",
                    "While",
                    "xor",

                    // fr
                    "fr=*ligne(",
                    "fr=*ligne+(",
                    "fr=∆Liste(",
                    "fr=a+bi",
                    "fr=abs(",
                    "fr=AffGraph",
                    "fr=Archive",
                    "fr=argument(",
                    "fr=arrondi(",
                    "fr=Asm(",
                    "fr=AsmComp(",
                    "fr=AsmPrgm",
                    "fr=AxesAff",
                    "fr=AxesNAff",
                    "fr=BinAléat(",
                    "fr=Capt(",
                    "fr=CaptVar(",
                    "fr=carChaîne(",
                    "fr=Cercle(",
                    "fr=chaîne(",
                    "fr=Chaîne►Equ(",
                    "fr=codeTouch(",
                    "fr=Combinaison",
                    "fr=DéSarchive",
                    "fr=dim(",
                    "fr=Disp",
                    "fr=Efface entrées",
                    "fr=EffDessin",
                    "fr=EffEcr",
                    "fr=EffListe",
                    "fr=EffToutListes",
                    "fr=EffVar",
                    "fr=Else",
                    "fr=End",
                    "fr=ent(",
                    "fr=entAléat(",
                    "fr=Envoi(",
                    "fr=et",
                    "fr=expr(",
                    "fr=FonctAff",
                    "fr=FonctNAff",
                    "fr=For(",
                    "fr=Gauss(",
                    "fr=Gauss-Jordand(",
                    "fr=Goto",
                    "fr=Graph1(",
                    "fr=Graph2(",
                    "fr=Graph3(",
                    "fr=GraphAff",
                    "fr=GraphNAff",
                    "fr=Horizontale",
                    "fr=If",
                    "fr=imag(",
                    "fr=Input",
                    "fr=Lbl",
                    "fr=Ligne(",
                    "fr=ligne+(",
                    "fr=ListesDéfaut(",
                    "fr=longueur(",
                    "fr=max(",
                    "fr=Menu(",
                    "fr=min(",
                    "fr=moyenne(",
                    "fr=nbrAléat",
                    "fr=non(",
                    "fr=ou",
                    "fr=ouExcl",
                    "fr=Output(",
                    "fr=partDéc(",
                    "fr=partEnt(",
                    "fr=Pause",
                    "fr=permutLigne(",
                    "fr=pgcd(",
                    "fr=prgm",
                    "fr=Prompt",
                    "fr=Pt-Aff(",
                    "fr=Pt-Change(",
                    "fr=Pt-NAff(",
                    "fr=Pxl-Aff(",
                    "fr=Pxl-Change(",
                    "fr=Pxl-NAff(",
                    "fr=pxl-Test(",
                    "fr=RappelBDG",
                    "fr=RappelImage",
                    "fr=réel(",
                    "fr=Remplir(",
                    "fr=Rep",
                    "fr=Repeat",
                    "fr=Return",
                    "fr=SauveBDG",
                    "fr=SauveImage",
                    "fr=somCum(",
                    "fr=somme(",
                    "fr=sous-Chaîne(",
                    "fr=Stats 1-Var",
                    "fr=Stop",
                    "fr=suite(",
                    "fr=Texte(",
                    "fr=Then",
                    "fr=Trace",
                    "fr=Tricroi(",
                    "fr=TriDécroi",
                    "fr=Verticale",
                    "fr=While"
                };


                _listSuggestion = _nameList.Where(x => x.StartsWith(sender.Text,
                    StringComparison.InvariantCultureIgnoreCase)).ToList();

                if (_listSuggestion.Count > 0)
                {
                    
                    sender.ItemsSource = _listSuggestion;
                }
                else
                    sender.ItemsSource = new string[] { "No results found" };
            }
        }


        private void AutoSuggestBox_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            // Set sender.Text. You can use args.SelectedItem to build your text string.
            var selectedItem = args.SelectedItem.ToString();
            sender.Text = selectedItem;
        }


        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                // User selected an item from the suggestion list, take an action on it here.
            }
            else
            {
                // Use args.QueryText to determine what to do.
            }
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

