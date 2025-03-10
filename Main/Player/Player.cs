using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class Player
    {
        Field field;
        Queue<Item> inventory = new Queue<Item>();

        private Item? lefthand;
        private Item? righthand;


        public Dictionary<string,Attribute> attributes;
        
        private AAggression aggression = new AAggression();
        private AHealth health = new AHealth();
        private ALuck luck = new ALuck();
        private AStrength strength = new AStrength();
        private AWisdom wisdom = new AWisdom();

        private int coins = 0;
        private int gold = 0;
        
        public Player()
        {
            attributes = new Dictionary<string, Attribute>();
            attributes.Add("Aggression",aggression);
            attributes.Add("Health",health);
            attributes.Add("Luck",luck);
            attributes.Add("Strength",strength);
            attributes.Add("Wisdom",wisdom);
        }
        
        public void ChangeField(Field field) => this.field = field;

        public IEnumerable<string> GetAttributesData()
        {
            yield return "Attributes: ";
            foreach(var attribute in attributes.Values)
                yield return attribute.GetData();

        }

        public IEnumerable<string> GetInventoryString()
        {
            int i = 0;
            yield return "Inventory: ";
            foreach (var item in inventory)
                yield return  item.GetDataRepresentation();
           
        }

        public Queue<Item> GetInventory() => inventory;
        public IEnumerable<string> GetHandsString()
        {
            yield return "Right Hand: " + righthand?.GetDataRepresentation();
            yield return "Left Hand: " + lefthand?.GetDataRepresentation();
        }
        
        
        public Item? DeleteItemFromInventory()
        {
            if (inventory.Count > 0)
            {
                Item ret = inventory.Dequeue();
                ret.DeletePlayerEffects(this);
                return ret;
            }

            return null;
        }

        public bool AddItemToInventory(Item? item)
        {
            if(item != null) inventory.Enqueue(item);
            return true;
        }

        public void ScrollInventory()
        {
            if (inventory.Count > 0)
            {
                Item item = inventory.Dequeue();
                inventory.Enqueue(item);
            }
        }

        
        /// /////////
        public bool AddToFreeHand(Item item)
        {
            if (righthand == null)
            {
                righthand = item;
                return true;
            }
            if (lefthand == null)
            {
                lefthand = item;
                return true;
            }
            return false;
        }

        public bool AddToBothHands(Item item)
        {
            if (lefthand == null && righthand == null)
            {
                lefthand = righthand = item;
                return true;
            }
            return false;
        }

        public Item? PeekItemInventory()
        {
            if (inventory.Count > 0)
                return inventory.Peek();
            return null;   
        }

        public Item? DeleteItemFromRightHand()
        {
            Item? ret = righthand;
            if (righthand == lefthand)
                lefthand = null;
            righthand = null;
            return ret;
        }
        public Item? DeleteItemFromLeftHand()
        {
            Item? ret = lefthand;
            if (righthand == lefthand)
                righthand = null;
            lefthand = null;
            return ret;
        }
        
        public void AddCoin()=> coins++;
        public void AddGold()=> gold++;

        public IEnumerable<string> GetAssets()
        {
            yield return "Assets";
            yield return "Coins: " + coins;
            yield return "Gold: " + gold; 
        }
        /*
        Board b;

        Field f;
        void GetItems()
        {
            f.GetItems
        }

        void UpdateAvaiableItems()
        {
             f.GetItems(this);
        }

        void UpdatdeFieldItems()
        {
            b.UpdateFieldItens(this, List<Item> items)
        }
        */
    }
}
