
using System.Collections.Generic;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{

    public partial class LayoutPropertyGroupView:LayoutBase<LayoutFieldSet>
    {
        [Inject]
        protected ILogger<LayoutPropertyGroupView> Logger{get;set;}

        private string _title;
        private IEnumerable<Member> _contextActions;
        private IEnumerable<Member> _contextProperties;

        protected override void OnLayoutSet(LayoutFieldSet value)
        {
            base.OnLayoutSet(value);
            _title = value.name;
        }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            _contextActions = this.Context.ro.Actions;
            _contextProperties = Context.ro.Properties;
        }
    }
}