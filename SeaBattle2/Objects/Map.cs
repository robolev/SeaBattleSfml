namespace SeaBattle2;

public class Map
{
     public enum CellState
    {
        Empty,
        Ship,
        Hit,
        Miss,
        Wave,
        DoubleWave,
        TripleWave,
    }

     static int gridSize = 10;


    private Cell currentField;

    static Random rand = new Random();

    public void SetCurrentField(Cell field)
    { 
        currentField = field;
    }
        
    public Cell GetCurrentfield()
    { 
        return currentField;          
    }
}
