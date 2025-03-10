using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public abstract class Item : IItem
    /// dodac w item pole name
    {
        public string name = "No Name";

        public override string ToString() => throw new NotImplementedException();



        public virtual string GetBoardRepresentation() => "-";

        public virtual string GetDataRepresentation(Item item) => item.GetDataRepresentation();
        public virtual string GetDataRepresentation()
        {
            
            int? a = GetDataValues(); 
            if(a != null)
                return GetName() + ": " + a.ToString();
            return GetName();
        
        }

        public virtual int? GetDataValues() => null;
        
        public virtual string GetName() => name;


        public virtual bool MoveToPlayerHands(Player player) => player.AddToFreeHand(this);
        public virtual bool MoveToPlayerHands(Player player, Item item) => player.AddToFreeHand(item);


        public virtual bool AddToPlayerInventory(Player player) => player.AddItemToInventory(this);
        public virtual bool AddToPlayerInventory(Player player, Item item) => player.AddItemToInventory(item);
        
        public virtual void DeletePlayerEffects(Player player) {}
        public virtual void DeletePlayerEffects(Player player, Item item) {}

        public bool PlaceOnField(Field field)
        {
            field.AddItem(this);
            return true;
        }
    }
}
