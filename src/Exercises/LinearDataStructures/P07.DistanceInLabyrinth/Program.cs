// 60/100

namespace P07.DistanceInLabyrinth
{
    using System;
    using System.Collections.Generic;

    public class Program
    {
        public static void Main()
        {
            var passedPositions = new Stack<Position>();
            int size = int.Parse(Console.ReadLine());
            var board = new string[size, size];
            var currentPosition = new Position(0, 0);

            for (int row = 0; row < size; row++)
            {
                string line = Console.ReadLine();
                for (int col = 0; col < line.Length; col++)
                {
                    if (line[col] == '*')
                    {
                        currentPosition = new Position(row, col);
                    }
                    board[row, col] = line[col].ToString();
                }
            }
            passedPositions.Push(currentPosition);
            int distance = 0;
            while (passedPositions.Count > 0)
            {
                var positions = currentPosition.GetReachablePositions(board);
                if (positions.Count == 0)
                {
                    currentPosition = passedPositions.Pop();
                    if (passedPositions.Count > 0)
                    {
                        distance = int.Parse(board[currentPosition.Row, currentPosition.Column]);
                    }
                    else
                    {
                        distance = 0;
                    }
                    continue;
                }
                distance++;
                foreach (var position in positions)
                {
                    board[position.Row, position.Column] = distance.ToString();
                    passedPositions.Push(position);
                }
             
                currentPosition = positions[0];
            }

            PrintBoard(board);
        }

        public static void PrintBoard(string[,] board)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                for (int col = 0; col < board.GetLength(1); col++)
                {
                    if (board[row, col] == "0")
                    {
                        board[row, col] = "u";
                    }
                    Console.Write(board[row, col]);
                }
                Console.WriteLine();
            }
        }
    }

    public class Position
    {
        public Position(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }

        public int Row { get; set; }

        public int Column { get; set; }

        public bool IsReachable(string[,] board, int row, int column)
        {
            return row >= 0 && row < board.GetLength(0) && column >= 0 && column < board.GetLength(1) && board[row, column] == "0";
        }

        public List<Position> GetReachablePositions(string[,] board)
        {
            var positions = new List<Position>();
            
            if (this.IsReachable(board, this.Row - 1, this.Column))
            {
                positions.Add(new Position(this.Row - 1, this.Column));
            }
            if (this.IsReachable(board, this.Row, this.Column + 1))
            {
                positions.Add(new Position(this.Row, this.Column + 1));
            }
            if (this.IsReachable(board, this.Row + 1, this.Column))
            {
                positions.Add(new Position(this.Row + 1, this.Column));
            }
            if (this.IsReachable(board, this.Row, this.Column - 1))
            {
                positions.Add(new Position(this.Row, this.Column - 1));
            }

            return positions;
        }
    }
}
