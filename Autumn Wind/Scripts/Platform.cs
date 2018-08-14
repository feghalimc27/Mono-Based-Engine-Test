using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Autumn_Wind {
	class Platform : PhysicsObject {
		public Platform(Texture2D texture, Vector2 position) : base(texture, position, 0) { }
	}
}
