namespace ProjOb;

public class Strong : WeaponDec , IWeapon
{
    const string attribute = "(Strong)";
    public Strong(IWeapon weapon)
    {
        this.weapon = weapon;
        this.item = weapon;
        this.name = attribute;
    }

    public override int GetAtack() => weapon.GetAtack() + 5; 



}