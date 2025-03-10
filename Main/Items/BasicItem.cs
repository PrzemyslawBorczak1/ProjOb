namespace Main;

public class BasicItem : Item
{
    const string name = "BasicItem";
    private int counter;
    public BasicItem(int v) => counter = v;

    public override string GetDataRepresentation() => name + counter;

    public override string GetName() => name;

    public override string GetBoardRepresentation() => "i";
}