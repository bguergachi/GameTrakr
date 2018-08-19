using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using RestSharp;
using Newtonsoft.Json;

namespace GameTrakr
{
    public static class API
    {
        private static readonly RestClient client = new RestClient(Global.BASE_URL);

        public async static Task<List<Game>> getGamesByName(string name)
        {
            var request = new RestRequest($"/games/?search={name}&fields=id,name,slug,games,tags,genres,release_dates,cover,rating", Method.GET);
            request.AddHeader(Global.USER_KEY, Global.IGDB_KEY);

            var cancellationTokenSource = new CancellationTokenSource();

            var response = await client.ExecuteTaskAsync(request,cancellationTokenSource.Token);

            return JsonConvert.DeserializeObject<List<Game>>(response.Content);
        }

         

        

    }
}
