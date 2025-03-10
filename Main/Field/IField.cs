using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    interface IField
    {
        public List<Item> GetItems();
        public void AddItem(Item item);
        public int GetItemsAmount();


        public Player? GetPlayer();
        public void DeletePlayer();



    }
}
