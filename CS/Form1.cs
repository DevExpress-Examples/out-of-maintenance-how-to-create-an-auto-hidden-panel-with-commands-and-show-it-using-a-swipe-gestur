using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Gesture;

namespace WinRTMenu {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }
    }

    public class MyPanel : PanelControl, IGestureClient {
        public MyPanel() {
            this.helper = new GestureHelper(this);
        }
        
        GestureHelper helper;
        protected GestureHelper GestureHelper {
            get { return helper; }
        }

        protected override void WndProc(ref Message m) {
            if(GestureHelper.WndProc(ref m))
                return;
            base.WndProc(ref m);
        }

        int GestureAreaWidth { get { return 32; } }
        protected Rectangle GestureArea {
            get { return new Rectangle(Width - GestureAreaWidth, 0, GestureAreaWidth, Height); }
        }

        PanelControl menuPanel;
        [DefaultValue(null)]
        public PanelControl MenuPanel {
            get { return menuPanel; }
            set {
                if(MenuPanel == value)
                    return;
                menuPanel = value;
                OnMenuPanelChanged();
            }
        }

        protected virtual void OnMenuPanelChanged() {
            if(MenuPanel == null)
                return;
            InitMenuPanel();
            HideMenuPanel();
        }

        void InitMenuPanel() {
            MenuPanel.Dock = DockStyle.Right;
            Controls.Add(MenuPanel);
        }

        void HideMenuPanel() {
            if(MenuPanel == null)
                return;
            MenuPanel.Width = 0;
        }

        protected override void OnHandleCreated(EventArgs e) {
            base.OnHandleCreated(e);
            HideMenuPanel();
        }

        #region IGestureClient Members

        GestureAllowArgs[] IGestureClient.CheckAllowGestures(Point point) {
            if(GestureArea.Contains(point))
                return new GestureAllowArgs[] { GestureAllowArgs.Pan };
            HideMenuPanel();
            return new GestureAllowArgs[] { };
        }

        IntPtr IGestureClient.Handle {
            get {
                return IsHandleCreated ? Handle : IntPtr.Zero;
            }
        }

        void IGestureClient.OnBegin(GestureArgs info) {
            this.deltaWidth = 0;   
        }

        int deltaWidth = 0;
        int ShowMenuDelta { get { return 64; } }
        bool IsMenuVisible { get { return MenuPanel != null && MenuPanel.Width > 0; } }

        void IGestureClient.OnPan(GestureArgs info, Point delta, ref Point overPan) {
            if(MenuPanel == null || IsMenuVisible)
                return;
            deltaWidth += delta.X;
            if(deltaWidth < -ShowMenuDelta)
                ShowMenuPanel();
        }

        private void ShowMenuPanel() {
            MenuPanel.Width = 64;
        }

        void IGestureClient.OnPressAndTap(GestureArgs info) {
            
        }

        void IGestureClient.OnRotate(GestureArgs info, Point center, double degreeDelta) {
            
        }

        void IGestureClient.OnTwoFingerTap(GestureArgs info) {
            
        }

        void IGestureClient.OnZoom(GestureArgs info, Point center, double zoomDelta) {
            
        }

        IntPtr IGestureClient.OverPanWindowHandle {
            get {
                Form frm = FindForm();
                if(frm != null && frm.IsHandleCreated)
                    return frm.Handle;
                return IntPtr.Zero;
            }
        }

        Point IGestureClient.PointToClient(Point p) {
            return PointToClient(p);
        }

        #endregion
    }
}