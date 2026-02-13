using System;

namespace AdventureGame.Core
{
    /// the game maze that has random maze with walls items monsters and a exit
    
    public class Maze
    {
        
        /// gets width of maze
        
        public int Width { get; private set; }
        
        /// gets height of the maze
        
        public int Height { get; private set; }
        
        /// array of tiles of maze
        
        private Tile[,] tiles;

   
        /// random number generator for maze 
      
        private Random random;

     
        /// creats a maze with specific demensions using a width and height mimimum of ten
        
        public Maze(int width, int height)
        {
            /// makes sure the width and height are 10
            
            Width = Math.Max(width, 10);
            Height = Math.Max(height, 10);
            
            tiles = new Tile[Width, Height];
            random = new Random();
            
            GenerateMaze();
        }
        
        /// makes the layout of the maze with walls items monsters exit
        /// and also makes a border of walls and also makes random walls so its an maze
        
        private void GenerateMaze()
        {
            // tells it all the tiles are empty using a for
            
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    tiles[x, y] = new Tile(TileType.Empty);
                }
            }

            // creates the border walls
            
            for (int x = 0; x < Width; x++)
            {
                tiles[x, 0] = new Tile(TileType.Wall);
                tiles[x, Height - 1] = new Tile(TileType.Wall);
            }
            for (int y = 0; y < Height; y++)
            {
                tiles[0, y] = new Tile(TileType.Wall);
                tiles[Width - 1, y] = new Tile(TileType.Wall);
            }

            // adds random internal walls i did about 15%
            for (int x = 1; x < Width - 1; x++)
            {
                for (int y = 1; y < Height - 1; y++)
                {
                    if (random.NextDouble() < 0.15)
                    {
                        tiles[x, y] = new Tile(TileType.Wall);
                    }
                }
            }

            // places an exit on the bottom right but isnt on the wall 
            int exitX = Width - 2;
            int exitY = Height - 2;
            tiles[exitX, exitY] = new Tile(TileType.Exit);

            // places random amount of weapons of 3-5 using for
            int weaponCount = random.Next(3, 6);
            for (int i = 0; i < weaponCount; i++)
            {
                PlaceItemRandomly(CreateRandomWeapon());
            }

            // places 4-6 potions randomly using for 
            int potionCount = random.Next(4, 7);
            for (int i = 0; i < potionCount; i++)
            {
                PlaceItemRandomly(new Potion(20));
            }

            // places 5-8 monsters using for
            int monsterCount = random.Next(5, 9);
            for (int i = 0; i < monsterCount; i++)
            {
                PlaceMonsterRandomly();
            }
        }
        
        /// creates a weapon with random modifier between 3-10
        
        private Weapon CreateRandomWeapon()
        {
            int modifier = random.Next(3, 11);
            string[] weaponNames = { "Sword", "Axe", "Dagger", "Mace", "Spear" };
            string name = weaponNames[random.Next(weaponNames.Length)];
            return new Weapon(name, modifier);
        }
        
        /// places an item on a random tile 
        
        private void PlaceItemRandomly(Item item)
        {
            int x, y;
            int attempts = 0;
            
          /// finding a empty tile had to use some help to find a empty tile 
            do
            {
                x = random.Next(1, Width - 1);
                y = random.Next(1, Height - 1);
                attempts++;
            } while (tiles[x, y].Type != TileType.Empty && attempts < 100);

            // only put it on the tile if its empty using a if else if 
            if (tiles[x, y].Type == TileType.Empty)
            {
                tiles[x, y].Item = item;
                
                if (item is Weapon)
                {
                    tiles[x, y].Type = TileType.Weapon;
                }
                else if (item is Potion)
                {
                    tiles[x, y].Type = TileType.Potion;
                }
            }
        }
        
        /// puts a monster on a random tile

        private void PlaceMonsterRandomly()
        {
            int x, y;
            int attempts = 0;
            
           /// try to find a empty tile using a do while 
            do
            {
                x = random.Next(1, Width - 1);
                y = random.Next(1, Height - 1);
                attempts++;
            } while (tiles[x, y].Type != TileType.Empty && attempts < 100);

            // only use it if the tile is empty 
            if (tiles[x, y].Type == TileType.Empty)
            {
                tiles[x, y].Monster = new Monster(random);
                tiles[x, y].Type = TileType.Monster;
            }
        }
        
        /// gets the tile in the right spot using x y and then i null it if is out of bounds using a if 
        
        public Tile GetTile(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return null;
            }
            return tiles[x, y];
        }
        
        /// checking to see if the coordinate are valid returns true if it in bounds and not a wall
      
        public bool IsWalkable(int x, int y)
        {
            if (x < 0 || x >= Width || y < 0 || y >= Height)
            {
                return false;
            }
            return tiles[x, y].Type != TileType.Wall;
        }
        
        /// clears that tile after the monster is defeated or item is picked up
  
        public void ClearTile(int x, int y)
        {
            if (x >= 0 && x < Width && y >= 0 && y < Height)
            {
                tiles[x, y].Type = TileType.Empty;
                tiles[x, y].Item = null;
                tiles[x, y].Monster = null;
            }
        }
    }
}