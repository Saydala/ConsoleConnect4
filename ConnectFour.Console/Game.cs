using ConnectFour.BLL;

namespace ConnectFour.Console
{
    public class Game
    {
        public Player CurrentPlayer { get; set; }
        public Player Player1 { get; set; }
        public Player Player2 { get; set; }
        public Board GameBoard { get; set; }

        public void StartGame()
        {
            Player1 = new Player { PlayerID = 1 };
            Player2 = new Player { PlayerID = 2 };
            CurrentPlayer = Player1;

            GameBoard = new Board(new Cell[5, 5]);

            DrawBoard();
        }

        public void DrawBoard()
        {
            System.Console.Clear();

            string board = "";

            for (int row = 4; row > -1; row--)
            {
                for (int col = 0; col < 5; col++)
                {
                    if (GameBoard.Cells[row, col] != null)
                    {
                        board += GameBoard.Cells[row, col].Coin.
                            DiskPlayer.PlayerID.ToString() + "\t";
                    }
                    else
                    {
                        board += "0\t";
                    }
                }
                board += "\n";
            }

            System.Console.WriteLine(board);
        }

        public void ChangePlayer()
        {
            if (CurrentPlayer == Player1)
            {
                CurrentPlayer = Player2;
            }
            else
            {
                CurrentPlayer = Player1;
            }
        }

        public Player CheckForWin()
        {
            Cell[,] currentBoard = GameBoard.Cells;

            //1. Check winning by rows.
            for (int row = 0; row < 5; row++)
            {
                for (int col = 0; col < 2; col++)
                {
                    if (currentBoard[row, col] != null &&
                        currentBoard[row, col + 1] != null &&
                        currentBoard[row, col + 2] != null &&
                        currentBoard[row, col + 3] != null)
                    {
                        Player winner = currentBoard[row, col].Coin.DiskPlayer;
                        if (currentBoard[row, col + 1].Coin.DiskPlayer == winner &&
                        currentBoard[row, col + 2].Coin.DiskPlayer == winner &&
                        currentBoard[row, col + 3].Coin.DiskPlayer == winner)
                        {
                            return winner;
                        }
                    }
                }
            }

            //2. Check winning by columns.
            for (int col = 0; col < 5; col++)
            {
                for (int row = 0; row < 2; row++)
                {
                    if (currentBoard[row, col] != null &&
                        currentBoard[row + 1, col] != null &&
                        currentBoard[row + 2, col] != null &&
                        currentBoard[row + 3, col] != null)
                    {
                        Player winner = currentBoard[row, col].Coin.DiskPlayer;
                        if (currentBoard[row + 1, col].Coin.DiskPlayer == winner &&
                        currentBoard[row + 2, col].Coin.DiskPlayer == winner &&
                        currentBoard[row + 3, col].Coin.DiskPlayer == winner)
                        {
                            return winner;
                        }
                    }
                }
            }

            //3. Check winning by diagonals from left side.
            int[][] diagonalStartLeft = { 
                new int [] { 0, 0 }, new int [] { 0, 1 },
                new int [] { 1, 0 }, new int [] { 1, 1 }
            };

            for (int i = 0; i < diagonalStartLeft.Length; i++)
            {
                int rowIndex = diagonalStartLeft[i][0];
                int colIndex = diagonalStartLeft[i][1];

                if (currentBoard[rowIndex, colIndex] != null &&
                        currentBoard[rowIndex + 1, colIndex + 1] != null &&
                        currentBoard[rowIndex + 2, colIndex + 2] != null &&
                        currentBoard[rowIndex + 3, colIndex + 3] != null)
                {
                    Player winner = currentBoard[rowIndex, colIndex].Coin.DiskPlayer;
                    if (currentBoard[rowIndex + 1, colIndex + 1].Coin.DiskPlayer == winner &&
                    currentBoard[rowIndex + 2, colIndex + 2].Coin.DiskPlayer == winner &&
                    currentBoard[rowIndex + 3, colIndex + 3].Coin.DiskPlayer == winner)
                    {
                        return winner;
                    }
                }
            }

            //3. Check winning by diagonals from right side.
            int[][] diagonalStartRight = {
                new int [] { 0, 4 }, new int [] { 0, 3 },
                new int [] { 1, 4 }, new int [] { 1, 3 }
            };

            for (int i = 0; i < diagonalStartRight.Length; i++)
            {
                int rowIndex = diagonalStartRight[i][0];
                int colIndex = diagonalStartRight[i][1];

                if (currentBoard[rowIndex, colIndex] != null &&
                        currentBoard[rowIndex + 1, colIndex - 1] != null &&
                        currentBoard[rowIndex + 2, colIndex - 2] != null &&
                        currentBoard[rowIndex + 3, colIndex - 3] != null)
                {
                    Player winner = currentBoard[rowIndex, colIndex].Coin.DiskPlayer;
                    if (currentBoard[rowIndex + 1, colIndex - 1].Coin.DiskPlayer == winner &&
                    currentBoard[rowIndex + 2, colIndex - 2].Coin.DiskPlayer == winner &&
                    currentBoard[rowIndex + 3, colIndex - 3].Coin.DiskPlayer == winner)
                    {
                        return winner;
                    }
                }
            }

            return null;
        }

        public bool ValidateEntry(int column)
        {
            int columnIndex = column - 1;

            if (GameBoard.Cells[4, columnIndex] != null)
            {
                return false;
            }

            for (int row = 0; row < 5; row++)
            {
                if (GameBoard.Cells[row, columnIndex] == null)
                {
                    GameBoard.Cells[row, columnIndex] = new Cell(new Coin(CurrentPlayer));
                    break;
                }
            }

            return true;
        }

    }
}
