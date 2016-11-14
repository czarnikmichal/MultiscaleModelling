using MultiscaleModelling.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiscaleModelling.Utilities
{
    class CAMethods1
    {
        public Board1 board { get; private set; }
        private Random rand = new Random();
        public BoundaryMethods BoundaryMethod;
        public bool IsPeriodic;
        public enum BoundaryMethods { Neumann, Moore, Pentagonal, Hexagonal, Rules };
        public CAMethods1()
        {
            board = new Board1(); 
            BoundaryMethod = BoundaryMethods.Neumann;
            IsPeriodic = false;
        }

        public void AddNewCell(int x, int y)
        {
            board.AddCell(x, y);
        }

        public void CreateCircularInclusion(int x, int y, int radius)
        {
            for (int i = x - radius; i <= x; i++)
            {
                for (int j = y - radius; j <= y; j++)
                {
                    if (((i - x) * (i - x)) + ((j - y) * (j - y)) <= (radius * radius))
                    {
                        int i1 = x - (i - x);
                        int j1 = y - (j - y);
                        int i2 = i;
                        int j2 = j;
                        if (IsPeriodic)
                        {
                            i1 = (i1 + board.SizeX) % board.SizeX;
                            j1 = (j1 + board.SizeY) % board.SizeY;
                            i2 = (i2 + board.SizeX) % board.SizeX;
                            j2 = (j2 + board.SizeY) % board.SizeY;
                        }
                        if(i1 >= 0 && i1 < board.SizeX && i2 >= 0 && i2 < board.SizeX && j1 >= 0 && j1 < board.SizeY && j2 >= 0 && j2 < board.SizeY)
                        {
                            board.AddInclusionCell(i, j);
                            board.AddInclusionCell(i1, j);
                            board.AddInclusionCell(i1, j1);
                            board.AddInclusionCell(i, j1);
                        }
                    }
                }
            }
        }

        public void CreateRectangleInclusion(int x, int y, int sizeX, int sizeY)
        {
            for (int i = x-(sizeX/2); i < x + (sizeX / 2); i++)
            {
                for (int j = y - (sizeY / 2); j < y + (sizeY / 2); j++)
                {
                    int tempI = i;
                    int tempJ = j;
                    if (IsPeriodic)
                    {
                        tempI = (tempI + board.SizeX) % board.SizeX;
                        tempJ = (tempJ + board.SizeY) % board.SizeY;
                    }
                    if(tempI>=0 && tempI < board.SizeX && tempJ>=0 && tempJ<board.SizeY)
                        board.AddInclusionCell(tempI, tempJ);
                }
            }
        }

        public void AddRandomCells(int number)
        {
            while (number > 0)
            {
                int x = rand.Next(board.SizeX);
                int y = rand.Next(board.SizeY);
                if (board.AddCell(x, y))
                {
                    number--;
                }
            }
        }

        public void Count()
        {
            List<Coordinate> listCoord = GetBoundreisForList(board.NewlyAdded);
            if (board.NewlyAdded.Count == 0)
            {
                listCoord = FindBoundries();
            }
            foreach (var item in listCoord)
            {

                if (IsPeriodic)
                {
                    item.CoordinateX = (item.CoordinateX + board.SizeX) % board.SizeX;
                    item.CoordinateY = (item.CoordinateY + board.SizeY) % board.SizeY;
                }
                else if (item.CoordinateX < 0 || item.CoordinateX >= board.SizeX || item.CoordinateY >= board.SizeY || item.CoordinateY < 0)
                {
                    continue;
                }
                if (board.board[item.CoordinateX, item.CoordinateY] == 0)
                {
                    if (BoundaryMethod == BoundaryMethods.Rules)
                    {
                        //rule1
                        Dictionary<int, int> group = new Dictionary<int, int>();
                        var points = GetRule1(item);
                        foreach (var point in points)
                        {
                            if (IsPeriodic)
                            {
                                point.CoordinateX = (point.CoordinateX + board.SizeX) % board.SizeX;
                                point.CoordinateY = (point.CoordinateY + board.SizeY) % board.SizeY;
                            }
                            else if (point.CoordinateX < 0 || point.CoordinateX >= board.SizeX || point.CoordinateY >= board.SizeY || point.CoordinateY < 0)
                            {
                                continue;
                            }
                            if (board.board[point.CoordinateX, point.CoordinateY] > 0)
                            {
                                if (group.ContainsKey(board.board[point.CoordinateX, point.CoordinateY]))
                                {
                                    group[board.board[point.CoordinateX, point.CoordinateY]] = group[board.board[point.CoordinateX, point.CoordinateY]] + 1;
                                }
                                else
                                {
                                    group.Add(board.board[point.CoordinateX, point.CoordinateY], 1);
                                }
                            }
                        }
                        var key = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;
                        var maxValue = (group.Count > 0) ? group.Values.Max() : 0;
                        if (maxValue>=5)
                            board.AddCell(item.CoordinateX, item.CoordinateY, key);

                        //rule2
                        group = new Dictionary<int, int>();
                        points = GetRule2(item);
                        foreach (var point in points)
                        {
                            if (IsPeriodic)
                            {
                                point.CoordinateX = (point.CoordinateX + board.SizeX) % board.SizeX;
                                point.CoordinateY = (point.CoordinateY + board.SizeY) % board.SizeY;
                            }
                            else if (point.CoordinateX < 0 || point.CoordinateX >= board.SizeX || point.CoordinateY >= board.SizeY || point.CoordinateY < 0)
                            {
                                continue;
                            }
                            if (board.board[point.CoordinateX, point.CoordinateY] > 0)
                            {
                                if (group.ContainsKey(board.board[point.CoordinateX, point.CoordinateY]))
                                {
                                    group[board.board[point.CoordinateX, point.CoordinateY]] = group[board.board[point.CoordinateX, point.CoordinateY]] + 1;
                                }
                                else
                                {
                                    group.Add(board.board[point.CoordinateX, point.CoordinateY], 1);
                                }
                            }
                        }
                        key = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;
                        maxValue = (group.Count>0)?group.Values.Max():0;
                        if (maxValue >= 3)
                            board.AddCell(item.CoordinateX, item.CoordinateY, key);

                        //rule3
                        group = new Dictionary<int, int>();
                        points = GetRule3(item);
                        foreach (var point in points)
                        {
                            if (IsPeriodic)
                            {
                                point.CoordinateX = (point.CoordinateX + board.SizeX) % board.SizeX;
                                point.CoordinateY = (point.CoordinateY + board.SizeY) % board.SizeY;
                            }
                            else if (point.CoordinateX < 0 || point.CoordinateX >= board.SizeX || point.CoordinateY >= board.SizeY || point.CoordinateY < 0)
                            {
                                continue;
                            }
                            if (board.board[point.CoordinateX, point.CoordinateY] > 0)
                            {
                                if (group.ContainsKey(board.board[point.CoordinateX, point.CoordinateY]))
                                {
                                    group[board.board[point.CoordinateX, point.CoordinateY]] = group[board.board[point.CoordinateX, point.CoordinateY]] + 1;
                                }
                                else
                                {
                                    group.Add(board.board[point.CoordinateX, point.CoordinateY], 1);
                                }
                            }
                        }
                        key = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;
                        maxValue = (group.Count > 0) ? group.Values.Max() : 0;
                        if (maxValue >= 3)
                            board.AddCell(item.CoordinateX, item.CoordinateY, key);

                        //rule4 
                        group = new Dictionary<int, int>();
                        points = GetRule1(item);
                        foreach (var point in points)
                        {
                            if (IsPeriodic)
                            {
                                point.CoordinateX = (point.CoordinateX + board.SizeX) % board.SizeX;
                                point.CoordinateY = (point.CoordinateY + board.SizeY) % board.SizeY;
                            }
                            else if (point.CoordinateX < 0 || point.CoordinateX >= board.SizeX || point.CoordinateY >= board.SizeY || point.CoordinateY < 0)
                            {
                                continue;
                            }
                            if (board.board[point.CoordinateX, point.CoordinateY] > 0)
                            {
                                if (group.ContainsKey(board.board[point.CoordinateX, point.CoordinateY]))
                                {
                                    group[board.board[point.CoordinateX, point.CoordinateY]] = group[board.board[point.CoordinateX, point.CoordinateY]] + 1;
                                }
                                else
                                {
                                    group.Add(board.board[point.CoordinateX, point.CoordinateY], 1);
                                }
                            }
                        }
                        key = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;
                        int propability = 10;
                        if(rand.Next(100)<=propability)
                            board.AddCell(item.CoordinateX, item.CoordinateY, key);
                    }
                    else
                    {
                        Dictionary<int, int> group = new Dictionary<int, int>();
                        var points = CheckBoundriesForPoint(item);
                        foreach (var point in points)
                        {
                            if (IsPeriodic)
                            {
                                point.CoordinateX = (point.CoordinateX + board.SizeX) % board.SizeX;
                                point.CoordinateY = (point.CoordinateY + board.SizeY) % board.SizeY;
                            } else if (point.CoordinateX < 0 || point.CoordinateX >= board.SizeX || point.CoordinateY >= board.SizeY || point.CoordinateY < 0)
                            {
                                continue;
                            }
                            if (board.board[point.CoordinateX, point.CoordinateY] > 0)
                            {
                                if (group.ContainsKey(board.board[point.CoordinateX, point.CoordinateY]))
                                {
                                    group[board.board[point.CoordinateX, point.CoordinateY]] = group[board.board[point.CoordinateX, point.CoordinateY]] + 1;
                                }
                                else
                                {
                                    group.Add(board.board[point.CoordinateX, point.CoordinateY], 1);
                                }
                            }
                        }
                        var c = group.FirstOrDefault(x => x.Value == group.Values.Max()).Key;
                        board.AddCell(item.CoordinateX, item.CoordinateY, c);
                    }
                }
            }
        }
        public List<Coordinate> GetBoundreisForList(List <Coordinate> toCheck)
        {
            List<Coordinate> pointsToCheck = new List<Coordinate>();
            foreach (var item in toCheck)
            {
                pointsToCheck.AddRange(CheckBoundriesForPoint(item));
            }
            board.NewlyAdded.Clear();
            return pointsToCheck;
        }

        public List<Coordinate> CheckBoundriesForPoint(Coordinate item)
        {
            List<Coordinate> pointsToCheck = new List<Coordinate>();
            switch (BoundaryMethod)
                {
                case BoundaryMethods.Hexagonal:
                    switch (rand.Next() % 2)
                    {
                        case 0:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
                            break;
                        case 1:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
                            break;
                    }
                break;
                case BoundaryMethods.Moore:
                    pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
                    break;
                case BoundaryMethods.Neumann:
                    pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                    pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                break;
                case BoundaryMethods.Pentagonal:
                    switch (rand.Next() % 4)
                    {
                        case 0:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
                            break;
                        case 1:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
                            break;
                        case 2:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
                            break;
                        case 3:
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
                            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
                            break;
                    } 
                break;
                case BoundaryMethods.Rules:
                    return GetRule1(item);
                    break;
            }
            return pointsToCheck;
        }

        public BoundaryMethods TranslateComboBox(string value)
        {
            switch (value)
            {
                case @"von Neumann":
                    return BoundaryMethods.Neumann;
                case @"Moore":
                    return BoundaryMethods.Moore;
                case @"Random Hexagonal":
                    return BoundaryMethods.Hexagonal;
                case @"Random Pentagonal":
                    return BoundaryMethods.Pentagonal;
                case @"Moore Rules":
                    return BoundaryMethods.Rules;
            }
            return BoundaryMethods.Neumann;
        }

        public void ClearBoard()
        {
            int sizeX = board.SizeX;
            int sizeY = board.SizeY;
            board = new Board1();
            board.SizeX = sizeX;
            board.SizeY = sizeY;
        }

        public List<Coordinate> FindBoundries()
        {
            List<Coordinate> list = new List<Coordinate>();
            for (int i = 0; i < board.SizeX; i++)
            {
                for (int j = 0; j < board.SizeY; j++)
                {
                    for(int x = -1; x<2; x++)
                    {
                        for (int y = -1; y < 2; y++)
                        {
                            int tempY = j + y;
                            int tempX = i + x;
                            if (IsPeriodic)
                            {
                                tempX = (tempX + board.SizeX) % board.SizeX;
                                tempY = (tempY + board.SizeY) % board.SizeY;
                            }
                            if(!(tempX<0 || tempX >=board.SizeX || tempY<0 || tempY >= board.SizeY))
                            {
                                if (board.board[tempX, tempY] != board.board[i,j])
                                {
                                    list.Add(new Coordinate(i, j));
                                    y = 3;
                                    x = 3;
                                }
                            }
                        }
                    }
                }
            }
            return list;
        }

        public void AddSquareInclusions(int number, int hgh, int wdth)
        {
            var boundries = FindBoundries();
            while (number > 0)
            {
                var a = boundries.ElementAt(rand.Next(boundries.Count));
                CreateRectangleInclusion(a.CoordinateX, a.CoordinateY, wdth, hgh);
                number--;
            }
        }

        public void AddCircleInclusions(int number, int r)
        {
            var boundries = FindBoundries();
            while (number > 0)
            {
                var a = boundries.ElementAt(rand.Next(boundries.Count));
                CreateCircularInclusion(a.CoordinateX, a.CoordinateY, r);
                number--;
            }
        }
        private List<Coordinate> GetRule1(Coordinate item)
        {
            List<Coordinate> pointsToCheck = new List<Coordinate>();
            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
            return pointsToCheck;
        }

        private List<Coordinate> GetRule2(Coordinate item)
        {
            List<Coordinate> pointsToCheck = new List<Coordinate>();
            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX, item.CoordinateY - 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY));
            return pointsToCheck;
        }

        private List<Coordinate> GetRule3(Coordinate item)
        {
            List<Coordinate> pointsToCheck = new List<Coordinate>();
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY - 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX - 1, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY + 1));
            pointsToCheck.Add(new Coordinate(item.CoordinateX + 1, item.CoordinateY - 1));
            return pointsToCheck;
        }

        public bool ShouldEnd()
        {
            for (int i = 0; i < board.SizeX; i++)
            {
                for (int j = 0; j < board.SizeY; j++)
                {
                    if (board.board[i, j] == 0)
                        return true;
                }
            }
            return false;
        }
    }
}
