namespace ProjOb;

using System.Reflection;
public class DungeonBuilder : IBuilder
{
    // doadac wartosci dla ilosci itemow dla losowania
    
    int X = 21;
    int Y = 61;

     int MaxRandAmount;
     int MinRandAmount;

     int maxChambersAmount;
     int minChambersAmount;


    public Field[,] board;
    public Board? readyBoard;
    
    public Player? player;
    private Printer printer = Printer.GetInstance();
    
    Random random = new Random();

    private Type[] WeaponDecorators;
    private Type[] Weapons;

    private Type[] Assets;
    private Type[] Potions;

    private Type[] Items = { typeof(Rock), typeof(Stick) };

    private Type[] Enemies;


    public DungeonBuilder()
    {
        WeaponDecorators = WeaponDec.GetWeaponDecorators();
        Weapons = Weapon.GetWeapons();
        Assets = Asset.GetAssets();
        
        Potions = Potion.GetPotions();

        Enemies = Enemy.GetEnemies();
        
        SetProbabilities();

    }

    public virtual void SetProbabilities()
    {
        
        MaxRandAmount = 2 * (X + Y);
        MinRandAmount = 0;
        
        maxChambersAmount = X * Y;
        minChambersAmount = X * Y / 2;
    }

    public void AddPlayer()
    {
        if(player == null)
            player = new Player();

        if (readyBoard != null)
        {
            readyBoard.AddPlayer(player);
        }
    }

    public void GenerateEmptyDungeon()
    {
        board = new Field[Y, X];

        for (int i = 0; i < Y; i++)
        {
            for (int j = 0; j < X; j++)
            {
                board[i, j] = new Field();
            }
        }

    }

    public void GenerateFilledDungeon()
    {
        printer.SetMazeHasItems(false);
        board = new Field[Y, X];

        for (int i = 0; i < Y; i++)
        {
            for (int j = 0; j < X; j++)
            {
                board[i, j] = new Field(ERoomType.Wall);
            }
        }

    }
    
    public void GeneratePaths()
    {
        
        Stack<(int, int)> stack = new Stack<(int, int)>();
        int x = 0;
        int y = 0;

        int[,] maze = new int[Y, X];
        int[] dx = [-2, 0, 0, 2];
        int[] dy = [0, -2, 2, 0];

        stack.Push((y, x));
        (int, int) nextMove = (y, x);
        while (stack.Count > 0)
        {
            bool move = true;
            nextMove = stack.Pop();
            while (move)
            {
                move = false;
                (y, x) = nextMove;
                int xn, yn;
                int rand = random.Next(0, 4);
                
                maze[y, x] = 1;
                for (int i = 0; i < 4; i++)
                {
                    xn = x + dx[rand];
                    yn = y + dy[rand];

                    if (xn < 0 || xn >= X || yn < 0 || yn >= Y)
                    {
                        
                        rand++;
                        rand %= 4;
                        continue;
                    }

                    if (maze[yn, xn] == 0)
                    {
                        stack.Push((yn, xn));
                        nextMove = (yn, xn);
                        move = true;
                        maze[yn, xn] = 1;

                        maze[yn - dy[rand] / 2, xn - dx[rand] / 2] = 1;
                        break;
                    }

                    rand++;
                    rand %= 4;
                }
            }
        }

        
        board[0, 0].ChangeRoomStatus(ERoomType.Empty);
        for (int i = 0; i < Y; i++)
        {
            for (int j = 0; j < X; j++)
            {
                if (maze[i, j] == 1)
                    board[i, j].ChangeRoomStatus(ERoomType.Empty);
            }

        }

    }

    
    
    // duzo powatrzania kodu here do poprawy
    public void AddChambers()
    {

        int chambers = random.Next(minChambersAmount, maxChambersAmount);
        for (int i = 0; i < chambers; i++)
        {
            board[random.Next(Y),random.Next(X)].ChangeRoomStatus(ERoomType.Empty);
        }
    }

