namespace ProjOb;



public interface IModifier : TurnObserver
{
    public int Modify(int amount);
    public AttributeType GetAttributeType();

    public int GetPriority();

    public bool IsExpired();

    public string GetEfectRepresentation();

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
    public void Update() { }

    public bool IsExpired() => false;



    public string GetEfectRepresentation()
    {
        if(value > 0)
            return $"Weapon Modifier {attributeType.ToString()}: +{value}";
        else
            return $"Weapon Modifier {attributeType.ToString()}: {value}";
    }   

}



