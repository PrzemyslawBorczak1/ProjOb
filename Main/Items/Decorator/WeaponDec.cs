namespace Main;

public abstract class WeaponDec : Decorator , IWeapon
{
    public IWeapon weapon;
    public virtual int GetAtack() => weapon.GetAtack();

    public override string GetDataRepresentation() => GetName() + ": " + GetAtack().ToString();

}