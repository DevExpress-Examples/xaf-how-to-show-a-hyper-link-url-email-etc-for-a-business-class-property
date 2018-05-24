Imports System
Imports DevExpress.ExpressApp.Updating

Namespace E2096.Module
    Public Class Updater
        Inherits ModuleUpdater

        Public Sub New(ByVal objectSpace As DevExpress.ExpressApp.IObjectSpace, ByVal currentDBVersion As Version)
            MyBase.New(objectSpace, currentDBVersion)
        End Sub
        Public Overrides Sub UpdateDatabaseAfterUpdateSchema()
            MyBase.UpdateDatabaseAfterUpdateSchema()
            Dim obj1 As HyperLinkDemoObject = ObjectSpace.CreateObject(Of HyperLinkDemoObject)()
            obj1.Name = "HyperLinkDemoObject1"
            obj1.Url = "support@devexpress.com"
            obj1.Save()
            Dim obj2 As HyperLinkDemoObject = ObjectSpace.CreateObject(Of HyperLinkDemoObject)()
            obj2.Name = "HyperLinkDemoObject2"
            obj2.Url = "www.devexpress.com"
            obj2.Save()
            ObjectSpace.CommitChanges()
        End Sub
    End Class
End Namespace