using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using System;

namespace Template
{
	class Poäng
	{
		private Vector2 position;
		SpriteFont text;
		int poäng = 0;

		public Poäng(Vector2 position, SpriteFont text)
		{
			this.position = position;
			this.text = text;
		}

		public virtual void DrawString(SpriteBatch spriteBatch)
		{
			spriteBatch.DrawString(text, poäng.ToString(), position, Color.White);
		}

		public virtual void AddPoint()
		{
			poäng++;
		}
	}
}
