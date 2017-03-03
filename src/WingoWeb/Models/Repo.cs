using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using RestSharp.Authenticators;
using WingoWeb.Models;

namespace WingoWeb.Models
{
    public class Repo
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public GitHubUser Owner { get; set; }


        public static List<Repo> GetStars()
        {
            var client = new RestClient("https://api.github.com");
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.userName, EnvironmentVariables.password);
            var request = new RestRequest("user/starred");
            request.AddHeader("User-Agent", EnvironmentVariables.userName);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(response.Content);
            var repoList = JsonConvert.DeserializeObject<List<Repo>>(jsonResponse.ToString());

            return repoList;
        }

        public static Task<IRestResponse> GetResponseContentAsync(RestClient theClient, RestRequest theRequest)
        {
            var tcs = new TaskCompletionSource<IRestResponse>();
            theClient.ExecuteAsync(theRequest, response => {
                tcs.SetResult(response);
            });
            return tcs.Task;
        }
    }
}
