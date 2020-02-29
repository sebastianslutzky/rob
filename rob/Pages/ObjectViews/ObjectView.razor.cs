using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using rob.API.ApacheISISApi;
using rob.layout.representations;

namespace rob.Pages.ObjectViews
{
    public partial class ObjectView: LayoutBase<ObjectLayout>
    {
        [Inject]
        protected ILogger<ObjectView> Logger { get; set; }

   

        //protected override async Task OnInitializedAsync()
        //{
        //    if (Context == null)
        //    {

        //        Logger.LogInformation("NO CONTEXT SET");
        //        return;
        //    }
        //    if (Layout == null)
        //    {

        //        Logger.LogInformation("NO LAYOUT SET");
        //        return;
        //    }
        //    Logger.LogInformation("number of rows:");

        //    Logger.LogInformation(Layout.row.Length.ToString());
        //}

}
}
