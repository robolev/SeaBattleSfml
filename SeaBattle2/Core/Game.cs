using Agario.Agario.Objects.Interfaces;
using Engine.Config;
using SFML.Graphics;

namespace SeaBattle2;

public class Game:GameCore
{

    public  View camera;
    
    public static Game Instance { get; private set; }

    private Menu _menu;
    private GameScene _game;
    private PlayerTypeSelection _playerType;

    private List<Iscene> _scenes = new List<Iscene>();

    public Game()
    {
        camera = new View(new FloatRect(0f, 0f, EngineConfig.WindowWidth, EngineConfig.WindowHeight));
        
    }
    
    public override void Initialize()
    {
         _menu = new Menu(Engine.window);
         _menu.OnStart += OnStart; 
         _scenes.Add(_menu);
         _scenes[0].Load();
         _game = new GameScene();
         _playerType = new PlayerTypeSelection();
    }

    private void OnStart()
    {
        _scenes.Add(_playerType);
        _scenes[1].Load();
        _playerType.LoadGame += LoadGame;
    }

    private void LoadGame()
    {
        _scenes.Add(_game);
        _scenes[2].Load();
    }


    protected override void OnFrameStart()
    {
         
    }

    protected override void OnFrameEnd()
    {
      
    }

    protected override void OnWindowClosed(object sender, EventArgs args)
    {
        
    }

}