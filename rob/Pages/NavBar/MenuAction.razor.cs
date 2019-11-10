using System.Threading.Tasks;
using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using RestfulObjectApi.Representation.Types;
using rob.Representation.Types ;
namespace rob.Pages.NavBar {
    public partial class MenuAction{

    [Inject]
    protected ILogger<MenuAction> logger{get;set;}
    [Inject]
    protected Api Api { get; set; }
    [Inject]
    protected ApacheIsisApi IsisApi { get; set; }
    [Inject]
    protected ActionInvocationService Invoker { get; set; }

    [Parameter]
    public Member Context{get;set;}
    private string friendlyName;
    private ActionDescription descriptor;

    private List action;


    protected override async Task OnInitializedAsync()
    {
        logger.LogInformation(Context);
           // get action resource
        action = await this.Api.Load<List>(Context.details);
        logger.LogInformation("details");
        logger.LogInformation(action);

        //infer ActionDescription from DescrubedBy
        descriptor = await this.Api.Load<ActionDescription>(action.DescribedBy); 
        friendlyName = descriptor.extensions.friendlyName;
        logger.LogInformation("descriptor");
        logger.LogInformation(descriptor);
    }
    public void InvokeAction(){
        Invoker.InvokeAction(Context);
    }
    }
}