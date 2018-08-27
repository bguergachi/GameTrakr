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
            Game Hey = JsonConvert.DeserializeObject<SearchList<Game>>(response.Content)[0];
            Debug.Write("This: " + response.Content);
            */

            doSOmestuff();

            this.InitializeComponent();
        }

        public async void doSOmestuff()
        {
            SearchList searchList = new SearchList();
            await searchList.searchGame("Call of duty");
            await searchList.searchGame("Halo");
            searchList.generateGamesList();

            string jsonData = JsonConvert.SerializeObject(searchList.generateGamesList());
            Debug.WriteLine("Json:" + jsonData);

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

            
            //            Set appropriate list types
            Wishlist.setFilter(new GameFilter(Global.ListType.WishList));
            PlayingList.setFilter(new GameFilter(Global.ListType.PlayingList));
            FinishedList.setFilter(new GameFilter(Global.ListType.FinishedList));

            LoadLists();

        }

        private async void LoadLists()
        {
            SearchList searchList = new SearchList();
            string game = "Call of duty";
            await searchList.searchGame(game);

            Wishlist.SearchList = searchList;
            Wishlist.updateList();
        }
    }
}
