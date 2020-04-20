using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;

namespace ContosoUniversity.Pages
{
    public class ClientModel : PageModel
    {
        //private readonly IHttpClientFactory clientFactory;
        private readonly GitHubService gitHubService;

        public IEnumerable<GitHubBranch> Branches { get; private set; }

        public bool GetBranchesError { get; private set; }

        //public ClientModel(IHttpClientFactory clientFactory)
        //{
        //    this.clientFactory = clientFactory;
        //}   

        public ClientModel(GitHubService gitHubService)
        {
            this.gitHubService = gitHubService;
        }

        //public async Task OnGetAsync()
        //{
        //    var request = new HttpRequestMessage(HttpMethod.Get,
        //        "repos/aspnet/AspNetCore.Docs/branches");

        //    var client = this.clientFactory.CreateClient("github");

        //    var response = await client.SendAsync(request);

        //    if (response.IsSuccessStatusCode)
        //    {
        //        using var responseStream = await response.Content.ReadAsStreamAsync();
        //        Branches = await JsonSerializer.DeserializeAsync<IEnumerable<GitHubBranch>>(responseStream);
        //    }
        //    else
        //    {
        //        GetBranchesError = true;
        //        Branches = Array.Empty<GitHubBranch>();
        //    }
        //}

        public async Task OnGetAsync()
        {
            try
            {
                Branches = await this.gitHubService.GetAspNetDocsIssues();
            }
            catch (HttpRequestException)
            {
                
            }
        }
    }
}