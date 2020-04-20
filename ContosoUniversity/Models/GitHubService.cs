using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace ContosoUniversity.Models
{
    public class GitHubService
    {
        private readonly HttpClient Client;

        public GitHubService(HttpClient client)
        {
            //client.BaseAddress = new Uri("https://api.github.com/");
            //// GitHub API versioning
            //client.DefaultRequestHeaders.Add("Accept",
            //    "application/vnd.github.v3+json");
            //// GitHub requires a user-agent
            //client.DefaultRequestHeaders.Add("User-Agent",
            //    "HttpClientFactory-Sample");

            Client = client;
        }

        public async Task<IEnumerable<GitHubBranch>> GetAspNetDocsIssues()
        {
            var response = await Client.GetAsync(
                "repos/aspnet/AspNetCore.Docs/branches");

            response.EnsureSuccessStatusCode();

            using var responseStream = await response.Content.ReadAsStreamAsync();
            return await JsonSerializer.DeserializeAsync
                <IEnumerable<GitHubBranch>>(responseStream);
        }
    }
}
