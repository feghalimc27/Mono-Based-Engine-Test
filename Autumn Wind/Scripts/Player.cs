using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Autumn_Wind {
	class Player : PhysicsObject {
		
		private Vector2 spriteSize = new Vector2(32, 32);
		private InputManager inputManager {
			get {
				return Game1.inputManager;
			}
		}

		private float acceleration = 3;
		private new float friction = 0.78f;

		public override Rectangle collisionBox {
			get {
				return new Rectangle((int)_position.X, (int)_position.Y, (int)spriteSize.X, (int)spriteSize.Y);
			}
		}

		public Player(Texture2D texture, Vector2 position) : base(texture, position) {
			
		}

		public override void Initialize() {
			base.Initialize();
		}

		public override void LoadContent() {
			base.LoadContent();
		}

		public override void Update(GameTime gameTime, List<PhysicsObject> objects) {
			Move(gameTime);

			base.Update(gameTime, objects);
		}

		public override void Draw(SpriteBatch spriteBatch) {
			DrawStatic(spriteBatch);
		}

		public override void DrawAnimated(SpriteBatch spriteBatch, Vector2 spritePosition, Vector2 spriteStripEndPosition, Vector2 spriteSize, float animationSpeed) {
			base.DrawAnimated(spriteBatch, spritePosition, spriteStripEndPosition, spriteSize, animationSpeed);
		}

		private void Move(GameTime gameTime) {
			DebugOutput(inputManager.GetAxisValue(3).ToString());
			DebugOutput(inputManager.GetButtonDown("Jump").ToString());

			if (inputManager.GetAxisValue(3) > 0) {
				movement.X += acceleration * (float)gameTime.ElapsedGameTime.Milliseconds;
			}
			if (inputManager.GetAxisValue(3) < 0) {
				movement.X -= acceleration * (float)gameTime.ElapsedGameTime.Milliseconds;
			}
		}
	}
}
