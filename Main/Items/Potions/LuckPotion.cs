namespace ProjOb;

public class LuckPotion : Potion
{
    const string itName = "LuckPotion";

    public LuckPotion() :  this(3) { }



    public LuckPotion(int duration)
    {
        this.name = itName;
        this.attributeType = AttributeType.Luck;
        this.duration = duration;
        this.left = this.duration;
    }


    public override int Modify(int amount)
    {
        return amount * (duration - left + 1);
    }

}