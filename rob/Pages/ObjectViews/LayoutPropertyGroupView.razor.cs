
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using rob.Layout;

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

                if (Layout.unreferencedActions == true)
                {
                    _contextActions = _contextActions.Union(Unreferenced.Actions);
                }
                
                if (Layout.unreferencedProperties == true)
                {
                    _contextProperties = _contextProperties.Union(Unreferenced.Properties);
                }
            }

            return base.OnParametersSetAsync();
        }

    }
}