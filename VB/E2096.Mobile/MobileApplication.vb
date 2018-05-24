Imports System
Imports System.Configuration
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports System.ComponentModel
Imports DevExpress.ExpressApp.Mobile
Imports System.Collections.Generic
Imports DevExpress.ExpressApp.Xpo
Imports DevExpress.ExpressApp.Security

Namespace E2096.Mobile
    ' For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/DevExpressExpressAppWebWebApplicationMembersTopicAll.aspx
    Partial Public Class E2096MobileApplication
        Inherits MobileApplication

        Private module1 As DevExpress.ExpressApp.SystemModule.SystemModule
        Private module2 As DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule
        Private module3 As E2096.Module.E2096Module
        Private module4 As HyperLinkPropertyEditor.Mobile.HyperLinkPropertyEditorMobileModule
        Private objectsModule As DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule

#Region "Default XAF configuration options (https:" 'www.devexpress.com/kb=T501418)
        Shared Sub New()
            DevExpress.Persistent.Base.PasswordCryptographer.EnableRfc2898 = True
            DevExpress.Persistent.Base.PasswordCryptographer.SupportLegacySha512 = False
        End Sub
#End Region
        Public Sub New()
            Tracing.Initialize()
            If ConfigurationManager.ConnectionStrings("ConnectionString") IsNot Nothing Then
                ConnectionString = ConfigurationManager.ConnectionStrings("ConnectionString").ConnectionString
            End If

            InitializeComponent()
            DatabaseUpdateMode = DatabaseUpdateMode.UpdateDatabaseAlways
        End Sub
        Protected Overrides Sub CreateDefaultObjectSpaceProvider(ByVal args As CreateCustomObjectSpaceProviderEventArgs)
            args.ObjectSpaceProvider = New XPObjectSpaceProvider(GetDataStoreProvider(args.ConnectionString, args.Connection), True)
            args.ObjectSpaceProviders.Add(New NonPersistentObjectSpaceProvider(TypesInfo, Nothing))
        End Sub
        Private Function GetDataStoreProvider(ByVal connectionString As String, ByVal connection As System.Data.IDbConnection) As IXpoDataStoreProvider
            Dim dataStoreProvider As IXpoDataStoreProvider = Nothing
            If Not String.IsNullOrEmpty(connectionString) Then
                dataStoreProvider = New ConnectionStringDataStoreProvider(connectionString)
            ElseIf connection IsNot Nothing Then
                dataStoreProvider = New ConnectionDataStoreProvider(connection)
            End If
            Return dataStoreProvider
        End Function
        Private Sub HyperLinkPropertyEditorMobileApplication_DatabaseVersionMismatch(ByVal sender As Object, ByVal e As DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs) Handles MyBase.DatabaseVersionMismatch
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
            Me.module2 = New DevExpress.ExpressApp.Mobile.SystemModule.SystemMobileModule()
            Me.module3 = New E2096.Module.E2096Module()
            Me.module4 = New HyperLinkPropertyEditor.Mobile.HyperLinkPropertyEditorMobileModule()
            Me.objectsModule = New DevExpress.ExpressApp.Objects.BusinessClassLibraryCustomizationModule()
            DirectCast(Me, System.ComponentModel.ISupportInitialize).BeginInit()
            ' 
            ' E2096
            ' 
            Me.ApplicationName = "E2096"
            Me.Modules.Add(Me.module1)
            Me.Modules.Add(Me.module2)
            Me.Modules.Add(Me.module3)
            Me.Modules.Add(Me.module4)
            Me.Modules.Add(Me.objectsModule)
            '            Me.DatabaseVersionMismatch += New System.EventHandler(Of DevExpress.ExpressApp.DatabaseVersionMismatchEventArgs)(Me.HyperLinkPropertyEditorMobileApplication_DatabaseVersionMismatch)
            DirectCast(Me, System.ComponentModel.ISupportInitialize).EndInit()

        End Sub
    End Class
End Namespace
