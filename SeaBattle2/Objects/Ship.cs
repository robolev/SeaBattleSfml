using System.Numerics;
using SFML.System;

namespace SeaBattle2;

public class Ship : Cell
{
    public Cell[] ShipCells;
    public Config.ShipType shipType;
	
    public Ship(Vector2 position, Config.ShipType ship) : base(position)
    {
        base.CellType = Map.CellState.Ship;
        shipType = ship;
        base.Position = position;
    }
	
    public override void ProcessDefenseHit()
    {
        base.CellType = Map.CellState.Hit;
    }
	
    public bool IsAlive()
    {
        return ShipCells.Any(cell => cell.CellType == Map.CellState.Ship);
    }

}