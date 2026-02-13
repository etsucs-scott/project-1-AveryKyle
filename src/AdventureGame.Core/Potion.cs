using System;

namespace AdventureGame.Core
{
    
    /// potion class that has a healing potion that restores health when picked up used immediately and leaves inventory
    
    public class Potion : Item
    {
        /// gets the amount of health this potion restores
      
        public int HealAmount { get; private set; }
        
        /// Creates a new potion with the specific heal amount
 
        public Potion(int healAmount) 
            : base("Health Potion", "You used a potion and restored " + healAmount + " HP!")
        {
            HealAmount = healAmount;
        }
    }
}