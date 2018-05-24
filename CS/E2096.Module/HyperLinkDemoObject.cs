using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;

namespace E2096.Module {
    [DefaultClassOptions]
    [DefaultListViewOptions(true, NewItemRowPosition.None)]
    public class HyperLinkDemoObject : BaseObject {
        public HyperLinkDemoObject(Session session) : base(session) { }
        private string _Name;
        public string Name {
            get { return _Name; }
            set { SetPropertyValue("Name", ref _Name, value); }
        }
        private string _Url;
        [RuleRegularExpression("HyperLinkDemoObject.Url.RuleRegularExpression", DefaultContexts.Save, @"(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})")]
		[EditorAlias("HyperLinkStringPropertyEditor")]
        public string Url {
            get { return _Url; }
            set { SetPropertyValue("Url", ref _Url, value); }
        }
		[EditorAlias("HyperLinkStringPropertyEditor")]
		public string ReadOnlyUrl {
			get { return "www.devexpress.com"; }
		}
    }
}