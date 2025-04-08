namespace ProjOb;

public class Coin : Asset
{
   
    public Coin() => this.name = "Coin";
    public override string GetBoardRepresentation() => "$";
    
/*
    public override bool AddToPlayerInventory(Player player)
    {
        player.AddCoin();
        return true;
    }
*/
    public override bool AddToPlayerHands(Player player, Item? item = null)
    {
        player.AddCoin();
        return true;
    }
    
    public override bool AddToPlayerInventory(Player player,Item? item = null)
    {
        player.AddCoin();
        return true;
    }
}