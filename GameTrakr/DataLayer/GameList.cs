using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Newtonsoft.Json;




namespace GameTrakr
{
    public class GameList : DisplayList
    {
        public GameFilter Filter { get; }
        
        
        public GameList(GameFilter filter) : base()
        {
            this.Filter = filter;
        }

        public override List<Game> generateGamesList()
        {
           return Filter.returnFiltered(games);
        }
    }
}
