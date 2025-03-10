namespace Main;

public class Modifier
{
    private int priority;

    public Modifier() => this.priority = 0;
    public Modifier(int priority) => this.priority = priority;
    
    public int Modify(int value) => value - 5;
    
    
    public int GetPriority() => priority;

}