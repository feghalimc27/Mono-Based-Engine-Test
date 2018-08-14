using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Autumn_Wind
{
    public class Game1 : Game
    {
        string windowTitle = System.Reflection.Assembly.GetExecutingAssembly().GetName().Name.ToString() + " Alpha " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

		List<PhysicsObject> physicsObjects;

        public static InputManager inputManager;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

		protected override void Initialize() {
			this.Window.Title = windowTitle;
            // TODO: Add your initialization logic here

            inputManager = new InputManager();

            physicsObjects = new List<PhysicsObject> {
                new PhysicsObject(Content.Load<Texture2D>("Sprites/tempPhysicsBall"), new Vector2(100, 25)),
                new PhysicsObject(Content.Load<Texture2D>("Sprites/tempPhysicsBall"), new Vector2(200, 25), 15, false, 1.1f),
                new PhysicsObject(Content.Load<Texture2D>("Sprites/tempPhysicsBall"), new Vector2(300, 25) , 0, true),
                new PhysicsObject(Content.Load<Texture2D>("Sprites/tempPlatform"), new Vector2(100, 400), 0)
			};

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

			// TODO: Add your update logic here
			foreach (var obj in physicsObjects) {
				obj.Update(gameTime, physicsObjects);
			}

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

			// TODO: Add your drawing code here
			spriteBatch.Begin();
			foreach (var obj in physicsObjects) {
				obj.Draw(spriteBatch);
			}
			spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
