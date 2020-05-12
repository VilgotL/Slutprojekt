using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using Microsoft.Xna.Framework.Audio;
using System.Threading.Tasks;
using System.Diagnostics;

namespace Template
{
	class Boll
	{
		//textur
		private Texture2D texture;
		//position
		private Vector2 position;
		//hitbox
		private Rectangle rec;
		//fart i x-led
		private float fartY = 4f;
		//fart i y-led
		private float fartX = 4f;
		//sammanlagd fart
		private float totalFart = 50f;
		Random rnd;
		Stopwatch tidX = new Stopwatch();
		Stopwatch tidY = new Stopwatch();

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
			//flyttar bollen
			position.Y += fartY;
			position.X += fartX;
			//flyttar hitboxen
			rec.Y = (int)Math.Round(position.Y);
			rec.X = (int)Math.Round(position.X);
		}

		//ritar ut på skärmen
		public virtual void Draw(SpriteBatch spriteBatch)
		{
			spriteBatch.Draw(texture, new Rectangle(position.ToPoint(), new Point(20, 17)), Color.White);
		}

		//studsa (antingen i x-led eller y-led)
		public void StudsaX(bool x)
		{
			//x-led
			if (x)
			{	
				//om det har gått mer än 10 millisekunder sen senaste studsten (så att den inte kan byta riktning 2 gånger sammtidigt och på så sätt fortsätta i samam riktning och åka igenom)
				if (tidX.ElapsedMilliseconds > 10 || !tidX.IsRunning)
				{
					//byt riktining
					fartX = -fartX;
					//stanna och återställ tiden
					tidX.Stop();
					tidX.Reset();
				}
				tidX.Start();
			}
			//y-led
			else
			{
				//samma som x
				if (tidY.ElapsedMilliseconds > 10 || !tidY.IsRunning)
				{
					fartY = -fartY;
					tidY.Stop();
					tidY.Reset();
				}
				tidY.Start();
			}
		}
		//studsa på brädan
		public void StudsaBräda()
		{
			//öka farten efter varje studs
			totalFart += 2f;
			//skapar ett decimaltal från 2 till 6
			rnd = new Random();
			double a = rnd.NextDouble();
			double b = rnd.Next(2, 6);
			float c = (float)(a + b);
			//sätter farten i x-led till decimaltalet
			if (fartX >= 0)
				fartX = c;
			else
				fartX = -c;
			//använder Pythagoras sats för att anpassa y-hastigheten så att den totala hastigheten (diagonalen) har samma storlek
			double d = -Math.Sqrt(totalFart - (fartX * fartX));
			float e = (float)d;
			fartY = e;
		}
	}
}
