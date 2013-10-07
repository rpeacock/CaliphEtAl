using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

/*Edited Version of Tutorial http://www.xnaresources.com/default.asp?page=Tutorial:TileEngineSeries:3 */

namespace TilingTest
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        TileMap myMap = new TileMap();
        int squaresAcross = 15;
        int squaresDown = 33;
        int baseOffsetX = 0;
        int baseOffsetY = 0;

        static public Vector2 Location = Vector2.Zero;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
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
            Tile.TileSetTexture = Content.Load<Texture2D>(@"images\TileSets\part3_tileset");
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
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
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            //Camera Movement 

            //KeyboardState ks = Keyboard.GetState();
            //if (ks.IsKeyDown(Keys.Left))
            //{
            //    Location.X = MathHelper.Clamp(Location.X - 2, 0,
            //        (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            //}

            //if (ks.IsKeyDown(Keys.Right))
            //{
            //    Location.X = MathHelper.Clamp(Location.X + 2, 0,
            //        (myMap.MapWidth - squaresAcross) * Tile.TileStepX);
            //}

            //if (ks.IsKeyDown(Keys.Up))
            //{
            //    Location.Y = MathHelper.Clamp(Location.Y - 2, 0,
            //        (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            //}

            //if (ks.IsKeyDown(Keys.Down))
            //{
            //    Location.Y = MathHelper.Clamp(Location.Y + 2, 0,
            //        (myMap.MapHeight - squaresDown) * Tile.TileStepY);
            //}
            // TODO: Add your update logic here

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

            Vector2 firstSquare = new Vector2 (Location.X % Tile.TileStepX, Location.Y / Tile.TileStepY);
            
            int firstX = (int)firstSquare.X;
            int firstY = (int)firstSquare.Y;

            Vector2 squareOffset = new Vector2(Location.X % Tile.TileStepX, Location.Y / Tile.TileStepY);

            int offsetX = (int)squareOffset.X;
            int offsetY = (int)squareOffset.Y;

            for (int y = 0; y < squaresDown; y++)
            {
                int rowOffset = 0;
                if ((firstY + y) % 2 == 1)
                    rowOffset = Tile.OddRowXOffset;

                for (int x = 0; x < squaresAcross; x++)
                {
                    foreach (int tileID in myMap.Rows[y + firstY].Columns[x + firstX].BaseTiles)
                    {
                        spriteBatch.Draw(Tile.TileSetTexture,new Rectangle((x * Tile.TileStepX) - offsetX + rowOffset + baseOffsetX,(y * Tile.TileStepY) - offsetY + baseOffsetY,Tile.TileWidth, Tile.TileHeight),Tile.GetSourceRectangle(tileID),Color.White);
                    }
                }
                
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
