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
            int[,] tab = new int[5, 5];
            tab = prog.GenerujTablice();
            
            prog.Draw(tab);

            List<Point> points = prog.AddingToList(tab);

            Console.WriteLine("\n");

            foreach (var p in points)
            {
                Console.WriteLine(p.X + " " + p.Y);
            }

            prog.MakeMatrix(points);

            Console.ReadKey();
        }

        public int[,] GenerujTablice()
        {
            //int[,] numery = new int[5, 5];

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

            return numery;
        }

        public void Draw(int[,] table)
        {
            for(int i = 0; i<5; i++)
            {
                for(int j = 0; j< 5; j++)
                {
                    Console.Write(table[i, j]);
                }
                Console.Write("\n");
            }
        }

        public List<Point> AddingToList(int[,] table)
        {
            List<Point> points = new List<Point>();

            for(int i = 0; i< 5; i++)
            {
                for(int j = 0; j<5; j++)
                {
                    if(table[i,j] == 1)
                    {
                        Point p = new Point();
                        p.X = i;
                        p.Y = j;

                        points.Add(p);
                    }
                }
            }

            return points;
        }

        public void MakeMatrix(List<Point> l)
        {

            double[,] matrix = new double[l.Count, l.Count];

            for(int i = 0; i < l.Count; i++)
            {
                for(int j = 0; j < l.Count; j++)
                {
                    matrix[i, j] = (CheckDistance(l[i], l[j]));
                }
            }

            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    if (i == j)
                    {
                        Console.Write("X");
                    }
                    else
                    {
                        Console.Write(" " + String.Format("{0:N2}", matrix[i, j]) + " ");
                    }
                    
                }
                Console.Write("\n");
            }
            Console.Write("\n");
            Console.Write("\nSąsiedztwo:\n");

            DistanceMatrix(matrix, l);
        }

        private double CheckDistance(Point point, Point p)
        {
            int distanceX = p.X - point.X;
            int distanceY = p.Y - point.Y;

            double distance = /*Math.Round*/(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));
            return distance;
        }

        private void DistanceMatrix(double[,] tab, List<Point> l)
        {
            var matrixOdleglosci = new double[l.Count, l.Count];

            for(int i = 0; i < l.Count; i++)
            {
                for(int j = 0; j < l.Count; j++)
                {
                    matrixOdleglosci[i, j] = tab[i, j] * CheckNeigbours(l[i], l[j]);
                }
            }

            NewDraw(matrixOdleglosci, l.Count, l.Count);

            Shortest(matrixOdleglosci, l.Count);
        }

        private double CheckNeigbours(Point point1, Point point2)
        {
            if (((point1.X == point2.X + 1) || (point1.X == point2.X - 1) || (point1.X == point2.X)) && ((point1.Y == point2.Y + 1) || (point1.Y == point2.Y - 1) || (point1.Y == point2.Y)))
            {
                return 1.00;
            }
            else
                return 0;
        }

        private void NewDraw(double[,] tab, int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if(i == j)
                    {
                        Console.Write(" " + "X" + " ");
                    }
                    Console.Write(" " + String.Format("{0:N2}", tab[i, j]) + " ");

                }
                Console.Write("\n");
            }
        }

        private List<double> Shortest(double[,] tab, int a)
        {
            List<double> shortestList = new List<double>();

            double[] shortest = new double[a];

            for(int i = 0; i < a; i++)
            {
                shortest[i] = 9999999;
                for (int j = 0; j < a; j++)
                {
                    if(tab[i,j] < shortest[i])
                    {
                        shortest[i] = tab[i, j];
                        shortestList[i] = shortest[i];
                    }
                }
            }

            foreach(var p in shortestList)
            {
                Console.WriteLine(p);
            }

            return shortestList;
        }
    }
}
