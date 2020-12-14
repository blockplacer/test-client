using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace Brickon.GLStuff
{
    class GLStuff
    {
         void OnLoad(EventArgs e)
        {
            
            GL.Enable(EnableCap.DepthTest);
        }
        public Bitmap TakeScreenshot(GLControl glControl1)
        {
            int w = glControl1.Width;
            int h = glControl1.Height;

            Bitmap g = new Bitmap(w,h);
            BitmapData data = g.LockBits(glControl1.ClientRectangle, ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            GL.ReadPixels(0, 0, w, h, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, data.Scan0);
            g.UnlockBits(data);
            g.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return g;
        }
        public void OnResize(Point viewport_pos,Size viewport_size,float fov,float r,float vrange)
        {
            GL.Viewport(viewport_pos, viewport_size);
            Matrix4 Projection = Matrix4.CreatePerspectiveFieldOfView(fov, r, 0.2f, vrange);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref Projection);
        }
    }
}
