using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenTK.Input;
namespace Brickon.Keyboard
{
    class Keyboard
    {
        public void Keyboard_(KeyEventArgs key,float z,float x,float y)
        {
            if (key.KeyCode == Keys.W)
            
                z -=0.1f;
            if (key.KeyCode == Keys.S)
                z += 0.1f;
            if (key.KeyCode == Keys.A)
                x -= 0.1f;
            if (key.KeyCode == Keys.D)
                x += 0.1f;
            if (key.KeyCode == Keys.E)
                y -= 0.1f;
            if (key.KeyCode == Keys.Q)
                y += 0.1f;
        }
    }
}
