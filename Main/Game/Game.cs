using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ProjOb
{
    class Game
    {
        private Board? board;
        private Player? player;

        private Printer printer;
        private IHandler? handler;

        public Game()
        {
            var dungeonBuilder = new DungeonBuilder();
            var legendBuilder = new LegendBuilder();
            var chainBuilder = new ChainBuilder();
            
            IDirector director = new NormalDungeon();
             //director = new DungeonDirectors();
            
            
            
            director.Build(dungeonBuilder);
            director.Build(legendBuilder);
            director.Build(chainBuilder);
            
            
            
            board = dungeonBuilder.GetBoard();
            player = dungeonBuilder.GetPlayer();
            handler = chainBuilder.GetHandler();
            
            
            printer = Printer.GetInstance();
            printer.AddBoard(board);
            Console.Clear();
            Console.WriteLine("Press key to start");
            Console.ReadKey(true);
            
            ReadKey();
        }

        // zawsze drukuje wszystko nie zawsze potrzebnie
        void ReadKey()
        {
            printer.PrintOverlay();
            printer.PrintBoard();
            

            printer.PrintLegend();

            printer.RedrawData();


            ConsoleKeyInfo c;
            do
            {
                c = Console.ReadKey(true);
                Input input = new Input(c, player, board);
                
                
                handler.Handle(input);
                
            } while (c.KeyChar != 'q');
            

            // do
            // {
            //     
            //     (x, y) = board.GetPlayerPosition();
            //    
            //     printer.ResetData();
            //     printer.PrintPlayerData();
            //     printer.PrintFieldData(x,y);
            //     c = Console.ReadKey(true).KeyChar;
            //     
            //     Item? i;
            //     switch (c)
            //     {
            //         case 'a':
            //             printer.PrintField(board.MovePlayer(player, Move.Left));
            //             printer.PrintField((x, y));
            //             continue;
            //         case 'w':
            //             printer.PrintField(board.MovePlayer(player, Move.Up));
            //             printer.PrintField((x, y));
            //             continue;
            //         case 's':
            //             printer.PrintField(board.MovePlayer(player, Move.Down));
            //             printer.PrintField((x, y));
            //             continue;
            //         case 'd':
            //             printer.PrintField(board.MovePlayer(player, Move.Right));
            //             printer.PrintField((x, y));
            //             continue;
            //         case 'p':
            //             board[x, y].ScrollItems();
            //             continue;
            //         case 'e':
            //             board[x, y].DeleteItem()?.AddToPlayerInventory(player);
            //             continue;
            //         case 'o':
            //             board[x, y].AddItem(player.PeekItemInventory()?.DeleteItemFromPlayerInventory(player));
            //             continue;
            //         case 'i':
            //             player.ScrollInventory();
            //             continue;
            //         case 'u':
            //             while((i = player.PeekItemInventory()?.DeleteItemFromPlayerInventory(player)) != null)
            //                 board[x,y].AddItem(i);
            //             continue;
            //         case 'r':
            //             i = board[x, y].PeekItemField();
            //             if(i != null && i.MoveToPlayerHands(player))
            //                 board[x,y].DeleteItem();
            //             continue;
            //         case 'f':
            //             i = player.PeekItemInventory();
            //             if(i != null && i.MoveToPlayerHands(player))
            //                 i.DeleteItemFromPlayerInventory(player);
            //             continue;
            //         
            //         case '1':
            //             player.DeleteItemFromRightHand()?.PlaceOnField(board[x, y]);
            //             continue;
            //         case '2':
            //             player.DeleteItemFromLeftHand()?.PlaceOnField(board[x, y]);
            //             continue;
            //         
            //         case '3':
            //             player.DeleteItemFromRightHand()?.AddToPlayerInventory(player);
            //             continue;
            //         case '4':
            //             player.DeleteItemFromLeftHand()?.AddToPlayerInventory(player);
            //             continue;
            //     }
            // } while (c != 'q');
        }
    }
}
