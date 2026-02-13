using System;

namespace AdventureGame.Core
{
    
    /// TileType enum to show the different types of tiles that can exist
    /// I had to look up this enum and this really helped me so much and fixed so many problems in my code
    /// helped me define my fixed set constant names think we should talk about this in class this is a great thing

    public enum TileType
    {
        /// empty, walk tile
        
        Empty,
        
        /// solid wall that blocks movement
       
        Wall,
        
        /// tile containing a monster 
        
        Monster,
        
        /// tile containing a weapon 
       
        Weapon,
        
        /// tile containing a potion 
        Potion,
        
        ///  exit tile  wins game
  
        Exit
    }
}