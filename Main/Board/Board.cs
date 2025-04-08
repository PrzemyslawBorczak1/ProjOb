
namespace ProjOb
{
    public class Board 
    {
       // static Printer printer = Printer.GetInstance();
        
        private Field[,] board;

        private Player? player;
        
        private int x;
        private int y;

        //private readonly RoomStatus[] roomTypes = { RoomStatus.Empty, RoomStatus.Items, RoomStatus.Wall };


        public Board(Field[,] board)
        {
            this.board = board;
        }
        

        public void AddPlayer(Player player)
        {
            this.player = player;
            (x,y) = (0, 0);

            board[0, 0].AddPlayer(player);
            player.ChangeField(board[0,0]);
        }
        private void DeletePlayerFromField()
        {
            board[x, y].DeletePlayer();
        }
        
        
        // private void GenerateBoard()
        // {
        //     board = new Field[GetSizeR(),GetSizeC() ];
        //     Random r = new (2137);
        //
        //     for (int i = 0; i < GetSizeR(); i++)
        //     {
        //         for(int j = 0; j < GetSizeC(); j++)
        //         {
        //             int rand = (r.Next(1, 420) * (i + j) % 3);
        //             board[i, j] = new Field(roomTypes[rand]);
        //             if (rand == 1)
        //             {
        //                 
        //                     board[i, j].AddItem(new UnLucky(new UnLucky(new Axe(0))));
        //                     board[i, j].AddItem(new UnLucky(new Sword()));
        //                     board[i, j].AddItem(new Coin());
        //                     board[i, j].AddItem(new Gold());
        //                     board[i, j].AddItem(new BasicItem(3));
        //                     
        //                     board[i, j].AddItem(new Strong(new Axe(0)));
        //                     board[i, j].AddItem(new Strong(new UnLucky(new Strong(new Axe(0)))));
        //                     
        //                     
        //                     board[i, j].AddItem(new Strong(new Strong(new Strong(new Axe(0)))));
        //             }
        //         }
        //     }
        // }
        //
        //
        
        public (int,int) MovePlayer(Player player, Move move)
        {
            var (xNew, yNew, canMove) = CanMove(player, move);

            if (!canMove)
            {
                return (-1, -1);
            }

            DeletePlayerFromField();
            board[xNew, yNew].AddPlayer(player);
            
            return (x, y) = (xNew, yNew);
        }
        
        private (int,int,bool) CanMove(Player player, Move move)
        {
            var (i, j) = (x, y);

            switch (move)
            {
                case Move.Up:
                    j--;
                    break;
                case Move.Down:
                    j++;
                    break;
                case Move.Left:
                    i--;
                    break;
                case Move.Right:
                    i++;
                    break;
            }
            
            if (i < 0 || j < 0 || j >= GetSizeX() || i >= GetSizeY() ||
                       !board[i,j].CanHavePlayer())
                return (-1,-1,false);
            
            return (i,j,true);
        }
        
        public (int, int) GetPlayerPosition() => (x,y);
        public Player? GetPlayer() => player;
        public Field this[int i, int j]
        {
            get => board[i, j];
            set => board[i, j] = value;
        }
        public int GetSizeX() => board.GetLength(1);
        public int GetSizeY() => board.GetLength(0);
    }
}
