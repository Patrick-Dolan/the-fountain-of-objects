using TheFountainOfObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("The Fountain of Objects");
        Console.WriteLine("=======================");

        GameManager gameManager = new GameManager();
        
        // Intro Text
        Console.ForegroundColor = ConsoleColor.Magenta;
        Console.WriteLine("You have entered the cave containing the Fountain of Objects.");
        Console.WriteLine("Unnatural darkness pervades the caverns, preventing both natural and human-made light.");
        Console.WriteLine("You must navigate the caverns in the dark, relying on your sense of smell and hearing");
        Console.WriteLine("to figure out what room you are in and what dangers lurk nearby.");
        Console.ForegroundColor = ConsoleColor.White;


        while (!gameManager.PlayerHasWon())
        {
            PlayerTurn();
        }

        Console.WriteLine($"You are in the room at (Row={gameManager.Player.CurrentLocation[1]}, Column={gameManager.Player.CurrentLocation[0]}).");
        Console.ForegroundColor= ConsoleColor.Magenta;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.ForegroundColor= ConsoleColor.White;
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("You Win!");
        Console.ForegroundColor = ConsoleColor.White;

        void PlayerTurn()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={gameManager.Player.CurrentLocation[1]}, Column={gameManager.Player.CurrentLocation[0]}).");
            if (gameManager.Map.MapLocations[gameManager.Player.CurrentLocation[0], gameManager.Player.CurrentLocation[1]] == "Entrance")
            {
                Console.ForegroundColor= ConsoleColor.Yellow;
                Console.WriteLine("You see light coming from outside the cavern. This is the entrance.");
                Console.ForegroundColor= ConsoleColor.White;
            }
            else if (gameManager.Map.MapLocations[gameManager.Player.CurrentLocation[1], gameManager.Player.CurrentLocation[0]] == "FountainOfObjects")
            {
                Console.ForegroundColor= ConsoleColor.Blue;
                if (gameManager.FountainEnabled)
                {
                    Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                }
                else
                {
                    Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                }
                Console.ForegroundColor= ConsoleColor.White;
            }
            HandleUserCommands();
        }

        void HandleUserCommands()
        {
            Console.Write("What do you want to do? ");
            Console.ForegroundColor = ConsoleColor.Cyan;
            string? userCommand = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (userCommand == null) return;

            if (gameManager.ValidCommands.Contains(userCommand))
            {
                if (userCommand == "enable fountain")
                {
                    gameManager.FountainEnabled = true;
                } 
                else
                {
                    gameManager.MovePlayer(userCommand);
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid command. Please try again.");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}