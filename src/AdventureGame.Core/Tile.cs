using System;

namespace AdventureGame.Core
{
    /// Represents a single tile in the maze and each tile has a type that may have a item or monste
    
    public class Tile
    {
        
        /// gets or sets type of tile
      
        public TileType Type { get; set; }
        
        /// gets or sets the item on tile null if none
        
        public Item Item { get; set; }
        
        /// gets or sets the monster on this tile null if none
        
        public Monster Monster { get; set; }
        
        /// creates a new empty tile
        
        public Tile()
        {
            Type = TileType.Empty;
            Item = null;
            Monster = null;
        }
        
        /// Creates a new tile with the specific type
     
        public Tile(TileType type)
        {
            Type = type;
            Item = null;
            Monster = null;
        }
    }
}