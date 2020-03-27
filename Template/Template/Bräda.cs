using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
	class Bräda
	{
		private Texture2D texture;
		private Vector2 position;

		public Bräda(Texture2D texture, Vector2 position)
		{
			this.position = position;
			this.texture = texture;
		}
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, position, Color.White);
		}
	}
}
