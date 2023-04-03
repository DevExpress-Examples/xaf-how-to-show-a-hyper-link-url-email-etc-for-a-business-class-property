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
        public bool ReadOnly {
            get => GetPropertyValue<bool>();
            set => SetPropertyValue(value);
        }
        // ...
        public void SetValueFromUI(string value) {
            SetPropertyValue(value, notify: false, nameof(Value));
            ValueChanged?.Invoke(this, EventArgs.Empty);
        }
        public event EventHandler ValueChanged;
    }
}
