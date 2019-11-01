using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using static rob.Pages.FetchData;
using Blazor.Extensions.Logging;
using System.Dynamic;
using System.Net.Http.Headers;
using System;
using RestfulObjectApi.Representation.Types;

public class Api
{
    private HttpClient http;
    private ILogger<Api> logger;
    public Api(HttpClient http, ILogger<Api> logger)
    {
        this.http = http;
        this.logger = logger;
    }
    public async Task<HomePage> LoadHomePage()
    {
        var restfulBaseAddress = "http://localhost:8080";
        var restfulApiAddress = $"{restfulBaseAddress}/restful/";
        var homePage = restfulApiAddress;

        var link = new Link { href = restfulApiAddress };
        return await this.Load<HomePage>(link);
    }

    public async Task<T> Load<T>(Link l) where T : class
    {
        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
    "Basic", Convert.ToBase64String(
        System.Text.ASCIIEncoding.ASCII.GetBytes(
           $"superadmin:pass")));
        //this.logger.LogInformation("Loading " + l.href);
        var obj = await http.GetJsonAsync<T>(l.href);
        //logger.LogInformation<T>(obj);
        return obj;
    }
}
