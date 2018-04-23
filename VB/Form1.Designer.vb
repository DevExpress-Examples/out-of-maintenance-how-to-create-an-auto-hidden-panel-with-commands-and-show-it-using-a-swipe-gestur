Imports Microsoft.VisualBasic
Imports System
Namespace WinRTMenu
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
			Me.panelControl1 = New WinRTMenu.MyPanel()
			Me.menuPanel = New DevExpress.XtraEditors.PanelControl()
			Me.labelControl3 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl2 = New DevExpress.XtraEditors.LabelControl()
			Me.labelControl1 = New DevExpress.XtraEditors.LabelControl()
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.panelControl1.SuspendLayout()
			CType(Me.menuPanel, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.menuPanel.SuspendLayout()
			Me.SuspendLayout()
			' 
			' panelControl1
			' 
			Me.panelControl1.Controls.Add(Me.menuPanel)
			Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Fill
			Me.panelControl1.Location = New System.Drawing.Point(0, 0)
			Me.panelControl1.MenuPanel = Me.menuPanel
			Me.panelControl1.Name = "panelControl1"
			Me.panelControl1.Size = New System.Drawing.Size(1047, 481)
			Me.panelControl1.TabIndex = 0
			' 
			' menuPanel
			' 
			Me.menuPanel.Controls.Add(Me.labelControl3)
			Me.menuPanel.Controls.Add(Me.labelControl2)
			Me.menuPanel.Controls.Add(Me.labelControl1)
			Me.menuPanel.Dock = System.Windows.Forms.DockStyle.Right
			Me.menuPanel.Location = New System.Drawing.Point(1045, 2)
			Me.menuPanel.LookAndFeel.SkinName = "DevExpress Dark Style"
			Me.menuPanel.LookAndFeel.UseDefaultLookAndFeel = False
			Me.menuPanel.Name = "menuPanel"
			Me.menuPanel.Size = New System.Drawing.Size(0, 477)
			Me.menuPanel.TabIndex = 0
			' 
			' labelControl3
			' 
			Me.labelControl3.Appearance.Image = My.Resources.Edit_32x32
			Me.labelControl3.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
			Me.labelControl3.Location = New System.Drawing.Point(16, 274)
			Me.labelControl3.Name = "labelControl3"
			Me.labelControl3.Size = New System.Drawing.Size(37, 36)
			Me.labelControl3.TabIndex = 2
			' 
			' labelControl2
			' 
			Me.labelControl2.Appearance.Image = My.Resources.Save_32x32
			Me.labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
			Me.labelControl2.Location = New System.Drawing.Point(16, 219)
			Me.labelControl2.Name = "labelControl2"
			Me.labelControl2.Size = New System.Drawing.Size(37, 36)
			Me.labelControl2.TabIndex = 1
			' 
			' labelControl1
			' 
			Me.labelControl1.Appearance.Image = My.Resources.Delete_32x32
			Me.labelControl1.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter
			Me.labelControl1.Location = New System.Drawing.Point(16, 167)
			Me.labelControl1.Name = "labelControl1"
			Me.labelControl1.Size = New System.Drawing.Size(37, 36)
			Me.labelControl1.TabIndex = 0
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(1047, 481)
			Me.Controls.Add(Me.panelControl1)
			Me.Name = "Form1"
			Me.Text = "Form1"
			CType(Me.panelControl1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.panelControl1.ResumeLayout(False)
			CType(Me.menuPanel, System.ComponentModel.ISupportInitialize).EndInit()
			Me.menuPanel.ResumeLayout(False)
			Me.menuPanel.PerformLayout()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private panelControl1 As MyPanel
		Private menuPanel As DevExpress.XtraEditors.PanelControl
		Private labelControl1 As DevExpress.XtraEditors.LabelControl
		Private labelControl2 As DevExpress.XtraEditors.LabelControl
		Private labelControl3 As DevExpress.XtraEditors.LabelControl
	End Class
End Namespace

