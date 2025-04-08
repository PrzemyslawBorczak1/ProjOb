namespace ProjOb;

using System.Reflection;
public abstract class Asset :  Item
{
    public static Type[] GetAssets()
    {
        Type baseType = typeof(Asset);
        
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t))
            .ToArray();
    }
    
    
    
}