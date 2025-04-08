namespace ProjOb;

public class Stick  : Item
{
    const string itName = "Stick";

    public Stick() => this.name = itName;
    
    public override string GetBoardRepresentation() => "-";
}