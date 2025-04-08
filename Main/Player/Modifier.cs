namespace ProjOb;



public interface IModifier
{
    public int Modify(int amount);
    public AttributeType GetAttributeType();

    public int GetPriority();
}


public class Modifier : IModifier
{

    protected AttributeType attributeType;
    int value;

    public Modifier(AttributeType at, int value) {
        attributeType = at;
        this.value = value;
    }
    
    public virtual int Modify(int amount) => amount + value;



    public AttributeType GetAttributeType() => attributeType;
    public int GetPriority() => 1;


}



