using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Tablica
    {

        public int[,] GenerujTablice()
        {
            //int[,] numery = new int[5, 5];
            Console.WriteLine("Tablica: ");


            int[,] numery = {
                { 0, 1, 0, 0, 1},
                { 1, 1, 1, 0, 0},
                { 0, 1, 1, 1, 0},
                { 1, 0, 1, 0, 1},
                { 1, 0, 0, 1, 0}
            };


            //Random random = new Random();

            //for (int i = 0; i < 5; i++)
            //{
            //    for (int j = 0; j < 5; j++)
            //    {
            //        numery[i, j] = random.Next(0, 2);
            //    }
            //}

            Draw(numery);

            return numery;
        }

        public void WriteOutPoints(List<Point> points)
        {
            Console.WriteLine("\nPunkty: ");

            foreach (var p in points)
            {
                Console.WriteLine(p.X + " " + p.Y);
            }
        }


        public void Draw(int[,] table)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.Write("\n");
            }
        }
    }
}
