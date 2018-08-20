using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Diagnostics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

namespace GameTrakr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            /*
            var client = new RestClient("https://api-endpoint.igdb.com");

            var request = new RestRequest("/games/?search=Call_of&fields=id,name,slug,games,tags,genres,release_dates,cover,rating", Method.GET);
            request.AddHeader("user-key", "1a3cd3cfd8f3b3573966ed025be2c9c1");
            IRestResponse response = client.Execute(request);
            Game Hey = JsonConvert.DeserializeObject<List<Game>>(response.Content)[0];
            Debug.Write("This: " + response.Content);
            */

            SearchList searchList = new SearchList();
            string game = "Call of duty";
            searchList.searchGame(game);
            searchList.generateGamesList();

            this.InitializeComponent();
        }



        private void GameListView_Loaded(object sender, RoutedEventArgs e)
        {

            // Set appropriate list types
            //            Wishlist.list = new GameList(new GameFilter(Global.ListType.WishList));
            //            PlayingList.list = new GameList(new GameFilter(Global.ListType.PlayingList));
            //            FinishedList.list = new GameList(new GameFilter(Global.ListType.FinishedList));

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //             using Windows.UI.ViewManagement;
            Windows.ApplicationModel.Core.CoreApplication.GetCurrentView().TitleBar.ExtendViewIntoTitleBar = false;
            var titleBar = ApplicationView.GetForCurrentView().TitleBar;

            // Set active window colors
            titleBar.ForegroundColor = Windows.UI.Colors.White;
            titleBar.BackgroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonBackgroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonHoverForegroundColor = Windows.UI.Colors.White;
            titleBar.ButtonHoverBackgroundColor = Windows.UI.Colors.DodgerBlue;
            titleBar.ButtonPressedForegroundColor = Windows.UI.Colors.Gray;
            titleBar.ButtonPressedBackgroundColor = Windows.UI.Colors.DarkBlue;

            //             Set inactive window colors
            titleBar.InactiveForegroundColor = Windows.UI.Colors.Gray;
            titleBar.InactiveBackgroundColor = Windows.UI.Colors.Black;
            titleBar.ButtonInactiveForegroundColor = Windows.UI.Colors.Gray;
            titleBar.ButtonInactiveBackgroundColor = Windows.UI.Colors.Black;


            loadLists();

        }

        private async void loadLists()
        {
            SearchList searchList = new SearchList();
            string game = "Call of duty";
            await searchList.searchGame(game);

            Wishlist.List = searchList;
            Wishlist.updateList();
        }
    }
}
