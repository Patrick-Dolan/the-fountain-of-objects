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
        public bool PlayerHasWon() => (FountainEnabled && Player.CurrentLocation[0] == 0 && Player.CurrentLocation[1] == 0);
        public void ToggleFountain() => FountainEnabled = !FountainEnabled;
        public void MovePlayer(string direction)
        {
            switch (direction)
            {
                case "move north":
                    if (Player.CurrentLocation[1] - 1 < Map.MinIndex) return;
                    Player.CurrentLocation[1]--;
                    break;
                case "move south":
                    if (Player.CurrentLocation[1] + 1 > Map.MaxIndex) return;
                    Player.CurrentLocation[1]++;
                    break;
                case "move east":
                    if (Player.CurrentLocation[0] - 1 < Map.MinIndex) return;
                    Player.CurrentLocation[0]++;
                    break;
                case "move west":
                    if (Player.CurrentLocation[0] + 1 > Map.MaxIndex) return;
                    Player.CurrentLocation[0]--;
                    break;
                default:
                    Console.WriteLine("Error: GameManager MovePlayer method invalid input.");
                    break;
            }
        }
    }
}
