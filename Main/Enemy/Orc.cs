namespace ProjOb;

public class Orc : Enemy
{
    const string itname = "Orc";

    public Orc()
    {
        name = itname;
    }
    public override string GetBoardRepresentation() => "O";
}