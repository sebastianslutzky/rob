using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{

    public partial class LayoutColumnView:LayoutBase<LayoutColumn>
    {
        [Inject]
        protected ILogger<LayoutColumnView> Logger{get;set;}
    }
}