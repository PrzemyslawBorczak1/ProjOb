namespace ProjOb;

public class RoomStatus
{
    ERoomType roomType;

    public RoomStatus(ERoomType roomType)
    {
        this.roomType = roomType;
    }

    public bool CanHavePlayer() => roomType == ERoomType.Empty;

    public bool HasRepresentation() => roomType == ERoomType.Wall;

    public string? RoomRepresentation()
    {
        if (roomType == ERoomType.Wall)
            return ((char)roomType).ToString();
        
        return null;
    }

    public bool CanHaveItems() =>  roomType == ERoomType.Empty;
    
    
    public bool CanHaveEnemy() => roomType == ERoomType.Empty;

}
