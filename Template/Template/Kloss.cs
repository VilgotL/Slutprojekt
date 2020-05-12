using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Audio;

namespace Template
{
	class Kloss
	{
		//Textur
		private Texture2D texture;
		//Position
		private Vector2 position;
		//Hitbox
		private Rectangle rec;
		//Hitbox för sidorna
		private Rectangle rec1;
		private Rectangle rec2;
		private Rectangle rec3;
		private Rectangle rec4;
		//Ljudeffekt
		private SoundEffect ljud;



		public Kloss(Texture2D texture, Vector2 position, Rectangle rec, Rectangle rec1, Rectangle rec2, Rectangle rec3, Rectangle rec4, SoundEffect ljud)
		{
			this.texture = texture;
			this.position = position;
			this.rec = rec;
			this.rec1 = rec1;
			this.rec2 = rec2;
			this.rec3 = rec3;
			this.rec4 = rec4;
			this.ljud = ljud;
		}

		public Rectangle Rec
		{
			get { return rec; }
		}

		public Rectangle Rec1
		{
			get { return rec1; }
		}

		public Rectangle Rec2
		{
			get { return rec2; }
		}

		public Rectangle Rec3
		{
			get { return rec3; }
		}

		public Rectangle Rec4
		{
			get { return rec4; }
		}

		//Ritar ut på skärmen
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(100, 30)), Color.White);
		}

		//Tar bort klossar
		public void Krossa()
		{
			//Flytta utanför skärmen
			position.X = 2000;
			//Flytta hitboxarna till samma plats som texturen
			rec.X = (int)Math.Round(position.X);
			rec1.X = (int)Math.Round(position.X);
			rec2.X = (int)Math.Round(position.X);
			rec3.X = (int)Math.Round(position.X);
			rec4.X = (int)Math.Round(position.X);
			//Spela upp ljudeffekt
			ljud.Play(0.5f, 0.0f, 0.0f);
		}
	}
}
