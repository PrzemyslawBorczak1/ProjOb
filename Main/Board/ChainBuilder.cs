namespace ProjOb;

public class ChainBuilder : IBuilder
{
    IHandler? handler = null;
    private bool HasItems = false;

    void ItemMethod()
    {
        if (!HasItems)
        {
            HasItems = true;
            AddToHandler(new PickUpHandler());
            AddToHandler(new DropItem());
            AddToHandler(new DropAllItems());
            AddToHandler(new PlaceItemInHand());
            AddToHandler(new HideItemFromHandInEq());
        }
    }
    
    
    void AddToHandler(IHandler handler)
    {
        if (this.handler == null)
            this.handler = handler;
        else
        {
            handler.SetNext(this.handler);
            this.handler = handler;
        }
    }

    public void GenerateEmptyDungeon() {}

    public void GenerateFilledDungeon() {}
    
    public void GeneratePaths(){}
    
    public void AddChambers(){}
    
    public void AddCentralRoom(){}
    
    
    
    public void AddWeapons() => ItemMethod();
    
    public void AddPotions() => ItemMethod();
    
    public void AddModifiedWeapons() => ItemMethod();   
    
    public void AddItems() => ItemMethod();
    
    public void AddEnemies() {}

    public void AddAssets() => ItemMethod();

  


    public void AddPlayer()
    {
        AddToHandler(new MoveHandler());
    }
    public IHandler? GetHandler() => handler;
}