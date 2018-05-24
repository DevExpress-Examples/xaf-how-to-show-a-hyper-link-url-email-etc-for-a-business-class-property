Imports System
Imports System.Collections.Generic
Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Updating

Namespace HyperLinkPropertyEditor.Win
    Public NotInheritable Partial Class HyperLinkPropertyEditorWindowsFormsModule
        Inherits ModuleBase

        Public Sub New()
            InitializeComponent()
        End Sub
        Protected Overrides Function GetDeclaredControllerTypes() As IEnumerable(Of Type)
            Return New Type() { GetType(GridListEditorOpenHyperLinkViewController) }
        End Function
        Protected Overrides Function GetRegularTypes() As IEnumerable(Of Type)
            Return New Type() { GetType(WinHyperLinkStringPropertyEditor) }
        End Function
        Public Overrides Function GetModuleUpdaters(ByVal objectSpace As IObjectSpace, ByVal versionFromDB As Version) As IEnumerable(Of ModuleUpdater)
            Return ModuleUpdater.EmptyModuleUpdaters
        End Function
        Protected Overrides Function GetDeclaredExportedTypes() As IEnumerable(Of Type)
            Return Type.EmptyTypes
        End Function
    End Class
End Namespace
