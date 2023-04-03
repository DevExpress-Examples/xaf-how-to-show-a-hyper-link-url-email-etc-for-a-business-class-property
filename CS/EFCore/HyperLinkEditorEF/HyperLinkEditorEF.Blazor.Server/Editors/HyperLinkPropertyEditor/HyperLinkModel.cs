using DevExpress.ExpressApp.Blazor.Components.Models;

namespace HyperLinkEditor.Blazor.Server.Editors.HyperLinkProperyEditor {
    public class HyperLinkModel : ComponentModelBase {
        public string Value {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }

        public string DisplayValue {
            get => GetPropertyValue<string>();
            set => SetPropertyValue(value);
        }
        
    }
}
