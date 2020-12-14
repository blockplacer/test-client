using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mc.exe
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        public bool postprocessing = true;
        public float j58312 = 0.0f;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                postprocessing = true;
            }else
            { postprocessing = false; }//true
        }

        private void button1_Click(object sender, EventArgs e)
        {

            timer1.Start();
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
           // if(j58312 > 0)
           // {
                j58312 += 0.01f;
            //}
            if(j58312 < 1.0f)
            {
                this.Opacity = 0.0f;
            }
        }
    }
}
