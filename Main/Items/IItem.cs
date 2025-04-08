using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb
{
    public interface IItem
    {
        public string GetBoardRepresentation();
        
        public string GetDataRepresentation();
        
   //     public bool AddToPlayerHands(Player player);
        public bool AddToPlayerHands(Player player, Item item);
        
        
      //  public bool AddToPlayerInventory(Player player);
        public bool AddToPlayerInventory(Player player,Item item);
        
      
        public Item? DeleteItemFromPlayerInventory(Player player, Item item);
      //  public Item? DeleteItemFromPlayerInventory(Player player);
        
        public void PlaceOnField(Field field);
        public string GetName();



    }
}
