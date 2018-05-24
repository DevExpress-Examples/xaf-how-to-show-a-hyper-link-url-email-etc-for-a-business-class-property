Imports System
Imports DevExpress.Web
Imports System.Web.UI.WebControls
Imports DevExpress.ExpressApp.Web
Imports DevExpress.ExpressApp.Model
Imports DevExpress.ExpressApp.Editors
Imports System.Text.RegularExpressions
Imports DevExpress.ExpressApp.Localization
Imports DevExpress.ExpressApp.Web.Editors.ASPx
Imports DevExpress.ExpressApp.Web.TestScripts

Namespace HyperLinkPropertyEditor.Web
    <PropertyEditor(GetType(System.String), "HyperLinkStringPropertyEditor", False)>
    Public Class WebHyperLinkStringPropertyEditor
        Inherits ASPxPropertyEditor

        'Dennis TODO: This is to be setup via the Model Editor at the ViewItems | PropertyEditors | HyperLinkStringPropertyEditor level once.
        Public Const UrlEmailMask As String = "(((http|https|ftp)\://)?[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&amp;amp;%\$#\=~])*)|([a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,6})"
        Public Sub New(ByVal objectType As Type, ByVal info As IModelMemberViewItem)
            MyBase.New(objectType, info)
            Me.CancelClickEventPropagation = True
        End Sub
        Protected Overrides Function CreateEditModeControlCore() As WebControl
            If AllowEdit.ResultValue Then
                Dim textBox As ASPxTextBox = RenderHelper.CreateASPxTextBox()
                textBox.ID = "textBox"
                textBox.ValidationSettings.RegularExpression.ValidationExpression = UrlEmailMask
                textBox.ValidationSettings.RegularExpression.ErrorText = UserVisibleExceptionLocalizer.GetExceptionMessage(UserVisibleExceptionId.MaskValidationErrorMessage)
                AddHandler textBox.TextChanged, AddressOf EditValueChangedHandler
                Return textBox
            Else
                Return CreateViewModeControlCore()
            End If
        End Function
        Protected Overrides Function CreateViewModeControlCore() As WebControl
            Dim hyperlink As ASPxHyperLink = RenderHelper.CreateASPxHyperLink()
            hyperlink.ID = "hyperlink"
            Return hyperlink
        End Function
        Protected Overrides Sub ReadEditModeValueCore()
            MyBase.ReadEditModeValueCore()
            If TypeOf ASPxEditor Is ASPxHyperLink Then
                SetupHyperLink(CType(ASPxEditor, ASPxHyperLink))
            End If
        End Sub
        Protected Overrides Sub ReadViewModeValueCore()
            MyBase.ReadViewModeValueCore()
            Dim hyperlink As ASPxHyperLink = CType(InplaceViewModeEditor, ASPxHyperLink)
            SetupHyperLink(hyperlink)
        End Sub
        Private Sub SetupHyperLink(ByVal hyperlink As ASPxHyperLink)
            Dim url As String = Convert.ToString(PropertyValue)
            hyperlink.Text = url
            hyperlink.NavigateUrl = GetResolvedUrl(url)
        End Sub
        Public Overrides Sub BreakLinksToControl(ByVal unwireEventsOnly As Boolean)
            If TypeOf ASPxEditor Is ASPxTextBox Then
                RemoveHandler CType(ASPxEditor, ASPxTextBox).TextChanged, AddressOf EditValueChangedHandler
            End If
            MyBase.BreakLinksToControl(unwireEventsOnly)
        End Sub
        Private Shared Function GetResolvedUrl(ByVal value As Object) As String
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
        Protected Overrides Sub ApplyReadOnly()
            MyBase.ApplyReadOnly()
            If TypeOf ASPxEditor Is ASPxHyperLink Then
                ASPxEditor.ClientEnabled = True
            End If
        End Sub
        Public Overrides ReadOnly Property CanFormatPropertyValue() As Boolean
            Get
                Return False
            End Get
        End Property
    End Class
End Namespace