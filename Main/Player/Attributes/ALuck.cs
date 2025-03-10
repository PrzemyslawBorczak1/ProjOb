namespace Main;

public class ALuck : Attribute
{
    private const string name = "Luck: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}