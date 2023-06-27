using System.Numerics;
using SFML.Graphics;

namespace SeaBattle2;

public class Cell
{
    public Vector2 Position;
    public Map.CellState CellType { get; set; } = Map.CellState.Empty;

    public Texture cell;
    public Cell(Vector2 position, Map.CellState cellType)
    {
        Position = position;
        CellType = cellType;
    }

    public Cell(Vector2 position)
    {
        Position = position;
        CellType = Map.CellState.Empty;
    }

    public virtual void ProcessDefenseHit()
    {
        CellType = Map.CellState.Hit;
    }
	
    public bool IsAlreadyHit()
    {
        return CellType == Map.CellState.Hit || CellType == Map.CellState.Miss;
    }
	
    public bool InBounds()
    {
        return Position.X >= 0 && Position.X < 10 && Position.Y >= 0 && Position.Y < 10;
    }
    

    public object PixelMap { get; set; }
    
    public virtual void ProcessAttackHit(Map map, Vector2 coords)
    {
        Cell cell = map.GetCurrentfield();
        if (cell.CellType == Map.CellState.Ship)
        {
            Console.WriteLine("Hit!");
            CellType = Map.CellState.Hit;
        }
        else
        {
            Console.WriteLine("Miss!");
            CellType = Map.CellState.Miss;
        }
    }
}
