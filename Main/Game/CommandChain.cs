using ProjOb;
using System.Numerics;

namespace ProjOb;

public interface IHandler
{
    IHandler SetNext(IHandler handler);
        
    Object? Handle(Input input);
}

public class BasicHandler : IHandler
{
    private IHandler? nextHandler;
    
    public static Printer printer = Printer.GetInstance();

    public IHandler SetNext(IHandler handler)
    {
        this.nextHandler = handler;
        return handler;
    }

    public virtual Object? Handle(Input input)
    {
        if (this.nextHandler != null)
        {
            return this.nextHandler.Handle(input);
        }
        else
        {
            printer.RedrawData();
            printer.PrintAction($"No effect for {input.GetChar()}",ConsoleColor.Red);
            return null;
        }
    }
}
public class MoveHandler : BasicHandler
{
    private void MovePlayer(Input input,Move move)
    {
        Board board = input.GetBoard();
        Player player = input.GetPlayer();
        var (x, y) = board.GetPlayerPosition();
        var (xNew, yNew) = board.MovePlayer(player, move);
        if ((xNew, yNew) == (-1,-1))
        {
            printer.PrintAction("You cant move here", ConsoleColor.Red);
            return;
        }
        printer.PrintField(xNew,yNew);
        printer.PrintField((x, y));
        TurnSubject.Notify();
        
        printer.RedrawData();
        printer.PrintAction($"You moved {move.ToString()}",ConsoleColor.DarkYellow);

        
    }
    public override Object? Handle(Input input)
    {
        char c = input.GetChar();
        switch (c)
        {
            case 'A' or 'a':
                MovePlayer(input,Move.Left);
                return null;
            case 'W' or 'w':
                MovePlayer(input,Move.Up);
                return null;
            case 'S' or 's':
                MovePlayer(input, Move.Down);
                return null;
            case 'D' or 'd':
                MovePlayer(input, Move.Right);
                return null;
        }
        return base.Handle(input);
    }
}

class PickUpHandler : BasicHandler
{
    public override Object? Handle(Input input)
    {
        if (input.GetChar() == 'E' || input.GetChar() == 'e')
        {
            Board board = input.GetBoard();
            Player player = input.GetPlayer();
            var (x, y) = board.GetPlayerPosition();

            Item? it = board[x, y].DeleteItem();
            if(it == null)
            {
                printer.PrintAction("No items on this field", ConsoleColor.Red);
                return input;
            }

            if(it.AddToPlayerHands(player) == false)
                it.AddToPlayerInventory(player);

            printer.RedrawData();
            return input;
        }
        return base.Handle(input);
    }
}

class DropItem : BasicHandler
{
    private void Drop(ConsoleKeyInfo c, Board board, Player player, int nb)
    {
        if (c.Modifiers == ConsoleModifiers.Control)
        {
            DeletePotion(board, player, nb);
            return;
        }
        DeleteItem(board, player, nb);

    }
    private void DeleteItem(Board board, Player player, int nb)
    {
        var (x, y) = board.GetPlayerPosition();
        Item? it = player.DeleteItemFromInventory(nb);
        if (it == null)
        {
            printer.PrintAction($"You dont have {nb + 1} items", ConsoleColor.Red);
            return;
        }
        PlaceItemOnField(it, board[x, y]);

        printer.RedrawData();
        return;
    }

    private void DeletePotion(Board board, Player player, int nb)
    {
        var (x, y) = board.GetPlayerPosition();
        Potion? pt = player.DeletePotion(nb);
        if (pt == null)
        {
            printer.PrintAction($"You dont have {nb + 1} potions", ConsoleColor.Red);
            return;
        }
        PlaceItemOnField(pt, board[x, y]);

        printer.RedrawData();
        return;
    }

    private void PlaceItemOnField(Item? item, Field field) 
    {
        item?.PlaceOnField(field);

       // printer.PrintField(x, y);
        printer.RedrawData();
    }

    public override Object? Handle(Input input)
    {
        if (input.GetChar() == 'F' || input.GetChar() == 'f')
        {
            //printer.RedrawData();
            Player player = input.GetPlayer();
            Board board = input.GetBoard();
            var (x, y) = board.GetPlayerPosition();


            for (int i = 0; i < 2; i++)
            {

                printer.PrintAction("   1-4 to drop item from eq");
                printer.PrintAction("   Ctrl + 1-4 to drop potion");
                printer.PrintAction("   E/R to drop item from left/right hand");


                ConsoleKeyInfo c = Console.ReadKey(true);
                input.SetKey(c);
                switch (c.Key)
                {
                    case ConsoleKey.D1:
                        Drop(c, board, player, 0);
                        return null;
                    case ConsoleKey.D2:
                        Drop(c, board, player, 1);
                        return null;
                    case ConsoleKey.D3:
                        Drop(c, board, player, 2);
                        return null;
                    case ConsoleKey.D4:
                        Drop(c, board, player, 3);
                        return null;
                    case ConsoleKey.E:
                        Item? it = player.DeleteItemFromLeftHand();
                        if (it == null)
                        {
                            printer.PrintAction("You dont have Item in your left hand", ConsoleColor.Red);
                            return null;
                        }
                        PlaceItemOnField(it, board[x, y]);
                        return null;
                    case ConsoleKey.R:
                        it = player.DeleteItemFromRightHand();
                        if (it == null)
                        {
                            printer.PrintAction("You dont have Item in your right hand", ConsoleColor.Red);
                            return null;
                        }
                        PlaceItemOnField(it, board[x, y]);
                        return null;
                }
            }
        }
        printer.RedrawData();
        return base.Handle(input);
    }

}   

