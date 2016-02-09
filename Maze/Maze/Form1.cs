using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maze
{
   
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
           
        }
       
        private void Form1_Load(object sender, EventArgs e)
        {
           
            
            

        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Maze maze = new Maze(25, 25, 9);
            maze.Draw(g);
            
        }

       


   

    }
}
