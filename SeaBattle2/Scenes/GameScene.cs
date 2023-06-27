using SFML.Graphics;

namespace SeaBattle2;

public class GameScene:Iscene
{
    public int ZIndex { get; set; } = 1;


    static int gridSize = 10;
    private static Cell[,] field1 = new Cell[gridSize, gridSize];
    private static Cell[,] field2 = new Cell[gridSize, gridSize];

    private Map map = new Map();
    private GridMap _gridMap;
    
    static bool player1Turn;
    
    public void Load()
    {
        
        Engine.Engine.Instance.RegisterActor(this,this);
        field1 = LevelGenerator.GenerateLevel();
        field2 = LevelGenerator.GenerateLevel();
        _gridMap = new GridMap(field1);
    }
    
    public void Draw(RenderTarget target)
    {
        _gridMap.Draw(target);
    }

 
    public void Update(float deltaTime)
    {
        Cell[,] currentfild = player1Turn ? field2 : field1;
        
         _gridMap.SetCurrentField(currentfild);
    }

  

    public void Unload()
    {
        Engine.Engine.Instance.drawables.Remove(this);
        Engine.Engine.Instance.updatables.Remove(this);
    }
}