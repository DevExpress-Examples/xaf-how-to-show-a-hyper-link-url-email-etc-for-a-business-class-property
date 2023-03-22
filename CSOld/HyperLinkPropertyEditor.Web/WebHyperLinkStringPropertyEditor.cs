using System;
using DevExpress.Web;
using System.Web.UI.WebControls;
using DevExpress.ExpressApp.Web;
using DevExpress.ExpressApp.Model;
using DevExpress.ExpressApp.Editors;
using System.Text.RegularExpressions;
using DevExpress.ExpressApp.Localization;
using DevExpress.ExpressApp.Web.Editors.ASPx;
using DevExpress.ExpressApp.Web.TestScripts;

namespace HyperLinkPropertyEditor.Web {
	[PropertyEditor(typeof(System.String), "HyperLinkStringPropertyEditor", false)]
	public class WebHyperLinkStringPropertyEditor : ASPxPropertyEditor {
		//Dennis TODO: This is to be setup via the Model Editor at the ViewItems | PropertyEditors | HyperLinkStringPropertyEditor level once.
		public const string UrlEmailMask = @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})";
		public WebHyperLinkStringPropertyEditor(Type objectType, IModelMemberViewItem info)
			: base(objectType, info) {
			this.CancelClickEventPropagation = true;
		}
		protected override WebControl CreateEditModeControlCore() {
			if(AllowEdit.ResultValue) {
				ASPxTextBox textBox = RenderHelper.CreateASPxTextBox();
				textBox.ID = "textBox";
				textBox.ValidationSettings.RegularExpression.ValidationExpression = UrlEmailMask;
				textBox.ValidationSettings.RegularExpression.ErrorText = UserVisibleExceptionLocalizer.GetExceptionMessage(UserVisibleExceptionId.MaskValidationErrorMessage);
				textBox.TextChanged += EditValueChangedHandler;
				return textBox;
			}
			else {
				return CreateViewModeControlCore();
			}
		}
		protected override WebControl CreateViewModeControlCore() {
			ASPxHyperLink hyperlink = RenderHelper.CreateASPxHyperLink();
			hyperlink.ID = "hyperlink";
			return hyperlink;
		}
		protected override void ReadEditModeValueCore() {
			base.ReadEditModeValueCore();
			if(ASPxEditor is ASPxHyperLink) {
				SetupHyperLink((ASPxHyperLink)ASPxEditor);
			}
		}
		protected override void ReadViewModeValueCore() {
			base.ReadViewModeValueCore();
			ASPxHyperLink hyperlink = (ASPxHyperLink)InplaceViewModeEditor;
			SetupHyperLink(hyperlink);
		}
		private void SetupHyperLink(ASPxHyperLink hyperlink) {
			string url = Convert.ToString(PropertyValue);
			hyperlink.Text = url;
			hyperlink.NavigateUrl = GetResolvedUrl(url);
		}
		public override void BreakLinksToControl(bool unwireEventsOnly) {
			if(ASPxEditor is ASPxTextBox) {
				((ASPxTextBox)ASPxEditor).TextChanged -= EditValueChangedHandler;
			}
			base.BreakLinksToControl(unwireEventsOnly);
		}
		private static string GetResolvedUrl(object value) {
			string url = Convert.ToString(value);
			if(!string.IsNullOrEmpty(url)) {
				if(url.Contains("@") && IsValidUrl(url)) {
					return string.Format("mailto:{0}", url);
				}
				if(!url.Contains("://")) {
					url = string.Format("http://{0}", url);
				}
				if(IsValidUrl(url)) {
					return url;
				}
			}
			return string.Empty;
		}
		private static bool IsValidUrl(string url) {
			return Regex.IsMatch(url, UrlEmailMask);
		}
		protected override void ApplyReadOnly() {
			base.ApplyReadOnly();
			if(ASPxEditor is ASPxHyperLink) {
				ASPxEditor.ClientEnabled = true;
			}
		}
		public override bool CanFormatPropertyValue {
			get { return false; }
		}
	}
}