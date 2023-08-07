namespace TheFountainOfObjects
{
    internal class Map
    {
        public string[,] MapLocations { get; set; } = new string[4, 4];
        public int MaxIndex { get; } = 3;
        public int MinIndex { get; } = 0;
        public Map() 
        {
            MapLocations[0, 0] = "Entrance";
            MapLocations[0, 2] = "FountainOfObjects";
        }
    }
}
