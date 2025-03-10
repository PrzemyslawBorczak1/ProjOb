namespace Main;

public class AHealth : Attribute
{
    private const string name = "Health: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}