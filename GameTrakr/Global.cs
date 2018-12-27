using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GameTrakr
{
    public static class Global
    {
        public static List<GameList> gamesLists = new List<GameList>();

        public const string BASE_URL = "https://api-endpoint.igdb.com";
        public const string IGDB_KEY = "a6457ef6cd0f839da23d84df34414030";
        public const string USER_KEY = "user-key";

        //       public enum ListType {WishList="Wishlist", PlayingList = "Playing", FinishedList, CustomList};


        public class ListType
        {
            private ListType(string value, string icon, string fileName) { Value = value;
                Icon = icon;
                FileName = fileName;
            }

            public string Value { get; }
            public string Icon { get; }
            public string FileName { get; }

            public static ListType WishList { get { return new ListType("Wishlist", "", "WishList"); } }
            public static ListType PlayingList { get { return new ListType("Playing", "", "PlayingList"); } }
            public static ListType FinishedList { get { return new ListType("Finished", "" , "FinishedList"); } }


            public override bool Equals(object obj)
            {
                if (!(obj is ListType))
                {
                    return false;
                }

                var gameList = (ListType)obj;
                return (this.FileName == gameList.FileName);
            }
        }

        public static async Task ShowError()
        {
            ContentDialog noWifiDialog = new ContentDialog
            {
                Title = "Unable to connect to database",
                Content = "Check your connection and try again.",
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noWifiDialog.ShowAsync();
        }
    }
}
