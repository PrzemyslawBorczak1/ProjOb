using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace ProjOb 
{
    public sealed class Printer
    {
        private Board? board;
        private Player? player;

        private bool MazeHasItems = false;
        private bool MazeHasEnemies = false;

        int indent = 10;
        private int boardBeginingY;
        private int boardBeginingX;
        
        private int buffer;
        private int legend;
        private int legendTop;
        
        private string legendStr;

        private int dataTop = 0;

        private int potions;
        private int potionsTop = 0;


        //
        // private List<Section> sections = new ();
        // private Dictionary<string, Section> sectionsMap = new();



        private static Printer? _instance = null;

        public static Printer GetInstance()
        {
            if (_instance == null)
                _instance = new Printer();

            return _instance;

        }

        private Printer()
        {
        }
        
        public void SetMazeHasItems(bool cond) => MazeHasItems = cond;
        public void SetMazeHasEnemies(bool cond) => MazeHasEnemies = cond;
        public void SetPlayer(Player player) => this.player = player;
        public void AddBoard(Board board)
        {
            this.board = board;
            this.player = board.GetPlayer();
        }

        public void PrintField((int, int) position) => PrintField(position.Item1, position.Item2);

        public void PrintField(int i, int j)
        {
            if (board == null)
                return;

            if (i < 0 || j < 0)
            {
                return;
            }

            Console.SetCursorPosition(boardBeginingX + i, boardBeginingY + j);

            var (color, text) = board[i, j].PrintData();

            Console.ForegroundColor = color;     
            Console.Write(text);
            Console.ResetColor();
        }

        public void PrintOverlay()
        {
            if (board == null)
            {

                boardBeginingX = 0;
                boardBeginingY = 0;

                buffer = 4 * indent;
                legend = 0;
                return;
            }

            int x = board.GetSizeY();
            int y = board.GetSizeX();


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
                Console.SetCursorPosition(i, y + 1);
                Console.Write("\u2580");
            }


            boardBeginingX = 1;
            boardBeginingY = 1;

            buffer = x + 2 + indent + 1;
            legend = y + 2;
            legendTop = legend;
            potions = buffer + 30;
            Console.ResetColor();

        }

        public void PrintBoard()
        {
            if (board == null)
                return;
            
            for (int i = 0; i < board.GetSizeY(); i++)
            {
                for (int j = 0; j < board.GetSizeX(); j++)
                {
                    PrintField(i, j); 
                }
            }
        }

        public void ResetData()
        {

            string spaces = new string(' ', 60);
            for (int i = dataTop; i > 0; i--)
            {
                Console.SetCursorPosition(buffer, i);
                Console.Write(spaces);
            }

            dataTop = 0;
        }

        public void GetPrintData(IEnumerable<string>? data)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            int i = 1;

            foreach (var attribute in data)
            {
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write(attribute);
                i++;
            }

            Console.ResetColor();
        }
        public void PrintPlayerData()
        {
            if (player == null)
                return;
            
            Console.SetCursorPosition(buffer, dataTop++);
            Console.Write("Player:");
            GetPrintData(player.GetAttributesData());
            Console.SetCursorPosition(buffer, dataTop++);
            Console.Write("========");

            PrintActivEfects();

            if (MazeHasItems)
            {
                GetPrintData(player.GetAssets());
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("========");

                GetPrintData(player.GetHandsString());
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("========");
            }

            if (player.HasElixirs())
            {
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("Elixirs:");
                GetPrintData(player.GetElixirsString());

                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("========");
            }
            

            if (player.GetInventory().Count != 0)
            {

                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("Inventory:");
                GetPrintData(player.GetInventoryString());

                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("========");
            }

        }

        public void PrintFieldData(int i, int j)
        {
            if(MazeHasEnemies && player != null)
                PrintClosestEnemy(i, j);
            PrintFieldItems(i, j);

        }

        public void PrintFieldItems(int i, int j)
        {
            if (board == null)
                return;

            Field field = board[i, j];

            if (field.GetItems().Count != 0)
            {
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("Items on the field");
                GetPrintData(field.GetItemsNames());
                Console.SetCursorPosition(buffer, dataTop++);
                Console.Write("========");

            }

        }

        public void PrintClosestEnemy(int i, int j)
        {
            Enemy? enemy = board[i, j].GetEnemy();
            string enemyName = " ";

            int iNew, jNew;
            if (enemy == null)
            {
                for (int k = -1; k <= 1; k++)
                {
                    for (int l = -1; l <= 1; l++)
                    {
                        iNew = i + k;
                        jNew = j + l;


                        if (iNew >= 0 && iNew < board.GetSizeY() && jNew >= 0 && jNew < board.GetSizeX())
                        {
                            if (board[iNew, jNew].HasEnemy())
                            {
                                enemy = board[iNew, jNew].GetEnemy();
                                enemyName = enemy!.GetName();
                            }
                        }
                    }

                }

            }
            else
                enemyName = enemy.GetName();

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(buffer, dataTop++);
            Console.Write("Closest Enemy: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(enemyName);
            Console.ResetColor();
            Console.SetCursorPosition(buffer, dataTop++);
            Console.Write("========");

        }

        public void ResetLegend()
        {
            
            string spaces = new string(' ', 60);
            for ( ; legendTop > legend; legendTop--)
            {
             
                Console.SetCursorPosition(0, legendTop);
                Console.Write(spaces);   
            }
            
        }

        public void AddLegened(string legend) => legendStr = legend;

        public void PrintLegend()
        {

            if (player != null)
            {
                Console.SetCursorPosition(0, legend);
                Console.WriteLine(legendStr);
            }



            }

        public void PrintAction(string action, ConsoleColor color = ConsoleColor.DarkCyan)
        {
            Console.SetCursorPosition(buffer, dataTop++ );
            Console.ForegroundColor = color;
            Console.Write(action);
            Console.ResetColor();
            
        }
        
       
        public void RedrawData()
        {
            
            ResetData();

            PrintPlayerData();
            PrintActivEfects();
            
            if (board != null)
            {
                var (x, y) = board.GetPlayerPosition();
                PrintFieldData(x, y);
            }
        }
        



        public void PrintActivEfects()
        {
            Console.ForegroundColor = ConsoleColor.DarkCyan;

            ResetActivEfects();
            if (player == null)
                return;
            foreach(var at in player.GetAttributes())
            {
                foreach (var mod in at.GetModifiers())
                {
                    Console.SetCursorPosition(potions, potionsTop++);
                    Console.Write(mod.GetEfectRepresentation());
                }
            }
            Console.ResetColor();
        }

        public void ResetActivEfects()
        {

            string spaces = new string(' ', 40);
            while (potionsTop > 0)
            {
                Console.SetCursorPosition(potions, potionsTop--);
                Console.Write(spaces);
            }

            Console.SetCursorPosition(potions, potionsTop);
            Console.Write(spaces);
        }

    }
}
