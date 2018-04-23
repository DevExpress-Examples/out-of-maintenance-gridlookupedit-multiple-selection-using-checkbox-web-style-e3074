Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraGrid.Columns
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository

Namespace GridLookUpEditCBMultipleSelection
	Partial Public Class Form1
		Inherits Form
		Private gridCheckMarksSA As GridCheckMarksSelection
		Private gridCheckMarksIP As GridCheckMarksSelection

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			Dim dt As DataTable = FillDataTable()
			gridLookUpEdit1.Properties.DataSource = dt
			gridLookUpEdit1.Properties.DisplayMember = "Fruit"
			gridLookUpEdit1.Properties.View.OptionsSelection.MultiSelect = True
			AddHandler gridLookUpEdit1.CustomDisplayText, AddressOf gridLookUpEdit1_CustomDisplayText
			gridLookUpEdit1.Properties.PopulateViewColumns()

			repositoryItemGridLookUpEdit1.DataSource = dt
			repositoryItemGridLookUpEdit1.DisplayMember = "Fruit"
			repositoryItemGridLookUpEdit1.View.OptionsSelection.MultiSelect = True
			AddHandler repositoryItemGridLookUpEdit1.CustomDisplayText, AddressOf gridLookUpEdit1_CustomDisplayText
			repositoryItemGridLookUpEdit1.PopulateViewColumns()



			gridCheckMarksSA = New GridCheckMarksSelection(gridLookUpEdit1.Properties)
			AddHandler gridCheckMarksSA.SelectionChanged, AddressOf gridCheckMarks_SelectionChanged
			gridCheckMarksSA.SelectAll(dt.DefaultView)
			gridLookUpEdit1.Properties.Tag = gridCheckMarksSA

			gridCheckMarksIP = New GridCheckMarksSelection(repositoryItemGridLookUpEdit1)
			repositoryItemGridLookUpEdit1.Tag = gridCheckMarksIP
			AddHandler gridCheckMarksIP.SelectionChanged, AddressOf gridCheckMarks_SelectionChanged
		End Sub

		Private Sub gridCheckMarks_SelectionChanged(ByVal sender As Object, ByVal e As EventArgs)
			If TypeOf ActiveControl Is GridLookUpEdit Then
				Dim sb As New StringBuilder()
				For Each rv As DataRowView In (TryCast(sender, GridCheckMarksSelection)).Selection
					If sb.ToString().Length > 0 Then
						sb.Append(", ")
					End If
					sb.Append(rv("Fruit").ToString())
				Next rv
				TryCast(ActiveControl, GridLookUpEdit).Text = sb.ToString()
			End If
		End Sub

		Private Sub gridLookUpEdit1_CustomDisplayText(ByVal sender As Object, ByVal e As DevExpress.XtraEditors.Controls.CustomDisplayTextEventArgs)
			Dim sb As New StringBuilder()
			Dim gridCheckMark As GridCheckMarksSelection = If(TypeOf sender Is GridLookUpEdit, TryCast((TryCast(sender, GridLookUpEdit)).Properties.Tag, GridCheckMarksSelection), TryCast((TryCast(sender, RepositoryItemGridLookUpEdit)).Tag, GridCheckMarksSelection))
			If gridCheckMark Is Nothing Then
				Return
			End If
			For Each rv As DataRowView In gridCheckMark.Selection
				If sb.ToString().Length > 0 Then
					sb.Append(", ")
				End If
				sb.Append(rv("Fruit").ToString())
			Next rv
			e.DisplayText = sb.ToString()
		End Sub

		Private Function FillDataTable() As DataTable
			Dim _dataTable As New DataTable()
			Dim col As DataColumn
			Dim row As DataRow

			col = New DataColumn()
			col.ColumnName = "Fruit"
			col.DataType = System.Type.GetType("System.String")
			_dataTable.Columns.Add(col)

			row = _dataTable.NewRow()
			row("Fruit") = "Peach"
			_dataTable.Rows.Add(row)
			row = _dataTable.NewRow()
			row("Fruit") = "Apple"
			_dataTable.Rows.Add(row)
			row = _dataTable.NewRow()
			row("Fruit") = "Banana"
			_dataTable.Rows.Add(row)

			Return _dataTable
		End Function

		Private Sub barEditItem1_EditValueChanged(ByVal sender As Object, ByVal e As EventArgs) Handles barEditItem1.EditValueChanged

		End Sub
	End Class
End Namespace
