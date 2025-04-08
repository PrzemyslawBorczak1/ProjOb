
namespace ProjOb
{
    public class Field
    {
        private Queue<Item>? items;// dodac pole item amount i getter
        private Player? player;

        private RoomStatus roomStatus;
        private Enemy? enemy;

        public Field(ERoomType eRoomType)
        {
            this.roomStatus = new RoomStatus(eRoomType);
            items  = new Queue<Item>();
        }

        public bool CanHaveItems() => roomStatus.CanHaveItems();
        public Field() : this(ERoomType.Empty) { }
        public bool CanHavePlayer() => roomStatus.CanHavePlayer();
        
        public void ChangeRoomStatus(ERoomType roomStatus) => this.roomStatus = new RoomStatus(roomStatus);

     //   public RoomType GetFieldType() => roomType;
     //   public void SetRoomType(RoomType roomType) => this.roomType = roomType;
     public void AddPlayer(Player player) => this.player = player;
     
     ///   public RoomStatus GetRoomType() => roomStatus;
        
        
        // ///  kiepskie
        public void DeletePlayer() => this.player = null;
        
        // do poprawy
        
        public bool HasPlayer() => this.player != null;
        public (ConsoleColor, string) PrintData()
        {
            
            if (HasPlayer())
            {
                return (ConsoleColor.Red,"P");
            }
            
            
            
            ConsoleColor color = ConsoleColor.Gray;
            
            string? rep = roomStatus.RoomRepresentation(); 
            if (rep != null)
                return (color, rep);

            if (HasEnemy())
                return (enemy.GetColor(), enemy.GetBoardRepresentation());
            
            
            if(items != null && items.Count > 0)
                return (color, items.First().GetBoardRepresentation());
            
            return (color, " ");
        }

        public bool HasEnemy() => enemy != null;

        public void AddEnemy(Enemy enemy) => this.enemy = enemy;

        public bool CanHaveEnemy() => roomStatus.CanHaveEnemy();

        public Enemy? GetEnemy() => enemy;
        
        public bool HasItems() => items != null && items.Count > 0;
        
        // do poprawy
        public void AddItem(Item? item)
        {
            if (item != null)
            {
                items.Enqueue(item);
                //roomStatus = RoomStatus.Items;
            }
        }


        public IEnumerable<string> GetItemsNames()
        {
            if(items == null)
                yield break;
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
            // if(items.Count == 1)
            //     roomStatus = RoomStatus.Empty;
            //
            if(items.Count > 0)
                return items.Dequeue();
            return null;
        }

        public Queue<Item> GetItems() => items;
        public int GetItemsAmount() => items.Count;
        public Player? GetPlayer() => player;
    }


}
