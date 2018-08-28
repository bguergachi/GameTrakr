using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    public class GameFilter
    {
        public Global.ListType listType { get ; }

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
                if (game.list == listType)
                {
                    filteredList.Add(game);
                }
            }

            return filteredList;
        }

    }
}
