using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Lab_05_BV.Objects
{
    internal class GreenCircle : BaseObject
    {
       public float size1 = -35;
       public float size2 = 35;
        
        public GreenCircle(float x, float y, float angle) : base(x, y, angle)
        {
        }
        public override void Render(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Green), size1, size1 , size2 , size2);
            g.DrawString(
    time.ToString(),
    new Font("Verdana", 8), // шрифт и размер
    new SolidBrush(Color.Green), // цвет шрифта
    3, 3 // точка в которой нарисовать текст
);
        }
        public override GraphicsPath GetGraphicsPath()
        {
            var path = base.GetGraphicsPath();
            path.AddEllipse(size1, size1, size2, size2);
            return path;
        }

        public int GetTime()
        {
            return time;
        }
        public void SetTime(int resTime)
        {
            time = resTime;
        }
        public bool UpdateCircle()
        {
            if(time != 0)
            {
                time--;
            }
            else if (time == 0)
            {
                return true;
            }
            return false;
        }
        public override int UpdateTimer()
        {
           return this.time--;
        }
    }
    

    
}
