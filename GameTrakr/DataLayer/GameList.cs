using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    public class GameList : DisplayList
    {
        GameFilter filter;

        public GameList(GameFilter filter) : base()
        {
            this.filter = filter;
        }

        
        public override List<Game> generateGamesList()
        {
           return filter.returnFiltered(games);
        }
    }
}
