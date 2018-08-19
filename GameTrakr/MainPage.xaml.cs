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
using RestSharp;
using RestSharp.Authenticators;
using Newtonsoft.Json;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace GameTrakr
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            
            var client = new RestClient("https://api-endpoint.igdb.com");

            var request = new RestRequest("/games/?search=Call_of&fields=id,name,slug,games,tags,genres,release_dates,cover,rating", Method.GET);
            request.AddHeader("user-key", "1a3cd3cfd8f3b3573966ed025be2c9c1");
            IRestResponse response = client.Execute(request);
            Game Hey = JsonConvert.DeserializeObject<List<Game>>(response.Content)[0];
            Console.Write("This: " + response.Content);
            
            this.InitializeComponent();
        }

        private void GameListView_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
