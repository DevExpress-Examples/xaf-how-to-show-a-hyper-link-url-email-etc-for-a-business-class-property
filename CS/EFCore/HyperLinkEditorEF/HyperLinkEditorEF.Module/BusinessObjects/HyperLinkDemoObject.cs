using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl.EF;

namespace E2096.Module {
    [DefaultClassOptions]
    [DefaultListViewOptions(true, NewItemRowPosition.None)]
    public class HyperLinkDemoObject : BaseObject {
    
        public virtual string Name {            get;set;        }
        public virtual string MailUrl {            get;set;        }
		public string Url {			get { return "www.devexpress.com"; }		}
    }
}