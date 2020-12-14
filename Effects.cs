using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Brickon.Effects
{
    class Effects
    {
        int z32984 = 0;
        public void effect1(Bitmap noise,int j)
        {

            for (int i = 0; i < noise.Width; i++)
            {
                for (int x = 0; x < noise.Height; x++)
                {
                    int calc = new Random().Next(5, 100);
                    //int calc = (int)(((SimplexNoise.Noise.Generate(i, x) + 1) / 2) * randomised);
                    //int calc = (int)(((SimplexNoise.Noise.Generate(i, x) + 1) / 2) * new Random().Next(10, 15));// int calc = (int)(((SimplexNoise.Noise.Generate(i, x) + 1) / 2) * new Random().Next(50,255));
                    //noise.SetPixel(i, x, Color.FromArgb(255, new Random().Next(10, 255), new Random().Next(10, 255), new Random().Next(10, 255))); // Color.FromArgb(255/*calc*/, calc, calc, calc));
                    z32984++;
                    noise.SetPixel(i, x, Color.White);
                    noise.SetPixel(i,x, Color.FromArgb(4 + j, calc+ new Random().Next(0, 100), calc+ new Random().Next(0, 100), calc + new Random().Next(0, 100)));
                }
            }
        }
    }
    
}
