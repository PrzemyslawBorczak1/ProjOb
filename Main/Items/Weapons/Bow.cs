namespace Main;

public class Bow : Weapon
{
    private const string nameOfItem = "Bow";
    public Bow(int damage) : base(damage) => this.name = nameOfItem;
    public Bow() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => "B";
}