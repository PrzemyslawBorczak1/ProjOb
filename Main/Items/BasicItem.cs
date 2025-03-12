namespace Main;

public class BasicItem : Item
{
    const string itName = "BasicItem";
    private int counter;

    public BasicItem(int v)
    {
        counter = v;
        this.name = itName;
    }

    public override string GetDataRepresentation() => name + counter;
    public override string GetBoardRepresentation() => "i";
}