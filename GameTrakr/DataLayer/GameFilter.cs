using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameTrakr
{


    class GameFilter
    {
        private string platform;
        private string[] tags;
        private string coverPath;
        private int year;
        private string listType;
        private string title;
        private int gameRating;
        private int userRating;

        public string Title { get => title; set => title = value; }
        public string Platform { get => platform; set => platform = value; }
        public string[] Tags { get => tags; set => tags = value; }
        public string CoverPath { get => coverPath; set => coverPath = value; }
        public int GameRating { get => gameRating; set => gameRating = value; }
        public int UserRating { get => userRating; set => userRating = value; }
        public int Year { get => year; set => year = value; }
        public string ListType { get => listType; set => listType = value; }

        public GameFilter(string listType)
        {
            this.listType = listType;
        }


    }
}
