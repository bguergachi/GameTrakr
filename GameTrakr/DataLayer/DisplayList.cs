using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;

namespace GameTrakr
{
    //Interface to display using polymorphism
    public abstract class DisplayList
    {
        protected List<Game> games { get; set; }
        protected StorageFolder localFolder { get; set; }

        public DisplayList()
        {
            games = new List<Game>();
        }

        public virtual async void addGame(Game game)
        {
            games.Add(game);
        }

        public virtual async void removeGame(int ID)
        {
            games.Remove(new Game() { id = ID });
        }

        public void clearGames()
        {
            games.Clear();
        }

        abstract public List<Game> generateGamesList();
    }
}
