using System;
using DevExpress.ExpressApp.Updating;

namespace E2096.Module {
    public class Updater : ModuleUpdater {
        public Updater(DevExpress.ExpressApp.IObjectSpace objectSpace, Version currentDBVersion) : base(objectSpace, currentDBVersion) { }
        public override void UpdateDatabaseAfterUpdateSchema() {
            base.UpdateDatabaseAfterUpdateSchema();
            HyperLinkDemoObject obj1 = ObjectSpace.CreateObject<HyperLinkDemoObject>();
            obj1.Name = "HyperLinkDemoObject1";
            obj1.Url = "support@devexpress.com";
            obj1.Save();
            HyperLinkDemoObject obj2 = ObjectSpace.CreateObject<HyperLinkDemoObject>();
            obj2.Name = "HyperLinkDemoObject2";
            obj2.Url = "www.devexpress.com";
            obj2.Save();
            ObjectSpace.CommitChanges();
        }
    }
}