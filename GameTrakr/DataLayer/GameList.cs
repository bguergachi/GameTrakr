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

        public GameList(GameFilter filter, List<Game> games) : base(games)
        {
            this.Filter = filter;
        }

        public override async Task<List<Game>> generateGamesList()
        {
           return Filter.returnFiltered(games);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GameList))
            {
                return false;
            }

            var gameList = (GameList)obj;
            return (this.Filter.listType == gameList.Filter.listType);
        }
    }
}
