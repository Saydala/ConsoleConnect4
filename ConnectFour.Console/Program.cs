using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConnectFour.BLL;

namespace ConnectFour.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Game connect4 = new Game();
            connect4.StartGame();

            while (true)
            {
                int input = int.Parse(System.Console.ReadLine());

                if (connect4.ValidateEntry(input))
                {
                    Player winner = connect4.CheckForWin();
                    if (winner != null)
                    {
                        connect4.DrawBoard();
                        System.Console.WriteLine(winner.PlayerID.ToString() + "win");
                        break;
                    }
                    else
                    {
                        connect4.ChangePlayer();
                        connect4.DrawBoard();
                    }
                }
                else
                {
                    System.Console.WriteLine("Input is invalid");
                }
            }

            System.Console.WriteLine("Game over");
            System.Console.ReadLine();
        }
    }
}
