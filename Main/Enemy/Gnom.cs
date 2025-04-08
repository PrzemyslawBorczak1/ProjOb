namespace ProjOb;

public class Gnom : Enemy
{
    
    const string itname = "Gnom";

    public Gnom()
    {
        name = itname;
    }
    public override string GetBoardRepresentation() => "G";
    
}