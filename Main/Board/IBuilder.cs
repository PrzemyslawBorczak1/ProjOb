namespace ProjOb;

public interface IBuilder
{
    public void GenerateEmptyDungeon();
    
    public void GenerateFilledDungeon();
    
    public void GeneratePaths();
    
    public void AddChambers();
    
    public void AddCentralRoom();
    
    public void AddWeapons();
    
    public void AddPotions();
    
    public void AddModifiedWeapons();
    
    public void AddItems();
    
    public void AddEnemies();
    
    public void AddAssets();
    
    public void AddPlayer();
    
    
}