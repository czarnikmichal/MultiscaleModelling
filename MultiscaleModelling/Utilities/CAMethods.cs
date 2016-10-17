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
        public enum Methods {Neumann, Hexagonal, Pentagonal, Moore };
        private static Random rand = new Random();
        private static Board board = new Board();

        public static void CreateRandomCells(int numberOfCells, int maxX, int maxY)
        {
            for(int i = board.NumberOfGroups; i<numberOfCells+board.NumberOfGroups;)
            {
                Coordinate coord = new Coordinate(rand.Next() % board.SizeX, rand.Next() % board.SizeY);
                Cell c1 = new Cell(i);
                if (board.AddToBoard(c1, coord))
                    i++;
            }             
        }

        public static void CountNextStep(Methods m, bool periodic)
        {
            Dictionary<Coordinate, Cell> tempDict = board.GetBoard();
            foreach(Coordinate c1 in tempDict.Keys)
            {
                switch (m)
                {
                    case Methods.Neumann:
                        CountNeumann(tempDict, periodic);
                        break;
                    case Methods.Moore:
                        CountMoore(tempDict, periodic);
                        break;
                    case Methods.Pentagonal:
                        CountPentagonal(tempDict, periodic);
                        break;
                    case Methods.Hexagonal:
                        CountHexagonal(tempDict, periodic);
                        break;

                }
            }
        }

        private static void CountNeumann(Dictionary<Coordinate, Cell> tempDict, bool periodic)
        {
            throw new NotImplementedException();
        }

        private static void CountMoore(Dictionary<Coordinate, Cell> tempDict, bool periodic)
        {
            throw new NotImplementedException();
        }

        private static void CountPentagonal(Dictionary<Coordinate, Cell> tempDict, bool periodic)
        {
            throw new NotImplementedException();
        }

        private static void CountHexagonal(Dictionary<Coordinate, Cell> tempDict, bool periodic)
        {
            throw new NotImplementedException();
        }
    }
}
