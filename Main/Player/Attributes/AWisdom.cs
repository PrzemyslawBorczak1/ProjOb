namespace Main;

public class AWisdom : Attribute
{
    private const string name = "Wisdom: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}