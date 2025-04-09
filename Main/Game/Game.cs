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
            Console.ForegroundColor = ConsoleColor.White;
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
            

           
        }
    }
}
