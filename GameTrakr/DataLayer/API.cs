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
            var request = new RestRequest($"/games/?search={name}&fields=id,name,slug,genres.name,themes.name,platforms.name,release_dates,cover,rating&expand=genres,themes,platforms", Method.GET);
            request.AddHeader(Global.USER_KEY, Global.IGDB_KEY);

            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteTaskAsync(request,cancellationTokenSource.Token);
            Debug.Write("Response content: " + response.Content);


            if (response.IsSuccessful)
            {
                return JsonConvert.DeserializeObject<List<Game>>(response.Content);
            }
            else
            {
                return new List<Game>();
            }

        }

        public static object GetPropValue(object src, string propName)
        {
            var propertyInfo = src.GetType().GetProperty(propName);
            if (propertyInfo.GetGetMethod().IsStatic)
                return propertyInfo.GetValue(null, null);
            else
                return propertyInfo.GetValue(src, null);
        }

        public async static Task<List<GameList>> getGamesFromLocalDatabase()
        {
            try
            {
                StorageFolder jsonDataBaseFolder = await databaseFolder.GetFolderAsync("json");
                List<GameList> gameLists = new List<GameList>();
                foreach (StorageFile dataFile in await jsonDataBaseFolder.GetFilesAsync())
                {
                    string jsonData = await FileIO.ReadTextAsync(dataFile);
                    string fileName = Path.GetFileNameWithoutExtension(dataFile.Path);
                    Type type = typeof(Global.ListType);
                    gameLists.Add(new GameList(new GameFilter((Global.ListType)type.GetProperty(fileName).GetValue(null, null)), JsonConvert.DeserializeObject<List<Game>>(jsonData)));
                }
                return gameLists;

            }
            catch (FileNotFoundException e)
            {
                return new List<GameList>();
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
                StorageFolder imageDataBaseFolder = await databaseFolder.CreateFolderAsync("images", CreationCollisionOption.OpenIfExists);

                gameList.generateGamesList().ForEach( g =>
                {
                    File.Move(g.imagePath, imageDataBaseFolder.Path + Path.GetFileName(g.imagePath));
                    g.imagePath = imageDataBaseFolder.Path + Path.GetFileName(g.imagePath);

                });

                StorageFolder jsonDataBaseFolder = await databaseFolder.CreateFolderAsync("json", CreationCollisionOption.OpenIfExists);
                StorageFile dataFile = await jsonDataBaseFolder.CreateFileAsync(gameList.Filter.listType.Value + ".json", CreationCollisionOption.OpenIfExists);
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
