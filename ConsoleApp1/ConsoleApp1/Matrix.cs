using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Matrix
    {
        Program program = new Program();
        public void MakeMatrix(List<Point> l)
        {
            Console.Write("\nTabela odległości: \n");
            double[,] matrix = new double[l.Count, l.Count];

            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
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

        private double CheckNeigbours(Point point1, Point point2)
        {
            if (((point1.X == point2.X + 1) || (point1.X == point2.X - 1) || (point1.X == point2.X)) && ((point1.Y == point2.Y + 1) || (point1.Y == point2.Y - 1) || (point1.Y == point2.Y)))
            {
                return 1.00;
            }
            else
                return 0;
        }

        private void DistanceMatrix(double[,] tab, List<Point> l)
        {
            var matrixOdleglosci = new double[l.Count, l.Count];

            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < l.Count; j++)
                {
                    matrixOdleglosci[i, j] = tab[i, j] * CheckNeigbours(l[i], l[j]);
                }
            }

            NewDraw(matrixOdleglosci, l.Count, l.Count);

            program.Djikstra(matrixOdleglosci, l);

            //Shortest(matrixOdleglosci, l.Count);
        }

        private double CheckDistance(Point point, Point p)
        {
            int distanceX = p.X - point.X;
            int distanceY = p.Y - point.Y;

            double distance = /*Math.Round*/(Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2)));
            return distance;
        }

        private void NewDraw(double[,] tab, int a, int b)
        {
            for (int i = 0; i < a; i++)
            {
                for (int j = 0; j < a; j++)
                {
                    if (i == j)
                    {
                        Console.Write(" " + "X" + " ");
                    }
                    Console.Write(" " + String.Format("{0:N2}", tab[i, j]) + " ");

                }
                Console.Write("\n");
            }
        }
    }
}
