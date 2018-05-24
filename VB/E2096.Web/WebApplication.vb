Imports DevExpress.ExpressApp
Imports DevExpress.ExpressApp.Xpo
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Web

Namespace E2096.Web
    Partial Public Class E2096AspNetApplication
        Inherits WebApplication

        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(args.ConnectionString, args.Connection, True)
        End Sub
        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule
        Private module3 As E2096.Module.E2096Module
        Private HyperLinkPropertyEditorAspNetModule1 As HyperLinkPropertyEditor.Web.HyperLinkPropertyEditorAspNetModule
        Private module6 As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub E2096AspNetApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
#If EASYTEST Then
            e.Updater.Update()
            e.Handled = True
#Else
            e.Updater.Update()
            e.Handled = True
#End If
        End Sub

        Private Sub InitializeComponent()
            Me.module1 = New DevExpress.ExpressApp.SystemModule.SystemModule()
            Me.module2 = New DevExpress.ExpressApp.Web.SystemModule.SystemAspNetModule()
            Me.module3 = New E2096.Module.E2096Module()
            Me.module6 = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            Me.HyperLinkPropertyEditorAspNetModule1 = New HyperLinkPropertyEditor.Web.HyperLinkPropertyEditorAspNetModule()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' module1
            ' 
            Me.module1.AdditionalExportedTypes.Add(GetType(DevExpress.Xpo.XPObjectType))
            ' 
            ' E2096AspNetApplication
            ' 
            Me.ApplicationName = "E2096"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module6)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.HyperLinkPropertyEditorAspNetModule1)
'            Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.E2096AspNetApplication_DatabaseVersionMismatch)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
