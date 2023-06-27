using System.Numerics;

namespace SeaBattle2;

public class LevelGenerator
{
	private static Random? random;

	public static Cell[,] GenerateLevel()
	{
		random = new Random ();
		var level = MakeEmptyMap ();

		PlaceShips(ref level);

		return level;
	}

	public static Cell[,] MakeEmptyMap()
	{
		var level = new Cell[Config.MapSizeX, Config.MapSizeY];
		
		for (int x = 0; x < Config.MapSizeX; x++)
		{
			for (int y = 0; y < Config.MapSizeY; y++)
			{
				level[x, y] = new Cell(new Vector2(x, y), Map.CellState.Empty);
			}
		}

		return level;
	}

	public static void PlaceShips(ref Cell[,] map)
	{
		var ships = Config.ShipConfigurations;
		ships = ships.Sort(SortShipConfigExtensions.SortTypes.FromLongestToShortest);
		foreach(var ship in ships)
		{
			for (int i = 0; i < ship.Value.count; i++)
			{
				PlaceShip(ref map, ship.Key, ship.Value.length);
			}
		}
	}


	private static void PlaceShip(ref Cell[,] map, Config.ShipType ship, int length = 1)
	{
		bool isPlaced = false;
		int xLength = map.GetLength(0);
		int yLength = map.GetLength(1);

		while (!isPlaced)
		{
		
			int x = random.Next(xLength);
			int y = random.Next(yLength);

			
			int orientation = random.Next(2);

	
			if ((orientation == 0 && x + length <= xLength) ||
			    (orientation == 1 && y + length <= yLength))
			{
			
				bool overlaps = false;

				for (int i = -1; i <= length; i++)
				{
					for (int j = -1; j <= 1; j++)
					{
						int cx = x + (orientation == 0 ? i : 0);
						int cy = y + (orientation == 1 ? i : 0);

					
						for (int ii = -1; ii <= 1; ii++)
						{
							for (int jj = -1; jj <= 1; jj++)
							{
								int tx = cx + ii;
								int ty = cy + jj;

								if (tx >= 0 && tx < xLength && 
								    ty >= 0 && ty < yLength && 
								    map[tx, ty].CellType != Map.CellState.Empty)
								{
									overlaps = true;
									break;
								}
							}

							if (overlaps) break;
						}

						if (overlaps) break;
					}

					if (overlaps) break;
				}

				
				if (!overlaps)
				{
					Cell[] shipCells = new Cell[length];
					for (int i = 0; i < length; i++)
					{
						int cx = x + (orientation == 0 ? i : 0);
						int cy = y + (orientation == 1 ? i : 0);
						Ship shipObj = new Ship(new Vector2(cx, cy), ship);
						shipCells[i] = shipObj;
						map[cx, cy] = shipObj;
					}

		
					foreach(var cell1 in shipCells)
					{
						var cell = (Ship) cell1;
						cell.ShipCells = shipCells;
					}

					isPlaced = true;
				}
			}
		}
	}
}
