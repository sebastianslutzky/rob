
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{

    public partial class LayoutPropertyGroupView:LayoutBase<LayoutFieldSet>
    {
        [Inject]
        protected ILogger<LayoutPropertyGroupView> Logger{get;set;}

        private string _title;
        private IEnumerable<Member> _contextActions;


        protected override void OnLayoutSet(LayoutFieldSet value)
        {
            base.OnLayoutSet(value);
            _title = value.name;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _contextActions = this.Context.ro.Actions;
        }
    }
}