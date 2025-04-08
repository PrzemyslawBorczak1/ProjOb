namespace ProjOb;

public class Modifier
{
    private int priority;
    private int time;

    
    public Modifier(int priority = 0) => this.priority = priority;
    
    public int Modify(int value) => value - 5;
    
    public int GetPriority() => priority;

}