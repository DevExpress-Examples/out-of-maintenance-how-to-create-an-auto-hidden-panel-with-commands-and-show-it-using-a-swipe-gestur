Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraEditors
Imports DevExpress.Utils.Gesture

Namespace WinRTMenu
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub
	End Class

	Public Class MyPanel
		Inherits PanelControl
		Implements IGestureClient
		Public Sub New()
			Me.helper = New GestureHelper(Me)
		End Sub

		Private helper As GestureHelper
		Protected ReadOnly Property GestureHelper() As GestureHelper
			Get
				Return helper
			End Get
		End Property

		Protected Overrides Sub WndProc(ByRef m As Message)
			If GestureHelper.WndProc(m) Then
				Return
			End If
			MyBase.WndProc(m)
		End Sub

		Private ReadOnly Property GestureAreaWidth() As Integer
			Get
				Return 32
			End Get
		End Property
		Protected ReadOnly Property GestureArea() As Rectangle
			Get
				Return New Rectangle(Width - GestureAreaWidth, 0, GestureAreaWidth, Height)
			End Get
		End Property

		Private menuPanel_Renamed As PanelControl
		<System.ComponentModel.DefaultValue(CType(Nothing, Object))> _
		Public Property MenuPanel() As PanelControl
			Get
				Return menuPanel_Renamed
			End Get
			Set(ByVal value As PanelControl)
				If MenuPanel Is value Then
					Return
				End If
				menuPanel_Renamed = value
				OnMenuPanelChanged()
			End Set
		End Property

		Protected Overridable Sub OnMenuPanelChanged()
			If MenuPanel Is Nothing Then
				Return
			End If
			InitMenuPanel()
			HideMenuPanel()
		End Sub

		Private Sub InitMenuPanel()
			MenuPanel.Dock = DockStyle.Right
			Controls.Add(MenuPanel)
		End Sub

		Private Sub HideMenuPanel()
			If MenuPanel Is Nothing Then
				Return
			End If
			MenuPanel.Width = 0
		End Sub

		Protected Overrides Sub OnHandleCreated(ByVal e As EventArgs)
			MyBase.OnHandleCreated(e)
			HideMenuPanel()
		End Sub

		#Region "IGestureClient Members"

		Private Function CheckAllowGestures(ByVal point As Point) As GestureAllowArgs() Implements IGestureClient.CheckAllowGestures
			If GestureArea.Contains(point) Then
				Return New GestureAllowArgs() { GestureAllowArgs.Pan }
			End If
			HideMenuPanel()
			Return New GestureAllowArgs() { }
		End Function

		Private ReadOnly Property Handle() As IntPtr Implements IGestureClient.Handle
			Get
				Return If(IsHandleCreated, Handle, IntPtr.Zero)
			End Get
		End Property

		Private Sub OnBegin(ByVal info As GestureArgs) Implements IGestureClient.OnBegin
			Me.deltaWidth = 0
		End Sub

		Private deltaWidth As Integer = 0
		Private ReadOnly Property ShowMenuDelta() As Integer
			Get
				Return 64
			End Get
		End Property
		Private ReadOnly Property IsMenuVisible() As Boolean
			Get
				Return MenuPanel IsNot Nothing AndAlso MenuPanel.Width > 0
			End Get
		End Property

		Private Sub OnPan(ByVal info As GestureArgs, ByVal delta As Point, ByRef overPan As Point) Implements IGestureClient.OnPan
			If MenuPanel Is Nothing OrElse IsMenuVisible Then
				Return
			End If
			deltaWidth += delta.X
			If deltaWidth < -ShowMenuDelta Then
				ShowMenuPanel()
			End If
		End Sub

		Private Sub ShowMenuPanel()
			MenuPanel.Width = 64
		End Sub

		Private Sub OnPressAndTap(ByVal info As GestureArgs) Implements IGestureClient.OnPressAndTap

		End Sub

		Private Sub OnRotate(ByVal info As GestureArgs, ByVal center As Point, ByVal degreeDelta As Double) Implements IGestureClient.OnRotate

		End Sub

		Private Sub OnTwoFingerTap(ByVal info As GestureArgs) Implements IGestureClient.OnTwoFingerTap

		End Sub

		Private Sub OnZoom(ByVal info As GestureArgs, ByVal center As Point, ByVal zoomDelta As Double) Implements IGestureClient.OnZoom

		End Sub

		Private ReadOnly Property OverPanWindowHandle() As IntPtr Implements IGestureClient.OverPanWindowHandle
			Get
				Dim frm As Form = FindForm()
				If frm IsNot Nothing AndAlso frm.IsHandleCreated Then
					Return frm.Handle
				End If
				Return IntPtr.Zero
			End Get
		End Property

		Private Function PointToClient(ByVal p As Point) As Point Implements IGestureClient.PointToClient
			Return PointToClient(p)
		End Function

		#End Region
	End Class
End Namespace