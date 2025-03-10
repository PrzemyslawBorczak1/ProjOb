namespace Main;

public class AStrength : Attribute
{
    private const string name = "Strength: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}