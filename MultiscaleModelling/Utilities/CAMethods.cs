using MultiscaleModelling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Utilities
{
    static class CAMethods
    {
        static Random rand = new Random();
        public static Cell [,] CreteDiemsnions(int sizeX, int sizeY)
        {
            var a = new Cell[sizeX, sizeY];
            return a;
        }

        public static void InitialPopulate(ref Cell[,] cA, ref List<Coordinate> cL, int numberOfCellGroups)
        {
            int sizeX = cA.GetLength(0);
            int sizeY = cA.GetLength(1);
            if (numberOfCellGroups < sizeX * sizeY)
            {
                for (int i = 0; i < numberOfCellGroups; i++)
                {
                    Coordinate c = new Coordinate(rand.Next(0, sizeX), rand.Next(0, sizeY));
                    if (cL.Contains(c))
                    {
                        i--;
                        continue;
                    }
                    cL.Add(c);
                    cA[c.CoordinateX, c.CoordinateY] = new Cell(i);
                }
            }
        }
    }
}
