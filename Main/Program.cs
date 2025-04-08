namespace ProjOb

{
    
    using System.Text;
    
    
    
    public class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            Console.SetBufferSize(1000, 1000);
            
            Console.OutputEncoding = Encoding.UTF8;
            
            new Game();
        }
    }
}
