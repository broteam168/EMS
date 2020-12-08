using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;

namespace LDSong.Libs
{
    public class TranspCtrl2 : Panel
    {
        private Color brushColor = Color.Transparent;
        private Color fillColor = Color.Transparent;
        private int opacity = 20;
        private float lineThick = 1.0f;

        public TranspCtrl2()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.ResizeRedraw, true);

            //Set style for double buffering
            SetStyle(ControlStyles.DoubleBuffer | ControlStyles.AllPaintingInWmPaint | ControlStyles.UserPaint, true);

            //Set the default backcolor
            this.BackColor = Color.Transparent;
        }

        public Color FillColor
        {
            get
            {
                return this.fillColor;
            }
            set
            {
                this.fillColor = value;
                this.Invalidate();
            }
        }

        public float LineThick
        {
            get
            {
                return this.lineThick;
            }
            set
            {
                this.lineThick = value;
                this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            Graphics g = e.Graphics;
            g.SmoothingMode = SmoothingMode.HighQuality;

            RectangleF r = new RectangleF(0.0f, 0.0f, (float)this.Width, (float)this.Height);
            float cx = r.Width - 9;
            float cy = r.Height - 9;
            float offset = 0.4f;

            Pen pen = new Pen(new SolidBrush(this.ForeColor), lineThick);
            pen.Alignment = PenAlignment.Center;
            SolidBrush brush = new SolidBrush(fillColor);
            SolidBrush bckgnd = new SolidBrush(this.BackColor);

            // Creates a path to draw graphics
            GraphicsPath path = new GraphicsPath();

            // Paint the control
            if (this.BackColor == Color.Transparent)
            {
                // Add the AddEllipse method to the path.
                path.AddEllipse(0.0f, 0.0f, cx, cy);

                // Creates the region area for the control painting
                this.Region = new Region(path);

                //Draw the shape over the region               
                g.FillEllipse(brush, 0.0f, 0.0f, cx, cy);

                //Draw the outline
                g.DrawEllipse(pen, lineThick / 2.0f, lineThick / 2.0f, cx - lineThick - offset, cy - lineThick - offset);
            }
            else
            {
                //Add a rectangle to the path. This will be the control background.
                path.AddRectangle(r);

                //Creates a region area for the background painting
                this.Region = new Region(path);

                //Paint the control background
                g.FillRegion(bckgnd, this.Region);

                //Draw the shape over the control background
                g.FillEllipse(brush, 0.0f, 0.0f, cx, cy);

                // Draw the shape outline
                g.DrawEllipse(pen, lineThick / 2.0f, lineThick / 2.0f, cx - lineThick, cy - lineThick);
            }

            pen.Dispose();
            brush.Dispose();
            bckgnd.Dispose();
            this.Region.Dispose();
            path.Dispose();
        }
    }
}