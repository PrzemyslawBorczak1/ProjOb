namespace Main;

public class Coin : Assets
{
    const string name = "Coin";
    

    public override string GetDataRepresentation() => "Coin";

    public override string GetName() => name;

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