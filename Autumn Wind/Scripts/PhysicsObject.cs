using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Autumn_Wind {
    class PhysicsObject : Tile {
		/*
         * Base class containing all attributes of a physics object.
         */

		// TODO: Physics related functions and attributes

		private const float globalGravity = 25.0f;

		protected bool isStatic = false;

		protected float gravity = globalGravity;
		protected float friction = 0;

		protected Vector2 movement = new Vector2(0, 0);

        public PhysicsObject() : base() {

        }

		public PhysicsObject(Texture2D sprite, Vector2 position, float newGravity = globalGravity, bool staticState = false) : base (sprite, position) {
			gravity = newGravity;
			isStatic = staticState;
		}

		protected void ApplyGravity(GameTime gameTime) {
			movement.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
		}

		protected void ApplyMovement() {
			_position += movement;
		}

        public override void Initialize() {
            base.Initialize();
        }

        public override void LoadContent() {
            base.LoadContent();
        }

        public override void Update(GameTime gameTime) {
			// Apply gravity
			// TODO: Add physics check before applying movement
			if (!isStatic) {
				ApplyGravity(gameTime);
			}

			ApplyMovement();

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
			DrawStatic(spriteBatch);

            base.Draw(spriteBatch);
        }
    }
}
