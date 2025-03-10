namespace Main;

public class Strong : Decorator
{
    const string attribute = "(Strong)";
    public Strong(Item item)
    {
        this.item = item;
        this.name = attribute;
    }
    
    // chyba do usuniecia?
    public override string GetDataRepresentation()
    {
        int? data = GetDataValues();
        if(data != null) 
            return GetName() + ": " + data.ToString();
        return GetName();
    }

    public override int? GetDataValues()
    {
        int? data = item.GetDataValues();
        if (data != null) 
            return data + 5;
        return null;
    }


    /*
    public override string GetName() => item.GetName() + attribute;

    public override string GetDataRepresentation()
    {
        return GetName() + ": " + weapon.Atack();
    }


*/

}