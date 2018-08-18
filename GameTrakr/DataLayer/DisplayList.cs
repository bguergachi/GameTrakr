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
        List<Game> games { get; set; }

        public void addGame(Game game)
        {
            games.Add(game);
        }

        public void removeGame(int ID)
        {
            games.Remove(new Game() { id = ID });
        }

        public void clearGamees()
        {
            games.Clear();
        }

        abstract public void displayGames();
    }
}
