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
        Console.WriteLine("You enter the Cavern of Objects, a maze of rooms filled with dangerous pits, in search of the Fountain of Objects.");
        Console.WriteLine("Unnatural darkness pervades the caverns, preventing both natural and human-made light. The only light you see is in the entrance.");
        Console.WriteLine("You must navigate the caverns in the dark, relying on your other senses");
        Console.WriteLine("Find the Fountain of Objects, activate it, and return to the entrance.");
        Console.ForegroundColor = ConsoleColor.White;

        // Game loop
        while (!gameManager.PlayerHasWon())
        {
            PlayerTurn();
        }

        // Game Win
        Console.WriteLine($"You are in the room at (Row={gameManager.Player.CurrentLocation[1]}, Column={gameManager.Player.CurrentLocation[0]}).");
        Console.ForegroundColor= ConsoleColor.Magenta;
        Console.WriteLine("The Fountain of Objects has been reactivated, and you have escaped with your life!");
        Console.ForegroundColor= ConsoleColor.White;
        Console.ForegroundColor= ConsoleColor.Green;
        Console.WriteLine("You Win!");
        Console.ForegroundColor = ConsoleColor.White;

        // Methods
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

            bool PlayerinFountainChamber = gameManager.Map.MapLocations[gameManager.Player.CurrentLocation[1], gameManager.Player.CurrentLocation[0]] == "FountainOfObjects";

            if (gameManager.ValidCommands.Contains(userCommand))
            {
                if (userCommand == "help")
                {
                    DisplayHelpCommands();
                }
                else if (userCommand == "enable fountain" && PlayerinFountainChamber)
                {
                    gameManager.FountainEnabled = true;
                }
                else if (userCommand == "disable fountain" && PlayerinFountainChamber)
                {
                    gameManager.FountainEnabled = false;
                }
                else if (userCommand == "enable fountain" || userCommand == "disable fountain")
                {
                    Console.WriteLine("The fountain is not in this room so you can't enable or disable it.");
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

        void DisplayHelpCommands()
        {
            Console.WriteLine("======================================================================================================");
            Console.WriteLine("Commands");
            Console.WriteLine("------------------------------------------------------------------------------------------------------");
            Console.WriteLine("'help' - Will list all commands available.");
            Console.WriteLine("'enable fountain' - Will enable the Fountain of Object if you are in room where it is located.");
            Console.WriteLine("'disable fountain' - Will disable the Fountain of Object if you are in room where it is located.");
            Console.WriteLine("'move north' - Will move you up one in the current column you are in.");
            Console.WriteLine("'move south' - Will move you down one in the current column you are in.");
            Console.WriteLine("'move east' - Will move you up one in the current row you are in.");
            Console.WriteLine("'move west' - Will move you down one in the current row you are in.");
            Console.WriteLine("======================================================================================================");
        }
    }
}