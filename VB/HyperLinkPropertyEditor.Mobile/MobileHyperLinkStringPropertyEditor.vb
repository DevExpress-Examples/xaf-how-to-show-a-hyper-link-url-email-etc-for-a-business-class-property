Imports DevExpress.ExpressApp.Editors
Imports DevExpress.ExpressApp.Mobile
Imports DevExpress.ExpressApp.Mobile.Editors
Imports DevExpress.ExpressApp.Mobile.MobileModel
Imports DevExpress.ExpressApp.Model
Imports System

Namespace HyperLinkPropertyEditor.Mobile
    <PropertyEditor(GetType(System.String), "HyperLinkStringPropertyEditor", False)>
    Public Class MobileHyperLinkStringPropertyEditor
        Inherits MobileStringPropertyEditor

        Public Sub New(ByVal objectType As Type, ByVal model As IModelMemberViewItem)
            MyBase.New(objectType, model)
        End Sub
        Protected Overrides Function CreateViewModeControlCore() As Object
            Dim editor As New LinkComponent()
            editor.AddStyle("padding", "0px")
            Return editor
        End Function
        Protected Overrides Sub ReadViewModeValueCore()
            Dim linkPropertyName As String = PropertyName.ToClientIdentifier() & "Link"
            Dim linkCalculatedProperty As CalculatedField = ClientModelManager.RegisterProperty(linkPropertyName)
            linkCalculatedProperty.Getter = String.Format("var origValue = {0};" & ControlChars.CrLf & _
"                                                        var result = origValue;" & ControlChars.CrLf & _
"                                                        if (origValue) {{" & ControlChars.CrLf & _
"                                                            var phoneMatch = origValue.match(/\d/g);" & ControlChars.CrLf & _
"                                                            if (origValue.indexOf('@') !== -1) {{" & ControlChars.CrLf & _
"                                                                result = 'mailto://' + origValue;" & ControlChars.CrLf & _
"                                                            }} else if(phoneMatch && phoneMatch.length === 10) {{" & ControlChars.CrLf & _
"                                                                result = 'tel:' + origValue;" & ControlChars.CrLf & _
"                                                            }} else if(origValue.indexOf('://') == -1) {{" & ControlChars.CrLf & _
"                                                                result = 'http://' + origValue;" & ControlChars.CrLf & _
"                                                            }} else {{ " & ControlChars.CrLf & _
"                                                                result = origValue;" & ControlChars.CrLf & _
"                                                            }}" & ControlChars.CrLf & _
"                                                        }}" & ControlChars.CrLf & _
"                                                        return result;", BindToCurrentObjectProperty())

            Dim linkControl As LinkComponent = (CType(Control, LinkComponent))
            linkControl.Text = BindToCurrentObjectProperty()
            linkControl.Link = BindToProperty(linkPropertyName)
        End Sub
    End Class
End Namespace
