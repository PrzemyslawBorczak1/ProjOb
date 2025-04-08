namespace ProjOb;

public class DungeonDirectors : IDirector
{
    public void Build(IBuilder builder)
    {

        builder.GenerateFilledDungeon();

        builder.AddPlayer();

        builder.AddCentralRoom();
        builder.GeneratePaths();
        
        builder.AddChambers();
        builder.AddChambers();

        builder.AddEnemies();
        builder.AddEnemies();
       builder.AddPotions();
        

    }

}


public class NormalDungeon : IDirector
{


    public void Build(IBuilder builder)
    {

        builder.GenerateFilledDungeon();

        builder.AddPlayer();

        builder.AddCentralRoom();
        builder.GeneratePaths();
       
        builder.AddChambers();
        builder.AddChambers();
        builder.AddChambers();
        
        builder.AddAssets();
        builder.AddItems();
        builder.AddModifiedWeapons();
        builder.AddModifiedWeapons();
       // builder.AddWeapons();
        builder.AddEnemies();

       // builder.AddWeapons();
        builder.AddModifiedWeapons();
        builder.AddItems();
        builder.AddPotions();
        builder.AddAssets();

    }


}