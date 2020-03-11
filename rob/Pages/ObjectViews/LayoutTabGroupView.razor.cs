
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using rob.Layout;

namespace rob.Pages.ObjectViews{

    public partial class LayoutTabGroupView:LayoutBase<LayoutTabGroup>
    {
        [Inject]
        protected ILogger<LayoutTabGroup> Logger{get;set;}

        private int _selectedIndex;
        private LayoutTab SelectedTab { get; set; }

        protected override void OnInitialized()
        {
            base.OnInitialized();
            if (Layout.tab != null)
            {
                SelectTab(0);    
            }
        }

        public string listItemClass(int i)
        {
            var active = i == _selectedIndex? "active":string.Empty;
            return $"tab{i} {active} link";
        }

        private void SelectTab(int index)
        {
            _selectedIndex = index;
            SelectedTab = Layout.tab[index];
            StateHasChanged();
        }
    }
}