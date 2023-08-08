using TheFountainOfObjects;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("The Fountain of Objects");
        Console.WriteLine("=======================");

        GameManager gameManager = new GameManager();

        while(!gameManager.PlayerHasWon())
        {
            PlayerTurn();
        }

        Console.WriteLine($"You are in the room at (Row={gameManager.Player.CurrentLocation[1]}, Column={gameManager.Player.CurrentLocation[0]}).");
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.WriteLine("You Win!");

        void PlayerTurn()
        {
            Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine($"You are in the room at (Row={gameManager.Player.CurrentLocation[1]}, Column={gameManager.Player.CurrentLocation[0]}).");
            if (gameManager.Map.MapLocations[gameManager.Player.CurrentLocation[0], gameManager.Player.CurrentLocation[1]] == "Entrance")
            {
                Console.WriteLine("You see light coming from the cavern entrance.");
            }
            else if (gameManager.Map.MapLocations[gameManager.Player.CurrentLocation[1], gameManager.Player.CurrentLocation[0]] == "FountainOfObjects")
            {
                if (gameManager.FountainEnabled)
                {
                    Console.WriteLine("You hear the rushing waters from the Fountain of Objects. It has been reactivated!");
                }
                else
                {
                    Console.WriteLine("You hear water dripping in this room. The Fountain of Objects is here!");
                }
            }
            HandleUserCommands();
        }

        void HandleUserCommands()
        {
            Console.Write("What do you want to do? ");
            string? userCommand = Console.ReadLine();

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
                Console.WriteLine("Invalid command. Please try again.");
            }
        }
    }
}