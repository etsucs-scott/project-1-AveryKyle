using System;

namespace AdventureGame.Core
{
    /// item names and a pickup message when they go over it 
    
    public class Item
    {
        /// gets name of item
        
        public string Name { get; protected set; }
        
        /// gets the message to pop up when item picked up
       
        public string PickupMessage { get; protected set; }
        
        ///  I had to look up this protected because i didnt want anything from my other subclasses to call this
        /// created an item with a name and pickup message
        
        protected Item(string name, string pickupMessage)
        {
            Name = name;
            PickupMessage = pickupMessage;
        }
    }
}