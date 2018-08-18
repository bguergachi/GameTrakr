using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{
    public struct Game
    {
        public string title { get; set; }
        public string platform { get; set; }
        public string[] tags { get; set; }
        public string coverPath { get; set; }
        public int gameRating { get; set; }
        public int userRating { get; set; }
        public int year { get; set; }
        public int month { get; set; }
        public string list { get; set; }
        public int id { get; set; }


        public override bool Equals(object obj)
        {
            if (!(obj is Game))
            {
                return false;
            }

            var game = (Game)obj;
            return id == game.id;
        }
    }
}
