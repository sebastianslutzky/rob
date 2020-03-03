using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using rob.Services;
using RestfulObjectApi.Representation.Types;

namespace rob.Shared{
public partial class ObjectRouter: ComponentBase{
    [Inject]
    protected ILogger<ObjectRouter> logger{get;set;}
    [Inject]
    protected ApacheIsisApi IsisApi{get;set;}
    [Inject]
    protected ObjectLoadedPublisherService Publisher{get;set;}

    [Parameter]
    public string Resource{get;set;}

    protected async override void OnInitialized()
    {
       //logger.LogInformation(Resource);
       var loadedObject = await this.IsisApi.LoadAsIsisSingleObject(new Link(){href=Resource,method= "Get" });
       Publisher.Publish(this,loadedObject);

    }
}
}