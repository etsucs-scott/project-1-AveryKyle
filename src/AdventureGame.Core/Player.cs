using System;

namespace AdventureGame.Core
{
    
    /// this the player character controlled by the user that tracks health inventory and position
    
    public class Player : ICharacter
    {
        // constants for player health and damage 
        private const int StartingHealth = 100;
        private const int MaxHealth = 150;
        private const int BaseDamage = 10;

        
        /// gets or sets the player's current health 
        
        public int Health { get; set; }
        
        /// gets the player's name.
        
        public string Name { get; private set; }
        
        /// gets the player's current X positon
        
        public int X { get; set; }
        
        /// gets the player's current Y position 
    
        public int Y { get; set; }
        
        /// used an array of weapons that player collected
        
        private Weapon[] inventory;
        
        /// Current number of weapons in inventory.
      
        private int weaponCount;
        
        /// creates new player with starting health and position using x and y 
       
        public Player(int startX, int startY)
        {
            Name = "Hero";
            Health = StartingHealth;
            X = startX;
            Y = startY;
            inventory = new Weapon[100]; // Max 100 weapons
            weaponCount = 0;
        }
        
        /// adds a weapon to the player inventory 
        
        public void AddWeapon(Weapon weapon)
        {
            if (weaponCount < inventory.Length)
            {
                inventory[weaponCount] = weapon;
                weaponCount++;
            }
        }
        
        /// Heal player by a specific amount only up to max health
   
        public void Heal(int amount)
        {
            Health += amount;
            // caps health 
            if (Health > MaxHealth)
            {
                Health = MaxHealth;
            }
        }
        
        /// gets the best mod from all weapons in inventory and then returns 0 if you have no weapons using if 
        
        private int GetBestWeaponModifier()
        {
            if (weaponCount == 0)
            {
                return 0;
            }
            
            int bestModifier = 0;
            for (int i = 0; i < weaponCount; i++)
            {
                if (inventory[i].AttackModifier > bestModifier)
                {
                    bestModifier = inventory[i].AttackModifier;
                }
            }
            return bestModifier;
        }
        
        /// attacks another character with base damage plus best weapon mod
        
        public void Attack(ICharacter target)
        {
            int totalDamage = BaseDamage + GetBestWeaponModifier();
            target.TakeDamage(totalDamage);
        }
        
        /// reduces health by the damage amount using if 
      
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        
        /// checks if the player is still alive using a bool
      
        public bool IsAlive()
        {
            return Health > 0;
        }
        
        /// gets the total damage the player can do
        
        public int GetTotalDamage()
        {
            return BaseDamage + GetBestWeaponModifier();
        }
    }
}