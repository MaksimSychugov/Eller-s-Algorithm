using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Maze
{
    class Maze
    {
        Random random = new Random();
         static int mazeHeight;
         static int mazeWidth;
         int zoom;
        //Graphics gr;
        int[,] mass;
        public Maze(int height, int width, int size)
        {
            zoom = size;
            mazeHeight = height;
            mazeWidth = width;
            mass = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    if (i == 0)
                    {
                        mass[i, j] = j + 1;
                    }
                    else
                    {
                        mass[i, j] = 0;
                    }
                }
            }
        }


        //====================================

        void DrawRightBorder(int numberLine, Graphics g)
        {
            int c;
            for (int j = 0; j < mazeHeight - 1; j++)
            {
                c = random.Next(0, 2);
                if (c == 1 || mass[numberLine, j] == mass[numberLine, j + 1])
                {
                    g.DrawLine(new Pen(Color.Black), (j + 1) * zoom, numberLine * zoom, (j + 1) * zoom, (numberLine+1) * zoom);
                }
                else
                {
                    mass[numberLine, j + 1] = mass[numberLine, j];
                }
            }
        }
        //=================================
        void DrawDownBorder(int numberLine, Graphics g)
        {
            int end = 0;
            int rand;
            for (int begin = 0; begin < mazeHeight - 1; begin++)
            {
                if (mass[numberLine, begin] == mass[numberLine, begin + 1])
                {
                    end++;
                }
                if (end != 0 && mass[numberLine, begin] != mass[numberLine, begin + 1])
                {
                    int r1 = random.Next(begin - end, begin + 1);
                    for (int k = begin - end; k < begin + 1; k++)
                    {
                        rand = random.Next(0, 2);
                        if (k != r1 && numberLine != mazeWidth-2 && rand == 1)
                        {
                            g.DrawLine(new Pen(Color.Black), (k) * zoom, (numberLine + 1) * zoom, (k + 1) * zoom, (numberLine + 1) * zoom);
                            mass[numberLine, k] = 0;
                        }
                        if (k != r1 && numberLine == mazeWidth - 2 && rand==1)
                        {
                            g.DrawLine(new Pen(Color.Black), (k) * zoom, (numberLine + 1) * zoom, (k + 1) * zoom, (numberLine + 1) * zoom);
                            mass[numberLine, k] = 0;
                        }
                    }
                    end = 0;
                }
                if (begin == mazeHeight - 2 && mass[numberLine, begin] == mass[numberLine, begin + 1])
                {
                    int r2 = random.Next(begin - end + 1, begin + 2);
                    for (int k = begin - end + 1; k < begin + 2; k++)
                    {
                        if (k != r2)
                        {
                            g.DrawLine(new Pen(Color.Black), (k) * zoom, (numberLine + 1) * zoom, (k + 1) * zoom, (numberLine + 1) * zoom);
                            mass[numberLine, k] = 0;
                        }
                    }
                }
                if (mass[numberLine, begin] != mass[numberLine, begin + 1])
                {
                    end = 0;
                }
            }
        }

        //===================================
        void CopyLine(int nuberLine)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                mass[nuberLine + 1, j] = mass[nuberLine, j];
            }
        }

        void CopyLineAndSet(int numberLine, Graphics g)
        {
            for (int j = 0; j < mazeHeight; j++)
            {
                mass[numberLine + 1, j] = mass[numberLine, j];
            }
            for (int k = 0; k < mazeHeight-1; k++)
            {
                if (mass[numberLine + 1, k] == mass[numberLine + 1, k + 1] && mass[numberLine + 1, k]!=0)
               {
                   g.DrawLine(new Pen(Color.Black), (k + 1) * zoom, (numberLine+1) * zoom, (k + 1) * zoom, (numberLine + 2) * zoom);
               }
            }
            
        }

        void SetSet(int numberLine)
        {
            List<int> Set1 = new List<int>();
            List<int> Set2 = new List<int>();
            bool isHit = false;
            for (int k = 0; k < mazeHeight; k++)
            {
                if(mass[numberLine,k] != 0)
                {
                    Set1.Add(mass[numberLine, k]);
                }
            }
            for(int k = 1; k < mazeHeight+1; k++)
            {
                for(int n = 0; n < Set1.Count; n++)
                {
                    if (k == Set1[n])
                    {
                        break;
                    }
                    if (n == Set1.Count - 1)
                    {
                        isHit = true;
                    }
                }
                if (isHit)
                {
                    Set2.Add(k);
                    isHit = false;
                }
            }
            int number = 0;
            for (int k = 0; k < mazeHeight; k++) 
            {
                if(mass[numberLine,k]==0 && number != Set2.Count)
                {
                    mass[numberLine, k] = Set2[number];
                    number++;
                }
            }
            Set1.Clear();
            Set2.Clear();
           
        }

       public void Draw(Graphics g)
        {
           
            g.DrawRectangle(new Pen(Color.Black), 0, 0, mazeHeight*zoom, mazeWidth*zoom);
            for (int i = 0; i < mazeWidth-1; i++)
            {
                DrawRightBorder(i, g);
                DrawDownBorder(i, g);
                CopyLine(i);
                SetSet(i+1);
            }
            CopyLineAndSet(mazeWidth - 2, g);

           
           




        
        }

       


    }
}