public class DropAllItems : BasicHandler
{
    public override Object? Handle(Input input)
    {
        if (input.GetChar() == 'X' || input.GetChar() == 'x')
        {
            Board board = input.GetBoard();
            Player player = input.GetPlayer();
            var (x, y) = board.GetPlayerPosition();

            Item? it;
            int i = 0;
            while ((it = player.DeleteItemFromInventory(0)) != null)
            {
                board[x, y].AddItem(it);
                i++;
            }
            while ((it = player.DeletePotion(0)) != null)
            {
                board[x, y].AddItem(it);
                i++;
            }

            if (i == 0)
                printer.PrintAction($"You dont have any items", ConsoleColor.Red);
            else
                printer.RedrawData();
            return input;
        }

        return base.Handle(input);
    }
    
}

public class PlaceItemInHand : BasicHandler
{
    public override Object? Handle(Input input)
    {

        if (input.GetChar() == 'C' || input.GetChar() == 'c')
        {
            //printer.RedrawData();
            Player player = input.GetPlayer();

           


            for (int i = 0; i < 2; i++)
            {
                printer.PrintAction("   1-4 to choose item to place in hands");
                ConsoleKeyInfo c = Console.ReadKey(true);
                input.SetKey(c);
                switch (c.KeyChar)
                {
                    case '1':
                        PlaceItem(player, 0);
                        return null;
                    case '2':
                        PlaceItem(player, 1);
                        return null;
                    case '3':
                        PlaceItem(player, 2);
                        return null;
                    case '4':
                        PlaceItem(player, 3);
                        return null;
                }

            }
        }
        return base.Handle(input);

    }

    public void PlaceItem(Player player, int nb)
    {
        Item? it = player.DeleteItemFromInventory(nb);
        if (it == null)
        {
            printer.PrintAction($"You dont have {nb + 1} items", ConsoleColor.Red);
            return;
        }
        if(it.AddToPlayerHands(player) == false)
        {
            printer.PrintAction($"You already have full hands", ConsoleColor.Red);
            player.AddItemToInventory(it, nb);
            return;
        }

        printer.RedrawData();
    }
}

public class HideItemFromHandInEq : BasicHandler
{
    public override Object? Handle(Input input)
    {

        if (input.GetChar() == 'Z' || input.GetChar() == 'z')
        {
            Player player = input.GetPlayer();

            for (int i = 0; i < 2; i++)
            {
                printer.PrintAction("   E/R to choose hand");
                ConsoleKeyInfo c = Console.ReadKey(true);
                input.SetKey(c);
                Item? it;
                switch (c.KeyChar)
                {
                    case 'E' or 'e':
                        it = player.DeleteItemFromLeftHand();
                        AddToInventory(player, it);
                        return null;
                    case 'R' or 'r':
                        it = player.DeleteItemFromRightHand();
                        AddToInventory(player, it);
                        return null;
                }
            }
        }
        return base.Handle(input);
    }
     void AddToInventory(Player player, Item? item)
    {
        if(item == null)
        {
            printer.PrintAction("Your hand is empty", ConsoleColor.Red);
            return;
        }
        // player.AddToInventoryEnd(item);
        item.AddToPlayerInventory(player);
        printer.RedrawData();
    }

}

public class ScrollEq
{

}

public class DrinkPotion : BasicHandler

{
    public override Object? Handle(Input input)
    {
        if (input.GetChar() == 'R' || input.GetChar() == 'r')
        {

            for (int i = 0; i < 2; i++)
            {
                printer.PrintAction("   1-4 to choose potion to drink");
                ConsoleKeyInfo c = Console.ReadKey(true);
                switch (c.KeyChar)
                {
                    case '1':
                        DrinkEl(input, 1);
                        return null;
                    case '2':
                        DrinkEl(input, 2);
                        return null;
                    case '3':
                        DrinkEl(input, 3);
                        return null;
                    case '4':
                        DrinkEl(input, 4);
                        return null;
                }

            }
        }
        return base.Handle(input);
    }
    private void DrinkEl(Input input, int nb)
    {
        Player player = input.GetPlayer();
        Potion? potion = player.DeletePotion(nb - 1);

        if (potion == null)
        {
            printer.PrintAction($"You dont have {nb} potions");
            return;
        }

        potion.Drink(player);
        printer.RedrawData();
    }
}

