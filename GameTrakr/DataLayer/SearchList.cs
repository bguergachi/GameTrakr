using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using Windows.Storage;

namespace GameTrakr
{
    class SearchList: DisplayList
    {
        StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;

        public override void displayGames()
        {
            Debug.Write(games);
        }

        public async void searchGame(string name)
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
                    StorageFile sampleFile = await localFolder.GetFileAsync("dataFile.txt");
                    String timestamp = await FileIO.ReadTextAsync(sampleFile);
                    // Data is contained in timestamp
                }
                catch (FileNotFoundException e)
                {
                    // Cannot find file
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

        private async void downloadImage(string slug)
        {


            using (var client = new WebClient())
            {
                client.DownloadFile("http://example.com/file/song/a.mpeg", slug+".jpg");
            }


        }
    }
}
