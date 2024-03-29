using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace WodeWinForm.MyControls
{
   public class ButtonEx:Button
    {
        public ButtonEx()
        {
            //this.SetStyle(ControlStyles.Selectable, false);
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Graphics g = e.Graphics;

            g.Clear(BackColor);

            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter | TextFormatFlags.WordBreak;

            TextRenderer.DrawText(g, Text, Font, ClientRectangle, ForeColor, flags);
        }
    }
}
