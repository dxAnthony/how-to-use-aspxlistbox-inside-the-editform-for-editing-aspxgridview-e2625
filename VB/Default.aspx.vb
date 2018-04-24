Option Infer On

Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports DevExpress.Web

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)

    End Sub

    Protected Sub ASPxListBox1_DataBound(ByVal sender As Object, ByVal e As EventArgs)
        Dim listBox = DirectCast(sender, ASPxListBox)

        Dim editingRowVisibleIndex As Integer = ASPxGridView1.EditingRowVisibleIndex
        Dim rowValue As String = ASPxGridView1.GetRowValues(editingRowVisibleIndex, "Description").ToString()
        Dim rowValueItems() As String = rowValue.Split(";"c)

        Dim rowValueItemsAsList As New List(Of String)()
        rowValueItemsAsList.AddRange(rowValueItems)

        For Each item As ListEditItem In listBox.Items
            If rowValueItemsAsList.Contains(item.Value.ToString()) Then
                item.Selected = True
            End If
        Next item
    End Sub
    Protected Sub ASPxGridView1_RowUpdating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataUpdatingEventArgs)
        Dim grid = DirectCast(sender, ASPxGridView)
        Dim listBox As ASPxListBox = CType(grid.FindEditFormTemplateControl("ASPxListBox1"), ASPxListBox)

        Dim selectedItemsAsString As String = String.Empty

        For Each item As ListEditItem In listBox.SelectedItems
            selectedItemsAsString &= item.Text & ";"
        Next item

        If selectedItemsAsString.Length > 0 Then
            selectedItemsAsString = selectedItemsAsString.Trim(";"c)
        End If

        ' e.NewValues["Description"] = selectedItemsAsString; //Uncomment this line to allow editing 
    End Sub



    Protected Sub ASPxGridView1_RowValidating(ByVal sender As Object, ByVal e As DevExpress.Web.Data.ASPxDataValidationEventArgs)
        e.RowError = "Data source modification is not allowed. To test the updating operation, download the project and run it locally" 'Remove this line in local environment
    End Sub
End Class