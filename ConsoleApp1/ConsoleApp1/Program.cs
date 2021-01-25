using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Program prog = new Program();
            int[,] tab = new int[20, 20];
            tab = prog.GenerujTablice();

            prog.Draw(prog.GenerujTablice());


            Console.ReadKey();
        }

        public int[,] GenerujTablice()
        {
            int[,] numery = new int[20, 20];
            Random random = new Random();

            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    numery[i, j] = random.Next(0, 2);
                }
            }

            return numery;
        }

        public void Draw(int[,] table)
        {
            for(int i = 0; i<20; i++)
            {
                for(int j = 0; j< 20; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.Write("\n");
            }

            Console.Write(table.Length);
        }

        public void AddingToList(int[,] table)
        {
            List<Point> points = new List<Point>();
            Point p = new Point();

            for(int i = 0; i< 20; i++)
            {
                for(int j = 0; j<20; j++)
                {
                    if(table[i,j] == 1)
                    {
                        p.X = i;
                        p.Y = j;

                        points.Add(p);
                    }
                }
            }
        }
    }
}
