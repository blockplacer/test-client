using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Brickon.Effects;
using Brickon.GLStuff;
using Brickon.Utils;
using Brickon.Keyboard;
//using Brickon.Player;
using Brickon.Block_;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using Network;
using Shared;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using MoonSharp.Interpreter;
using MoonSharp.Interpreter.Loaders;
using System.Net;
using System.Windows.Input;
namespace Mc.exe
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        static Graphics graphics;
        static Bitmap noise = new Bitmap(700, 500);

        Bitmap game= new Bitmap(400, 400);
        Bitmap game_2 = new Bitmap(400, 400);
       
        public bool postprocessing = true;
        bool form2start = false;
       string update_string = "_";
        string update__string = "_";
        string join_string = "_";
        int join = 8;

        //1. Establish a connection to the server.
       ConnectionResult connectionResult = ConnectionResult.Connected;
        //unstatic

        TcpConnection tcpConnection;

        int player_ = 9;

        
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

            ImageAttributes attributes = new ImageAttributes();
            e.Graphics.DrawImage(game, 1, 1);
            try
            {
                
 e.Graphics.DrawImage(noise, 1, 1,game.Width,game.Height);
                if (postprocessing == true)
                {

                
                ColorMatrix color = new ColorMatrix();

                //set the opacity  
                color.Matrix33 = 0.20f;
                //color.Matrix10 = 0.500f;

                attributes.SetColorMatrix(color, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);

                e.Graphics.DrawImage(game_2, new Rectangle(0, 0, game.Width, game.Height), 0, 0, game.Width, game.Height, GraphicsUnit.Pixel, attributes);
                }
            }
            catch (InvalidOperationException)
            {

                //throw;
            }
            //create a color matrix object  
          

            //gfx.DrawImage(game_2, new Rectangle(1, 1, game.Width, game.Height),GraphicsUnit.Pixel,attributes);
            //}
            //  e.Graphics.DrawImage(game_2, 1, 1, game.Width, game.Height);

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            pictureBox1.Invalidate();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if(postprocessing == true)
            {
                pictureBox1.Size = this.Size;

            }
            else
            {
                pictureBox1.Location = new Point(200, 70000);
            }
            glControl1.Size = this.Size;
        }
       static Random rd = new Random();
        int randomised = rd.Next(10, 255);
        Effects effect = new Effects();
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            // Console.WriteLine("workpls");
             noise.SetPixel(2, 2, Color.Purple);
            effect.effect1(noise,1);
            
          

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            if(postprocessing == true)
            {
                if (backgroundWorker1.IsBusy != true)
                backgroundWorker1.RunWorkerAsync();
            }
            glControl1.Invalidate();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetImage(noise);
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            game_2 = game;
          
        }
        Bitmap map_ = new Bitmap("map1.png");
        int seed = new Random().Next(728748274, 828727482);
        void chunk(float x,float y,float z)
        {
            FastNoiseLite noise_ = new FastNoiseLite();
            noise_.SetNoiseType(FastNoiseLite.NoiseType.OpenSimplex2);
            noise_.SetSeed(seed);
           // noise_.SetRotationType3D(FastNoiseLite.RotationType3D.ImproveXYPlanes);
            
            // Gather noise data
           
           

            for (int xj = 0; xj < 24; xj++)
            {
                for (int xjj = 0; xjj < 24; xjj++)
                {
                    Block_ block = new Block_();//j
                    block.set_v1(new Vector3(xjj, utils.angerintesifies(noise_.GetNoise(xjj, xj)), xj));
                  //  if(new Random().Next(14,1))
                 // if(utils.angerintesifies(noise_.GetNoise(xjj, xj)) == 5)
                    //    block.set_v1_material(4);
                    block.set_v1_material(1);////Math.Random//new Random().Next(1,5)
                    block.set_v1_blocktype(1);
                    stuff__.block_file.Add(block);
                }
            }

            /* for (int i = 0; i < map_.Width; i++)
             {
                 for (int xj = 0; xj < map_.Height; xj++)
                 {
                    // int height = (int)map_.GetPixel(i + (int)x, xj + (int)z).GetBrightness();//)
                    // for (int xjj = 0; xjj < height; xjj++)
                    // {
                         //utils
                         //*/
            //block(i+x, xjj+y, xj+z, textures[2], textures[0], textures[1]);
            //
            /*
            Block_ chunk_block = new Block_();
            chunk_block.set_v1(new Vector3((int)(i + x), (int)y, (int)(xj + z)));//+ xjj
            chunk_block.set_v1_material(1);//new 
        stuff__.stuff__.block_file.Add(chunk_block);*/
            //   stuff__.stuff__.block_file.Add();
            //       stuff__.stuff__.block_file.Add();
            /*   if (
(player.x_ <= 1 + i && 1 + player.x_ >= i) &&
(player.y_ <= 1 + xjj && 1 + player.y_ >= xjj) &&
(player.z_ <= 1 + xj && 1 + player.z_ >= xj)
)
               {
                  // player.y -= 0.1f;
                   //  System.out.println("Player is colliding!!!");
               }*/

            /*        // }
                 }
             }*/

        }
        List<int> textures = new List<int>();//;
        private int grass;
        private int terrain;
        int grass_2 = 5;
        List<int> chunks = new List<int>();
        List<int> collision = new List<int>();

        int selected_object = 1;
        //     {1,1,1,1,1}
        static int chunknum_ = Int32.Parse(File.ReadAllText("usermaps/chunk"));
       // Console.WriteLine(chunknum_ +1);
            string chunknum = chunknum_ + 1.ToString();
        PositionResponse myPositionFromServer;
        private void glControl1_Load(object sender, EventArgs e)
        {


             

            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures.Add(1);
            textures[0] = newTexture( new Bitmap("grass.png"));
            textures[1] = newTexture(new Bitmap("grass_side.png"));
            textures[2] = newTexture(new Bitmap("43242.png"));
            textures[3] = newTexture(new Bitmap("pnks1.png"));
            textures[4] = newTexture(new Bitmap("j5.png"));
            textures[5] = newTexture(new Bitmap("j4711.png"));
            textures[6] = newTexture(new Bitmap("j41415.png"));
            textures[7] = newTexture(new Bitmap("j5884.png"));
            chunk(0.00001F, 0.000001f, 0.000001F);   /*chunk(0.00001F, 0.000001f, 8.000001F);
            /* chunk(0.00001F, 0.000001f, 16.000001F);
             chunk(0.00001F, 0.000001f, 20.000001F);
             chunk(0.00001F, 0.000001f, 24.000001F);*/
            
           // File
            for (int xj = 0; xj < stuff__.block_file.Count; xj++)
            {

              //    File.AppendAllText($"usermaps/{chunknum_+1}.txt", String.Join(",", stuff__.stuff__.block_file[xj].get_v1(), stuff__.stuff__.block_file[xj].get_v1_material(), stuff__.stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }
                
                //File.AppendAllText("map.txt", String.Join(",", stuff__.stuff__.block_file[xj].get_v1(), stuff__.stuff__.block_file[xj].get_v1_material(), stuff__.stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }
                //+0.00001f
                //+0.000001f
                //  block(stuff__.stuff__.block_file[xj].get_v1(), stuff__.stuff__.block_file[xj], BeginMode.Quads);
                // block(2, 0.00001f, 0.000001f, textures[1], textures[0], textures[2]);
                //block(stuff__.stuff__.block_file[i], stuff__.stuff__.block_file[i+1], stuff__.stuff__.block_file[i+2], textures[1], textures[0], textures[2]);
            }
           // chunknum_++;

          //  File.WriteAllText("map.txt", string.Join(",", string.Concat(stuff__.stuff__.block_file.ToArray())));



            stuff__.block_file.Clear();
            
            
            //  Console.WriteLine(GL.GetError());

            /*  chunks.Add(1);
              chunks.Add(1);
             chunks[1] = GL.GenLists(1);
              GL.NewList(chunks[1], ListMode.Compile);



              chunk(0.00001F, 0.000001f, 0.000001F);
              chunk(0.00001F, 0.000001f, 8.000001F);
              chunk(0.00001F, 0.000001f, 16.000001F);
              chunk(0.00001F, 0.000001f, 20.000001F);
              chunk(0.00001F, 0.000001f, 24.000001F);
              // chunk(0.00001F, 0.000001f, 8.000001F);

              //  chunk(0.00001F, 0.000001f, 16.000001F);
              GL.EndList(); */


            GL.Enable(EnableCap.Fog);
            GL.Fog(FogParameter.FogMode, (int)FogMode.Linear);
            GL.Hint(HintTarget.FogHint, HintMode.Nicest);
            GL.Fog(FogParameter.FogColor, new float[] { new Random().Next(1,255) / 255.0f, new Random().Next(1, 255) / 255.0f, new Random().Next(1, 255) / 255.0f });

            GL.Fog(FogParameter.FogStart, (float)40 / 100.0f);
            GL.Fog(FogParameter.FogEnd, 40.0f);

            /* GL.Fog(FogParameter.FogColor, new float[] {0.0001f,0.00001f,255 });
             GL.Fog(FogParameter.FogDensity, 0000.1f);
             GL.Fog(FogParameter.FogStart, (float)700.0f);
             GL.Fog(FogParameter.FogEnd, 9999.0f);*/
            GL.Enable(EnableCap.DepthTest);
          //  GL.Enable(EnableCap.CullFace);
        }
        int chunk_v = 1;
        void block(float x,float y,float z,int sidetexture,int second,int third)
        {
            GL.PushMatrix();
            GL.Translate(x, y, z);
            
            GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            GL.ActiveTexture(TextureUnit.Texture0);
            //sides of block
            GL.Begin(BeginMode.Quads); GL.Vertex3(1,0,0);GL.TexCoord2(0.0f, 0.0f);  GL.Vertex3(1,0,-1);GL.TexCoord2(1.0f, 0.0f);  GL.Vertex3(1,1,-1);GL.TexCoord2(1.0f, 1.0f);  GL.Vertex3(1,1,0);GL.TexCoord2(0.0f, 1.0f);  GL.Vertex3(1,0,0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1,0,0);GL.TexCoord2(0.0f, 0.0f);  GL.Vertex3(0,0,0);GL.TexCoord2(1.0f, 0.0f);  GL.Vertex3(0,1,0);GL.TexCoord2(1.0f, 1.0f);  GL.Vertex3(1,1,0);GL.TexCoord2(0.0f, 1.0f);  GL.Vertex3(1,0,0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0,0,0);GL.TexCoord2(0.0f, 0.0f);  GL.Vertex3(0,0,-1);GL.TexCoord2(1.0f, 0.0f);  GL.Vertex3(0,1,-1);GL.TexCoord2(1.0f, 1.0f);  GL.Vertex3(0,1,0);GL.TexCoord2(0.0f, 1.0f);  GL.Vertex3(0,0,0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0,0,-1);GL.TexCoord2(0.0f, 0.0f);  GL.Vertex3(1,0,-1);GL.TexCoord2(1.0f, 0.0f);  GL.Vertex3(1,1,-1);GL.TexCoord2(1.0f, 1.0f);  GL.Vertex3(0,1,-1);GL.TexCoord2(0.0f, 1.0f);  GL.Vertex3(0,0,-1); GL.End();
            //2th
            GL.BindTexture(TextureTarget.Texture2D, second);
           
            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End();
            //3rd
            GL.BindTexture(TextureTarget.Texture2D, third);
            
            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            GL.PopMatrix();
        }
        void block(float x, float y, float z, int sidetexture, int second, int third,Vector3 size,int rotation,Vector3 rotation_)
        {
           
            GL.PushMatrix();
            GL.Translate(x, y, z);
            
            GL.Scale(size);
            GL.Rotate(rotation, rotation_);
            GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            GL.ActiveTexture(TextureUnit.Texture0);
            //sides of block
            GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            //2th
            GL.BindTexture(TextureTarget.Texture2D, second);

            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End();
            //3rd
            GL.BindTexture(TextureTarget.Texture2D, third);

            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            GL.PopMatrix();
        }
        void block(float x, float y, float z)
        {
            //block_.setv1
            GL.PushMatrix();
            GL.Translate(x, y, z);

         
            GL.ActiveTexture(TextureUnit.Texture0);
            //sides of block
            GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            //2th
            

            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End();
            //3rd
          

            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            GL.PopMatrix();
        }
        void block(float x, float y, float z,Vector3 scale)
        {
            //block_.setv1
            GL.PushMatrix();
            GL.Disable(EnableCap.DepthTest);
            GL.Translate(x, y, z);
            GL.Scale(scale);
            GL.BindTexture(TextureTarget.Texture2D, textures[7]);
            GL.ActiveTexture(TextureUnit.Texture0);
            
            //sides of block
            GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            //2th


            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End();
            //3rd


            GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            GL.Enable(EnableCap.DepthTest);
            GL.PopMatrix();
        }
        void block(Vector3 v, Block_ block,BeginMode begin_mode,Vector3 size)//,int[] light
        {
            GL.PushMatrix();
            GL.Translate(v);
            GL.Scale(size);
            if(block.get_v1_blocktype() == 2)
            {
                if (block.v1_light_level == 1)
                GL.Color3(0.900f, 0.900f, 0.900f);
            if (block.v1_light_level == 2)
                GL.Color3(0.800f, 0.800f, 0.800f);
            if (block.v1_light_level == 3)
                GL.Color3(0.700f, 0.700f, 0.700f);
            if (block.v1_light_level == 4)
                GL.Color3(0.500f, 0.500f, 0.500f);
            if (block.v1_light_level == 5)
                GL.Color3(0.200f, 0.200f, 2.900f);
            if (block.v1_light_level == 8)
                GL.Color3(0.001f, 0.001f, 0.001f);
            }
            if (block.get_v1_material() == 0x1)
                GL.BindTexture(TextureTarget.Texture2D, textures[1]); //GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            if (block.get_v1_material() == 0x2)
                GL.BindTexture(TextureTarget.Texture2D, textures[2]); //GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            if (block.get_v1_material() == 0x3)
                GL.BindTexture(TextureTarget.Texture2D, textures[3]);
            if (block.get_v1_material() == 0x4)
                GL.BindTexture(TextureTarget.Texture2D, textures[4]);
            if (block.get_v1_material() == 0x5)
                GL.BindTexture(TextureTarget.Texture2D, textures[5]);
            GL.ActiveTexture(TextureUnit.Texture0);
            //sides of block
            GL.Begin(begin_mode); GL.Color3(Color.Orange); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(begin_mode); GL.Color3(Color.Green);  GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.End(); GL.Begin(begin_mode); GL.Color3(Color.Indigo);  GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.End(); GL.Begin(begin_mode); GL.Color3(Color.Indigo);  GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            //2th
           
            if (block.get_v1_material() == 0x1)
                GL.BindTexture(TextureTarget.Texture2D, textures[0]);
            if (block.get_v1_material() == 0x2)
                GL.BindTexture(TextureTarget.Texture2D, textures[2]); //GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            if (block.get_v1_material() == 0x3)
                GL.BindTexture(TextureTarget.Texture2D, textures[3]);
            if (block.get_v1_material() == 0x4)
                GL.BindTexture(TextureTarget.Texture2D, textures[4]);
            if (block.get_v1_material() == 0x5)
                GL.BindTexture(TextureTarget.Texture2D, textures[6]);
            //GL.BindTexture(TextureTarget.Texture2D, second);

            GL.Begin(begin_mode); GL.Color3(Color.Cyan); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End();
            //3rd
            //GL.BindTexture(TextureTarget.Texture2D, third);
            if (block.get_v1_material() == 0x1)
                GL.BindTexture(TextureTarget.Texture2D,textures[2]);
            if (block.get_v1_material() == 0x2)
                GL.BindTexture(TextureTarget.Texture2D, textures[2]); //GL.BindTexture(TextureTarget.Texture2D, sidetexture);
            if (block.get_v1_material() == 0x3)
                GL.BindTexture(TextureTarget.Texture2D, textures[3]);
            if (block.get_v1_material() == 0x4)
                GL.BindTexture(TextureTarget.Texture2D, textures[4]);
            if (block.get_v1_material() == 0x5)
                GL.BindTexture(TextureTarget.Texture2D, textures[6]);
            GL.Begin(begin_mode); GL.Color3(Color.Purple);  GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End();
            GL.PopMatrix();
        }
        Block_ block_ = new Block_();
        int newTexture(Bitmap textureBitmap)
        {
            int texture;
            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            BitmapData data = textureBitmap.LockBits(new System.Drawing.Rectangle(0, 0, textureBitmap.Width, textureBitmap.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            textureBitmap.UnlockBits(data);


            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Nearest);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);
            return texture;
        }
        int rotate;

         public void server_update()
        {//async
            //Thread
            
        }
        bool plr_gravity = true;
        public void MapNet(string update____string)
        {
            string[] map_;
            //  Console.WriteLine(update__string);
            //map_;
            //string line = File.ReadAllText(filelocation);//
            try
            {

           
            map_ = update____string.Split(new char[] { ',', ';', '(', ')', ' ' }, StringSplitOptions.RemoveEmptyEntries);
            for (int xj = 0; xj < map_.Length - 4; xj++)//length
            {
                // Console.WriteLine(map_[xj])

                if (map_[xj] == "__")//block_
                {
                    for (int xjj = 0; xjj < stuff__.block_file.Count; xjj++)
                    {

                        if (stuff__.block_file[xjj].get_v1() == new Vector3(Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2]), Int32.Parse(map_[xj + 3])))//{
                        {
                            stuff__.block_file.RemoveAt(xjj);
                        }

                        }
                
                }
                /*   for (int xj = 0; xj < stuff__.stuff__.block_file.Count; xj++)
                {
if(stuff__.stuff__.block_file[xj].get_v1() == new Vector3((int)-player.x, (int)-player.y, (int)-player.z+5))//{
                    {
                        Block_ block_ = new Block_(); block_.set_v1(new Vector3((int)-player.x, (int)-player.y, (int)-player.z + 5));
                        //stuff__.stuff__.block_file.Remove(block);
                        stuff__.stuff__.block_file.RemoveAt(xj);
                        stuff__.stuff__.block_file.Add(block_);////
                    }*/

                if (map_[xj] == "block_")//block_
                {
                    bool already_generated = false;
                    // Console.WriteLine(Int32.Parse(map_[xj + 1]));

                    /* Block_ block = new Block_();
                     block.set_v1(new Vector3(Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2]), Int32.Parse(map_[xj + 3])));//
                     block.set_v1_material(Int32.Parse(map_[xj + 4]));
                     block.set_v1_blocktype(selected_8);*/



                //   block.
                //   stuff__.stuff__.block_file.Add(block_);
                for (int i = 0; i < stuff__.block_file.Count; i++)
                    {

                        if (stuff__.block_file[i].get_v1() == new Vector3(Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2]), Int32.Parse(map_[xj + 3])))
                        {

                            already_generated = true;
                            /*Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);*/


                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");

                        }
                        else
                        {
                            already_generated = false;
                            //+0.00001f
                            //+0.000001f
                            //block(stuff__.block_file[i].get_v1(), stuff__.block_file[i], BeginMode.Quads);
                            // block(2, 0.00001f, 0.000001f, textures[1], textures[0], textures[2]);
                            //block(stuff__.block_file[i], stuff__.block_file[i+1], stuff__.block_file[i+2], textures[1], textures[0], textures[2]);
                        }
                    }
                    if (already_generated == false)//for memory saving otherwise we will generate 2832 objects in second
                    {
                        Block_ chunk_block = new Block_();
                        chunk_block.set_v1(new Vector3(Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2]), Int32.Parse(map_[xj + 3])));
                        chunk_block.set_v1_material(Int32.Parse(map_[xj + 4]));//1
                        chunk_block.set_v1_blocktype(1);//Int32.Parse(map_[xj + 4])
                            chunk_block.set_v1_scale(new Vector3(1, 1, 1));
                        stuff__.block_file.Add(chunk_block);
                            stuff__.collision.Add(chunk_block.get_v1());
                        if(map_.Length-4 > 5)
                        {//
                            update____string = "_";//update__string
                        }
                        // if(block)}
                    }
                }


            }
            }
            catch (NullReferenceException)
            {

                //  throw;
            }

        }

        bool col_detection = false;
          float yaw = 0.0f;
        public void walkForward(float distance)
        {
            // double yaw_ =  (Math.PI / 180) * yaw;
            stuff__.player.x += distance * (float)Math.Sin((Math.PI / 180) * yaw);
            stuff__.player.z -= distance * (float)Math.Cos((Math.PI / 180) * yaw);
        }
        public void walkBackwards(float distance)
        {
            // double yaw_ =  (Math.PI / 180) * yaw;
          
            stuff__.player.x -= distance * (float)Math.Sin((Math.PI / 180) * yaw);
            stuff__.player.z += distance * (float)Math.Cos((Math.PI / 180) * yaw);
        }
        public void walkRight(float distance)
        {
            // double yaw_ =  (Math.PI / 180) * yaw;
            stuff__.player.x += distance * (float)Math.Sin((Math.PI / 180) * -yaw + 90);
            stuff__.player.z -= distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90);//
        }

        public void walkLeft(float distance)
        {
            // double yaw_ =  (Math.PI / 180) * yaw;

            stuff__.player.x -= distance * (float)Math.Sin((Math.PI / 180) *- yaw + 90);
            stuff__.player.z += distance * (float)Math.Cos((Math.PI / 180) * -yaw - 90);
        }
        DateTime time1 = DateTime.Now;
        DateTime time2 = DateTime.Now;

        int head_rotation;

        float walking__ = 0.00002f;
        bool walking____ = false;
        public async void walk________()
        {
            if (walking____ == true)
            {
                for (int xj = 0; xj < 8; xj++)
                {
                    walking__ += 0.01f;
                    await Sys.waitFunction(1);
                }
               
            }

            if (walking____ == false)
            {
                for (int xj = 0; xj < 8; xj++)
                {
                    walking__ -= 0.02f;
                    await Sys.waitFunction(1);
                }
            }
            if (walking__ > 0.3f)
                walking____ = false;
            if (walking__ < 0.2)
                walking____ = true;
        }
        private async void glControl1_Paint(object sender, PaintEventArgs e)
        {
           
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.Zero, Vector3.UnitZ, Vector3.UnitY);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);
            
            GL.Color3(Color.CornflowerBlue);

         

            //    GL.PushMatrix();
            //  GL.Scale(10, 10, 10);
            // block(-stuff__.player.x, -stuff__.player.y, -stuff__.player.z);

            //block(new Vector3(-stuff__.player.x, -stuff__.player.y, -stuff__.player.z + 5), new Block_(), BeginMode.Quads);
            //   GL.PopMatrix();

            GL.Rotate(yaw, 0, 1, 0);
            GL.Rotate(MousePosition.Y, 0, 0, 1);
            //Console.WriteLine(MousePosition.X);
            if (MousePosition.X > 1360- 5)
                OpenTK.Input.Mouse.SetPosition(632, MousePosition.Y);
            if (MousePosition.X < 2 )
                OpenTK.Input.Mouse.SetPosition(725, MousePosition.Y);
           
            GL.Translate(stuff__.player.x, stuff__.player.y+1,stuff__.player.z);
            
            GL.BindTexture(TextureTarget.Texture2D, textures[2]);
            GL.Enable(EnableCap.Texture2D);
           
            //  time = DateTime.Now.Millisecond ;
            //  dt = (time - last_frame) / 1000.0f;
            // last_frame = time;

            time2 = DateTime.Now;
            dt = (time2.Ticks - time1.Ticks) / 10000000f;
            yaw = MousePosition.X * 0.5f;
           
            block(-stuff__.player.x-1, -stuff__.player.y-1, -stuff__.player.z+5,new Vector3(10,10,10));

            //   GL.Scale(1,1,1);
            // GL.PushMatrix();
            //  GL.Translate((float)new Random().NextDouble(), 0,0);
            //GL.Scale((float)new Random().NextDouble(), (float)new Random().NextDouble(), (float)new Random().NextDouble());
            rotate++;

          

            //  GL.BindTexture
            block(1, 0.00001f, 7.000001f, textures[2], textures[0], textures[1]);
           
            head_rotation = (int)yaw;
          



            block(0.5f, 2, 6, textures[2], textures[0], textures[1], new Vector3(1, 1, 1), (int)yaw/12, new Vector3(0, 1, 0));//;
            block(1, 0.000001f, 6, textures[2], textures[0], textures[1], new Vector3(2, 2, 1), 0, new Vector3(0, 0, 0));
            //
            block(new Vector3((int)-stuff__.player.x, (int)-stuff__.player.y, (int)-stuff__.player.z + 5), new Block_(),BeginMode.Lines,new Vector3(1,1,1));

            if (col_detection == true)
            {
                if (plr_gravity == true)
                stuff__.player.y += 0.05f;
            }
            for (int i = 0; i < stuff__.block_file.Count; i++)
                {
                    //+0.00001f
                    //+0.000001f
                    block(new Vector3(stuff__.block_file[i].get_v1().X, stuff__.block_file[i].get_v1().Y-2 + walking__, stuff__.block_file[i].get_v1().Z), stuff__.block_file[i], BeginMode.Quads, stuff__.block_file[i].get_v1_scale());//new Vector3(1, 1, 1)
               
                 
                
            }//map_[xj]
                if(col_detection == true)
            {
    


                if (stuff__.collision.Contains(new Vector3(-(int)stuff__.player.x, -(int)stuff__.player.y, -(int)stuff__.player.z)))
            {
               // stuff__.player.y -= 0.1f;
                plr_gravity = false;
                 //Console.WriteLine("collision detected");
            }else
            {
                plr_gravity = true;
            }
                //  for (int xjj = 0; xjj < collision.Count; xjj++)
                // {

             
                   
              //  }
              

            }

            if (player_ == 9)
            {
                if (join == 8)
            {
                MapNet(join_string);
                join = 9;
            }
            }
            if (player_ == 9)
            {
               
            }

            for (int xj = 0; xj < players.Count; xj++)
            {
                players[xj].render();
            }
            MapNet(update__string);
            Console.WriteLine(update__string);
            //    Console.WriteLine(update__string);
            // }).Start();
            /*
            if((int)-player.z == 24*chunk_v)
            {



            /* chunk(0.00001F, 0.000001f, 16.000001F);
             chunk(0.00001F, 0.000001f, 20.000001F);
             chunk(0.00001F, 0.000001f, 24.000001F);*/

            /*
            for (int xj = 0; xj < stuff__.block_file.Count; xj++)
            {
                File.AppendAllText($"usermaps/{chunknum_ - 1}.txt", String.Join(",", stuff__.block_file[xj].get_v1(), stuff__.block_file[xj].get_v1_material(), stuff__.block_file[xj].get_v1_blocktype()));
            }
            chunk(0.00001F, 0.000001f, 0.000001F);   /*chunk(0.00001F, 0.000001f, 8.000001F);*/
            // File/*
            /*
            for (int xj = 0; xj < stuff__.block_file.Count; xj++)
            {

                File.AppendAllText($"usermaps/{chunknum_ + 1}.txt", String.Join(",", stuff__.block_file[xj].get_v1(), stuff__.block_file[xj].get_v1_material(), stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }

                //File.AppendAllText("map.txt", String.Join(",", stuff__.block_file[xj].get_v1(), stuff__.block_file[xj].get_v1_material(), stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }
                //+0.00001f
                //+0.000001f
                //  block(stuff__.block_file[xj].get_v1(), stuff__.block_file[xj], BeginMode.Quads);
                // block(2, 0.00001f, 0.000001f, textures[1], textures[0], textures[2]);
                //block(stuff__.block_file[i], stuff__.block_file[i+1], stuff__.block_file[i+2], textures[1], textures[0], textures[2]);
            }


            //  File.WriteAllText("map.txt", string.Join(",", string.Concat(stuff__.block_file.ToArray())));



            stuff__.block_file.Clear();



            MapLoad($"usermaps/{chunknum_ + 1}.txt" ,new Vector3(player.x,player.y,player.z));
            player.z += 1;
            chunknum_ ++;
            File.WriteAllText("usermaps/chunk", chunknum_.ToString());
        }
        */
            // GL.CallList(chunks[1]);
            // GL.Translate(1, 16, 1);
            // GL.CallList(chunks[1]);
            /* for (int i = 0; i < stuff__.block_file.Count-2; i++)
             {
                 //+0.00001f
                 //+0.000001f
                 block(stuff__.block_file[i], textures[2], textures[0], textures[1],BeginMode.Quads);
                // block(2, 0.00001f, 0.000001f, textures[1], textures[0], textures[2]);
                 //block(stuff__.block_file[i], stuff__.block_file[i+1], stuff__.block_file[i+2], textures[1], textures[0], textures[2]);
             }

          if(stuff__.block_file.Contains(new Vector3((int)-player.x,(int)-player.y,(int)-player.z)))
             {
                 player.z -= 0.1f;
                // Console.WriteLine("collision detected");
             }
             if (stuff__.block_file.Contains(new Vector3((int)-player.x, (int)-player.y, (int)-player.z)))
             {
                 player.z += 0.1f;
                 // Console.WriteLine("collision detected");
             }
             if (stuff__.block_file.Contains(new Vector3((int)-player.x, (int)-player.y, (int)-player.z)))
             {
                 player.x -= 0.1f;
                 // Console.WriteLine("collision detected");
             }
             if (stuff__.block_file.Contains(new Vector3((int)-player.x , (int)-player.y, (int)-player.z)))
             {
                 player.x += 0.1f;
                 // Console.WriteLine("collision detected");
             }*/
            // Console.WriteLine(stuff__.block_file.IndexOf(new Vector3((int)player.x, (int)player.y, (int)player.z)));
            //GL.Begin(BeginMode.Quads); GL.Color3(1.0f * (float)new Random().NextDouble(), 1.0f * (float)new Random().NextDouble(), 0.9f * (float)new Random().NextDouble()); GL.Vertex3(1, 1, -1); GL.Color3(1.0f * (float)new Random().NextDouble(), 1.0f * (float)new Random().NextDouble(), 0.9f * (float)new Random().NextDouble());  GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 1, -1); GL.End();
            // GL.PopMatrix();
            // GL.Begin(BeginMode.Quads); GL.Vertex3(1, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Color3(0.2f * (float)new Random().NextDouble(), 0.9f * (float)new Random().NextDouble(), 1.0f);  GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 0.0f);  GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 1, -1); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 1, -1); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(1, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 1, -1); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 1, -1); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, -1); GL.End(); GL.Begin(BeginMode.Quads); GL.Vertex3(0, 0, 0); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 1, 0); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(1, 1, 0); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 0, 0); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(0, 0, 0); GL.End();
            // GL.Begin(BeginMode.Quads); GL.Vertex3(1, 1, -1); GL.TexCoord2(0.0f, 0.0f); GL.Vertex3(0, 1, -1); GL.TexCoord2(1.0f, 0.0f); GL.Vertex3(0, 0, -1); GL.TexCoord2(1.0f, 1.0f); GL.Vertex3(1, 0, -1); GL.TexCoord2(0.0f, 1.0f); GL.Vertex3(1, 1, -1); GL.End();
            //block(player.x, player.y, player.z);
            if (postprocessing == true)
            {
                game = glstuff.TakeScreenshot(glControl1);

            }
            time1 = time2;
            glControl1.SwapBuffers();
            
        }
        Form2 form2;
        // TcpConnection tcpConnection;

        string scriptCode = File.ReadAllText("scrpt/drsv.lua");

        private void Form1_Load(object sender, EventArgs e)
        {

             form2 = new Form2();
            form2.Show();
            this.Opacity = 0.0f;
            this.ShowInTaskbar = false;
           
            
              ConnectionResult connectionResult = ConnectionResult.TCPConnectionNotAlive;
            //1. Establish a connection to the server.
           tcpConnection = ConnectionFactory.CreateTcpConnection("127.0.0.1", 1234, out connectionResult);
            //tcpConnection = ConnectionFactory.CreateTcpConnection("193.164.7.114", 1234, out connectionResult);// //, out connectionResult
          if(connectionResult == ConnectionResult.Connected)
            tcpConnection.KeepAlive = true;
             
            position__();
            ((ScriptLoaderBase)Script.DefaultOptions.ScriptLoader).ModulePaths = new string[] { "scrpt/?", "scrpt/?.lua" };


            UserData.RegisterAssembly();
           
            Script script = new Script();
            script.Options.ColonOperatorClrCallbackBehaviour = ColonOperatorBehaviour.TreatAsDotOnUserData;
            // script.RequireModule()
            script.Globals["Instert"] = typeof(Instert);
            script.Globals["Numbers"] = typeof(Numbers_);
            script.Globals["Sys"] = typeof(Sys);
            script.Globals["Network"] = typeof(networking);
            script.DoString(scriptCode);
            //DynValue res = 
            //  ((ScriptLoaderBase)script.Options.ScriptLoader).ModulePaths = new String[] { "scrpt/optimisations.lua" };//}$
            Block_ chunk_block = new Block_();
            chunk_block.set_v1(new Vector3(38443, 23423, 42423));
            chunk_block.set_v1_material(4);//1
                                                  //4
            chunk_block.set_v1_blocktype(1);
            chunk_block.set_v1_light_level(1);
            stuff__.block_file.Add(chunk_block);


            System.Windows.Forms.Cursor.Hide();

            //   stuff__.NewBlock(0, 1, 7);

            // graphics = Graphics.FromImage(noise);
            //graphics.FillRectangle(new SolidBrush(Color.FromArgb(255, 1, 1, 1)), 1, 1, 500 ,399);//1 1
        }
        GLStuff glstuff = new GLStuff();
        Brickon.Utils.Utils utils = new Brickon.Utils.Utils();
        private void glControl1_Resize(object sender, EventArgs e)
        {
            glstuff.OnResize(utils.RectangleToPoint(ClientRectangle), ClientSize, (float)Math.PI / 4, Width / (float)Height, 64.0f);
        }
        Brickon.Keyboard.Keyboard keyboard = new Brickon.Keyboard.Keyboard();
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
           
        }
        void MapLoad(string filelocation)
        {

            string[] map_;
            //map_;
            string line = File.ReadAllText(filelocation);//
            map_ = line.Split(new char[] { ',', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

           /* for (int xj = 0; xj < line.Split(',').Length - 2; xj+=3)//map_
            {
                stuff__.block_file.Add(new Vector3(Int32.Parse(map_[xj]), Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2])));
            }*/
            for (int xj = 0; xj < map_.Length; xj += 5)
            {
                // Here xj is an index of a X coordinate, xj + 1 is an index of a Y coordinate, xj + 2 is an index of a Z coordinate

                Block_ chunk_block = new Block_();
                chunk_block.set_v1(new Vector3(Int32.Parse(map_[xj]), Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2])));
                chunk_block.set_v1_material(Int32.Parse(map_[xj + 3]));//1
                chunk_block.set_v1_blocktype(Int32.Parse(map_[xj + 4]));
                chunk_block.set_v1_scale(new Vector3(1, 1, 1));
                stuff__.block_file.Add(chunk_block);
                stuff__.collision.Add(chunk_block.get_v1());
                // stuff__.block_file.Add(new Vector3(Int32.Parse(map_[xj]), Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2])));
            }

        }
        void MapLoad(string filelocation,Vector3 position)
        {

            string[] map_;
            //map_;
            string line = File.ReadAllText(filelocation);//
            map_ = line.Split(new char[] { ',', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            /* for (int xj = 0; xj < line.Split(',').Length - 2; xj+=3)//map_
             {
                 stuff__.block_file.Add(new Vector3(Int32.Parse(map_[xj]), Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2])));
             }*/
            for (int xj = 0; xj < map_.Length; xj += 5)
            {
                // Here xj is an index of a X coordinate, xj + 1 is an index of a Y coordinate, xj + 2 is an index of a Z coordinate

                Block_ chunk_block = new Block_();
                chunk_block.set_v1(new Vector3(Int32.Parse(map_[xj])+position.X, Int32.Parse(map_[xj + 1]) + position.Y, Int32.Parse(map_[xj + 2]) + position.Z));
                chunk_block.set_v1_material(Int32.Parse(map_[xj + 3]));//1
                chunk_block.set_v1_blocktype(Int32.Parse(map_[xj + 4]));
                chunk_block.set_v1_scale(new Vector3(1, 1, 1));
                stuff__.block_file.Add(chunk_block);
                stuff__.collision.Add(new Vector3(chunk_block.get_v1().X, chunk_block.get_v1().Y+1, chunk_block.get_v1().Z));
                // stuff__.block_file.Add(new Vector3(Int32.Parse(map_[xj]), Int32.Parse(map_[xj + 1]), Int32.Parse(map_[xj + 2])));
            }

        }

        int selected_8;
        float dt;
        float last_frame;
        float time;
        private async void glControl1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            System.Windows.Forms.KeyEventArgs key = e;
            /*if (e.KeyCode == Keys.W)
               // player.z -= 0.1f;
            if (e.KeyCode == Keys.S)
                player.z += 0.1f;*/
            if (key.KeyCode == Keys.D1)
                selected_object = 1;
            if (key.KeyCode == Keys.D2)
                selected_object = 2;
            if (key.KeyCode == Keys.D3)
                selected_object = 3;
            if (key.KeyCode == Keys.D4)
                selected_object = 4;
            if (key.KeyCode == Keys.D5)
                selected_object = 5;
            if (key.KeyCode == Keys.D8)
                selected_8 = 2;
            if (key.KeyCode == Keys.F7)
            {

                for (int xj = 0; xj < stuff__.block_file.Count; xj++)
                {
                    File.AppendAllText("usermap.txt", String.Join(",", stuff__.block_file[xj].get_v1(), stuff__.block_file[xj].get_v1_material(), stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }
                }
            }

       
            /* if (key.KeyCode == Keys.W)
             {

                 //   stuff__.player.z -= 0.1f;
                 //  stuff__.player.z_--;
             }*/


            /* if (key.KeyCode == Keys.W && (key.KeyCode == Keys.D))
             {

                 for (int xj = 0; xj < 25; xj++)
                 {
                     walkForward(0.5f * dt);
                     walkRight(0.5f * dt);
                     await Sys.waitFunction(1);
                 }
             }*/
            /* if (key.KeyCode == Keys.S)
             {

                 // stuff__.player.z += 0.1f;
                 //stuff__.player.z_++;
             }*/
            if (key.KeyCode == Keys.G)
            {
                for (int xj = 0; xj < 25; xj++)
                {
                    walkLeft(0.5f * dt);
                    await Sys.waitFunction(1);
                }
                //  stuff__.player.x -= 0.1f;
                //  stuff__.player.x_--;
            }
          /*  if (key.KeyCode == Keys.D)
            {
               
                //   stuff__.player.x += 0.1f;
                //    stuff__.player.x_++;
            }*/
            if (key.KeyCode == Keys.E)
            {
                stuff__.player.y -= 0.1f;
                stuff__.player.y_--;
            }
            if (key.KeyCode == Keys.J)
            {
                stuff__.player.y += 0.1f;
                stuff__.player.y_++;
            }
          
           /* if (key.KeyCode == Keys.Space)
            {
                
            }*/
            
            if (player_ == 8)
            {
                if (key.KeyCode == Keys.Z)
               {
                //{
                //Console.WriteLine(stuff__.block_file.ToArray()[1].ToString());
                stuff__.block_file.Clear();
                
                MapLoad("map.txt",new Vector3(-(int)stuff__.player.x, -(int)stuff__.player.y, -(int)stuff__.player.z));
               
                //}
            }

                if (key.KeyCode == Keys.F7)
                {

                    for (int xj = 0; xj < stuff__.block_file.Count; xj++)
                    {
                        File.AppendAllText("usermap.txt", String.Join(",", stuff__.block_file[xj].get_v1(), stuff__.block_file[xj].get_v1_material(), stuff__.block_file[xj].get_v1_blocktype()));//new char[] { ',', ';', '(', ')' }
                    }


                }
            if (key.KeyCode == Keys.F12)
            {
                MapLoad("usermap.txt");
             /*   string[] map_;
            //map_;
            string line = File.ReadAllText("usermap.txt");//
            map_ = line.Split(new char[] { ',', ';', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            for (int xj = 0; xj < line.Split(',').Length-2; xj++)//map_
            {
                stuff__.block_file.Add(new Vector3(Single.Parse(map_[xj]), Single.Parse(map_[xj + 1]), Single.Parse(map_[xj + 2])));
            }*/
            //Vector4
            }
            }
            if (key.KeyCode == Keys.V)
            {
                col_detection = true;
            }
            //  MapLoad("usermap.txt");
            /*  if(key.KeyCode == Keys.P)
              {

              //    stuff__.block_file.Add((int)-player.x);
             // stuff__.block_file.Add(1);
             // stuff__.block_file.Add((int)player.z - 1);
              }*/

        }
     
        private void timer4_Tick(object sender, EventArgs e)
        {
            postprocessing = form2.postprocessing;
            this.Opacity = form2.j58312;
            /* for (int y = 0; y < game_2.Height; y += 40)
             {
                 // paint a stripe
                 for (int ys = y; ys < y + 20; ys++)
                 {
                     for (int x = 0; x < game_2.Width; x++)
                     {
                         game_2.SetPixel(x, ys, Color.Linen);
                         game_2.MakeTransparent(Color.Linen);
                     }
                 }
             }*/

            // Console.WriteLine(grass.ToString());
            // 
        }

        private void glControl1_MouseClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            /* stuff__.block_file.Add((int)player.x);
             stuff__.block_file.Add((int)player.y);
             stuff__.block_file.Add((int)player.z);*/
          
        }
        
        private async void glControl1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
           if(e.Button == MouseButtons.Right)
            {
                Block_ block = new Block_();
                block.set_v1(new Vector3((int)-stuff__.player.x, (int)-stuff__.player.y, (int)-stuff__.player.z + 5));
                block.set_v1_material(selected_object);
                block.set_v1_blocktype(selected_8);//1
                block.set_v1_scale(new Vector3(1, 1, 1));
               // block.set_v1_light_level(Color.CornflowerBlue);
               Console.WriteLine(new Vector3((int)-stuff__.player.x, (int)-stuff__.player.y, (int)-stuff__.player.z + 5));//)
                if (player_ == 8)
                {
                    if (selected_8 == 2)
                {

                   // block.v1_light_level = 1;
                    for (int xj = 0; xj < stuff__.block_file.Count; xj++)
                    { if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X, block.get_v1().Y, block.get_v1().Z + 1))
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                           // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X, block.get_v1().Y , block.get_v1().Z))
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X-1, block.get_v1().Y, block.get_v1().Z ))//+ 1
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X +1, block.get_v1().Y , block.get_v1().Z ))//+ 1
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X, block.get_v1().Y, block.get_v1().Z+1))//+ 1
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X , block.get_v1().Y, block.get_v1().Z -1))//+ 1 
                        {
                            Block_ block_ = new Block_();
                            block_ = stuff__.block_file[xj];
                            block_.set_v1_light_level(4);
                            //block_.set_v1_material(4);
                            stuff__.block_file.RemoveAt(xj);
                            stuff__.block_file.Add(block_);

                            // stuff__.block_file[xj].set_v1_light_level(4);
                            // Console.WriteLine("collision detected");
                        }
                        
                        
                        /*
    if (stuff__.block_file[ xj].get_v1() == new Vector3(block.get_v1().X, block.get_v1().Y-1, block.get_v1().Z-1))
                        {
                                stuff__.block_file[xj].set_v1_light_level(4);
                             Console.WriteLine("collision detected");
                        } if (stuff__.block_file[xj].get_v1() == new Vector3(block.get_v1().X, block.get_v1().Y-1, block.get_v1().Z))
                            {
                                stuff__.block_file[xj].set_v1_light_level(4);
                                 Console.WriteLine("collision detected");
                            }
                            if (new Vector3((int)stuff__.block_file[xj].get_v1().X, (int)stuff__.block_file[xj].get_v1().Y, (int)stuff__.block_file[xj].get_v1().Z) == new Vector3((int)block.get_v1().X - 1, (int)block.get_v1().Y, (int)block.get_v1().Z))
                            {
                                stuff__.block_file[xj].set_v1_light_level(4);
                                 Console.WriteLine("collision detected");
                            }*/

                    }
                       // update_string += $"block_ {(int)block_.get_v1().X} {(int)block_.get_v1().Y} {(int)block_.get_v1().Z} {block_.get_v1_material()}";//""; //update_string += ""
                                                                                                                                                         //                                                                                                                 //(int)

                    }

                    stuff__.block_file.Add(block);//
                    stuff__.collision.Add(new Vector3(block.get_v1().X, block.get_v1().Y , block.get_v1().Z));//block_file

                }

                update_string += $" block_ {block.get_v1().X.ToString()} {block.get_v1().Y.ToString()} {block.get_v1().Z.ToString()} {block.get_v1_material().ToString()}";//(int)
                // player {player.x} {player.y} {player.z}
            }
            if (e.Button == MouseButtons.Left)
            {
               
                for (int xj = 0; xj < stuff__.block_file.Count; xj++)
                {
if(stuff__.block_file[xj].get_v1() == new Vector3((int)-stuff__.player.x, (int)-stuff__.player.y, (int)-stuff__.player.z+5))//{
                    {
                        Block_ block_ = new Block_(); block_.set_v1(new Vector3((int)-stuff__.player.x, (int)-stuff__.player.y, (int)-stuff__.player.z + 5));
                        //stuff__.block_file.Remove(block);
                        stuff__.block_file.RemoveAt(xj);
                       // stuff__.block_file.Add(block_);////
                    }

                   

                    //
                }
            
            }
        }
        List<Player> players = new List<Player>();
         async public void position__(){
            if (player_ == 9)
            {
                try
            {
                PositionResponse myPositionFromServer = await tcpConnection.SendAsync<PositionResponse>(new PositionRequest());
                update__string = myPositionFromServer.update_;
                join_string = myPositionFromServer.update_;
             
            }
            catch (KeyNotFoundException)
            {

               // throw;
            }
            }

        }
        //position__();
        string user_ = new Random().Next(4324, 4823).ToString();
        private async void timer5_Tick(object sender, EventArgs e)
        {
            if (player_ == 9)
            {
                if (connectionResult == ConnectionResult.Connected)
            {
                try
            {



                        // position__();
                        //  PositionResponse myPositionFromServer = await tcpConnection.SendAsync<PositionResponse>(new PositionRequest());

                        
                        if (connectionResult == ConnectionResult.Connected)
                        {
                            if (player_ == 9)
                            {
                                myPositionFromServer = await tcpConnection.SendAsync<PositionResponse>(new PositionRequest());//
                                tcpConnection.Send(new PositionUpdate() { X = stuff__.player.x, Y = stuff__.player.y, Z = stuff__.player.z, user = user_ , update_ = update_string });//"update"
                                update__string = myPositionFromServer.update_;
                                join_string = myPositionFromServer.update_;
                            }
                        }


                        players.Clear();
                    for (int xj = 0; xj < players.Count; xj++)
                    {
                        if (players[xj] != myPositionFromServer.player)
                        {
                            players.Add(myPositionFromServer.player); //[xj].
                        }
                    }

                }
            catch (KeyNotFoundException)
            {

                // throw;
            }
            }
            if (!backgroundWorker1.IsBusy)
            { }
            }
        }

        private void timer6_Tick(object sender, EventArgs e)
        {
            
          //  Console.WriteLine($"JJJJ: {join_string} ");//"
            update_string = "_";
          

            //map_update = "";
        }

        private void timer7_Tick(object sender, EventArgs e)
        {
          
            /* update_string += $" block_ {-player.x} {-player.y} {-player.z+1} 1";
           //  Thread.Sleep(500);
             update_string += $" __ {-player.x} {-player.y} {-player.z -1}";*/
        }

        private async void glControl1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.W))
            {
               
                for (int xj = 0; xj < 25; xj++)
                {
                    walkForward(0.5f * dt);
                    
                    await Sys.waitFunction(1);
                }
                walk________();

            }

            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.S))
            {
                for (int xj = 0; xj < 25; xj++)
                {
                    walkBackwards(0.5f * dt);
                    
                    await Sys.waitFunction(1);
                }
                walk________();
            }

            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.D))
            {
                for (int xj = 0; xj < 25; xj++)
                {
                    walkRight(0.5f * dt);
                    
                    await Sys.waitFunction(1);
                }
                walk________();
            }

            if (System.Windows.Input.Keyboard.IsKeyDown(System.Windows.Input.Key.Space))
            {
                if (plr_gravity == false)
                {
                    for (int xj = 0; xj < 20; xj++)
                    {
                        stuff__.player.y -= 0.1f;
                        plr_gravity = false;
                        await Sys.waitFunction(1);
                    }

                }

            }

        }
    }
    public static class stuff__{
        public static List<Block_> block_file = new List<Block_>() { new Block_()};
        public static List<Vector3> collision = new List<Vector3>();
        public static Player player = new Player();
        public static void NewBlock(int x, int y, int z,int x_size,int y_size,int z_size,int material)
    {
        Block_ chunk_block = new Block_();
        chunk_block.set_v1(new Vector3(x,y, z));
        chunk_block.set_v1_material(material);//1
        //4
            chunk_block.set_v1_blocktype(1);
        chunk_block.set_v1_light_level(1);
            chunk_block.set_v1_scale(new Vector3(x_size, y_size, z_size));
            //  Block_ block = new Block_();
            // block.set_v1(new Vector3(x, y, z));
            // block.set_v1_material(4);

            //  for (int xj = 0; xj < form1.stuff__.stuff__.block_file.Count; xj++)
            // {


            //   for (int xjj = 0; xjj <stuff__.block_file.Count; xjj++)
            //  {
            //      if (stuff__.block_file[ xjj].get_v1() == chunk_block.get_v1())
            //      {

            //  }
            //else
            //{
            stuff__.block_file.Add(chunk_block); //}
            stuff__.collision.Add(new Vector3(x, y + 1, z));
            // }


        }
}
    [MoonSharpUserData]
    public static class Numbers_
    {
        public static int RandomInt(int firstNumber, int secondNumber)
        {
            return new Random().Next(firstNumber, secondNumber);
        }
        public static float RandomFloat()
        { return (float)new Random().NextDouble(); }
    }
    [MoonSharpUserData]
    public static class Sys{ 

       
        
        public static async Task waitFunction(int time)
        {
            await Task.Delay(time);
        }
        public static async Task While(DynValue callback)
        {
            while (true)
            {
                if (callback.Type == MoonSharp.Interpreter.DataType.Function)
                {
                    callback.Function.Call();
                }
                await waitFunction(1);
            }
        }
        public static async void while_ (DynValue callback){
            await While(callback);//) 
         }
    public static async void wait(int time,DynValue callback)
        { await waitFunction(time);


            //https://stackoverflow.com/questions/50687687/how-to-call-await-async-c-sharp-method-from-lua-moonsharp-script
            //https://stackoverflow.com/questions/22158278

            if (callback.Type == MoonSharp.Interpreter.DataType.Function)
            {
                callback.Function.Call();
            }

        }
        public static string programPath()
        {
            return Path.GetDirectoryName(Application.ExecutablePath);
        }

        public static void map__()
        {
            stuff__.block_file.Clear();
        }
        public static int plr_Coord(string coord)
        {
            int returned_pos  = 5;
            if (coord == "X")
                returned_pos = (int)stuff__.player.x;
            if (coord == "Y")
                returned_pos = (int)stuff__.player.y;
            if (coord == "Z")
                returned_pos = (int)stuff__.player.z;
            return returned_pos;
        }
        public static void plr_set(string coord,float value)
        {
            if (coord == "X")
                stuff__.player.x = value;
            if (coord == "Y")
                stuff__.player.y = value;
            if (coord == "Z")
                stuff__.player.z = value;

        }
        public static bool map____(int x,int y,int z)
        {
          //  Block_ chunk_block = new Block_();
           // chunk_block.set_v1(new Vector3(x, y, z));
            bool returned = true;
            for (int xj = 0; xj < stuff__.block_file.Count; xj++)
            {
                if (stuff__.collision[xj] == new Vector3(x,y,z))//block_file//.
            {
                    returned = true;
                 //   Console.WriteLine("8j");
                }
                else
                {
                    returned = false;
                   // Console.WriteLine("5j");
                
                }
            }
            return returned;
        
        }
        public  static void fog(float Fog_)
        {
            GL.Fog(FogParameter.FogEnd, Fog_);
        }
    
    }//. 
    [MoonSharpUserData]
    public static class networking
    {
        public static string downloadString(string url)
    {
        WebClient string_download = new WebClient();
        return string_download.DownloadString(url);
    }
    }
}
