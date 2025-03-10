namespace Main;

public class Axe : Weapon
{
    private const string nameOfItem = "Axe";
    private const string boardRepresentation = "A";
    public Axe(int damage) : base(damage) => this.name = nameOfItem;
    public Axe() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => boardRepresentation;
    
    
    public override bool MoveToPlayerHands(Player player) => player.AddToBothHands(this);
    public override bool MoveToPlayerHands(Player player, Item item) => player.AddToBothHands(item);
}