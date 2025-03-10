using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main 
{
    public class Printer
    {
       public Board board;
       int indent = 20;
       private int boardBeginingR;
       private int boardBeginingC;
       private int buffer;
       private int legend;

       int dataTop = 0;
       public Printer(Board board)
        {
            this.board = board;
        }
       
        public void PrintField((int,int) position) => PrintField(position.Item1, position.Item2);
        public void PrintField(int i, int j)
        {
            if(i < 0 || j < 0)
            {
                return;
            }
            
            Console.SetCursorPosition(boardBeginingR + i, boardBeginingC + j);
            ConsoleColor color;
            string text;
            (color,text) = board[i, j].PrintData();
                
            Console.ForegroundColor = color;
            Console.Write(text);
            Console.ResetColor();
        }
        
        public void PrintOverlay()
        {
            int x = board.GetSizeR();
            int y = board.GetSizeC();
            
            
            Console.Clear(); 
            
            Console.ForegroundColor = ConsoleColor.Yellow;
            for (int i = 1; i < y + 1; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.Write("█");
                Console.SetCursorPosition(x + 1, i);
                Console.Write("█");
            }

            for (int i = 1; i < x + 1; i++)
            {
                Console.SetCursorPosition(i, 0);
                Console.Write("\u2584");
                Console.SetCursorPosition(i, y + 1 );
                Console.Write("\u2580");
            }
            

            boardBeginingR = 1;
            boardBeginingC = 1;

            buffer = x + 2 + indent + 1;
            legend = y + 2;
            Console.ResetColor();
            
            PrintLegend();
        }
        public void PrintBoard()
        {
            for(int i = 0; i < board.GetSizeR(); i++)
            {
                for(int j = 0; j < board.GetSizeC(); j++)
                {
                    PrintField(i,j);
                }
                Console.WriteLine();
            }
        }
        
/*
        public void PrintPlayerAttributes(Player player)
        {
            PrintData(player.GetAttributes());
            /*
            Console.SetCursorPosition(buffer, dataTop++);
            for (int j = 0; j < 10; j++)
            {
                Console.Write("=");
            }
            int i = 1;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(buffer,  dataTop++);
            Console.Write("Attributes: ");
            Console.ResetColor();
            foreach (var attribute in player.GetAttributes())
            {
                if (i > 5){
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(buffer + 3, dataTop++);
                    Console.Write("...");
                    
                    Console.ResetColor();
                    break;
                }

                Console.SetCursorPosition(buffer,  dataTop++);
                Console.Write(attribute);
                i++;
            }
            
            Console.SetCursorPosition(buffer, dataTop++);
            for (int j = 0; j < 10; j++)
            {
                Console.Write("=");
            }
        }
            */

        public void PrintData(IEnumerable<string>? data)
        {
            
            
            Console.SetCursorPosition(buffer, dataTop++);
            for (int j = 0; j < 10; j++)
            {
                Console.Write("=");
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            int i = 1;
            
            foreach (var attribute in data)
            {
                if (i > 6){
                    
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.SetCursorPosition(buffer + 3, dataTop++);
                    Console.Write("...");
                    
                    Console.ResetColor();
                    break;
                }

                Console.SetCursorPosition(buffer,  dataTop++);
                Console.Write(attribute);
                i++;
            }
            
            Console.ResetColor();
        }

        public void ResetData()
        {
            
            for (int i = dataTop; i > 0; i--)
            {
                Console.SetCursorPosition(buffer, i);
                for (int j = 0; j < 60; j++)
                    Console.Write(" ");
            }
            dataTop = 0;
        }

        public void PrintLegend()
        {
            Console.SetCursorPosition(0, legend);
            Console.WriteLine("""
                              (W/A/S/D) to move
                              E - pick up item
                              P - scroll items on the field
                              O - drop item
                              I - scroll inventory
                              U - drop all items from inventory
                              R - take item from field to free hand
                              F - take item form inventory to free hand
                              1/2 - drop item from right/left hand on the field
                              3/4 - move item from right/left hand to inventory 
                              """); 
        }


    }
}
