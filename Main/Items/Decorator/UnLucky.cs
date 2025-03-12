namespace Main;

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
    
    //public override 
    public override bool AddToPlayerInventory(Player player) 
    {
        player.attributes["Luck"].AddModifier(modifier);
        return item.AddToPlayerInventory(player, this);
        
    }
    public override bool AddToPlayerInventory(Player player,Item itemR)
    {
        player.attributes["Luck"].AddModifier(modifier);
        return item.AddToPlayerInventory(player, itemR);
        
    }
    
    public override Item? DeleteItemFromPlayerInventory(Player player)
    {
        player.attributes["Luck"].DeleteModifier(modifier);   
        return item.DeleteItemFromPlayerInventory(player,this);
    }
    public override Item? DeleteItemFromPlayerInventory(Player player, Item itemR)
    {
        player.attributes["Luck"].DeleteModifier(modifier);   
        return item.DeleteItemFromPlayerInventory(player,itemR);
    }
/*
    public override void DeletePlayerEffects(Player player)
    {
        player.attributes["Luck"].DeleteModifier(modifier);   
        item.DeletePlayerEffects(player, this);
    }
    public override void DeletePlayerEffects(Player player, Item itemR)
    {
        player.attributes["Luck"].DeleteModifier(modifier);   
        item.DeletePlayerEffects(player, itemR);
    }
    /*
    public override string GetName() => item.GetName() + attribute;

    public override string GetDataRepresentation() //// do poprawy brak statystyk dla weapon
    {
        return GetName();
    }
    */
}