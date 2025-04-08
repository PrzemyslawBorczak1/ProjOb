namespace ProjOb;

public class LegendBuilder : IBuilder
{
    private string legend;
    private bool MazeHasItems = false;
    

    public void GenerateEmptyDungeon() => legend = "";

    public void GenerateFilledDungeon() => legend = "";
    
    public void GeneratePaths(){}
    
    public void AddChambers(){}
    
    public void AddCentralRoom(){}
    
    
    
    public void AddWeapons()=> ItemMethod();
    
    public void AddPotions()=> ItemMethod();
    
    public void AddModifiedWeapons()=> ItemMethod();
    
    public void AddItems()=> ItemMethod();
    
    public void AddEnemies() {}

    public void AddAssets() => ItemMethod();

    public void ItemMethod()
    {
        
        if (!MazeHasItems)
        {
            legend += """
                      
                      E - pick up item
                      P - scroll items on the field
                      R - take item from field to free hand
                      """;
            
            legend += """
                      
                      O - drop item
                      I - scroll inventory
                      U - drop all items from inventory
                      F - take item form inventory to free hand
                      """;
            legend += """
                      
                      1 / 2 - drop item from right / left hand on the field
                      3 / 4 - move item from right / left hand to inventory
                      """;
            
            legend += """
                      
                      implemented:
                      (W/A/S/D) to move
                      E - pick up item
                      F - drop iteme
                      X - drop all
                      C - place item in hand
                      Z - hide sth from hand in eq
                      R - drink potion
                      """;
            MazeHasItems = true;
            
            Printer printer = Printer.GetInstance();
            printer.AddLegened(legend);
        }
    }


    public void AddPlayer()
    {
        legend += "\n (W/A/S/D) to move";

        Printer printer = Printer.GetInstance();
        printer.AddLegened(legend);

    }
}