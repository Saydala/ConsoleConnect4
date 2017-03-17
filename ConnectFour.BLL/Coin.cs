namespace ConnectFour.BLL
{
    public class Coin
    {
        public string Color { get; set; }

        public Player DiskPlayer { get; set; }

        public Coin(Player p)
        {
            this.DiskPlayer = p;
        }

    }
}
