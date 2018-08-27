using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;
using Windows.Storage;

namespace GameTrakr
{
    public static class API
    {
        private static readonly RestClient client = new RestClient(Global.BASE_URL);
        private static readonly StorageFolder databaseFolder = ApplicationData.Current.LocalFolder;

        public async static Task<List<Game>> getGamesByName(string name)
        {
            var request = new RestRequest($"/games/?search={name}&fields=id,name,platform,slug,games,tags,genres,release_dates,cover,rating", Method.GET);
            request.AddHeader(Global.USER_KEY, Global.IGDB_KEY);

            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteTaskAsync(request,cancellationTokenSource.Token);

            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Game>>(response.Content);
            }
            else
            {
                return new List<Game>();
            }
        }

        public async static Task<List<Game>> getGamesFromLocalDatabase(string list)
        {
            try
            {
                StorageFile dataFile = await databaseFolder.GetFileAsync(list + ".json");
                string jsonData = await FileIO.ReadTextAsync(dataFile);
                return JsonConvert.DeserializeObject<List<Game>>(jsonData);

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

        public async static Task saveGamesToLocalDatabase(GameList gameList)
        {
            try
            {
                StorageFile dataFile = await databaseFolder.CreateFileAsync(gameList.Filter.listType + ".json", CreationCollisionOption.OpenIfExists);
                await FileIO.WriteTextAsync(dataFile,JsonConvert.SerializeObject(gameList.generateGamesList()));

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
}
