using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GameTrakr
{
    public struct Game
    {
        public string name { get; set; }
        public string slug { get; set; }
        public IList<int> games { get; set; }
        public IList<int> tags { get; set; }
        public IList<int> genres { get; set; }
        public Dictionary<string, string> cover { get; set; }
        public IList<Dictionary<string, string>> release_dates { get; set; }
        public double rating { get; set; }
        public int userRating { get; set; }
        public Global.ListType list { get; set; }
        public int id { get; set; }
        public string imagePath { get; set; }



        public override bool Equals(object obj)
        {
            if (!(obj is Game))
            {
                return false;
            }

            var game = (Game)obj;
            return id == game.id;
        }

        public override int GetHashCode()
        {
            return id;
        }
    }
}
