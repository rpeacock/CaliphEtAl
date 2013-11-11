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
    public class SelectionComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D selectionTexture;

        Rectangle selectionDrawableRectangle;
        static Rectangle selectionPositionRectangle;

        public static List<Zone> zones = new List<Zone>();

        public SelectionComponent(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
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
            selectionTexture = Game.Content.Load<Texture2D>(@"sprites\selection");

            //Set rectangles
            selectionDrawableRectangle = new Rectangle(0, 0, selectionTexture.Width, selectionTexture.Height);
            selectionPositionRectangle = new Rectangle(500, 300, selectionTexture.Width, selectionTexture.Height);

            zones = MapComponent.GetZones();

            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            foreach (Zone zone in zones)
            {
                if (zone.Equals(Zone.GetSelectedZone()))
                {
                    selectionPositionRectangle = zone.GetPosition();
                }
            }    
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(selectionTexture, selectionPositionRectangle, selectionDrawableRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
