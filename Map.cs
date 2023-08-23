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
            MapLocations[2, 1] = "Pit";
        }

        // Making this static for now
        // In the future it would be ideal to make it find any pits then return a bool if you're adjacent to any of them
        public static bool IsAdjacentToPit(int column, int row)
        {
            bool adjacentInColumn = column == 1 & (row == 1 || row == 3);
            bool adjacentInRow = row == 2 && (column == 0 || column == 2);
            return adjacentInColumn || adjacentInRow ? true : false;
        }
    }
}
