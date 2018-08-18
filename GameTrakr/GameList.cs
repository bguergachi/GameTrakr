using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    class GameList : DisplayList
    {
        List<Game> games { get; set; }
        GameFilter filter;

        public GameList(GameFilter filter)
        {
            this.filter = filter;
        }

        public void addGame(Game game)
        {
            games.Add(game);
        }

        public void removeGame(int ID)
        {
            games.RemoveAll(new Game() {id=ID});
        }

        public void displayGames()
        {

        }
    }
}
