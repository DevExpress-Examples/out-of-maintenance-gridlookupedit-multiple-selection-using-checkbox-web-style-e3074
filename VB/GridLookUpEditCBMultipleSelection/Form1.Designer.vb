Imports Microsoft.VisualBasic
Imports System
Namespace GridLookUpEditCBMultipleSelection
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.components = New System.ComponentModel.Container()
			Me.gridLookUpEdit1 = New DevExpress.XtraEditors.GridLookUpEdit()
			Me.gridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.label1 = New System.Windows.Forms.Label()
			Me.barManager1 = New DevExpress.XtraBars.BarManager(Me.components)
			Me.bar2 = New DevExpress.XtraBars.Bar()
			Me.barEditItem1 = New DevExpress.XtraBars.BarEditItem()
			Me.repositoryItemGridLookUpEdit1 = New DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit()
			Me.repositoryItemGridLookUpEdit1View = New DevExpress.XtraGrid.Views.Grid.GridView()
			Me.barDockControlTop = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlBottom = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlLeft = New DevExpress.XtraBars.BarDockControl()
			Me.barDockControlRight = New DevExpress.XtraBars.BarDockControl()
			CType(Me.gridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.gridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.repositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridLookUpEdit1
			' 
			Me.gridLookUpEdit1.Location = New System.Drawing.Point(12, 64)
			Me.gridLookUpEdit1.Name = "gridLookUpEdit1"
			Me.gridLookUpEdit1.Properties.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.gridLookUpEdit1.Properties.View = Me.gridLookUpEdit1View
			Me.gridLookUpEdit1.Size = New System.Drawing.Size(214, 20)
			Me.gridLookUpEdit1.TabIndex = 0
			' 
			' gridLookUpEdit1View
			' 
			Me.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
			Me.gridLookUpEdit1View.Name = "gridLookUpEdit1View"
			Me.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
			Me.gridLookUpEdit1View.OptionsView.ShowGroupPanel = False
			' 
			' label1
			' 
			Me.label1.AutoSize = True
			Me.label1.Location = New System.Drawing.Point(12, 48)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(90, 13)
			Me.label1.TabIndex = 1
			Me.label1.Text = "Standalone editor"
			' 
			' barManager1
			' 
			Me.barManager1.Bars.AddRange(New DevExpress.XtraBars.Bar() { Me.bar2})
			Me.barManager1.DockControls.Add(Me.barDockControlTop)
			Me.barManager1.DockControls.Add(Me.barDockControlBottom)
			Me.barManager1.DockControls.Add(Me.barDockControlLeft)
			Me.barManager1.DockControls.Add(Me.barDockControlRight)
			Me.barManager1.Form = Me
			Me.barManager1.Items.AddRange(New DevExpress.XtraBars.BarItem() { Me.barEditItem1})
			Me.barManager1.MainMenu = Me.bar2
			Me.barManager1.MaxItemId = 1
			Me.barManager1.RepositoryItems.AddRange(New DevExpress.XtraEditors.Repository.RepositoryItem() { Me.repositoryItemGridLookUpEdit1})
			' 
			' bar2
			' 
			Me.bar2.BarName = "Main menu"
			Me.bar2.DockCol = 0
			Me.bar2.DockRow = 0
			Me.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top
			Me.bar2.LinksPersistInfo.AddRange(New DevExpress.XtraBars.LinkPersistInfo() { New DevExpress.XtraBars.LinkPersistInfo(DevExpress.XtraBars.BarLinkUserDefines.PaintStyle, Me.barEditItem1, DevExpress.XtraBars.BarItemPaintStyle.Caption)})
			Me.bar2.OptionsBar.MultiLine = True
			Me.bar2.OptionsBar.UseWholeRow = True
			Me.bar2.Text = "Main menu"
			' 
			' barEditItem1
			' 
			Me.barEditItem1.Caption = "In-place editor"
			Me.barEditItem1.Edit = Me.repositoryItemGridLookUpEdit1
			Me.barEditItem1.Id = 0
			Me.barEditItem1.Name = "barEditItem1"
			Me.barEditItem1.Width = 200
'			Me.barEditItem1.EditValueChanged += New System.EventHandler(Me.barEditItem1_EditValueChanged);
			' 
			' repositoryItemGridLookUpEdit1
			' 
			Me.repositoryItemGridLookUpEdit1.AutoHeight = False
			Me.repositoryItemGridLookUpEdit1.Buttons.AddRange(New DevExpress.XtraEditors.Controls.EditorButton() { New DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)})
			Me.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1"
			Me.repositoryItemGridLookUpEdit1.View = Me.repositoryItemGridLookUpEdit1View
			' 
			' repositoryItemGridLookUpEdit1View
			' 
			Me.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus
			Me.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View"
			Me.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = False
			Me.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = False
			' 
			' barDockControlTop
			' 
			Me.barDockControlTop.CausesValidation = False
			Me.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top
			Me.barDockControlTop.Location = New System.Drawing.Point(0, 0)
			Me.barDockControlTop.Size = New System.Drawing.Size(540, 22)
			' 
			' barDockControlBottom
			' 
			Me.barDockControlBottom.CausesValidation = False
			Me.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom
			Me.barDockControlBottom.Location = New System.Drawing.Point(0, 302)
			Me.barDockControlBottom.Size = New System.Drawing.Size(540, 0)
			' 
			' barDockControlLeft
			' 
			Me.barDockControlLeft.CausesValidation = False
			Me.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left
			Me.barDockControlLeft.Location = New System.Drawing.Point(0, 22)
			Me.barDockControlLeft.Size = New System.Drawing.Size(0, 280)
			' 
			' barDockControlRight
			' 
			Me.barDockControlRight.CausesValidation = False
			Me.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right
			Me.barDockControlRight.Location = New System.Drawing.Point(540, 22)
			Me.barDockControlRight.Size = New System.Drawing.Size(0, 280)
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(540, 302)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.gridLookUpEdit1)
			Me.Controls.Add(Me.barDockControlLeft)
			Me.Controls.Add(Me.barDockControlRight)
			Me.Controls.Add(Me.barDockControlBottom)
			Me.Controls.Add(Me.barDockControlTop)
			Me.Name = "Form1"
			Me.Text = "Form1"
'			Me.Load += New System.EventHandler(Me.Form1_Load);
			CType(Me.gridLookUpEdit1.Properties, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.gridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.barManager1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemGridLookUpEdit1, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.repositoryItemGridLookUpEdit1View, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private gridLookUpEdit1 As DevExpress.XtraEditors.GridLookUpEdit
		Private gridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
		Private label1 As System.Windows.Forms.Label
		Private barManager1 As DevExpress.XtraBars.BarManager
		Private bar2 As DevExpress.XtraBars.Bar
		Private WithEvents barEditItem1 As DevExpress.XtraBars.BarEditItem
		Private repositoryItemGridLookUpEdit1 As DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit
		Private repositoryItemGridLookUpEdit1View As DevExpress.XtraGrid.Views.Grid.GridView
		Private barDockControlTop As DevExpress.XtraBars.BarDockControl
		Private barDockControlBottom As DevExpress.XtraBars.BarDockControl
		Private barDockControlLeft As DevExpress.XtraBars.BarDockControl
		Private barDockControlRight As DevExpress.XtraBars.BarDockControl
	End Class
End Namespace

