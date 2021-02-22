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
            Tablica tablica = new Tablica();
            Matrix matrix = new Matrix();

            int[,] tab = new int[5, 5];
            tab = tablica.GenerujTablice();
            
            List<Point> points = prog.AddingToList(tab);
            tablica.WriteOutPoints(points);

            var tablicaMatrix = matrix.MakeMatrix(points);
            
            prog.Djikstra(matrix.DistanceMatrix(tablicaMatrix, points), points);


            Console.ReadKey();
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

        public void Djikstra(double[,] tablicaSasiedztwa, List<Point> points)
        {
            Point[] Z = new Point[points.Count];
            double[] dystans = new double[points.Count];
            List<int> punktyDoSprawdzenia = new List<int>();

            punktyDoSprawdzenia.Add(0);

            while (punktyDoSprawdzenia.Any<int>())
            {
                var punkt = punktyDoSprawdzenia.First<int>();
                for (int j = 0; j < points.Count; j++)
                {
                    var odleglosc = tablicaSasiedztwa[punkt, j];
                    if (((punkt != j)))
                    {
                        Z[j] = points[punkt];
                        dystans[j] = tablicaSasiedztwa[punkt, j] + dystans[punkt];
                        punktyDoSprawdzenia.Add(j);
                    }
                }
                    
                punktyDoSprawdzenia.Remove(punkt);
            }

            foreach (var p in Z)
            {
                Console.Write("\nZ:\n");
                Console.WriteLine(p);
            }

            foreach (var p in dystans)
            {
                Console.Write("\nDystans:\n");
                Console.WriteLine(p);
            }
        }
    }
}
