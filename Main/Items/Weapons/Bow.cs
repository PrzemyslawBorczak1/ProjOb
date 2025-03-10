namespace Main;

public class Bow : Weapon
{
    private const string nameOfItem = "Bow";
    private const string boardRepresentation = "B";
    public Bow(int damage) : base(damage) => this.name = nameOfItem;
    public Bow() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => boardRepresentation;
}