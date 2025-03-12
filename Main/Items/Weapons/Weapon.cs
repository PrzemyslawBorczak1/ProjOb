using System.Text;

namespace Main;

public abstract class Weapon : Item, IWeapon ////////// usunac atak z GetData    ////// zrobic get Name
{
    protected int damage = 0;
    public virtual int GetAtack() => damage;
    public override string GetName() => name;
    public Weapon(int damage)
    { 
        this.damage = damage;
        this.name = "No name";
    }

    public Weapon() => this.name = "No name";
    
    public override string GetDataRepresentation()
    {
        return GetName() + ": " + GetAtack().ToString();
    }
    
    /*
    public override string GetDataRepresentation()
    {
        StringBuilder ret = new StringBuilder(GetName());
        bool first = true;
        foreach (var at in GetDataValues())
        {
            if (first)
            {
                ret.Append(at);
                first = false;
            }
            ret.Append(", " + at);
        }

        return ret.ToString();
        
    }

    public override string GetDataRepresentation(Item item)
    {
        return item.GetDataRepresentation() + GetDataValues(); //// moze nie dzialac + Ienum
    }
    public override int? GetDataValues()
    {
         return Atack();
    }
    */


    /*
    public override string GetDataRepresentation() => "No Rep for wep";
    public override string GetDataRepresentation(Item item)=> "No rep for wep";

    */
    
}