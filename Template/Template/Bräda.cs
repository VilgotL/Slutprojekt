using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
	class Bräda
	{
		private Texture2D texture;
		private Vector2 position;
		private float fart = 5;
		private Rectangle rec;

		public Bräda(Texture2D texture, Vector2 position, Rectangle rec)
		{
			this.position = position;
			this.texture = texture;
			this.rec = rec;
		}

		public Rectangle Rec
		{
			get { return rec; }
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(100, 15)), Color.White);
		}
		
		public virtual void Update(GameTime gameTime)
		{
			KeyboardState kstate = Keyboard.GetState();
			if (kstate.IsKeyDown(Keys.D))
				position.X += fart;
			if (kstate.IsKeyDown(Keys.A))
				position.X -= fart;

			rec.X = (int)Math.Round(position.X);
		}
	}
}
