namespace Main;

public class Sword : Weapon
{
    private const string nameOfItem = "Sword";
    public Sword(int damage) : base(damage) => this.name = nameOfItem;
    public Sword() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => "S";
}