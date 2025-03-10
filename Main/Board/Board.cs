﻿
namespace Main
{
    public class Board 
    {
        const int R = 30;
        const int C = 40;


        public Field[,] board;

        Player? player;
        int x;
        int y;

        private RoomType[] roomTypes = { RoomType.Empty, RoomType.Items, RoomType.Wall };
     

        public Board() => GenerateBoard();
        public Board(Player player){ 
            AddPlayer(player);
            GenerateBoard();
        }

        public void AddPlayer(Player player)
        {
            this.player = player;
            (x,y) = (0, 0);

            board[0, 0].SetRoomType(RoomType.Player);
            board[0, 0].AddPlayer(player);
            player.ChangeField(board[0,0]);
        }
        public void DeletePlayerFromField()
        {
            board[x, y].DeletePlayer();
            
        }
        
        public void GenerateBoard()
        {
            board = new Field[GetSizeR(),GetSizeC() ];
            Random r = new Random(2137);

            for (int i = 0; i < GetSizeR(); i++)
            {
                for(int j = 0; j < GetSizeC(); j++)
                {
                    int rand = (r.Next(1, 420) * (i + j) % 3);
                    board[i, j] = new Field(roomTypes[rand]);
                    if (rand == 1)
                    {
                            board[i, j].AddItem(new Strong(new UnLucky(new UnLucky(new Strong(new Bow(0))))));
                            board[i, j].AddItem(new UnLucky(new UnLucky(new Axe(0))));
                            board[i, j].AddItem(new UnLucky(new Coin()));
                            board[i, j].AddItem(new Strong(new UnLucky(new Gold())));
                            board[i,j].AddItem(new Strong(new BasicItem(0)));
                            board[i,j].AddItem(new UnLucky(new Strong(new BasicItem(0))));
                    }
                }
            }
        }
        public (int,int) MovePlayer(Player player, Move move)
        {
            int xNew, yNew;
            bool canMove;
            (xNew, yNew, canMove) = CanMove(player, move);
            if (!canMove)
                return (-1,-1);

            DeletePlayerFromField();
            board[xNew, yNew].AddPlayer(player);
            (x, y) = (xNew, yNew);
            return (xNew, yNew);
        }

        public (int,int,bool) CanMove(Player player, Move move)
        {
            int i, j;
            (i, j) = (x, y);

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
            if (i < 0 || j < 0 || j >= GetSizeC() || i >= GetSizeR() ||
                       board[i,j].GetRoomType() == RoomType.Wall)
                return (-1,-1,false);
            
            return (i,j,true);
        }

        public (int, int) GetPlayerPosition() => (x,y);
        public Player GetPlayer() => player;

        public Field this[int i, int j]
        {
            get => board[i, j];
            set => board[i, j] = value;
        }

        public int GetSizeR() => C;
        public int GetSizeC() => R;
       

       

    }
}
