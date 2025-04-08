namespace ProjOb;

public class PowerPotion : Potion
{

    const string itName = "PowerPotion";
    public PowerPotion()
    {
        this.attributeType = AttributeType.Strength;
        this.name = itName;
        this.duration = 5;
        this.left = duration;
    }



    public override int Modify(int amount)
    {
        return amount + 2;
    }

}