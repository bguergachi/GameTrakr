using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;

namespace GameTrakr
{
    class SearchList: DisplayList
    {
        
        public override void displayGames()
        {
            Debug.Write(games);
        }

        public void searchGame(string name)
        {
            string gameToSearch = name.Replace(" ", "_");
            this.clearGames();
            this.games = API.getGamesByName(gameToSearch);

        }
    }
}
