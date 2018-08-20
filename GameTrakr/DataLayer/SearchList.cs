using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Drawing;
using Windows.Storage;
using System.Net.Http;
using Windows.Networking.BackgroundTransfer;

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
            await Task.Run(() => manageCacheImage());
        }

        private async void manageCacheImage()
        {
            games.ForEach(async (g) =>
            {
                try
                {
                    StorageFile image = await localFolder.GetFileAsync(g.slug + ".jpg");


                }
                catch (FileNotFoundException e)
                {
                    StorageFile image = await localFolder.GetFileAsync(g.slug + ".jpg");
                    HttpClient client = new HttpClient();
                    byte[] buffer = await client.GetByteArrayAsync("https:"+g.cover["url"]);
                    using (Stream stream = await image.OpenStreamForWriteAsync())
                    {
                        stream.Write(buffer, 0, buffer.Length);
                    }

                    g.imagePath = image.Path;
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
            );
        }
    }
}
