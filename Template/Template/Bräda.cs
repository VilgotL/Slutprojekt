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
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(100, 15)), Color.White);
		}
		
		public virtual void Update(GameTime gameTime)
		{
			KeyboardState kstate = Keyboard.GetState();
			if (kstate.IsKeyDown(Keys.D))
				position.X += 3;
			if (kstate.IsKeyDown(Keys.A))
				position.X -= 3;
		}
	}
}
