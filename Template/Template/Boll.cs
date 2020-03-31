using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Template
{
	class Boll
	{
		private Texture2D texture;
		private Vector2 position;
		private float fart = 3f;

		public Boll(Texture2D texture, Vector2 position)
		{
			this.texture = texture;
			this.position = position;
		}

		public virtual void Update(GameTime gameTime)
		{
			position.Y += fart;
		}

		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(20, 17)), Color.White);
		}
	}
}
