using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.Layout;

namespace rob.Pages.ObjectViews{


    public partial class LayoutRowView
    {
        [Inject]
        protected ILogger<LayoutRowView> Logger{get;set;}
        
        private LayoutColumnCollection[] _columns;

        protected override void OnLayoutSet(LayoutRow value)
        {
            base.OnLayoutSet(value);
            _columns = value.cols;
        }
     }
}
