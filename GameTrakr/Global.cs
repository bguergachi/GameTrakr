using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    public static class Global
    {
        public const string BASE_URL = "https://api-endpoint.igdb.com";
        public const string IGDB_KEY = "1a3cd3cfd8f3b3573966ed025be2c9c1";
        public const string USER_KEY = "user-key";

//       public enum ListType {WishList="Wishlist", PlayingList = "Playing", FinishedList, CustomList};


        public class ListType
        {
            private ListType(string value) { Value = value;}

            public string Value { get;}

            public static ListType WishList { get { return new ListType("Wishlist"); } }
            public static ListType PlayingList { get { return new ListType("Playing"); } }
            public static ListType FinishedList { get { return new ListType("Finished"); } }
        }
    }
}
