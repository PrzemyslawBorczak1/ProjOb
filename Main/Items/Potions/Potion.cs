using System.Reflection;

namespace ProjOb;
using System.Reflection;

public abstract class Potion : Item, IModifier
{
    const string itName = "Elixir";
    public int duration = 0;
    public int left = 0;


    public AttributeType attributeType;
    

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
    
    
    public override bool AddToPlayerInventory(Player player, Item? item = null)
    {
        if (item == null)
            player.AddToElixirs(this);
        else
            player.AddToElixirs((Potion)item);

        return true;
    }
    
    public override bool AddToPlayerHands(Player player, Item? item = null) =>  AddToPlayerInventory(player, item);


    public virtual int Modify(int amount) => amount;

    public virtual AttributeType GetAttributeType() => attributeType;

    public void Drink(Player player) => player.AddAtributeModifier(this);

    public int GetPriority() => 0;


}