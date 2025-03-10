namespace Main;

public class AAggression : Attribute
{
    private const string name = "Aggression: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}