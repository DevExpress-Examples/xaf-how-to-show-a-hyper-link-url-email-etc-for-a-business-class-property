using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Mobile;
using DevExpress.ExpressApp.Mobile.Editors;
using DevExpress.ExpressApp.Mobile.MobileModel;
using DevExpress.ExpressApp.Model;
using System;

namespace HyperLinkPropertyEditor.Mobile {
    [PropertyEditor(typeof(System.String), "HyperLinkStringPropertyEditor", false)]
    public class MobileHyperLinkStringPropertyEditor : MobileStringPropertyEditor {
        public MobileHyperLinkStringPropertyEditor(Type objectType, IModelMemberViewItem model)
            : base(objectType, model) {
        }
        protected override object CreateViewModeControlCore() {
            LinkComponent editor = new LinkComponent();
            editor.AddStyle("padding", "0px");
            return editor;
        }
        protected override void ReadViewModeValueCore() {
            string linkPropertyName = PropertyName.ToClientIdentifier() + "Link";
            CalculatedField linkCalculatedProperty = ClientModelManager.RegisterProperty(linkPropertyName);
            linkCalculatedProperty.Getter = String.Format(@"var origValue = {0};
                                                        var result = origValue;
                                                        if (origValue) {{
                                                            var phoneMatch = origValue.match(/\d/g);
                                                            if (origValue.indexOf('@') !== -1) {{
                                                                result = 'mailto://' + origValue;
                                                            }} else if(phoneMatch && phoneMatch.length === 10) {{
                                                                result = 'tel:' + origValue;
                                                            }} else if(origValue.indexOf('://') == -1) {{
                                                                result = 'http://' + origValue;
                                                            }} else {{ 
                                                                result = origValue;
                                                            }}
                                                        }}
                                                        return result;",
                                        BindToCurrentObjectProperty());

            LinkComponent linkControl = ((LinkComponent)Control);
            linkControl.Text = BindToCurrentObjectProperty();
            linkControl.Link = BindToProperty(linkPropertyName);
        }
    }
}
