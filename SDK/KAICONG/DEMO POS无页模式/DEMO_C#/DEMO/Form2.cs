using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using POSDLL_V2;
using POSDLL;

namespace DEMO
{
    public partial class Form2 : Form
    {
        #region:::::::::::::::::::::::::::::::::::::::::::Form level declarations:::::::::::::::::::::::::::::::::::::::::::
        public bool LeftButtonDown = false;

        public Point ClickPoint = new Point();
        public Point ReleasePoint = new Point();
        public Point LastPoint = new Point();
        public Point CurrentPoint = new Point();

        Graphics g;
        Pen MyPen = new Pen(Color.Blue, 1);
        Pen EraserPen = new Pen(Color.FromArgb(255, 255, 192), 1);

        private Form m_InstanceRef = null;
        public Form InstanceRef
        {
            get
            {
                return m_InstanceRef;
            }
            set
            {
                m_InstanceRef = value;
            }
        }

        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Event Handlers & Drawing Initialization:::::::::::::::::::::::::::::::::::::::::::
        public Form2()
        {

            InitializeComponent();
            this.MouseDown += new MouseEventHandler(mouse_Click);
            this.MouseUp += new MouseEventHandler(mouse_Up);
            this.MouseMove += new MouseEventHandler(mouse_Move);
            MyPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            g = this.CreateGraphics();


        }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Exit Button:::::::::::::::::::::::::::::::::::::::::::
        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion
        #region:::::::::::::::::::::::::::::::::::::::::::Mouse Buttons:::::::::::::::::::::::::::::::::::::::::::
        private void mouse_Click(object sender, MouseEventArgs e)
        {
            g.Clear(Color.FromArgb(255, 255, 192));
            LeftButtonDown = true;
            ClickPoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);
        }

        private void mouse_Up(object sender, MouseEventArgs e)
        {
            LeftButtonDown = false;
            ReleasePoint = new Point(System.Windows.Forms.Control.MousePosition.X, System.Windows.Forms.Control.MousePosition.Y);

            SaveScreen();
            this.Hide();
            POSDLL_V1.fmPOSDLL_V1.Show();

            byte[][] tmp = POSDLL.TEXTANDPIC.TAC_TurnPicToPixData(@"c:\demo.bmp");
            if (tmp != null)
            {
                byte[] data = POSDLL.CACULATE.CACU_PixDataToPrintedCommand_small(tmp, 0);
                POSDLL_V2.C_POSDLL.POS_WriteFile(POSDLL_V1.hPort, data);
            }

        }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::Drawing the rectangular selection window:::::::::::::::::::::::::::::::::::::::::::
        private void mouse_Move(object sender, MouseEventArgs e)
        {

            //Resize (actually delete then re-draw) the rectangle if the left mouse button is held down
            if (LeftButtonDown)
            {

                //Erase the previous rectangle
                g.DrawRectangle(EraserPen, ClickPoint.X, ClickPoint.Y, LastPoint.X - ClickPoint.X, LastPoint.Y - ClickPoint.Y);

                //Save the current location of the cursor for erasing the rectangle on next move
                LastPoint = new Point(Cursor.Position.X, Cursor.Position.Y);

                //Draw a new rectangle
                g.DrawRectangle(MyPen, ClickPoint.X, ClickPoint.Y, Cursor.Position.X - ClickPoint.X, Cursor.Position.Y - ClickPoint.Y);
                //Save the current cursor position, in case the button is released, for ScreenShot.CaptureImage
                CurrentPoint = new Point(Cursor.Position.X, Cursor.Position.Y);

            }

        }
        #endregion

        #region:::::::::::::::::::::::::::::::::::::::::::SaveScreen:::::::::::::::::::::::::::::::::::::::::::
        private void SaveScreen()
        {

            Point StartPoint = new Point(ClickPoint.X, ClickPoint.Y);
            Rectangle bounds = new Rectangle(ClickPoint.X, ClickPoint.Y, CurrentPoint.X - ClickPoint.X, CurrentPoint.Y - ClickPoint.Y);
            ScreenShot.CaptureImage(StartPoint, Point.Empty, bounds);
        }
        #endregion


    }
}