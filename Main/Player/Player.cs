using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb
{
    public class Player
    {
        Field? field;
        List<Item> inventory = new List<Item>();
        private List<Potion> potions = new List<Potion>();

        private Item? lefthand;
        private Item? righthand;


        public Dictionary<AttributeType,Attribute> attributes;
        
        private AAggression aggression = new AAggression();
        private AHealth health = new AHealth();
        private ALuck luck = new ALuck();
        private AStrength strength = new AStrength();
        private AWisdom wisdom = new AWisdom();

        private int coins = 0;
        private int gold = 0;
        
        public Player()
        {
            attributes = new Dictionary<AttributeType, Attribute>();
            attributes.Add(AttributeType.Aggression,aggression);
            attributes.Add(AttributeType.Health,health);
            attributes.Add(AttributeType.Luck,luck);
            attributes.Add(AttributeType.Strength,strength);
            attributes.Add(AttributeType.Wisdom,wisdom);
        }
        
        public void ChangeField(Field field) => this.field = field;

        public IEnumerable<string> GetAttributesData()
        {
            foreach(var attribute in attributes.Values)
                yield return attribute.GetData();

        }
        
        public void AddAtributeModifier(AttributeType at, Modifier modifier) => attributes[at].AddModifier(modifier);    
        
        
        
        
        
        public IEnumerable<string> GetInventoryString()
        {
            foreach (var item in inventory)
                yield return  item.GetDataRepresentation();
        }

        public IEnumerable<string> GetHandsString()
        {
            if (lefthand != null && righthand == lefthand)
                yield return "Both Hands: " + lefthand.GetDataRepresentation();
            else
            {
                yield return "Left Hand: " + lefthand?.GetDataRepresentation();
                yield return "Right Hand: " + righthand?.GetDataRepresentation();
            }

        }
        public List<Item> GetInventory() => inventory;





        public  Item? DeleteItemFromInventory(Item item)
        {
            if (inventory.Remove(item))
                return item;
            return null;

        }
        public Item? DeleteItemFromInventory(int i =  0)
        {
            if (inventory.Count > i)
            {
                Item ret = inventory[i];
                ret.DeleteItemFromPlayerInventory(this);
                return ret;
            }

            return null;
        }

        public Potion? DeletePotion(int i = 0)
        {
            if (potions.Count > i)
            {
                Potion ret = potions[i];
                potions.RemoveAt(i);
                return ret;
            }

            return null;
        }

        public bool AddItemToInventory(Item? item, int nb = 0)
        {
            if (item != null)
                inventory.Insert(nb,item);
            return true;
        }

        public void AddToInventoryEnd(Item? item)
        {
            if (item != null)
                inventory.Add(item);
        }
        public void ScrollInventory()
        {
            if (inventory.Count > 0)
            {
                Item item = inventory.First();
                inventory.Remove(item);
                inventory.Add(item);
            }
        }

        
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

        public bool AddToElixirs(Potion potion)
        {
            potions.Add(potion);
            return true;
        }

        public Item? PeekItemInventory()
        {
            if (inventory.Count > 0)
                return inventory[0];
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
        
        public bool HasSthInHands() => lefthand != null || righthand != null;
        public void AddCoin() => coins++;
        public void AddGold() => gold++;

        public IEnumerable<string> GetAssets()
        {
            yield return "Coins: " + coins;
            yield return "Gold: " + gold; 
        }

        public IEnumerable<string> GetElixirsString()
        {
            foreach (var potion in potions)
            {
                yield return potion.GetName();
            }
        }
        
        public bool HasElixirs() => potions.Count > 0;
        
        
        public Item? GetLefthand() => lefthand;
        public Item? GetRighthand() => righthand;
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
