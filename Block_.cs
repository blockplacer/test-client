using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;
namespace Brickon.Block_
{
   
    public struct Block_
    {
        private Vector3 v1;
        private int v1_material;
        private int v1_blocktype;
        public int v1_light_level;
        public Vector3 v1_scale;
    public void set_v1(Vector3 v)
        {

            v1 = v;
        }
        public void set_v1_scale(Vector3 v)
        {

            v1_scale = v;
        }
        public void set_v1_material(int material)
        {
            v1_material = material;
        }
        public void set_v1_blocktype(int material)
        {
            v1_blocktype = material;
        }
        public void set_v1_light_level(int material)
        {
            v1_light_level = material;
        }
        public Vector3 get_v1()
        {
            return v1;
        }
        public Vector3 get_v1_scale()
        {
            return v1_scale;
        }
        public int get_v1_material()
        {
            return v1_material;
        }
        public int get_v1_blocktype()
        {
            return v1_blocktype;
        }
    }
    
}
