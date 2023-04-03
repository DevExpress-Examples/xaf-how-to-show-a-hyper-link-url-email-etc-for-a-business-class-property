using System;
using DevExpress.Xpo;
using DevExpress.ExpressApp;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.BaseImpl;
using DevExpress.Persistent.Validation;
using DevExpress.Persistent.BaseImpl.EF;

namespace HyperLinkEditorEF.Module {
    [DefaultClassOptions]
    [DefaultListViewOptions(true, NewItemRowPosition.None)]
    public class HyperLinkDemoObject : BaseObject {

        public virtual string Name { get; set; }
        public virtual string MailUrl { get; set; }
        public virtual string Url { get; set; }
        public string UrlView { get { return Url; } }
        public string MailUrlView { get { return MailUrl; } }
    }
}