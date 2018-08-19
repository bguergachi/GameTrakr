using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace GameTrakr
{
    class SearchList: DisplayList
    {
        
        public override void displayGames()
        {
            
        }

        public string searchGame(string name)
        {
            API.searchByName(name);

            return "";
        }
    }
}
