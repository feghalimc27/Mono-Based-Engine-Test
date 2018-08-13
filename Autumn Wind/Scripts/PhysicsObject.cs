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

        protected float gravity = 25.0f;
		protected float friction = 0;
        
		protected Vector2 movement = new Vector2(0, 0);

        public PhysicsObject() : base() {

        }

        public PhysicsObject(Texture2D sprite, Vector2 position) : base(sprite, position) {

        }

		protected void ApplyGravity(GameTime gameTime) {
			movement.Y += gravity * (float)gameTime.ElapsedGameTime.TotalSeconds;
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
			// TODO: Add physics check before applying gravity
			ApplyGravity(gameTime);

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
            base.Draw(spriteBatch);
        }
    }
}
