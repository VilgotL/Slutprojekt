using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace Template
{
	class Boll
	{
		private Texture2D texture;
		private Vector2 position;
		private Rectangle rec;
		private float fartY = 4f;
		private float fartX = 4f;
		private float totalFart = 35f;
		Random rnd;

		public Boll(Texture2D texture, Vector2 position, Rectangle rec)
		{
			this.texture = texture;
			this.position = position;
			this.rec = rec;
		}

		public Rectangle Rec
		{
			get { return rec; }
		}
		public virtual void Update(GameTime gameTime)
		{
			position.Y += fartY;
			position.X += fartX;
			rec.Y = (int)Math.Round(position.Y);
			rec.X = (int)Math.Round(position.X);
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(20, 17)), Color.White);
		}

		public void StudsaX(bool x)
		{
			if (x)
			{
				fartX = -fartX;
			}
			else
			{
				fartY = -fartY;
			}
		}
		public void StudsaBräda()
		{
			totalFart += 2f;
			rnd = new Random();
			double a = rnd.NextDouble();
			double b = rnd.Next(2, 6);
			float c = (float)(a + b);
			if (fartX >= 0)
				fartX = c;
			else
				fartX = -c;
			double d = -Math.Sqrt(totalFart - (fartX * fartX));
			float e = (float)d;
			fartY = e;
		}
	}
}
