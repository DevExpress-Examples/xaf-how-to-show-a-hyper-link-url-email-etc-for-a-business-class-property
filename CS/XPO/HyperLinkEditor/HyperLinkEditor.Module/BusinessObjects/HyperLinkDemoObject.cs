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
        private string _mailUrl;
        public string MailUrl {
            get { return _mailUrl; }
            set { SetPropertyValue("MailUrl", ref _mailUrl, value); }
        }
		public string Url {
			get { return "www.devexpress.com"; }
		}
    }
}