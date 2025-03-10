namespace Main;

public abstract class Attribute
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