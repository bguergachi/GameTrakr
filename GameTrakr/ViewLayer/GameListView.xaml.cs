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

namespace GameTrakr.ViewLayer
{
    public sealed partial class GameListView : UserControl
    {
        public DisplayList SearchList { get; set; }
        public GameList List { get; set; }
        private bool IsSearchVisible = false;
        private bool IsSearching = false;


        public void setFilter(GameFilter filter)
        {
            List = new GameList(filter);
            titleText.Text = List.Filter.listType.Value;

            updateList();
        }

        public void updateList()
        {
            if (SearchList != null)
            {
                foreach (Game game in SearchList.generateGamesList())
                {
                    ListViewItem item = new ListViewItem();
                    item.Padding=new Thickness(0,0,0,0);
                    item.UseLayoutRounding = false;
                    item.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    item.Content = new GameCardView(game);

                    GameListViewComp.Items.Add(item);
                }

            }
        }

        public GameListView()
        {
            this.InitializeComponent();
        }

        private void SearchListBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsSearchVisible)
                this.ShowTextbox_SearchGame.Begin();
            else
                this.HideTextbox_SearchGame.Begin();
            this.IsSearchVisible = !this.IsSearchVisible;
        }

        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {
            if (!this.IsSearchVisible)
                this.ShowTextbox_AddGame.Begin();
            else
                this.HideTextbox_AddGame.Begin();
            this.IsSearchVisible = !this.IsSearchVisible;

        }

        private void GameListViewComp_Loaded(object sender, RoutedEventArgs e)
        {
            this.ShowTextbox_AddGame.Completed += new EventHandler<object>(this.ShowTextBoxCompleted);
            this.ShowTextbox_SearchGame.Completed += new EventHandler<object>(this.ShowTextBoxCompleted);

        }

        private void ShowTextBoxCompleted(object sender, object e)
        {
            this.ListSearchField.Focus(FocusState.Keyboard);
        }
    }
}
