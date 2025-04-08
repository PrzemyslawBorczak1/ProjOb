namespace ProjOb;

public abstract class Attribute
// klasy attribute do zmiany dodawnie do name
{
    List<Modifier> modifiers = new List<Modifier>();
    private int val = 10;

    public int GetValue()
    {
        int ret = val;
        foreach (var mod in modifiers.OrderBy(mod => mod.GetPriority())) /// moze nie dzialac
        {
            ret = mod.Modify(ret);
        }
        return ret;
    }

    public virtual void AddModifier(Modifier modifier) => modifiers.Add(modifier);
    public void DeleteModifier(Modifier modifier) => modifiers.Remove(modifier);
    public virtual string GetData()
    {
        return "None";
    }

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