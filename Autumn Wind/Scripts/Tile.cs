using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace Autumn_Wind {
    class Tile {
        /* 
        * Base tile class for all objects in the game. Contains default sprite data and position.
        */

        protected Texture2D _sprite;
        protected Vector2 _position;

        public Tile() {

        }

        public Tile(Texture2D sprite, Vector2 position) {
            _sprite = sprite;
            _position = position;
        }

        public virtual void Initialize() {
            // TODO: Tile initalize base function
        }

        public virtual void LoadContent() {
            // TODO: Tile load content base function
        }

        public virtual void Update(GameTime gameTime) {
            // TODO: Tile update base function
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            // TODO: Tile draw base function
			DrawStatic(spriteBatch);
        }

        public virtual void DrawStatic(SpriteBatch spriteBatch) {
            spriteBatch.Draw(_sprite, _position, Color.White);
        }

        public virtual void DrawAnimated(SpriteBatch spriteBatch, Vector2 spritePosition, Vector2 spriteStripEndPosition, Vector2 spriteSize, float animationSpeed) {
            // TODO: Tile draw animated function, look up how this is done
        }

		public void DebugOutput(string message) {
			System.Diagnostics.Trace.WriteLine(message);
		}

        // Get and Set Sprite
        protected Texture2D GetSprite() => _sprite;
        protected void SetSprite(Texture2D sprite) => _sprite = sprite;

        // Get and Set Position
        protected Vector2 GetPosition() => _position;
        protected void SetPosition(Vector2 position) => _position = position;
        protected void SetPosition(float x, float y) => _position = new Vector2(x, y);
    }
}
