namespace Main;

public class Strong : Decorator
{
    const string nameOfAttribute = "(Strong)";
    public Strong(Item item) //// zamiana potrzebna bo nie mzoan zakotwiczac dekoratorow
    {
        this.item = item;
        this.attribute = nameOfAttribute;
    }

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