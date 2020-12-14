using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon.Utils
{
    class Utils
    {
        public Point RectangleToPoint(Rectangle rect)
        { 
        return new Point(rect.X,rect.Y);
        }
        /*   public int floatconvertoint(float float_)//
           {

               while ((float)Math.Floor(float_) != float_)
               {
                   float_ *= 10;
               }
               return (int)float_;



           }*/

        public int angerintesifies(float damn_float)
        {
            var indouble = damn_float;
            double truncated = Math.Truncate(indouble);
            return (int)Math.Truncate((indouble - truncated) * 10);


        }
    }
}
