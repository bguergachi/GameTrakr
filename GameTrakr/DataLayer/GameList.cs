using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    class GameList : DisplayList
    {
        GameFilter filter;

        public GameList(GameFilter filter)
        {
            this.filter = filter;
        }

        
        public override void displayGames()
        {

        }
    }
}
