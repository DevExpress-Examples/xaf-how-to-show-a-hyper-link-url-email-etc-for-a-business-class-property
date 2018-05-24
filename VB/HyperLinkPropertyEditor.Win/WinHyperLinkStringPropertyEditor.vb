Imports System
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports DevExpress.ExpressApp.Model
Imports DevExpress.XtraEditors.Mask
Imports DevExpress.ExpressApp.Editors
Imports System.Text.RegularExpressions
Imports DevExpress.XtraEditors.Controls
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraEditors.Repository

Namespace HyperLinkPropertyEditor.Win
    <PropertyEditor(GetType(System.String), "HyperLinkStringPropertyEditor", False)>
    Public Class WinHyperLinkStringPropertyEditor
        Inherits StringPropertyEditor

        'Dennis TODO: This is to be setup via the Model Editor at the ViewItems | PropertyEditors | HyperLinkStringPropertyEditor level once.
        Public Const UrlEmailMask As String = "(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})"
        Private hyperlinkEditCore As HyperLinkEdit
        Public Sub New(ByVal objectType As Type, ByVal info As IModelMemberViewItem)
            MyBase.New(objectType, info)
        End Sub
        Public Shadows ReadOnly Property Control() As HyperLinkEdit
            Get
                Return hyperlinkEditCore
            End Get
        End Property
        Protected Overrides Function CreateRepositoryItem() As RepositoryItem
            Return New RepositoryItemHyperLinkEdit()
        End Function
        Protected Overrides Function CreateControlCore() As Object
            hyperlinkEditCore = New HyperLinkEdit()
            Return hyperlinkEditCore
        End Function
        Protected Overrides Sub SetupRepositoryItem(ByVal item As RepositoryItem)
            MyBase.SetupRepositoryItem(item)
            Dim hyperLinkProperties As RepositoryItemHyperLinkEdit = CType(item, RepositoryItemHyperLinkEdit)
            hyperLinkProperties.SingleClick = TypeOf View Is ListView
            hyperLinkProperties.TextEditStyle = TextEditStyles.Standard
            AddHandler hyperLinkProperties.OpenLink, AddressOf hyperLinkProperties_OpenLink
            EditMaskType = EditMaskType.RegEx
            hyperLinkProperties.Mask.MaskType = MaskType.RegEx
            hyperLinkProperties.Mask.EditMask = UrlEmailMask
        End Sub
        Private Sub hyperLinkProperties_OpenLink(ByVal sender As Object, ByVal e As OpenLinkEventArgs)
            e.EditValue = GetResolvedUrl(e.EditValue)
        End Sub
        Public Shared Function GetResolvedUrl(ByVal value As Object) As String
            Dim url As String = Convert.ToString(value)
            If Not String.IsNullOrEmpty(url) Then
                If url.Contains("@") AndAlso IsValidUrl(url) Then
                    Return String.Format("mailto:{0}", url)
                End If
                If Not url.Contains("://") Then
                    url = String.Format("http://{0}", url)
                End If
                If IsValidUrl(url) Then
                    Return url
                End If
            End If
            Return String.Empty
        End Function
        Private Shared Function IsValidUrl(ByVal url As String) As Boolean
            Return Regex.IsMatch(url, UrlEmailMask)
        End Function
    End Class
End Namespace