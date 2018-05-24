Imports System
Imports System.Drawing
Imports DevExpress.ExpressApp
Imports DevExpress.XtraEditors
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.ExpressApp.Win.Editors
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo

Namespace HyperLinkPropertyEditor.Win
    Public Class GridListEditorOpenHyperLinkViewController
        Inherits ViewController(Of ListView)

        Private gridListEditor As GridListEditor
        Protected Overrides Sub OnViewControlsCreated()
            MyBase.OnViewControlsCreated()
            gridListEditor = TryCast(CType(View, ListView).Editor, GridListEditor)
            If gridListEditor IsNot Nothing AndAlso gridListEditor.GridView IsNot Nothing Then
                AddHandler gridListEditor.GridView.MouseDown, AddressOf GridView_MouseDown
            End If
        End Sub
        Protected Overrides Sub OnDeactivated()
            If gridListEditor IsNot Nothing AndAlso gridListEditor.GridView IsNot Nothing Then
                RemoveHandler gridListEditor.GridView.MouseDown, AddressOf GridView_MouseDown
            End If
            MyBase.OnDeactivated()
        End Sub
        Private Sub GridView_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs)
            Dim gv As GridView = DirectCast(sender, GridView)
            Dim hi As GridHitInfo = gv.CalcHitInfo(New Point(e.X, e.Y))
            If hi.InRowCell Then
                Dim repositoryItemHyperLinkEdit As RepositoryItemHyperLinkEdit = TryCast(hi.Column.ColumnEdit, RepositoryItemHyperLinkEdit)
                If repositoryItemHyperLinkEdit IsNot Nothing Then
                    Dim editor As HyperLinkEdit = CType(repositoryItemHyperLinkEdit.CreateEditor(), HyperLinkEdit)
                    editor.ShowBrowser(WinHyperLinkStringPropertyEditor.GetResolvedUrl(gv.GetRowCellValue(hi.RowHandle, hi.Column)))
                End If
            End If
        End Sub
    End Class
End Namespace