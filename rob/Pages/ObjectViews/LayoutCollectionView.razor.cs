using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using rob.API.ApacheISISApi;
using rob.Layout;

namespace rob.Pages.ObjectViews
{
    public partial class LayoutCollectionView: LayoutBase<LayoutCollection>
    {
        private string _name;

        [Inject] 
        public ILogger<LayoutCollectionView> Logger { get; set; }
        [Inject] 
        public ApacheIsisApi IsisApi { get; set; }

        private IEnumerable<Member> _contextActions;
        private Member _collection;

        //TODO: compute collInstance
        //TODO: compute collDescriptor
        //TODO: render dummy  collectionTableView
        
        protected override Task OnParametersSetAsync()
        {
                _name = Layout.id;
                var filter = new CollectionLayoutFilter(Context, Layout);

                _contextActions = filter.Actions;
                _collection = filter.Collection;
                Logger.LogInformation("about to load it all");
                var details = this.IsisApi.Load(
                    _collection.details, "");
                Logger.LogInformation(details);
           
            //get Details from collection context
             //get collection descriptor from details
             return base.OnParametersSetAsync();
        }
        
        
        
        public void ActionInvokedHandler()
        {
            throw new NotImplementedException();   
        }
    }
}
