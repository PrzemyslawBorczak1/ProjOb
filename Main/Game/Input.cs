namespace ProjOb;

public class Input
{
    
    private ConsoleKeyInfo c;
    private Player player;
    private Board board;
    private Object? additionalData;
    public Input(ConsoleKeyInfo c, Player player, Board board, Object? additionalData = null)
    {
        this.c = c;
        this.player = player;
        this.board = board;
        this.additionalData = additionalData;
       
    }
    public void SetKey(ConsoleKeyInfo c) => this.c = c;
    public void SetKey(char c)
    {

        ConsoleKey key = (ConsoleKey)char.ToUpper(c);
        SetKey(new ConsoleKeyInfo(c, key, false, false, false));
    }
    
    public void SetAdditionalData(Object additionalData) => this.additionalData = additionalData;
    public ConsoleKeyInfo GetKey() => c;
    public char GetChar() => c.KeyChar;
    public Player GetPlayer() => player;
    public Board GetBoard() => board;
    
    public Object? GetAdditionalData() => additionalData;
}