Imports System
Imports DevExpress.ExpressApp
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Updating

Namespace HyperLinkPropertyEditor.Web
    Public NotInheritable Partial Class HyperLinkPropertyEditorAspNetModule
        Inherits ModuleBase

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Function GetRegularTypes() As IEnumerable(Of Type)
            Return New Type() { GetType(WebHyperLinkStringPropertyEditor) }
        End Function
        Protected Overrides Function GetDeclaredExportedTypes() As IEnumerable(Of Type)
            Return Type.EmptyTypes
        End Function
        Protected Overrides Function GetDeclaredControllerTypes() As IEnumerable(Of Type)
            Return Type.EmptyTypes
        End Function
        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Return ModuleUpdater.EmptyModuleUpdaters
        End Function
    End Class
End Namespace
