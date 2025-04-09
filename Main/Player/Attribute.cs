namespace ProjOb;
using System.Linq;

public abstract class Attribute
// klasy attribute do zmiany dodawnie do name
{
    List<IModifier> modifiers = new List<IModifier>();
    private int val = 10;

    public int GetValue()
    {
        int ret = val;
        foreach (var mod in modifiers.OrderBy(t => t.GetPriority())) /// moze nie dzialac   zwlaszcza jesli pota ma cos robic na usunieciu
        {
            if (mod.IsExpired())
            {
                modifiers.Remove(mod);
                TurnSubject.Detach(mod);
                continue;
            }
            ret = mod.Modify(ret);
        }
        return ret;
    }

    public virtual void AddModifier(IModifier modifier) => modifiers.Add(modifier);
    public void DeleteModifier(IModifier modifier) => modifiers.Remove(modifier);
    public virtual string GetData()
    {
        return "None";
    }
    public List<IModifier> GetModifiers() => modifiers;

    public void ChangeAttribute(int amount) => val += amount;

}


public class AAggression : Attribute
{
    private const string name = "Aggression: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}

public class AHealth : Attribute
{
    private const string name = "Health: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}

public class ALuck : Attribute
{
    private const string name = "Luck: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}

public class AStrength : Attribute
{
    private const string name = "Strength: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}

public class AWisdom : Attribute
{
    private const string name = "Wisdom: ";
    public override string GetData()
    {
        return name + GetValue();
    }
}