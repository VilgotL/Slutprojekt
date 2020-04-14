using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
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
        Kloss kloss;
        Rectangle vägg1 = new Rectangle(0, 0, 1, 600);
        Rectangle vägg2 = new Rectangle(1000, 0, 1, 600);
        Rectangle tak = new Rectangle(0, 0, 1000, 1);
        Rectangle golv = new Rectangle(0, 600, 1000, 1);

        Rectangle rec1 = new Rectangle(400, 150, 3, 30);
        Rectangle rec2 = new Rectangle(400, 177, 100, 3);
        Rectangle rec3 = new Rectangle(497, 150, 3, 30);
        Rectangle rec4 = new Rectangle(400, 150, 100, 3);


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
            spelare = new Bräda(Content.Load<Texture2D>("player"), new Vector2(300, 500), new Rectangle(300,500,100,15));
            boll = new Boll(Content.Load<Texture2D>("ball"), new Vector2(300, 100), new Rectangle(300,100,20,17));
            kloss = new Kloss(Content.Load<Texture2D>("unnamed"), new Vector2(400, 150), new Rectangle(400, 150, 100, 30));
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
            if (boll.Rec.Intersects(kloss.Rec))
            {
                kloss.Krossa();
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
            kloss.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
