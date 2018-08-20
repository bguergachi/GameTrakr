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
        public DisplayList List { get; set; }

        public void setFilter(GameFilter filter)
        {
            List = new GameList(filter);
            updateList();
        }

        public void updateList()
        {
            if (List != null)
            {
                foreach (Game game in List.generateGamesList())
                {
                    ListViewItem item = new ListViewItem();
                    item.Padding=new Thickness(0,0,0,0);
                    item.UseLayoutRounding = false;
                    item.HorizontalContentAlignment = HorizontalAlignment.Stretch;
                    item.Content = new GameCardView(game);
                    GameListViewComp.Items.Add(item);
                }

                List.generateGamesList();
            }
        }

        public GameListView()
        {
            this.InitializeComponent();
        }

        private void SearchListBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void AddGameBtn_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
