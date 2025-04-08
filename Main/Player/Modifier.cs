namespace ProjOb;

public class Modifier
{
    private int priority;
    private int time;

    
    public Modifier() => this.priority = 0;
    
    public int Modify(int value) => value - 5;
    
    public int GetPriority() => priority;

}