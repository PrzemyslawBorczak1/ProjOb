using System.Reflection;

namespace ProjOb;
using System.Reflection;

public abstract class Potion : Item
{
    const string itName = "Elixir";
    

    public Potion() => this.name = itName;
    public override string GetBoardRepresentation() => "E";
    
    public static Type[] GetPotions()
    {
        Type baseType = typeof(Potion);
        
        return Assembly.GetExecutingAssembly()
            .GetTypes()
            .Where(t => t.IsClass && !t.IsAbstract && baseType.IsAssignableFrom(t))
            .ToArray();
    }
    
    
    
    
    
/*
    public override bool AddToPlayerInventory(Player player)
    {
        player.AddToElixirs(this);
        return true;
    }
*/
    public override bool AddToPlayerInventory(Player player, Item? item = null)
    {
        if (item == null)
            player.AddToElixirs(this);
        else
            player.AddToElixirs((Potion)item);

        return true;
    }
/*
    public override bool AddToPlayerHands(Player player)
    {
        return AddToPlayerInventory(player);
    }
    */
    public override bool AddToPlayerHands(Player player, Item? item = null) =>  AddToPlayerInventory(player, item);
   
}