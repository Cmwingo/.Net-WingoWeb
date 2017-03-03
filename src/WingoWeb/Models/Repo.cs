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
        public string Owner { get; set; }
        public string Name { get; set; }
        public static List<Repo> GetRepos()
        {
            var client = new RestClient("https://api.github.com/users/" + EnvironmentVariables.userName + "/repos");
            client.Authenticator = new HttpBasicAuthenticator(EnvironmentVariables.userName, EnvironmentVariables.password);
            var request = new RestRequest();
            request.AddHeader("User-Agent", EnvironmentVariables.userName);

            var response = new RestResponse();
            Task.Run(async () =>
            {
                response = await GetResponseContentAsync(client, request) as RestResponse;
            }).Wait();
            JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(response.Content);
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
