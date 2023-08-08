namespace TheFountainOfObjects
{
    internal class GameManager
    {
        public Player Player { get; set; } = new Player();
        public Map Map { get; } = new Map();
        public bool Winner { get; set; } = false;
        public bool FountainEnabled { get; set; } = false;
        public string[] ValidCommands { get; set; } = new string[] { "enable fountain", "disable fountain", "move north", "move east", "move south", "move west", "help" };
        public GameManager() { }
        public bool PlayerHasWon() => (FountainEnabled && Player.CurrentLocation[0] == 0 && Player.CurrentLocation[1] == 0);
        public void MovePlayer(string direction)
        {
            if (direction == null) return;
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
                    if (Player.CurrentLocation[0] + 1 > Map.MaxIndex) return;
                    Player.CurrentLocation[0]++;
                    break;
                case "move west":
                    if (Player.CurrentLocation[0] - 1 < Map.MinIndex) return;
                    Player.CurrentLocation[0]--;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: GameManager MovePlayer method invalid input.");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
    }
}
