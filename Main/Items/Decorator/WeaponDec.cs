namespace ProjOb;

using System.Reflection;
public abstract class WeaponDec : Decorator , IWeapon
{
    public static Type[] GetWeaponDecorators()
    {
        Type baseType = typeof(WeaponDec);
        
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t))
            .ToArray();
    }
    
    
    public IWeapon weapon;
    public virtual int GetAtack() => weapon.GetAtack();

    public override string GetDataRepresentation() => GetName() + ": " + GetAtack().ToString();

}