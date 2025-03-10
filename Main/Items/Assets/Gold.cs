namespace Main;

public class Gold : Assets
{
    const string name = "Gold";
    

    public override string GetDataRepresentation() => "Gold";

    public override string GetName() => name;

    public override string GetBoardRepresentation() => "\u20ac";
    
    public override bool AddToPlayerInventory(Player player)
    {
        player.AddGold();
        return true;
    }

    public override bool AddToPlayerInventory(Player player,Item item)
    {
        player.AddGold();
        return true;
    }
}