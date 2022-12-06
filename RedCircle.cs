using Lab_05_BV.Objects;
using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_05_BV
{
    internal class RedCircle : BaseObject
    {
        public float size1 = -50;
        public float size2 = 50;
        public RedCircle(float x, float y, float angle, float r) : base(x, y, angle)
        {
            this.R = r;
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.FromArgb(120,255,0,0)), -R/2, -R/2, R, R);

        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(-R/2, -R/2, R, R);
            return path;
        }
        public override float UpdateRadius()
        {
            return this.R+=2;
        }
    }
}
