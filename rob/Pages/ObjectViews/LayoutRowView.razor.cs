using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.API.ApacheISISApi.Representations.layout;

namespace rob.Pages.ObjectViews{


    public partial class LayoutRowView:ComponentBase
    {
        [Inject]
        protected ILogger<LayoutRowView> Logger{get;set;}

        [CascadingParameter]
        public IsisSingleObject Context { get; set; }

        [CascadingParameter]
        public ObjectLayout Layout { get; set; }

    }
}
