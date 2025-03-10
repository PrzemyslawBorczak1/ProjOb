namespace Main;

public class Sword : Weapon
{
    private const string nameOfItem = "Sword";
    private const string boardRepresentation = "S";
    
    public Sword(int damage) : base(damage) => this.name = nameOfItem;
    public Sword() => this.name = nameOfItem;
    public override string GetBoardRepresentation() => boardRepresentation;
    
}