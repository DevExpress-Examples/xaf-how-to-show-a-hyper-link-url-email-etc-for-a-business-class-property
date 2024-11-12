using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;
using Microsoft.AspNetCore.Components;
using DevExpress.ExpressApp.Blazor;

namespace HyperLinkEditor.Blazor.Server.Editors.HyperLinkProperyEditor {
    [PropertyEditor(typeof(string), false)]
    public class HyperLinkPropertyEditor : BlazorPropertyEditorBase {
        public HyperLinkPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new HyperLinkAdapter(new HyperLinkModel());

        protected override RenderFragment CreateViewComponentCore(object dataContext) {
            HyperLinkModel componentModel = new HyperLinkModel();
            componentModel.Value = (string)this.GetPropertyValue(dataContext);
            componentModel.DisplayValue =  componentModel.Value;
            componentModel.SetAttribute("readonly", true);
            var adap=new HyperLinkAdapter(componentModel);
            return adap.GetComponentContent();
        }
    }
}
