using Agario;
using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace SeaBattle2
{
    public class Menu : Iscene
    {
        private LoadRandomImage _loadRandomImage = new LoadRandomImage();
        private RenderWindow _window;

        private Sprite _backgroundSprite = new Sprite();
        private Sprite _startButtonSprite = new Sprite();

        public bool _startButtonPressed = false;
        public Action OnStart;

        float Buttonscale = 0.2f;
        private float BagroundScale = 2f;

        public int ZIndex { get; set; } = 1;

        public Menu(RenderWindow window)
        {
            _window = window;
            _window.MouseButtonPressed += OnMouseButtonPressed;
        }
        
      
        public void Load()
        {
            Engine.Engine.Instance.RegisterActor(this,this);
            DrawMenu();
        }

        
        public void Update(float deltaTime)
        {
            
        }

        public void Draw(RenderTarget target)
        {
            target.Draw(_backgroundSprite);
            target.Draw(_startButtonSprite);
        }

        public void Unload()
        {
            Engine.Engine.Instance.drawables.Remove(this);
            Engine.Engine.Instance.updatables.Remove(this);
        }
        
        public void DrawMenu()
        {
            Texture backgroundTexture = _loadRandomImage.LoadRandomImageFromFile("Images");
            _backgroundSprite.Texture = backgroundTexture;
            _backgroundSprite.Position = new Vector2f(0f, 0f);
            _backgroundSprite.Scale = new Vector2f(BagroundScale, BagroundScale);

            Texture buttonTexture = _loadRandomImage.LoadRandomImageFromFile("ButtonImages");
            _startButtonSprite.Texture = buttonTexture;
            _startButtonSprite.Position = new Vector2f(1050, 500f);

            
        
            _startButtonSprite.Scale = new Vector2f(Buttonscale, Buttonscale);
        }
       

        private void OnMouseButtonPressed(object sender, MouseButtonEventArgs e)
        {
            if (e.Button == Mouse.Button.Left)
            {
                Vector2i mousePosition = Mouse.GetPosition(_window);
                Vector2f convertedPosition = _window.MapPixelToCoords(mousePosition);

                if (_startButtonSprite.GetGlobalBounds().Contains(convertedPosition.X, convertedPosition.Y))
                {
                    _startButtonPressed = true;
                    OnStart?.Invoke();
                    Unload();
                }
            }
        }

     
    }
}