using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace BMIS
{
    internal class roundFrm
    {
        public static void SetFormRoundedCorners(Form form, int radius)
        {
            var path = new GraphicsPath();
            path.StartFigure();
            path.AddArc(new Rectangle(0, 0, radius, radius), 180, 90);  // Top left
            path.AddArc(new Rectangle(form.Width - radius, 0, radius, radius), 270, 90); // Top right
            path.AddArc(new Rectangle(form.Width - radius, form.Height - radius, radius, radius), 0, 90); // Bottom right
            path.AddArc(new Rectangle(0, form.Height - radius, radius, radius), 90, 90); // Bottom left
            path.CloseFigure();
            form.Region = new Region(path);  // Apply the region to the form
        }
    }
}
