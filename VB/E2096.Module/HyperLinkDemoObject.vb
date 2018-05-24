Imports System
Imports DevExpress.Xpo
Imports DevExpress.ExpressApp
Imports DevExpress.Persistent.Base
Imports DevExpress.Persistent.BaseImpl
Imports DevExpress.Persistent.Validation

Namespace E2096.Module
    <DefaultClassOptions, DefaultListViewOptions(True, NewItemRowPosition.None)>
    Public Class HyperLinkDemoObject
        Inherits BaseObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub
        Private _Name As String
        Public Property Name() As String
            Get
                Return _Name
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Name", _Name, value)
            End Set
        End Property
        Private _Url As String
        <RuleRegularExpression("HyperLinkDemoObject.Url.RuleRegularExpression", DefaultContexts.Save, "(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})"), EditorAlias("HyperLinkStringPropertyEditor")>
        Public Property Url() As String
            Get
                Return _Url
            End Get
            Set(ByVal value As String)
                SetPropertyValue("Url", _Url, value)
            End Set
        End Property
        <EditorAlias("HyperLinkStringPropertyEditor")>
        Public ReadOnly Property ReadOnlyUrl() As String
            Get
                Return "www.devexpress.com"
            End Get
        End Property
    End Class
End Namespace