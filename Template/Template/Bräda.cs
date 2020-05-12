using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Template
{
	class Bräda
	{
		//Textur
		private Texture2D texture;
		//Position
		private Vector2 position;
		//fart
		private float fart = 5;
		//hitbox
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

		//Rita ut på skärmen
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(100, 15)), Color.White);
		}
		
		public virtual void Update(GameTime gameTime)
		{
			KeyboardState kstate = Keyboard.GetState();
			//Flytta höger med D
			if (kstate.IsKeyDown(Keys.D))
				if (position.X < 900)
					position.X += fart;
			//Flytta höger med A
			if (kstate.IsKeyDown(Keys.A))
				if (position.X > 0)
					position.X -= fart;
			//Flytta hitboxen till texturen
			rec.X = (int)Math.Round(position.X);
		}
	}
}
