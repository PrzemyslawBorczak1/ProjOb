using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Field  ///////// do naprawy odwolania raz po itemAmount a raz po count
    {
        Queue<Item> items;
        int itemsAmount = 0;

        Player? player;

        RoomType roomType;

        public Field(RoomType roomType)
        {
            this.roomType = roomType;
            items  = new Queue<Item>();
            if(roomType == RoomType.Items)
            {
                items.Enqueue(new Sword(0));
                itemsAmount++;
            }
        }
        public Field() : this(RoomType.Empty) { }

        public RoomType GetFieldType() => roomType;
        public void SetRoomType(RoomType roomType) => this.roomType = roomType;
        public void AddPlayer(Player player)
        {
            this.player = player;
            roomType = RoomType.Player;
        }
        public RoomType GetRoomType() => roomType;
        public void DeletePlayer() {
            player = null;
            roomType = (items.Count == 0) ? RoomType.Empty : RoomType.Items;  ///  kiepskie
        }
        public (ConsoleColor, string) PrintData()
        {
            string ret = (roomType == RoomType.Items) ?
                items.First().GetBoardRepresentation() : ((char)roomType).ToString();
            
            
            ConsoleColor color = (roomType == RoomType.Player) ?
                color = ConsoleColor.Red : ConsoleColor.Black;
            
                
            return (color, ret);
        }
        
        public void AddItem(Item? item)
        {
            if (item != null)
            {
                items.Enqueue(item);
                roomType = RoomType.Items;
            }
        }


        public IEnumerable<string> GetItemsNames()
        {
            yield return "Items on the field: ";
            foreach (Item item in items)
                yield return item.GetDataRepresentation();
        }

        public void ScrollItems()
        {
            if (items.Count > 0)
            {
                Item item = items.Dequeue();
                items.Enqueue(item);
            }
        }

        public Item? PeekItemField()
        {
            if (items.Count > 0)
                return items.Peek();
            return null;
        }
        
        public Item? DeleteItem()
        {
            if(items.Count == 1)
                roomType = RoomType.Empty;
            if(items.Count > 0)
                return items.Dequeue();
            return null;
        }

        public Queue<Item> GetItems() => items;
        public int GetItemsAmount() => itemsAmount;
        public Player? GetPlayer() => player;
    }


}
