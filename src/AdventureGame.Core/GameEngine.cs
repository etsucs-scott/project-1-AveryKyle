using System;

namespace AdventureGame.Core
{
  
    /// this is my  game engine that keeps the game running and makes sure i have all the rules
    /// does player movement battles item collection and win or lose conditions with my if statemenets and if else if
    /// this one one of the hardest parts for me trying to get everything to go together this alone took my atleast
    /// a week
  
    public class GameEngine
    {
        
        /// get maze for game
        
        public Maze Maze { get; private set; }
        
        /// gets player character
        
        public Player Player { get; private set; }
        
        /// gets the info if game is over with with a win or loss
      
        public bool IsGameOver { get; private set; }
        
        /// gets if you won
      
        public bool HasWon { get; private set; }
        
        /// gets last message once done
 
        public string LastMessage { get; private set; }
        
        /// this creates a new game with new dementations with using the width and height
        
        public GameEngine(int width, int height)
        {
            Maze = new Maze(width, height);
            
            /// this starts everytime in the top left corner 
            Player = new Player(1, 1);
            /// this message is when you start up the game 
            IsGameOver = false;
            HasWon = false;
            LastMessage = "Welcome to the dungeon! Find the exit (E) to win!";
        }
        
        /// Attempts to move the player in the specified direction this specific section i spent so many hours trying
        /// but i had to use some outside help with this section delta x and y and the change in x with
        /// helping moving it in the right direction i knew how to do the if and if else 
        
        public void MovePlayer(int deltaX, int deltaY)
        {
            // Clear past message
            LastMessage = "";

            // move to next position part i had help with 
            int newX = Player.X + deltaX;
            int newY = Player.Y + deltaY;

            // make sure move was valid
            if (!Maze.IsWalkable(newX, newY))
            {
                LastMessage = "You can't go that way!";
                return;
            }

            // Move player
            Player.X = newX;
            Player.Y = newY;

            // Check what's on the new tile using my titletype 
            Tile currentTile = Maze.GetTile(newX, newY);
            
            if (currentTile.Type == TileType.Monster)
            {
                HandleBattle(currentTile.Monster);
            }
            else if (currentTile.Type == TileType.Weapon)
            {
                HandleWeaponPickup(currentTile.Item as Weapon);
            }
            else if (currentTile.Type == TileType.Potion)
            {
                HandlePotionPickup(currentTile.Item as Potion);
            }
            else if (currentTile.Type == TileType.Exit)
            {
                HandleExit();
            }
        }
        
        /// does the battles with the monster 
        /// player attacks then monster attacks if it still is alive
        /// used some privates so that i can only call on it in here
        /// uses if statements and while
        
        private void HandleBattle(Monster monster)
        {
            string battleLog = "A " + monster.Name + " appears with " + monster.Health + " HP!\n";

            // battle last till someone dies
            while (monster.IsAlive() && Player.IsAlive())
            {
                // player attacks first 
                int playerDamage = Player.GetTotalDamage();
                Player.Attack(monster);
                battleLog += "You attack for " + playerDamage + " damage!\n";
                
                if (!monster.IsAlive())
                {
                    battleLog += "You defeated the " + monster.Name + "!";
                    Maze.ClearTile(Player.X, Player.Y);
                    break;
                }

                // monster responds
                int monsterHealth = monster.Health;
                monster.Attack(Player);
                battleLog += "Monster attacks for 10 damage! Monster HP: " + monsterHealth + "\n";
                
                if (!Player.IsAlive())
                {
                    battleLog += "You have been defeated!";
                    IsGameOver = true;
                    HasWon = false;
                    break;
                }
            }

            LastMessage = battleLog;
        }
        
        /// acts when someone picks up a weapon and adds to inventory
        
        private void HandleWeaponPickup(Weapon weapon)
        {
            Player.AddWeapon(weapon);
            LastMessage = weapon.PickupMessage;
            Maze.ClearTile(Player.X, Player.Y);
        }
        
        /// acts when picking up and using a potion immediately
        
        private void HandlePotionPickup(Potion potion)
        {
            int oldHealth = Player.Health;
            Player.Heal(potion.HealAmount);
            int actualHealing = Player.Health - oldHealth;
            
            LastMessage = potion.PickupMessage + " (Healed " + actualHealing + " HP)";
            Maze.ClearTile(Player.X, Player.Y);
        }
        
        /// acts when u reach the end and win

        private void HandleExit()
        {
            LastMessage = "Congratulations! You found the exit and escaped!";
            IsGameOver = true;
            HasWon = true;
        }
    }
}