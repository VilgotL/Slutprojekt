using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
	class Kloss
	{
		private Texture2D texture;
		private Vector2 position;
		private Rectangle rec;

		public Kloss(Texture2D texture, Vector2 position, Rectangle rec)
		{
			this.texture = texture;
			this.position = position;
			this.rec = rec;
		}

		public Rectangle Rec
		{
			get { return rec; }
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(100, 30)), Color.White);
		}

		public void Krossa()
		{
			position.X = 2000;
			rec.X = (int)Math.Round(position.X);
		}
	}
}
