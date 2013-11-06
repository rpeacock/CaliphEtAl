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
    public class ZoneGui : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D zoneGuiTexture;
        Rectangle zoneGuiRectangle;
        Rectangle zoneGuiRectanglePosition;

        //cashSouls Button
        Texture2D cashSoulsTexture;
        Rectangle cashSoulsRectangle;
        Rectangle cashSoulsRectanglePosition;

        //upgrade Button
        Texture2D upgradeTexture;
        Rectangle upgradeRectangle;
        Rectangle upgradeRectanglePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public ZoneGui(Game game)
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

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zoneGuiTexture = Game.Content.Load<Texture2D>(@"sprites\zoneGui");
            upgradeTexture = Game.Content.Load<Texture2D>(@"sprites\upgrade");
            cashSoulsTexture = Game.Content.Load<Texture2D>(@"sprites\cashSouls");

            //Zone rectangles
            zoneGuiRectangle = new Rectangle(0, 0, zoneGuiTexture.Width, zoneGuiTexture.Height);
            zoneGuiRectanglePosition = new Rectangle(0, 0, (int) (zoneGuiTexture.Width / 1.5), GraphicsDevice.Viewport.Bounds.Height);

            //Cash Souls button rectangles
            cashSoulsRectangle = new Rectangle(0, 0, cashSoulsTexture.Width, cashSoulsTexture.Height);
            cashSoulsRectanglePosition = new Rectangle(20, 400, cashSoulsTexture.Width, cashSoulsTexture.Height);
            
            //Upgrade Rectangles
            upgradeRectangle = new Rectangle(0, 0, upgradeTexture.Width, upgradeTexture.Height);
            upgradeRectanglePosition = new Rectangle(20, 350, upgradeTexture.Width, upgradeTexture.Height);

            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && cashSoulsRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                CashSouls();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && upgradeRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {

                Upgrade(Zone.GetSelectedZone());
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(zoneGuiTexture, zoneGuiRectanglePosition,zoneGuiRectangle, Color.White);
            spriteBatch.Draw(cashSoulsTexture, cashSoulsRectanglePosition, cashSoulsRectangle, Color.White);
            spriteBatch.Draw(upgradeTexture, upgradeRectanglePosition, upgradeRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //To be implemented
        public void Upgrade(Zone zoneToUpgrade)
        {
            zoneToUpgrade.Upgrade();
        }
        public void CashSouls()
        {

        }
    }
}
