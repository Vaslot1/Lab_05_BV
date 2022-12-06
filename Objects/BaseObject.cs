using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;

namespace Lab_05_BV.Objects
{
    internal class BaseObject
    {
        public float X;
        public float R;
        public float Y;
        public float Angle;
        public int time;
        public Action<BaseObject, BaseObject> OnOverlap;
        public BaseObject(float x, float y, float angle)
        {
            X = x;
            Y = y;
            Angle = angle;
            time = 100;
        }
        public Matrix GetTransform()
        {
            var matrix = new Matrix();
            matrix.Translate(X, Y);
            matrix.Rotate(Angle);
            return matrix;
        }
        public virtual void Render(Graphics g)
        {

        }
        public virtual GraphicsPath GetGraphicsPath()
        {
            return new GraphicsPath();
        }
        public virtual bool Overlaps(BaseObject obj, Graphics g)
        {

            var path1 = this.GetGraphicsPath();
            var path2 = obj.GetGraphicsPath();

            path1.Transform(this.GetTransform());
            path2.Transform(obj.GetTransform());

            var region = new Region(path1);
            region.Intersect(path2);
            return !region.IsEmpty(g);
        }
        public virtual void Overlap(BaseObject obj)
        {
            if (this.OnOverlap != null)
            {
                this.OnOverlap(this, obj);
            }
        }
        public virtual int UpdateTimer()
        {
            return this.time;
        }
        public virtual float UpdateRadius()
        {
            return this.R;
        }
    }
    

}
