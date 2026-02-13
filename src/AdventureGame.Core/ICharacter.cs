using System;
namespace AdventureGame.Core
{
    /// this is my interface of characters players and monsters they can attack take damage
    public interface ICharacter
    {
        
        /// get or set the health 
        int Health { get; set; }
        
        /// get name character
        string Name { get; }
        
        /// attacks other character does damage to them
        void Attack(ICharacter target);
        
        /// drops the  health by the damage amount taken
        void TakeDamage(int damage);

    
        /// makes sure they still alive this bool tells it if the health is greater than 0 true less than false 
        bool IsAlive();
    }
}