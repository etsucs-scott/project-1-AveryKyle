using System;
using AdventureGame.Core;

namespace AdventureGame.Console
{
    /// <summary>
    /// Main console application that handles user input and display.
    /// All game logic lives in AdventureGame.Core.
    /// </summary>
    class Program
    {
        
        /// entry point for maze
        static void Main(string[] args)
        {
            // makes a new game with 12x12 maze
            GameEngine game = new GameEngine(12, 12);

            // main loop 
            while (!game.IsGameOver)
            {
                // clear and redo everything
                System.Console.Clear();
                DisplayGame(game);

                // get input
                ConsoleKeyInfo keyInfo = System.Console.ReadKey(true);
                ProcessInput(keyInfo, game);
            }

            // game over screen
            System.Console.Clear();
            DisplayGame(game);
            
            System.Console.WriteLine();
            if (game.HasWon)
            {
                System.Console.WriteLine("*** YOU WIN! ***");
            }
            else
            {
                System.Console.WriteLine("*** GAME OVER ***");
            }
            
            System.Console.WriteLine("Press any key to exit...");
            System.Console.ReadKey();
        }
        
        /// displays the entire game state maze player stats messages
        static void DisplayGame(GameEngine game)
        {
            // display stats
            System.Console.WriteLine("Health: " + game.Player.Health + "/150 | Attack: " + game.Player.GetTotalDamage());
            System.Console.WriteLine("Controls: W=Up, A=Left, S=Down, D=Right");
            System.Console.WriteLine();

            // display any last messages
            if (!string.IsNullOrEmpty(game.LastMessage))
            {
                System.Console.WriteLine(game.LastMessage);
                System.Console.WriteLine();
            }

            // display maze
            DisplayMaze(game);

            // display legend
            System.Console.WriteLine();
            System.Console.WriteLine("Legend: @ = You, # = Wall, M = Monster, W = Weapon, P = Potion, E = Exit");
        }

        
        /// renders the maze grid with all tiles and the player using if else 
        static void DisplayMaze(GameEngine game)
        {
            for (int y = 0; y < game.Maze.Height; y++)
            {
                for (int x = 0; x < game.Maze.Width; x++)
                {
                    // makes sure player on tile
                    if (x == game.Player.X && y == game.Player.Y)
                    {
                        System.Console.Write("@ ");
                    }
                    else
                    {
                        // display the tile spot
                        Tile tile = game.Maze.GetTile(x, y);
                        char symbol = GetTileSymbol(tile);
                        System.Console.Write(symbol + " ");
                    }
                }
                System.Console.WriteLine();
            }
        }
        
        /// gets the display symbol for a tile based on its type using a if else if statement 
        static char GetTileSymbol(Tile tile)
        {
            if (tile.Type == TileType.Wall)
            {
                return '#';
            }
            else if (tile.Type == TileType.Monster)
            {
                return 'M';
            }
            else if (tile.Type == TileType.Weapon)
            {
                return 'W';
            }
            else if (tile.Type == TileType.Potion)
            {
                return 'P';
            }
            else if (tile.Type == TileType.Exit)
            {
                return 'E';
            }
            else
            {
                return '.';
            }
        }
        
        /// process ur keyboard input and calls the game methods using if else if 
   
        static void ProcessInput(ConsoleKeyInfo keyInfo, GameEngine game)
        {
            /// i mapped wasd to the movement i had some help on the internet with uparrow and downarrow command
            /// i didnt know how to do that 
            if (keyInfo.Key == ConsoleKey.W || keyInfo.Key == ConsoleKey.UpArrow)
            {
                game.MovePlayer(0, -1);
            }
            else if (keyInfo.Key == ConsoleKey.S || keyInfo.Key == ConsoleKey.DownArrow)
            {
                game.MovePlayer(0, 1);
            }
            else if (keyInfo.Key == ConsoleKey.A || keyInfo.Key == ConsoleKey.LeftArrow)
            {
                game.MovePlayer(-1, 0);
            }
            else if (keyInfo.Key == ConsoleKey.D || keyInfo.Key == ConsoleKey.RightArrow)
            {
                game.MovePlayer(1, 0);
            }
        }
    }
}