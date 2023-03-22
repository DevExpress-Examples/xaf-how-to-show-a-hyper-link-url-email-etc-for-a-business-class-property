using DevExpress.ExpressApp.Blazor.Editors.Adapters;
using DevExpress.ExpressApp.Blazor.Editors;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Model;

namespace HyperLinkEditor.Blazor.Server.Editors.HyperLinkProperyEditor {
    [PropertyEditor(typeof(string), false)]
    public class HyperLinkPropertyEditor : BlazorPropertyEditorBase {
        public HyperLinkPropertyEditor(Type objectType, IModelMemberViewItem model) : base(objectType, model) { }
        protected override IComponentAdapter CreateComponentAdapter() => new HyperLinkAdapter(new HyperLinkModel());
    }
}
