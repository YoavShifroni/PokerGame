using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PokerGame
{
    class LabelCircle : Label
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath graphics = new GraphicsPath();
            graphics.AddEllipse(0,0,ClientSize.Width,ClientSize.Height);
            this.Region = new System.Drawing.Region(graphics);
            base.OnPaint(e);
        }
    }
}
