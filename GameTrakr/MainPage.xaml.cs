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
using System.Threading.Tasks;

namespace GameTrakr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        

        

        public MainPage()
        {
            

            this.InitializeComponent();
            
            
            

        }


        

        

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {

            Global.gamesLists = await API.getGamesFromLocalDatabase();



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
            Wishlist.List.addGames(Global.gamesLists.Find(x => x.Filter.listType.Equals(Global.ListType.WishList)));
            PlayingList.setFilter(new GameFilter(Global.ListType.PlayingList));
            PlayingList.List.addGames(Global.gamesLists.Find(x => x.Filter.listType.Equals(Global.ListType.PlayingList)));
            FinishedList.setFilter(new GameFilter(Global.ListType.FinishedList));
            FinishedList.List.addGames(Global.gamesLists.Find(x => x.Filter.listType.Equals(Global.ListType.FinishedList)));

            Wishlist.updateList();
            PlayingList.updateList();
            FinishedList.updateList();
        }

    }
}
