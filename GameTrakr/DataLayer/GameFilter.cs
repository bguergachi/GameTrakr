using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    public class GameFilter
    {
        public Global.ListType listType { get ;}

        public GameFilter(Global.ListType listType)
        {
            this.listType = listType;
        }

        public List<Game> returnFiltered(List<Game> gamesList)
        {
            List<Game> filteredList = new List<Game>();
            foreach (Game game in gamesList)
            {
                // TODO: Need to make filter criteria more flexible. For now it only filters by list type

                    filteredList.Add(game);
            }

            return filteredList;
        }

        public override bool Equals(object obj)
        {
            if (!(obj is GameFilter))
            {
                return false;
            }

            var gameFilter = (GameFilter)obj;
            return (this.listType.Equals(gameFilter.listType));
        }

    }
}
