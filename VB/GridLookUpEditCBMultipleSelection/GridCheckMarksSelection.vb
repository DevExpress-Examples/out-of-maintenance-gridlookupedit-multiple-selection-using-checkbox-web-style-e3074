Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Collections
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.XtraGrid.Views.Grid
Imports DevExpress.XtraGrid.Views.Base
Imports System.Windows.Forms
Imports DevExpress.Utils.Drawing
Imports DevExpress.XtraGrid.Views.Grid.ViewInfo
Imports System.Drawing
Imports DevExpress.XtraGrid.Columns

Namespace GridLookUpEditCBMultipleSelection
	Public Class GridCheckMarksSelection
		Private _currentRepository As RepositoryItemGridLookUpEdit

		Protected selection_Renamed As ArrayList
		Protected checkColumnFieldName As String = "CheckMarkSelection"
		Private edit As RepositoryItemCheckEdit
		Private Const CheckboxIndent As Integer = 4

		Public Sub New(ByVal repository As RepositoryItemGridLookUpEdit)
			Me.New()
			CurrentRepository = repository
		End Sub

		Public Property CurrentRepository() As RepositoryItemGridLookUpEdit
			Get
				Return _currentRepository
			End Get
			Set(ByVal value As RepositoryItemGridLookUpEdit)
				If _currentRepository IsNot value Then
					Detach()
					Attach(value)
				End If
			End Set
		End Property

		Public Sub New()
			selection_Renamed = New ArrayList()
			Me.OnSelectionChanged()
		End Sub

		Public Property Selection() As ArrayList
			Get
				Return selection_Renamed
			End Get
			Set(ByVal value As ArrayList)
				selection_Renamed = value
			End Set
		End Property

		Public ReadOnly Property SelectedCount() As Integer
			Get
				Return selection_Renamed.Count
			End Get
		End Property

		Public Function GetSelectedRow(ByVal index As Integer) As Object
			Return selection_Renamed(index)
		End Function

		Public Function GetSelectedIndex(ByVal row As Object) As Integer
			Return selection_Renamed.IndexOf(row)
		End Function

		Public Sub ClearSelection(ByVal currentView As GridView)
			selection_Renamed.Clear()
			Invalidate(currentView)
			OnSelectionChanged()
		End Sub

		Public Sub SelectAll(ByVal sourceObject As Object)
			selection_Renamed.Clear()
			If sourceObject IsNot Nothing Then
				If TypeOf sourceObject Is ICollection Then
					selection_Renamed.AddRange((CType(sourceObject, ICollection)))
				Else
					Dim currentView As GridView = TryCast(sourceObject, GridView)
					For i As Integer = 0 To currentView.DataRowCount - 1
						selection_Renamed.Add(currentView.GetRow(i))
					Next i
					Invalidate(currentView)
				End If
			End If
			Me.OnSelectionChanged()
		End Sub


		Public Delegate Sub SelectionChangedEventHandler(ByVal sender As Object, ByVal e As EventArgs)
		Public Event SelectionChanged As SelectionChangedEventHandler
		Public Sub OnSelectionChanged()
			If SelectionChangedEvent IsNot Nothing Then
				Dim e As New EventArgs()
				RaiseEvent SelectionChanged(Me, e)
			End If
		End Sub
		Public Sub SelectGroup(ByVal currentView As GridView, ByVal rowHandle As Integer, ByVal [select] As Boolean)
			If IsGroupRowSelected(currentView, rowHandle) AndAlso [select] Then
				Return
			End If
			For i As Integer = 0 To currentView.GetChildRowCount(rowHandle) - 1
				Dim childRowHandle As Integer = currentView.GetChildRowHandle(rowHandle, i)
				If currentView.IsGroupRow(childRowHandle) Then
					SelectGroup(currentView, childRowHandle, [select])
				Else
					SelectRow(currentView, childRowHandle, [select], False)
				End If
			Next i
			Invalidate(currentView)
		End Sub

		Public Sub SelectRow(ByVal currentView As GridView, ByVal rowHandle As Integer, ByVal [select] As Boolean)
			SelectRow(currentView, rowHandle, [select], True)
		End Sub

		Public Sub InvertRowSelection(ByVal currentView As GridView, ByVal rowHandle As Integer)
			If currentView.IsDataRow(rowHandle) Then
				SelectRow(currentView, rowHandle, (Not IsRowSelected(currentView, rowHandle)))
			End If
			If currentView.IsGroupRow(rowHandle) Then
				SelectGroup(currentView, rowHandle, (Not IsGroupRowSelected(currentView, rowHandle)))
			End If
		End Sub
		Public Function IsGroupRowSelected(ByVal currentView As GridView, ByVal rowHandle As Integer) As Boolean
			For i As Integer = 0 To currentView.GetChildRowCount(rowHandle) - 1
				Dim row As Integer = currentView.GetChildRowHandle(rowHandle, i)
				If currentView.IsGroupRow(row) Then
					If (Not IsGroupRowSelected(currentView, row)) Then
						Return False
					End If
				Else
					If (Not IsRowSelected(currentView, row)) Then
						Return False
					End If
				End If
			Next i
			Return True
		End Function
		Public Function IsRowSelected(ByVal currentView As GridView, ByVal rowHandle As Integer) As Boolean
			If currentView.IsGroupRow(rowHandle) Then
				Return IsGroupRowSelected(currentView, rowHandle)
			End If

			Dim row As Object = currentView.GetRow(rowHandle)
			Return GetSelectedIndex(row) <> -1
		End Function

		Protected Overridable Sub Attach(ByVal rep As RepositoryItemGridLookUpEdit)
			If rep Is Nothing Then
				Return
			End If
			selection_Renamed.Clear()
			_currentRepository = rep

			edit = TryCast(_currentRepository.View.GridControl.RepositoryItems.Add("CheckEdit"), RepositoryItemCheckEdit)

			Dim column As GridColumn = _currentRepository.View.Columns.Add()
			column.OptionsColumn.AllowSort = DevExpress.Utils.DefaultBoolean.False
			column.Visible = True
			column.VisibleIndex = 0
			column.FieldName = checkColumnFieldName
			column.Caption = "Mark"
			column.OptionsColumn.ShowCaption = False
			column.OptionsColumn.AllowEdit = False
			column.OptionsColumn.AllowSize = False
			column.UnboundType = DevExpress.Data.UnboundColumnType.Boolean
			column.Width = GetCheckBoxWidth()
			column.ColumnEdit = edit

			AddHandler _currentRepository.View.Click, AddressOf View_Click
			AddHandler _currentRepository.View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
			AddHandler _currentRepository.View.CustomDrawGroupRow, AddressOf View_CustomDrawGroupRow
			AddHandler _currentRepository.View.CustomUnboundColumnData, AddressOf view_CustomUnboundColumnData
			AddHandler _currentRepository.View.KeyDown, AddressOf view_KeyDown
		End Sub

		Protected Overridable Sub Detach()
			If _currentRepository Is Nothing Then
				Return
			End If
			If edit IsNot Nothing Then
				_currentRepository.View.GridControl.RepositoryItems.Remove(edit)
				edit.Dispose()
			End If
			RemoveHandler _currentRepository.View.Click, AddressOf View_Click
			RemoveHandler _currentRepository.View.CustomDrawColumnHeader, AddressOf View_CustomDrawColumnHeader
			RemoveHandler _currentRepository.View.CustomDrawGroupRow, AddressOf View_CustomDrawGroupRow
			RemoveHandler _currentRepository.View.CustomUnboundColumnData, AddressOf view_CustomUnboundColumnData
			RemoveHandler _currentRepository.View.KeyDown, AddressOf view_KeyDown
			_currentRepository = Nothing
		End Sub
		Protected Function GetCheckBoxWidth() As Integer
			Dim info As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo = TryCast(edit.CreateViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
			Dim width As Integer = 0
			GraphicsInfo.Default.AddGraphics(Nothing)
			Try
				width = info.CalcBestFit(GraphicsInfo.Default.Graphics).Width
			Finally
				GraphicsInfo.Default.ReleaseGraphics()
			End Try
			Return width + CheckboxIndent * 2
		End Function

		Protected Sub DrawCheckBox(ByVal g As Graphics, ByVal r As Rectangle, ByVal Checked As Boolean)
			Dim info As DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo
			Dim painter As DevExpress.XtraEditors.Drawing.CheckEditPainter
			Dim args As DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs
			info = TryCast(edit.CreateViewInfo(), DevExpress.XtraEditors.ViewInfo.CheckEditViewInfo)
			painter = TryCast(edit.CreatePainter(), DevExpress.XtraEditors.Drawing.CheckEditPainter)
			info.EditValue = Checked
			info.Bounds = r
			info.CalcViewInfo(g)
			args = New DevExpress.XtraEditors.Drawing.ControlGraphicsInfoArgs(info, New DevExpress.Utils.Drawing.GraphicsCache(g), r)
			painter.Draw(args)
			args.Cache.Dispose()
		End Sub

		Private Sub Invalidate(ByVal currentView As GridView)
			currentView.BeginUpdate()
			currentView.EndUpdate()
		End Sub
		Private Sub SelectRow(ByVal currentView As GridView, ByVal rowHandle As Integer, ByVal [select] As Boolean, ByVal invalidate As Boolean)
			If IsRowSelected(currentView, rowHandle) = [select] Then
				Return
			End If
			Dim row As Object = currentView.GetRow(rowHandle)
			If [select] Then
				selection_Renamed.Add(row)
			Else
				selection_Renamed.Remove(row)
			End If
			If invalidate Then
				Me.Invalidate(currentView)
			End If
			OnSelectionChanged()
		End Sub
		Private Sub view_CustomUnboundColumnData(ByVal sender As Object, ByVal e As CustomColumnDataEventArgs)
			Dim currentView As GridView = TryCast(sender, GridView)
			If e.Column IsNot Nothing AndAlso e.Column.FieldName = checkColumnFieldName Then
				If e.IsGetData Then
					e.Value = IsRowSelected(currentView, currentView.GetRowHandle(e.ListSourceRowIndex))
				Else
					SelectRow(currentView, currentView.GetRowHandle(e.ListSourceRowIndex), CBool(e.Value))
				End If
			End If
		End Sub
		Private Sub view_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs)
			Dim currentView As GridView = TryCast(sender, GridView)
			If currentView.FocusedColumn.FieldName <> checkColumnFieldName OrElse e.KeyCode <> Keys.Space Then
				Return
			End If
			InvertRowSelection(currentView, currentView.FocusedRowHandle)
		End Sub
		Private Sub View_Click(ByVal sender As Object, ByVal e As EventArgs)
			Dim info As GridHitInfo
			Dim currentView As GridView = (TryCast(sender, GridView))
			Dim pt As Point = currentView.GridControl.PointToClient(Control.MousePosition)
			info = currentView.CalcHitInfo(pt)
			If info.Column IsNot Nothing AndAlso info.Column.FieldName = checkColumnFieldName Then
				If info.InColumn Then
					If SelectedCount = currentView.DataRowCount Then
						ClearSelection(currentView)
					Else
						SelectAll(currentView)
					End If
				End If
				If info.InRowCell Then
					InvertRowSelection(currentView, info.RowHandle)
				End If
			End If
			If info.InRow AndAlso currentView.IsGroupRow(info.RowHandle) AndAlso info.HitTest <> GridHitTest.RowGroupButton Then
				InvertRowSelection(currentView, info.RowHandle)
			End If
		End Sub
		Private Sub View_CustomDrawColumnHeader(ByVal sender As Object, ByVal e As ColumnHeaderCustomDrawEventArgs)
			If e.Column IsNot Nothing AndAlso e.Column.FieldName = checkColumnFieldName Then
				e.Info.InnerElements.Clear()
				e.Painter.DrawObject(e.Info)
				DrawCheckBox(e.Graphics, e.Bounds, SelectedCount = (TryCast(sender, GridView)).DataRowCount)
				e.Handled = True
			End If
		End Sub
		Private Sub View_CustomDrawGroupRow(ByVal sender As Object, ByVal e As RowObjectCustomDrawEventArgs)
			Dim info As DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo
			info = TryCast(e.Info, DevExpress.XtraGrid.Views.Grid.ViewInfo.GridGroupRowInfo)

			info.GroupText = "         " & info.GroupText.TrimStart()
			e.Info.Paint.FillRectangle(e.Graphics, e.Appearance.GetBackBrush(e.Cache), e.Bounds)
			e.Painter.DrawObject(e.Info)

			Dim r As Rectangle = info.ButtonBounds
			r.Offset(r.Width + CheckboxIndent * 2 - 1, 0)
			DrawCheckBox(e.Graphics, r, IsGroupRowSelected((TryCast(sender, GridView)), e.RowHandle))
			e.Handled = True
		End Sub
	End Class
End Namespace
