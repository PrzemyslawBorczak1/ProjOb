using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb.Items.Potions
{
    class WisdomPotion : Potion
    {
        const string itName = "WisdomPotion";
        public WisdomPotion()
        {
            this.name = itName;
        }



        public override void Drink(Player player)
        {
            player.ChangeAttribute(AttributeType.Wisdom, 1);
        }
    }
}
