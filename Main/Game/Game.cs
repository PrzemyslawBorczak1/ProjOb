using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    class Game
    {
        private Board board;
        private Player player;

        private Printer printer;
        public Game()
        {
            board = new Board();
            player = new Player();
            printer = new Printer(board);

            board.AddPlayer(player);
            
            printer.PrintOverlay();
            printer.PrintBoard();
            
            ReadKey();
        }
    
    // zawsze drukuje wszystko nie zawsze potrzebnie
        void ReadKey()
        {
            char c;
            int x, y;
            player = board.GetPlayer();
            
            if (player == null)
                return;
            do
            {
                printer.PrintData(player.GetAttributesData());
                (x, y) = board.GetPlayerPosition();
                printer.PrintData(player.GetAssets());
                printer.PrintData(player.GetHandsString());
                printer.PrintData(player.GetInventoryString());
                printer.PrintData(board[x,y].GetItemsNames());
                
                c = Console.ReadKey(true).KeyChar;
                printer.ResetData();
                
                Item? i;
                switch (c)
                {
                    case 'a':
                        printer.PrintField(board.MovePlayer(player, Move.Left));
                        printer.PrintField((x, y));
                        continue;
                    case 'w':
                        printer.PrintField(board.MovePlayer(player, Move.Up));
                        printer.PrintField((x, y));
                        continue;
                    case 's':
                        printer.PrintField(board.MovePlayer(player, Move.Down));
                        printer.PrintField((x, y));
                        continue;
                    case 'd':
                        printer.PrintField(board.MovePlayer(player, Move.Right));
                        printer.PrintField((x, y));
                        continue;
                    case 'p':
                        board[x, y].ScrollItems();
                        continue;
                    case 'e':
                        board[x, y].DeleteItem()?.AddToPlayerInventory(player);
                        continue;
                    case 'o':
                        board[x, y].AddItem(player.DeleteItemFromInventory());
                        continue;
                    case 'i':
                        player.ScrollInventory();
                        continue;
                    case 'u':
                        while((i = player.DeleteItemFromInventory()) != null)
                            board[x,y].AddItem(i);
                        continue;
                    case 'r':
                        i = board[x, y].PeekItemField();
                        if(i != null && i.MoveToPlayerHands(player))
                            board[x,y].DeleteItem();
                        continue;
                    case 'f':
                        i = player.PeekItemInventory();
                        if(i != null && i.MoveToPlayerHands(player))
                            player.DeleteItemFromInventory();
                        continue;
                    
                    case '1':
                        player.DeleteItemFromRightHand()?.PlaceOnField(board[x, y]);
                        continue;
                    case '2':
                        player.DeleteItemFromLeftHand()?.PlaceOnField(board[x, y]);
                        continue;
                    
                    case '3':
                        player.DeleteItemFromRightHand()?.AddToPlayerInventory(player);
                        continue;
                    case '4':
                        player.DeleteItemFromLeftHand()?.AddToPlayerInventory(player);
                        continue;
                }
            } while (c != 'q');
        }
    }
}
