using MultiscaleModelling.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MultiscaleModelling.Utilities
{
    static class CAMethods
    {
        private static Random rand = new Random();
        private static Board board = new Board();
        public enum Methods { Neumann, Moore, Pentagonal, Hexagonal };

        public static void CreateRandomCells(int numberOfCells)
        {
            int nOG = board.NumberOfGroups;
            for (int i = nOG; i < numberOfCells + nOG;)
            {
                Coordinate coord = new Coordinate(rand.Next() % board.SizeX, rand.Next() % board.SizeY);
                Cell c1 = new Cell(i+1);
                if (board.AddToBoard(c1, coord))
                    i++;
            }
        }

        public static void CountNextStep(Methods m, bool periodic)
        {
            List<Coordinate> keyList = board.GetBoard().Where(x => !x.Value.IsCounted).Select(x => x.Key).ToList();
            var a = board.GetBoard().Where(x => (x.Key.CoordinateX > board.SizeX || x.Key.CoordinateY > board.SizeY));
            foreach (Coordinate c1 in keyList)
            {
                switch (m)
                {
                    case Methods.Neumann:
                        CountNeumann(c1, periodic);
                        break;
                    case Methods.Moore:
                        CountMoore(c1, periodic);
                        break;
                    case Methods.Pentagonal:
                        CountPentagonal(c1, periodic);
                        break;
                    case Methods.Hexagonal:
                        CountHexagonal(c1, periodic);
                        break;
                }
                board.GetBoard()[c1].IsCounted = true;
            }
        }

        private static void CountPentagonal(Coordinate c1, bool periodic)
        {
            List<Coordinate> coordinateArray = new List<Coordinate>();
            switch (rand.Next() % 4)
            {
                case 0:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY + 1));
                    break;
                case 1:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY - 1));
                    break;
                case 2:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY - 1));
                    break;
                case 3:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY + 1));
                    break;
            }
            Count(c1, periodic, coordinateArray);
        }

        private static void CountHexagonal(Coordinate c1, bool periodic)
        {
            List<Coordinate> coordinateArray = new List<Coordinate>();
            switch (rand.Next() % 2)
            {
                case 0:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY + 1));
                    break;
                case 1:
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY + 1));
                    coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY - 1));
                    break;
            }
            Count(c1, periodic, coordinateArray);
        }

        private static void CountMoore(Coordinate c1, bool periodic)
        {
            List<Coordinate> coordinateArray = new List<Coordinate>();
            coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
            coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
            coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY + 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY - 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY - 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY + 1));
            Count(c1, periodic, coordinateArray);
        }

        private static void CountNeumann(Coordinate c1, bool periodic)
        {
            List<Coordinate> coordinateArray = new List<Coordinate>();
            coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY + 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX, c1.CoordinateY - 1));
            coordinateArray.Add(new Coordinate(c1.CoordinateX + 1, c1.CoordinateY));
            coordinateArray.Add(new Coordinate(c1.CoordinateX - 1, c1.CoordinateY));
            Count(c1, periodic, coordinateArray);
        }

        private static void Count(Coordinate c1, bool periodic, List<Coordinate> coordinateArray)
        {
            board.GetBoard()[c1].IsCounted = true;
            foreach (Coordinate c in coordinateArray)
            {
                board.AddToBoard(new Cell(board.GetBoard()[c1].GroupID), c, periodic);
            }
        }

        public static void DrawCell(this Graphics g, Cell cell, Coordinate coord)
        {
            g.DrawRectangle(board.Colors[cell.GroupID], new Rectangle(coord.CoordinateX, coord.CoordinateY, 1, 1));
            cell.IsNew = false;
        }

        public static void DrawBoard(this Graphics g)
        {
            foreach(var temp in board.GetBoard().Where(x=>x.Value.IsNew))
            {
                g.DrawCell(temp.Value, temp.Key);
            }
        }

        public static Methods TranslateComboBox(this string value){
            switch (value)
            {
                case @"von Neumann":
                    return Methods.Neumann;
                case @"Moore":
                    return Methods.Moore;
                case @"Random Hexagonal":
                    return Methods.Hexagonal;
                case @"Random Pentagonal":
                    return Methods.Pentagonal;
            }
            return Methods.Neumann;
        }
    }
}