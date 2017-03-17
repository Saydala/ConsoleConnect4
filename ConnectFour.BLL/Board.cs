namespace ConnectFour.BLL
{
    public class Board
    {
        public Board(Cell[,] cells)
        {
            this.Cells = cells;
        }

        public Cell[,] Cells { get; set; }

    }
}
