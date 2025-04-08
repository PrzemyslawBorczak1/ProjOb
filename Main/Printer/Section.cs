using System.Text;

namespace ProjOb;

public class Section
{
    StringBuilder data = new StringBuilder();

    private int width;
    private int height;
    
    private int position;


    public void Addstring(string str)
    {
        data.Append("\n");
        data.Append(str);
    }
    
    
}