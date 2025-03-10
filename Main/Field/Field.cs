
namespace Main
{
    public class Field
    {
        private Queue<Item> items;// dodac pole item amount i getter
        private Player? player;

        private RoomType roomType;

        public Field(RoomType roomType)
        {
            this.roomType = roomType;
            items  = new Queue<Item>();
            if(roomType == RoomType.Items)
            {
                items.Enqueue(new Sword(0));
            }
        }
        public Field() : this(RoomType.Empty) { }
        public bool CanHavePlayer() => roomType != RoomType.Wall;

        public RoomType GetFieldType() => roomType;
        public void SetRoomType(RoomType roomType) => this.roomType = roomType;
        public void AddPlayer(Player player)
        {
            this.player = player;
            roomType = RoomType.Player;
        }
        public RoomType GetRoomType() => roomType;
        
        
        // ///  kiepskie
        public void DeletePlayer() {
            player = null;
            roomType = (items.Count == 0) ? RoomType.Empty : RoomType.Items;
        }
        
        // do poprawy
        public (ConsoleColor, string) PrintData()
        {
            string ret = (roomType == RoomType.Items) ?
                items.First().GetBoardRepresentation() : ((char)roomType).ToString();
            
            ConsoleColor color = (roomType == RoomType.Player) ?
                color = ConsoleColor.Red : ConsoleColor.Black;
            
            return (color, ret);
        }
        
        // do poprawy
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
            foreach (var item in items)
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
        public int GetItemsAmount() => items.Count;
        public Player? GetPlayer() => player;
    }


}
