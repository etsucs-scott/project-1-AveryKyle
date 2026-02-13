using System;

namespace AdventureGame.Core
{
   
    ///  a weapon class that can be picked up and used to increase an attack damage 
    /// weapons stay in the player inventory best weapon mod
    
    public class Weapon : Item
    {
      
        /// gets the attack mod that this weapon adds to base damage
     
        public int AttackModifier { get; private set; }
        
        /// creates a new weapon with the specific name and attack mod
        
        public Weapon(string name, int attackModifier) 
            : base(name, "You picked up " + name + "! Attack +" + attackModifier)
        {
            AttackModifier = attackModifier;
        }
    }
}