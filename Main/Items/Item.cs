using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb
{
    public abstract class Item : IItem
    {
        public string name = "No Name";

        public override string ToString() => throw new NotImplementedException();



        public virtual string GetBoardRepresentation() => "-";

        public virtual string GetDataRepresentation() => GetName();

        public virtual string GetName() => name;


        public virtual bool AddToPlayerHands(Player player) => player.AddToFreeHand(this);
        public virtual bool AddToPlayerHands(Player player, Item item = null) => player.AddToFreeHand(item);


        public virtual bool AddToPlayerInventory(Player player) => player.AddItemToInventory(this);
        public virtual bool AddToPlayerInventory(Player player, Item item) => player.AddItemToInventory(item);
        
        public virtual  void PlaceOnField(Field field)=> field.AddItem(this);

        public virtual Item? DeleteItemFromPlayerInventory(Player player, Item item) => player.DeleteItemFromInventory();
        public virtual Item? DeleteItemFromPlayerInventory(Player player) => player.DeleteItemFromInventory();
    }
}
