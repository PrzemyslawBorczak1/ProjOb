using System.Reflection;

namespace ProjOb;

public class UnLucky : WeaponDec //   zmiana atrybutow  playera
{
    private const string attribute = "(UnLucky)";
    private Modifier modifier = new Modifier(AttributeType.Luck, -5);
    public UnLucky(IWeapon item)
    {
        this.item = item;
        this.weapon = item;
        this.name = attribute;
    }
    /*
    public override bool AddToPlayerInventory(Player player) 
    {
        player.AddAtributeModifier(AttributeType.Luck,modifier);
        return item.AddToPlayerInventory(player, this);
        
    }
    */
    public override bool AddToPlayerInventory(Player player,Item? itemR = null)
    {
        player.AddAtributeModifier(AttributeType.Luck,modifier);
        return itemR == null ? item.AddToPlayerInventory(player,this) : item.AddToPlayerInventory(player, itemR);
        
        
        
        
      //  return item.AddToPlayerInventory(player, itemR);
        
    }
    /*
    public override Item? DeleteItemFromPlayerInventory(Player player)
    {
        player.attributes[AttributeType.Luck].DeleteModifier(modifier);   
        return item.DeleteItemFromPlayerInventory(player,this);
    }
    
    */
    
    public override Item? DeleteItemFromPlayerInventory(Player player, Item? itemR = null)
    {
        player.DeleteModifier(AttributeType.Luck,modifier);   
        
        return itemR == null ? item.DeleteItemFromPlayerInventory(player,this) : item.DeleteItemFromPlayerInventory(player, itemR);
    }
}