namespace Main;

public class UnLucky : Decorator //   zmiana atrybutow  playera
{
    private const string nameOfAttribute = "(UnLucky)";
    private Modifier modifier = new Modifier();
    public UnLucky(Item item)
    {
        this.item = item;
        this.attribute = nameOfAttribute;
    }
    
    
    public override bool AddToPlayerInventory(Player player) //// nie dziala
    {
        player.attributes["Luck"].AddModifier(modifier);
        return item.AddToPlayerInventory(player, this);
        
    }
    public override bool AddToPlayerInventory(Player player,Item itemR) //// nie dziala
    {
        player.attributes["Luck"].AddModifier(modifier);
        return item.AddToPlayerInventory(player, itemR);
        
    }

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