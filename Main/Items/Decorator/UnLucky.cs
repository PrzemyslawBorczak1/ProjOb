using System.Reflection;

namespace ProjOb;

public class UnLucky : WeaponDec //   zmiana atrybutow  playera
{
    private const string attribute = "(UnLucky)";
    private Modifier modifier = new Modifier();
    public UnLucky(IWeapon item)
    {
        this.item = item;
        this.weapon = item;
        this.name = attribute;
    }
    
    public override bool AddToPlayerInventory(Player player) 
    {
        player.AddAtributeModifier(AttributeType.Luck,modifier);
        return item.AddToPlayerInventory(player, this);
        
    }
    public override bool AddToPlayerInventory(Player player,Item itemR)
    {
        player.AddAtributeModifier(AttributeType.Luck,modifier);
        return item.AddToPlayerInventory(player, itemR);
        
    }
    
    public override Item? DeleteItemFromPlayerInventory(Player player)
    {
        player.attributes[AttributeType.Luck].DeleteModifier(modifier);   
        return item.DeleteItemFromPlayerInventory(player,this);
    }
    public override Item? DeleteItemFromPlayerInventory(Player player, Item itemR)
    {
        player.attributes[AttributeType.Luck].DeleteModifier(modifier);   
        return item.DeleteItemFromPlayerInventory(player,itemR);
    }
}