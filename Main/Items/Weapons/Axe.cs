namespace ProjOb;

public class Axe : Weapon
{
    private const string nameOfItem = "Axe";
    public Axe(int damage) : base(damage) => this.name = nameOfItem;
    public Axe() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => "A";
    
    public override bool AddToPlayerHands(Player player) => player.AddToBothHands(this);
    public override bool AddToPlayerHands(Player player, Item item) => player.AddToBothHands(item);
}