Imports HyperLinkPropertyEditor.Mobile
Imports System
Imports System.Web

Namespace E2096.Mobile
    Public Class [Global]
        Inherits System.Web.HttpApplication

        Protected Sub Application_BeginRequest(ByVal sender As Object, ByVal e As EventArgs)
            CorsSupport.HandlePreflightRequest(HttpContext.Current)
        End Sub
    End Class
End Namespace
