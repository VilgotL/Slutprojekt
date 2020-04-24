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
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Bräda spelare;
        Boll boll;
        List<Kloss> klosslista = new List<Kloss>();
        Rectangle vägg1 = new Rectangle(0, 0, 1, 600);
        Rectangle vägg2 = new Rectangle(1000, 0, 1, 600);
        Rectangle tak = new Rectangle(0, 0, 1000, 1);
        Rectangle golv = new Rectangle(0, 600, 1000, 1);
        SoundEffect ljud;
        Stopwatch tid;


        //KOmentar
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1000;  
            graphics.PreferredBackBufferHeight = 600;   
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Hej
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            spelare = new Bräda(Content.Load<Texture2D>("player"), new Vector2(400, 500), new Rectangle(400, 500, 100, 15));
            boll = new Boll(Content.Load<Texture2D>("ball"), new Vector2(300, 100), new Rectangle(300,100,20,17), Content.Load<SoundEffect>("270343__littlerobotsoundfactory__shoot-01"));
            for (int i = 0; i < 10; i++)
            {
                int klossY = 0;
                if (i % 2 == 0)
                {
                    klossY = 0;
                }
                else
                {
                    klossY = 30;
                }
                int klossX = i * 100;
                klosslista.Add(new Kloss(Content.Load<Texture2D>("unnamed"), new Vector2(klossX, klossY), new Rectangle(klossX, klossY, 100, 30), new Rectangle(klossX, klossY, 3, 30), new Rectangle(klossX+3, klossY + 27, 94, 3), new Rectangle(klossX + 97, klossY, 3, 30), new Rectangle(klossX+3, klossY, 94, 3), Content.Load<SoundEffect>("270343__littlerobotsoundfactory__shoot-01")));

                tid = Stopwatch.StartNew();
            }

            // TODO: use this.Content to load your game content here 
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            spelare.Update(gameTime);
            boll.Update(gameTime);
            // TODO: Add your update logic here

            if (boll.Rec.Intersects(spelare.Rec))
            {
                boll.StudsaBräda();
            }
            foreach (Kloss element in klosslista)
            {
                if (boll.Rec.Intersects(element.Rec))
                {
                    if (boll.Rec.Intersects(element.Rec2))
                    {
                        boll.StudsaX(false);
                        element.Krossa();
                       
                    }
                    else if (boll.Rec.Intersects(element.Rec1))
                    {
                        boll.StudsaX(true);
                        element.Krossa();
                   
                    }
                    else if (boll.Rec.Intersects(element.Rec3))
                    {
                        boll.StudsaX(true);
                        element.Krossa();
                       
                    }
                    else if (boll.Rec.Intersects(element.Rec4))
                    {
                        boll.StudsaX(false);
                        element.Krossa();
                    }
                }
            }
            if (boll.Rec.Intersects(vägg1))
            {
                boll.StudsaX(true);
            }
            if (boll.Rec.Intersects(vägg2))
            {
                boll.StudsaX(true);
            }
            if (boll.Rec.Intersects(tak))
            {
                boll.StudsaX(false);
            }
            if (boll.Rec.Intersects(golv))
            {
                tid.Stop();
                Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            spriteBatch.Begin();
            spelare.Draw(spriteBatch);
            boll.Draw(spriteBatch);
            foreach (Kloss element in klosslista)
            {
                element.Draw(spriteBatch);
            }
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
