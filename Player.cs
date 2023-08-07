namespace TheFountainOfObjects
{
    internal class Player
    {
        public string Name { get; set; } = "Player One";
        public int[] CurrentLocation { get; set; } = new int[2] { 0, 0 };
        public Player() { }
        public Player(string name)
        {
            Name = name;
        }
    }
}
