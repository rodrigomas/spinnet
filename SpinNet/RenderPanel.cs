using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SpinNet
{
    class RenderPanel : Panel 
    {
        public RenderPanel() : base()
        {
            this.DoubleBuffered = true;
            this.ResizeRedraw = true;

            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            UpdateStyles();
        }


    }
}
