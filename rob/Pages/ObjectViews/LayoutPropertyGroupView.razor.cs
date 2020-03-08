
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using rob.layout.representations;
using Blazor.Extensions.Logging;

namespace rob.Pages.ObjectViews{

    public partial class LayoutPropertyGroupView:LayoutBase<LayoutFieldSet>
    {
        [Inject]
        protected ILogger<LayoutPropertyGroupView> Logger{get;set;}

        private string _title;
        private IEnumerable<Member> _contextActions;
        private IEnumerable<Member> _contextProperties;
        private FieldSetLayoutFilter _filter;

        protected override void OnLayoutSet(LayoutFieldSet value)
        {
            base.OnLayoutSet(value);
            _title = value.name;
        }

  

        protected override Task OnParametersSetAsync()
        {
            if (Context != null && Layout != null)
            {
                _filter = new FieldSetLayoutFilter(Context, Layout);

                _contextActions = _filter.Actions;
                _contextProperties = _filter.Properties;
            }

            return base.OnParametersSetAsync();
        }

    }
}