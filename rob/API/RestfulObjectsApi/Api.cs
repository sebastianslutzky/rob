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

        http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue(
    "Basic", Convert.ToBase64String(
        System.Text.ASCIIEncoding.ASCII.GetBytes(
           $"superadmin:pass")));
    }
    public async Task<HomePage> LoadHomePage()
    {
        var restfulBaseAddress = "http://localhost:8080";
        var restfulApiAddress = $"{restfulBaseAddress}/restful/";
        var homePage = restfulApiAddress;

        var link = new Link { href = restfulApiAddress };
        return await this.Load<HomePage>(link);
    }

    internal async void Request(Request request)
    {
        HttpMethod method = new HttpMethod(request.Target.method);
        HttpRequestMessage msg = new HttpRequestMessage(method,request.Target.href);
        var response =  await http.SendAsync(msg);
        logger.LogInformation("response received");
        logger.LogInformation(response);
    }

    public async Task<T> Load<T>(ILink l) where T : class
    {
        return  await http.GetJsonAsync<T>(l.href);
    }
}
