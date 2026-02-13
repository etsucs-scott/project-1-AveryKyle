using System;

namespace AdventureGame.Core
{
 
    /// this is the monster that player has to fight and i give the monster random health and deal a fixed damage
   
    public class Monster : ICharacter
    {
        // some constants that the monsters must have 
        private const int MinHealth = 30;
        private const int MaxHealth = 50;
        private const int MonsterDamage = 10;
        
        /// Gets or sets the monster's current health
      
        public int Health { get; set; }
        
        /// Gets the monster's name.
        
        public string Name { get; private set; }
        
        /// i create a new monster with random health
        
        public Monster(Random random)
        {
            // generate a random health between min and max
            Health = random.Next(MinHealth, MaxHealth + 1);
            Name = "Monster";
        }
        
        /// attacks another character doing fixed monster damage using the parameter target being attacked
        
        public void Attack(ICharacter target)
        {
            target.TakeDamage(MonsterDamage);
        }
        
        /// drops health by amount damage done using damage paramter and if statement
        
        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
        
        /// sees if monster still alive
    
        public bool IsAlive()
        {
            return Health > 0;
        }
    }
}