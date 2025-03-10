namespace Main;

public class Coin : Assets
{
   
    public Coin() => this.name = "Coin";
    public override string GetBoardRepresentation() => "$";
    

    public override bool AddToPlayerInventory(Player player)
    {
        player.AddCoin();
        return true;
    }

    public override bool AddToPlayerInventory(Player player,Item item)
    {
        player.AddCoin();
        return true;
    }
}