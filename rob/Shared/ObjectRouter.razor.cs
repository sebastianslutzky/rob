using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;

namespace rob.Shared{
public partial class ObjectRouter: ComponentBase{
    [Inject]
    protected ILogger<ObjectRouter> logger{get;set;}
    [Parameter]
    public string Resource{get;set;}
    protected override void OnInitialized()
    {
    }
}
}