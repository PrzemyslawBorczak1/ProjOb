namespace Main;

public abstract class Decorator : Item /// dodawanie statystyk brakuje
{
    protected Item item;
    protected string attribute;
    
    
    public override string GetBoardRepresentation() => item.GetBoardRepresentation();
    
   // public override string GetDataRepresentation() => item.GetDataRepresentation(this);
    public override string GetDataRepresentation(Item itemR) => item.GetDataRepresentation(itemR);

    public override int? GetDataValues() => item.GetDataValues();

   public override bool MoveToPlayerHands(Player player) => item.MoveToPlayerHands(player, this);
    public override bool MoveToPlayerHands(Player player,Item itemR) => item.MoveToPlayerHands(player, itemR);
    
    public override string GetName() => item.GetName() + attribute;
    
    
    public override bool AddToPlayerInventory(Player player, Item itemR) => item.AddToPlayerInventory(player, itemR);
    public override bool AddToPlayerInventory(Player player) => item.AddToPlayerInventory(player, this);
    
    public override void DeletePlayerEffects(Player player) => item.DeletePlayerEffects(player, this);
    
    public override void DeletePlayerEffects(Player player, Item itemR) => item.DeletePlayerEffects(player, itemR);
    
   // public override bool De(Player player) => item.AddToPlayerInventory(player, this);

    /*
    public override bool MoveToPlayerHands(Player player) => item.MoveToPlayerHands(player,this); //// gdzies sie nulle wywalaja
    
    
    

    public bool AddToPlayerInventory(Player player)
    {
        
        throw new NotImplementedException();
        item.AddToPlayerInventory(player); // nie dziala bo uzywa pojedynczego dodania :///
        return true;
    }
    public bool AddToPlayerInventory(Player player,Item item)
    {
        item.AddToPlayerInventory(player); // nie dziala bo uzywa pojedynczego dodania :///
        return true;
    }


    public bool PlaceOnField(Field field)
    {
        item.PlaceOnField(field);
        return true;
    }
    */
}