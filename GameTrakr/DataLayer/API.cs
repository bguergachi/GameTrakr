using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RestSharp.Authenticators;

namespace GameTrakr
{
    public static class API
    {
        private static readonly RestClient client = new RestClient(Global.BASE_URL);

        public static string searchByName(string name)
        {
            var request = new RestRequest($"/games/?search={name}&fields=name,publishers", Method.GET);
            request.AddHeader(Global.USER_KEY, Global.IGDB_KEY);
            IRestResponse response = client.Execute(request);
            return response.Content;
        }

        

    }
}
