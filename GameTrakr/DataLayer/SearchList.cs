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
        protected StorageFolder localFolder = ApplicationData.Current.LocalCacheFolder;

        

        public override async Task<List<Game>> generateGamesList()
        {
            return games;
        }

        public async Task searchGame(string name)
        {
            string gameToSearch = name.Replace(" ", "_");
            clearGames();
            this.games= await API.getGamesByName(gameToSearch);
            await manageCacheImage();

        }

        private async Task manageCacheImage()
        {
            this.games.ForEach(async (g) =>
            {
                try
                {
                    // Try getting the cover image locally
                    StorageFile image = await localFolder.GetFileAsync(g.slug + ".jpg");
                    g.imagePath = image.Path;
                }
                catch (FileNotFoundException e)
                {
                    // If doesn't exist locally, download it
                    StorageFile image = await localFolder.CreateFileAsync(g.slug + ".jpg", CreationCollisionOption.OpenIfExists);
                    if (g.cover != null)
                    {
                        HttpClient client = new HttpClient();
                        byte[] buffer = buffer = await client.GetByteArrayAsync("https:" + g.cover["url"]).ConfigureAwait(false);
                        try
                        {
                            using (Stream stream = await image.OpenStreamForWriteAsync())
                            {
                                stream.Write(buffer, 0, buffer.Length);
                            }
                        }
                        catch (IOException ex)
                        {
                            Debug.WriteLine("IOException source: {0}", ex.Source);
                        }
                        
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