    public void AddCentralRoom()
    {
        for (int dy = -2; dy <= 2; dy++)
        {
            for (int dx = -3; dx <= 3; dx++)
            {
                int nx = X/2 + dy;
                int ny = Y/2 + dx;

                if (nx >= 0 && nx < X && ny >= 0 && ny < Y)
                {
                    board[ny, nx].ChangeRoomStatus(ERoomType.Empty);
                }
            }
        }
    }

    // public void AddRandomItems()
    // {
    //     int chambers = random.Next(X + Y,X * Y);
    //     for (int i = 0; i < chambers; i++)
    //     {
    //    //     board[random.Next(Y),random.Next(X)].AddItem();
    //     }
    // }


    public void AddWeapons()
    {
        
        printer.SetMazeHasItems(true);
        int amount = random.Next(MinRandAmount, MaxRandAmount);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int nb = random.Next(Weapons.Length);
            if (board[y, x].CanHaveItems())
            {
                object? it = Activator.CreateInstance(Weapons[nb],new object[] {random.Next(10)});
                if (it != null)
                    board[y, x].AddItem((Item)it);

            }
        }
    }


    public void AddPotions()
    {
        
        printer.SetMazeHasItems(true);
        int amount = random.Next(MinRandAmount, MaxRandAmount);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int nb = random.Next(Potions.Length);
            if (board[y, x].CanHaveItems())
            {
                object? it = Activator.CreateInstance(Potions[nb]);
                if (it != null)
                    board[y, x].AddItem((Item)it);

            }
        }
    }

    public void AddModifiedWeapons()
    {
        
        printer.SetMazeHasItems(true);
        int amount = random.Next(0, MaxRandAmount / 4);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int wepNb = random.Next(Weapons.Length);
            object? wep = Activator.CreateInstance(Weapons[wepNb],new object[] {random.Next(10)});
            if (wep == null)
                return;
            
            
            int decNb = random.Next(WeaponDecorators.Length);
            object? decWep = Activator.CreateInstance(WeaponDecorators[decNb], new object[] { wep });
            if (decWep == null)
                return;

            if (random.Next(2) == 1)
            {
                decNb = random.Next(WeaponDecorators.Length);
                decWep = Activator.CreateInstance(WeaponDecorators[decNb], new object[] { decWep });
            }
            
            
            if (board[y, x].CanHaveItems())
            {
                if (decWep != null)
                    board[y, x].AddItem((Item)decWep);

            }
        }
    }
    
    public void AddItems(){
        
        printer.SetMazeHasItems(true);
        int amount = random.Next(MinRandAmount, MaxRandAmount);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int nb = random.Next(Items.Length);
            if (board[y, x].CanHaveItems())
            {
                object? it = Activator.CreateInstance(Items[nb]);
                if (it != null)
                    board[y, x].AddItem((Item)it);

            }
        }
    }

    public void AddEnemies()
    {
        printer.SetMazeHasEnemies(true);
        int amount = random.Next(MinRandAmount, MaxRandAmount);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int nb = random.Next(Enemies.Length);
            if (board[y, x].CanHaveItems())
            {
                object? it = Activator.CreateInstance(Enemies[nb]);
                if (it != null && board[y, x].CanHaveEnemy())
                    board[y, x].AddEnemy((Enemy)it);

            }
        }
    }

    public void AddAssets()
    {
        
        printer.SetMazeHasItems(true);
        int amount = random.Next(0, MaxRandAmount/4);
        for (int i = 0; i < amount; i++)
        {
            int y = random.Next(Y);
            int x = random.Next(X);

            int nb = random.Next(Assets.Length);
            if (board[y, x].CanHaveItems())
            {
                object? it = Activator.CreateInstance(Assets[nb]);
                if (it != null)
                    board[y, x].AddItem((Item)it);

            }
        }
    }


    public Board GetBoard()
    {
        if (readyBoard == null)
        {
            readyBoard = new Board(board);
            if(player != null)
                readyBoard.AddPlayer(player);
        }

        return readyBoard;
    }

    public Player GetPlayer() => player;
}
