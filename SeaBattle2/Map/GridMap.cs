using Agario;
using Agario.Agario.Objects.BaseObject;
using SFML.Graphics;
using SFML.System;

namespace SeaBattle2
{
    public class GridMap : BaseObject, IDrawable
    {
        private const int GridSize = 10;
        private const float CellSize = 60f;
        private const float GridOffsetX = 10f;
        private const float GridOffsetY = 10f;

        private Cell[,] currentField;

        private Texture emptyTexture;
        private List<Texture> shipTextures; 
        private Texture hitTexture;
        

        private Sprite[,] gridSprites;

        private Ship _ship;

        private Cell _cell;

        public int ZIndex { get; set; } = 2;

        public GridMap( Cell[,] field)
        {
            currentField = field;

            emptyTexture = new Texture(Path.Combine(Directory.GetCurrentDirectory(),"empty.png"));
            hitTexture = new Texture(Path.Combine(Directory.GetCurrentDirectory(),"hit.png"));

           
            shipTextures = new List<Texture>();
            var files = Directory.GetFiles(Path.Combine(Directory.GetCurrentDirectory(), "ShipSprite"), "*.png");
             
            
            foreach (var file in files)
            {
                shipTextures.Add(new Texture(file));
            }

            gridSprites = new Sprite[GridSize, GridSize];
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    gridSprites[i, j] = new Sprite(emptyTexture,new IntRect(0,0,70,63));
                    
                }
            }
        }

        public void Draw(RenderTarget target)
        {
            for (int i = 0; i < GridSize; i++)
            {
                for (int j = 0; j < GridSize; j++)
                {
                    if (currentField[i, j] == null)
                    {
                        Console.WriteLine("nothing");
                        return;
                    }

                    Vector2f position = new Vector2f(GridOffsetX + i * CellSize, GridOffsetY + j * CellSize);
                    gridSprites[i, j].Position = position;

                    switch (currentField[i, j].CellType)
                    {
                        case Map.CellState.Empty:
                            gridSprites[i, j].Texture = emptyTexture;
                            break;
                        case Map.CellState.Ship:
                            gridSprites[i, j].Texture = shipTextures[0];
                           SetWarships();
                           gridSprites[i, j].Texture = currentField[i, j].cell;
                           break;
                        case Map.CellState.Hit:
                            gridSprites[i, j].Texture = hitTexture;
                            break;
                        default:
                            Console.WriteLine("ne podoshlo");
                            break;
                      
                    }

                    target.Draw(gridSprites[i, j]);
                }
            }
        }

        public void SetWarships()
        {
            if (_cell is Ship)
            {
                switch (_ship.shipType)
                {
                    case Config.ShipType.Small:
                        _ship.ShipCells[0].cell = shipTextures[0]; 
                        _ship.ShipCells[1].cell = shipTextures[4]; 
                        break;
                    case Config.ShipType.Medium:
                        _ship.ShipCells[0].cell = shipTextures[0]; 
                        _ship.ShipCells[1].cell = shipTextures[2];
                        _ship.ShipCells[2].cell = shipTextures[4];
                        break; 
                    case  Config.ShipType.Large:
                        _ship.ShipCells[0].cell = shipTextures[0]; 
                        _ship.ShipCells[1].cell = shipTextures[1];
                        _ship.ShipCells[2].cell = shipTextures[2];
                        _ship.ShipCells[3].cell = shipTextures[4];
                        break;
                    case Config.ShipType.Huge:
                        _ship.ShipCells[0].cell = shipTextures[0]; 
                        _ship.ShipCells[1].cell = shipTextures[1];
                        _ship.ShipCells[2].cell = shipTextures[2];
                        _ship.ShipCells[3].cell = shipTextures[3];
                        _ship.ShipCells[4].cell = shipTextures[4];
                        break;
                }
                
            }
        }

        public void SetCurrentField(Cell[,] field)
        {
            currentField = field;
        }
    }
}