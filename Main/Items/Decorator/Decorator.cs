namespace ProjOb;

public abstract class Decorator : Item
{
    public IItem item;
    
    
    public override string GetBoardRepresentation() => item.GetBoardRepresentation();
    

   public override bool AddToPlayerHands(Player player) => item.AddToPlayerHands(player, this);
    public override bool AddToPlayerHands(Player player,Item itemR) => item.AddToPlayerHands(player, itemR);
    
    public override string GetName() => item.GetName() + name;
    
    
    public override bool AddToPlayerInventory(Player player, Item itemR) => item.AddToPlayerInventory(player, itemR);
    public override bool AddToPlayerInventory(Player player) => item.AddToPlayerInventory(player, this);
    
    public override Item? DeleteItemFromPlayerInventory(Player player) => item.DeleteItemFromPlayerInventory(player,this);

    public override Item? DeleteItemFromPlayerInventory(Player player, Item itemR) =>
        item.DeleteItemFromPlayerInventory(player, itemR);


}