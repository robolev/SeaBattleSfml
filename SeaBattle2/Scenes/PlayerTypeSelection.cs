using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace SeaBattle2
{
    public class PlayerTypeSelection:Iscene
    {
        private RenderWindow window;
        private bool isMachine;
        private bool selectionMade;

        public bool IsMachine => isMachine;
        
        public Action LoadGame;

        public int ZIndex { get; set; } = 1;
        
        public PlayerTypeSelection()
        {
            this.selectionMade = false;
        }

        public void Load()
        {
            Engine.Engine.Instance.RegisterActor(this,this);
        }
        
        public void Draw(RenderTarget target)
        {
            ShowPlayerTypeSelection();
        }

        
        public void Update(float deltaTime)
        {
           
        }

       

        public void Unload()
        {
            Engine.Engine.Instance.drawables.Remove(this);
            Engine.Engine.Instance.updatables.Remove(this);
            LoadGame.Invoke();
        }
        
        
        public void ShowPlayerTypeSelection()
        {
            Text titleText = new Text("Choose player type for this player:", new Font("arial.ttf"), 24);
            titleText.Position = new Vector2f(100f, 100f);

            Text humanText = new Text("1. Human", new Font("arial.ttf"), 20);
            humanText.Position = new Vector2f(100f, 150f);

            Text machineText = new Text("2. Machine", new Font("arial.ttf"), 20);
            machineText.Position = new Vector2f(100f, 200f);

            while (window.IsOpen && !selectionMade)
            {
                window.DispatchEvents();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Num1))
                {
                    isMachine = false;
                    selectionMade = true;
                }

                if (Keyboard.IsKeyPressed(Keyboard.Key.Num2))
                {
                    isMachine = true;
                    selectionMade = true;
                }

                window.Draw(titleText);
                window.Draw(humanText);
                window.Draw(machineText);
           
            }
        }

        
    }
}