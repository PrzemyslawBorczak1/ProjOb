namespace ProjOb;

using System.Reflection;
public abstract class Enemy
{
    public string name = "--";
    public virtual string GetBoardRepresentation() => "*";
    public virtual ConsoleColor  GetColor() => ConsoleColor.DarkBlue;
    
    public virtual string GetName() => name;
    public static Type[] GetEnemies()
    {
        Type baseType = typeof(Enemy);
        
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t))
            .ToArray();
    }
}