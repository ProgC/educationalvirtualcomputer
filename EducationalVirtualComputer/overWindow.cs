using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace EducationalVirtualComputer
{
    public partial class overWindow : Form
    {
        public overWindow()
        {
            InitializeComponent();
        }

        public int sx;
        public int sy;
        public int ex;
        public int ey;
        public int cellWidth;
        public int cellHeight;
        public virtualcomputer VirtualComputer;
        private int HighlightTime;
        private double HighlightOpacity;
        private double ScaleTick;
        
        private enum State
        {
            MOVING,
            HIGHLIGHTING,
        }

        State CurrentState = State.MOVING;
        
        private void overWindow_Load(object sender, EventArgs e)
        {
            Left = sx;
            Top = sy;
        }
        
        private void updateTimer_Tick(object sender, EventArgs e)
        {                           
            if (CurrentState == State.MOVING)
            {
                double dx = ex - this.Left;
                double dy = ey - this.Top;

                double dist = Math.Sqrt((double)(dx * dx + dy * dy));
                if (dist == 0) dist = 1;
                dx /= dist;
                dy /= dist;

                this.Left += (int)(dx * 20);// dist/2);
                this.Top += (int)(dy * 20);//dist/2);

                if (dist < 20)
                {
                    CurrentState = State.HIGHLIGHTING;
                    HighlightTime = 2 * 30;

                    Width = cellWidth;
                    Height = cellHeight;
                    BackColor = Color.Red;
                    Opacity = 1;
                    HighlightOpacity = -0.3;
                    ScaleTick = 0;

                    updateTimer.Interval = 30;
                    Left = ex;
                    Top = ey;
                }
            }
            else if (CurrentState == State.HIGHLIGHTING)
            {
                HighlightTime -= 1;

                /*Opacity += HighlightOpacity;
                if (HighlightOpacity == -0.3 && Opacity <= 0.5)
                {
                    Opacity = 0.5;
                    HighlightOpacity = 0.3;
                }
                else if ( HighlightOpacity == 0.3 && Opacity >= 1)
                {
                    Opacity = 1;
                    HighlightOpacity = -0.3;
                }*/
                
                // scale animation                
                ScaleTick += 0.5;
                double scale = 1.2 + Math.Sin(ScaleTick) * 0.2;
                double newCellWidth = cellWidth * scale;
                double newCellHeight = cellHeight * scale;
                
                double cx = ex + cellWidth / 2;
                double cy = ey + cellHeight / 2;

                Left = (int)(cx - newCellWidth / 2);
                Top = (int)(cy - newCellHeight / 2);
                Width = (int)newCellWidth;
                Height = (int)newCellHeight;
                
                if (HighlightTime < 0)
                {
                    VirtualComputer.EndOfAnimation();
                    Close();
                }

                // update label's location
                label1.Left = (Width / 2) - (label1.Width / 2);
                label1.Top = (Height / 2) - (label1.Height / 2);   
            }

                    
        }

        public void SetAnim(int inX, int inY, int inEx, int inEy, int inCellWidth, int inCellHeight)
        {
            sx = inX;
            sy = inY;
            ex = inEx;
            ey = inEy;
            cellWidth = inCellWidth;
            cellHeight = inCellHeight;
        }

        public void SetText(string val)
        {
            label1.Text = val;
        }
    }
}
