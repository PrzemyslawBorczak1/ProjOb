using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public interface IItem
    {
        public string GetBoardRepresentation();
        
        public string GetDataRepresentation();
        public string GetDataRepresentation(Item item);

        public int? GetDataValues();
        
        public bool MoveToPlayerHands(Player player);
        public bool MoveToPlayerHands(Player player, Item item);
        
        public bool AddToPlayerInventory(Player player);
        public bool AddToPlayerInventory(Player player,Item item);
        
        public bool PlaceOnField(Field field);

    }
}
