using System;
using DevExpress.ExpressApp;
using DevExpress.XtraEditors;
using DevExpress.ExpressApp.Model;
using DevExpress.XtraEditors.Mask;
using DevExpress.ExpressApp.Editors;
using System.Text.RegularExpressions;
using DevExpress.XtraEditors.Controls;
using DevExpress.ExpressApp.Win.Editors;
using DevExpress.XtraEditors.Repository;

namespace HyperLinkPropertyEditor.Win {
	[PropertyEditor(typeof(System.String),  false)]
    public class WinHyperLinkStringPropertyEditor : StringPropertyEditor {
        public const string UrlEmailMask = @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})";
        private HyperLinkEdit hyperlinkEditCore;
        public WinHyperLinkStringPropertyEditor(Type objectType, IModelMemberViewItem info)
            : base(objectType, info) {
        }
        public new HyperLinkEdit Control { get { return hyperlinkEditCore; } }
        protected override RepositoryItem CreateRepositoryItem() {
            return new RepositoryItemHyperLinkEdit();
        }
        protected override object CreateControlCore() {
            hyperlinkEditCore = new HyperLinkEdit();
            return hyperlinkEditCore;
        }
        protected override void SetupRepositoryItem(RepositoryItem item) {
            base.SetupRepositoryItem(item);
            RepositoryItemHyperLinkEdit hyperLinkProperties = (RepositoryItemHyperLinkEdit)item;
            hyperLinkProperties.SingleClick = View is ListView;
            hyperLinkProperties.TextEditStyle = TextEditStyles.Standard;
            hyperLinkProperties.OpenLink += hyperLinkProperties_OpenLink;
            EditMaskType = EditMaskType.RegEx;
            hyperLinkProperties.Mask.MaskType = MaskType.RegEx;
            hyperLinkProperties.Mask.EditMask = UrlEmailMask;
        }
        private void hyperLinkProperties_OpenLink(object sender, OpenLinkEventArgs e) {
            e.EditValue = GetResolvedUrl(e.EditValue);
        }
        public static string GetResolvedUrl(object value) {
            string url = Convert.ToString(value);
            if (!string.IsNullOrEmpty(url)) {
                if (url.Contains("@") && IsValidUrl(url))
                    return string.Format("mailto:{0}", url);
                if (!url.Contains("://"))
                    url = string.Format("http://{0}", url);
                if (IsValidUrl(url))
                    return url;
            }
            return string.Empty;
        }
        private static bool IsValidUrl(string url) {
            return Regex.IsMatch(url, UrlEmailMask);
        }
    }
}