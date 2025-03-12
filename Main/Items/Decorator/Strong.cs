namespace Main;

public class Strong : WeaponDec , IWeapon
{
    const string attribute = "(Strong)";
    public Strong(IWeapon weapon)
    {
        this.weapon = weapon;
        this.item = weapon;
        this.name = attribute;
    }

    //public virtual int GetAtack();
    public override int GetAtack() => weapon.GetAtack() + 5; 

    /*
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