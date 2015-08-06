using System;
using System.Collections.ObjectModel;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace SplitViewDemo
{
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<NavLink> navLinks = new ObservableCollection<NavLink>()
        {
            new NavLink() { Label = "People", Symbol =  Symbol.People  },
            new NavLink() { Label = "Globe", Symbol = Symbol.Globe },
            new NavLink() { Label = "Message", Symbol = Symbol.Message },
            new NavLink() { Label = "Mail", Symbol = Symbol.Mail },
            new NavLink() { Label = "CellPhone", Symbol = Symbol.CellPhone },
        };
        public MainPage()
        {
            this.InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            listView.ItemsSource = navLinks;
            base.OnNavigatedTo(e);
        }


        private void listView_ItemClick(object sender, ItemClickEventArgs e)
        {
            content.Text = (e.ClickedItem as NavLink).Label;
        }

        private void togglePaneButton_Click(object sender, RoutedEventArgs e)
        {
            splitView.IsPaneOpen = !splitView.IsPaneOpen;
        }

        private void displayModeCombobox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            splitView.DisplayMode = (SplitViewDisplayMode)Enum.Parse(typeof(SplitViewDisplayMode), (e.AddedItems[0] as ComboBoxItem).Content.ToString());
        }
    }


    public class NavLink
    {
        public string Label { get; set; }
        public Symbol Symbol { get; set; }
    }
}
