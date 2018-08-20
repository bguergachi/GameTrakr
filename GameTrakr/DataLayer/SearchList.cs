using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using Windows.Storage;
using System.Net;

namespace GameTrakr
{
    class SearchList: DisplayList
    {
        StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;

        public override List<Game> generateGamesList()
        {
            return games;
        }

        public async Task searchGame(string name)
        {
            string gameToSearch = name.Replace(" ", "_");
            clearGames();
            var games= await API.getGamesByName(gameToSearch);
            this.games = games;
            manageCashImage();
        }

        private async void manageCashImage()
        {
            foreach(Game g in games)
            {
                try
                {
                    StorageFile sampleFile = await localFolder.GetFileAsync(g.slug+".jpg");
                    String timestamp = await FileIO.ReadTextAsync(sampleFile);
                    // Data is contained in timestamp
                }
                catch (FileNotFoundException e)
                {
                    using (var client = new WebClient())
                    {
                        client.DownloadDataAsync(new Uri(g.cover["url"]), g.slug + ".jpg");
                    }
                }
                catch (IOException e)
                {
                    // Get information from the exception, then throw
                    // the info to the parent method.
                    if (e.Source != null)
                    {
                        Debug.WriteLine("IOException source: {0}", e.Source);
                    }
                    throw;
                }
            }
        }

        private void downloadImage(Game g)
        {
            


        }
    }
}
