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


namespace FluxOfSouls
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class MapComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D tileTexture;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        static Rectangle waterRectangle;
        static Rectangle landRectangle;
        static Rectangle villageRectangle;
        static Rectangle townRectangle;
        static Rectangle cityRectangle;

        public static List<Zone> zones = new List<Zone>();
        public static Zone selectedZone;

        public MapComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        public static List<Zone> GetZones()
        {
            return zones;
        }
        public static void setSelectedZone(Zone zone)
        {
            selectedZone = zone;
        }
         
        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            tileTexture = Game.Content.Load<Texture2D>(@"sprites\tiles");

            waterRectangle = new Rectangle(0, 0, tileTexture.Width / 5, tileTexture.Height);
            landRectangle = new Rectangle(40, 0, tileTexture.Width / 5, tileTexture.Height);
            villageRectangle = new Rectangle(80, 0, tileTexture.Width / 5, tileTexture.Height);
            townRectangle = new Rectangle(120, 0, tileTexture.Width / 5, tileTexture.Height);
            cityRectangle = new Rectangle(160, 0, tileTexture.Width / 5, tileTexture.Height);

            for (int i = 0; i < 10; i++)
            {
                for (int x = 0; x < 12; x++)
                {
                    zones.Add(new Zone(x, i));
                }
            }

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            //UPDATING is really being done inside each zone object... see Zone Class.

            currentMouseState = Mouse.GetState();
            foreach (Zone zone in zones)
            {
                

                if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && zone.GetPosition().Contains(currentMouseState.X, currentMouseState.Y))
                {
                    Zone.SetSelectedZone(zone);
                }               
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            foreach (Zone zone in zones)
            {
                spriteBatch.Begin();

                if(zone.GetZoneType().Equals(1))
                {
                    spriteBatch.Draw(tileTexture, zone.GetPosition(), waterRectangle, Color.White);
                }
                else if (zone.GetZoneType().Equals(2))
                {
                    spriteBatch.Draw(tileTexture, zone.GetPosition(), landRectangle, Color.White);
                }
                else if (zone.GetZoneType().Equals(3))
                {
                    spriteBatch.Draw(tileTexture, zone.GetPosition(), villageRectangle, Color.White);
                }
                else if (zone.GetZoneType().Equals(4))
                { 
                    spriteBatch.Draw(tileTexture, zone.GetPosition(), townRectangle, Color.White); 
                }
                else if (zone.GetZoneType().Equals(5))
                {
                    spriteBatch.Draw(tileTexture, zone.GetPosition(), cityRectangle, Color.White);
                }

                spriteBatch.End();
            }   
            base.Draw(gameTime);
        }
    }
}
