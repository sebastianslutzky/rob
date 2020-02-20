using System.Threading.Tasks;
using Blazor.Extensions.Logging;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using RestfulObjectApi.Representation.Types;
using rob.Representation.Types ;
namespace rob.Pages.NavBar {
    public partial class MenuAction : ComponentBase{

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
    private ObjectAction action;


    protected override async Task OnInitializedAsync()
    {
        logger.LogInformation(Context);
        action = await this.Api.Load<ObjectAction>(Context.details);

        descriptor = await this.Api.Load<ActionDescription>(action.DescribedBy); 
        friendlyName = descriptor.extensions.friendlyName;
        logger.LogInformation("descriptor");
        logger.LogInformation(descriptor);
    }
        public void InvokeAction(){
            Invoker.InvokeAction(action,friendlyName);
        }
    }
}