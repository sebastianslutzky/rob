using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{

    public partial class LayoutGridView:LayoutBase<ObjectLayout>
    {
        [Inject]
        protected ILogger<LayoutGridView> Logger{get;set;}
        private LayoutRow[] Rows;

        protected override void OnLayoutSet(ObjectLayout value)
        {
            base.OnLayoutSet(value);
            Rows = value.row;
        }
    }
}
