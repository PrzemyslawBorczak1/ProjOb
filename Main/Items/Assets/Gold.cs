namespace Main;

public class Gold : Assets
{
    public Gold() => this.name = "Gold";
    public override string GetBoardRepresentation() => "&";
    
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