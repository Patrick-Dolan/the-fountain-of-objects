namespace TheFountainOfObjects
{
    internal class GameManager
    {
        public Player Player { get; set; } = new Player();
        public Map Map { get; } = new Map();
        public bool Winner { get; set; } = false;
        public bool FountainEnabled { get; set; } = false;
        public GameManager(Player player)
        {
            Player = player;
        }
    }
}
