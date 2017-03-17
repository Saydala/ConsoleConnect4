namespace ConnectFour.BLL
{
    public class Cell
    {
        public Coin Coin { get; set; }

        public Cell(Coin c)
        {
            this.Coin = c;
        }
    }
}
