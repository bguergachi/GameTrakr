using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Windows.Storage;
using System.Threading.Tasks;

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

        public DisplayList(List<Game> games)
        {
            this.games = games;
        }

        public void addGame(Game game)
        {
            games.Add(game);
        }

        public void addGames(GameList gameList)
        {
            if (gameList != null)
            {
                foreach (Game g in gameList.games)
                {
                    addGame(g);
                }
            }
        }

        public void removeGame(int ID)
        {
            games.Remove(new Game() { id = ID });
        }

        public void clearGames()
        {
            games.Clear();
        }

        abstract public Task<List<Game>> generateGamesList();

    }
}
