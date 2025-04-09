using System;
using System.Reflection;

namespace ProjOb;

public class LegendBuilder : IBuilder
{
    private string legend;
    private bool MazeHasItems = false;
    private bool MazeHasPotions = false;
    

    public void GenerateEmptyDungeon() => legend = "";

    public void GenerateFilledDungeon() => legend = "";
    
    public void GeneratePaths(){}
    
    public void AddChambers(){}
    
    public void AddCentralRoom(){}
    
    
    
    public void AddWeapons()=> ItemMethod();

    public void AddPotions()
    {
        ItemMethod();
        if (!MazeHasPotions)
        {
            legend += "\nR - drink potion";
            MazeHasPotions = true;


            Printer printer = Printer.GetInstance();
            printer.AddLegened(legend);
        }
    }
    
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
                      F - drop item
                      X - drop all items
                      C - place item in hands
                      Z - hide item from hand to eq
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