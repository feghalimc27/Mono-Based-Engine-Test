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
        protected bool shouldBounceY = false;
        protected bool shouldBounceX = false;

        protected float bounceHeight = 0;

		protected float gravity = globalGravity;
		protected float friction = 0.78f;
        protected float bounciness = 0;

		protected Vector2 movement = new Vector2(0, 0);

		public virtual Rectangle collisionBox {
            get {
                return new Rectangle((int)_position.X, (int)_position.Y, _sprite.Width, _sprite.Height);
            }
        }

        public PhysicsObject() : base() {

        }

		public PhysicsObject(Texture2D sprite, Vector2 position, float newGravity = globalGravity, bool staticState = false, float bounce = 0) : base (sprite, position) {
			gravity = newGravity;
			isStatic = staticState;
            bounciness = bounce;

            if (newGravity == 0) {
                isStatic = true;
            }
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

        public virtual void Update(GameTime gameTime, List<PhysicsObject> objects) {
            // Apply gravity
            // TODO: Add physics check before applying movement
            if (!isStatic) {
				ApplyGravity(gameTime);
			}

            foreach (var physObject in objects) {
                if (this == physObject) {
                    continue;
                }

                if (this.movement.Y > 20 && physObject.movement.Y == 0) {

                }

                TestBounds(physObject);
            }

            ApplyMovement();
            ApplyBounce();

            base.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch) {
			DrawStatic(spriteBatch);

            base.Draw(spriteBatch);
        }

        // REMINDER: Rework if necessary
        // TODO: Add more checks incase object is moving in the air
        #region Collision
        protected bool CheckRight(PhysicsObject other) { 
            return this.collisionBox.Right + movement.X < other.collisionBox.Left &&
                this.collisionBox.Left < other.collisionBox.Left &&
                this.collisionBox.Bottom > other.collisionBox.Top &&
                this.collisionBox.Top < other.collisionBox.Bottom;
        }

        protected bool CheckLeft(PhysicsObject other) {
            return this.collisionBox.Left + movement.X > other.collisionBox.Right &&
                this.collisionBox.Right > other.collisionBox.Right &&
                this.collisionBox.Bottom > other.collisionBox.Top &&
                this.collisionBox.Top < other.collisionBox.Bottom;
        }

        protected bool CheckBottom(PhysicsObject other) {
            return this.collisionBox.Bottom + movement.Y > other.collisionBox.Top &&
                this.collisionBox.Top < other.collisionBox.Top &&
                this.collisionBox.Right > other.collisionBox.Left &&
                this.collisionBox.Left < other.collisionBox.Right;
        }

        protected bool CheckTop(PhysicsObject other) {
            return this.collisionBox.Top + movement.Y > other.collisionBox.Bottom &&
                this.collisionBox.Bottom > other.collisionBox.Bottom &&
                this.collisionBox.Right > other.collisionBox.Left &&
                this.collisionBox.Left < other.collisionBox.Right;
        }

        protected virtual void TestBounds(PhysicsObject other) {
            if ((CheckRight(other) && movement.X < 0) || (CheckLeft(other) && movement.X > 0)) {
                movement.X = 0;
            }

            if ((CheckBottom(other) && movement.Y > 0) || (CheckTop(other) && movement.Y < 0)) {
                if (movement.Y > 0) {
                    movement.Y = -(this.collisionBox.Bottom - other.collisionBox.Top);
                    if (bounciness > 0) {
                        shouldBounceY = true;
                        bounceHeight = this.collisionBox.Bottom - other.collisionBox.Top;
                    }
                }
            }
        }

        protected void ApplyBounce() {
            if (shouldBounceY) {
                movement.Y = bounceHeight * (bounciness / 1);
                bounceHeight = 0;
                shouldBounceY = false;
            }
        }
        #endregion
    }
}
