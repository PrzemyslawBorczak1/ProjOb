namespace ProjOb;

public class Rock : Item
{
    const string itName = "Rock";

    public Rock() => this.name = itName;

    public override string GetBoardRepresentation() => ".";
}