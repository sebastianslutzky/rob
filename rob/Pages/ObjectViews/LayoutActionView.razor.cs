using System;
using Microsoft.AspNetCore.Components;
using rob.API.ApacheISISApi;
using Microsoft.Extensions.Logging;
using Blazor.Extensions.Logging;
using System.Threading.Tasks;
using RestfulObjectApi.Representation.Types;
using rob.layout.representations;

namespace rob.Pages.ObjectViews{


    public partial class LayoutActionView
    {
        private ActionDescription _actionDescriptor;
        private string _name;
        private ObjectAction _actionDetails;

        [Inject]
        protected ILogger<LayoutActionView> Logger{get;set;}
        [Inject]
        private Api Api { get; set; }

        [Parameter]
        public Member Action { get; set; }
        
        [Parameter]
        public bool IsForCollection { get; set; }
        
        protected override async Task OnInitializedAsync()
        {
            _actionDetails = await Api.Load<ObjectAction>(Action.details);
            _actionDescriptor = await Api.Load<ActionDescription>(_actionDetails.DescribedBy);
            _name = _actionDescriptor.extensions.friendlyName;
        }

        private void InvokeAction()
        {
         throw new NotImplementedException();
         //todo: implement this at the end
         
            
            /*const actionLink = this._objectActionLink.links[0].href;

            this.metamodel.loadLink(ObjectAction, this._objectActionLink.links[0]).then(
                objectAction => {
                    this._actionDescriptor['IsForCollection'] = this.IsForCollection;
                    this.invoker.invokeAction(objectAction, this._actionDescriptor);
                });*/
        }
        /*protected override void OnLayoutSet(LayoutAction value)
        {
            base.OnLayoutSet(value);
            
            // 
            /*this.metamodel.getDetails<ObjectMember>(this._objectActionLink)
                .then(actionInstance => {
                    this.metamodel.getDescribedBy(ActionDescription, actionInstance).then(
                        actionDescriptor => {
                            this._actionDescriptor = actionDescriptor;
                            this.Name = actionDescriptor.friendlyName;
                            this.ToolTipText = this._actionDescriptor.indexableKey;
                        });
                });#1#
            
        }*/
    }
}
