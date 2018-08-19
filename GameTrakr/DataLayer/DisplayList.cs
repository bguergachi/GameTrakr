using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    //Interface to display using polymorphism
    abstract class DisplayList
    {
        protected List<Game> games { get; set; }

        public DisplayList()
        {
            games = new List<Game>();
        }

        public void addGame(Game game)
        {
            games.Add(game);
        }

        public void removeGame(int ID)
        {
            games.Remove(new Game() { id = ID });
        }

        public void clearGames()
        {
            games.Clear();
        }

        abstract public void displayGames();
    }
}
