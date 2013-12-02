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
    public class CurrencyControllerComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        Texture2D controllerContainerTexture;
        Texture2D getPointsButtonTexture;
        Texture2D sellSoulsButtonTexture;
        Texture2D buySoulsButtonTexture;

        //What to draw
        Rectangle controllerContainerDrawableRectangle;
        Rectangle getPointsButtonDrawableRectangle;
        Rectangle sellSoulsButtonDrawableRectangle;
        Rectangle buySoulsButtonDrawableRectangle;

        //where to draw and what size
        Rectangle controllerContainerPositionRectangle;
        Rectangle getPointsButtonPositionRectangle;
        Rectangle sellSoulsButtonPositionRectangle;
        Rectangle buySoulsButtonPositionRectangle;
        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public CurrencyControllerComponent(Game game)
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

            //Loading textures
            controllerContainerTexture = Game.Content.Load<Texture2D>(@"sprites\currencyController");
            getPointsButtonTexture = Game.Content.Load<Texture2D>(@"sprites\getPoints");
            sellSoulsButtonTexture = Game.Content.Load<Texture2D>(@"sprites\sellSouls");
            buySoulsButtonTexture = Game.Content.Load<Texture2D>(@"sprites\buySouls");

            controllerContainerDrawableRectangle = new Rectangle(0, 0, controllerContainerTexture.Bounds.Width, controllerContainerTexture.Bounds.Height);
            getPointsButtonDrawableRectangle = new Rectangle(0, 0, getPointsButtonTexture.Bounds.Width, getPointsButtonTexture.Bounds.Height);
            sellSoulsButtonDrawableRectangle = new Rectangle(0, 0, sellSoulsButtonTexture.Bounds.Width, sellSoulsButtonTexture.Bounds.Height);
            buySoulsButtonDrawableRectangle = new Rectangle(0, 0, buySoulsButtonTexture.Bounds.Width, buySoulsButtonTexture.Bounds.Height);

            //+200 is sending the whole component to the right
            controllerContainerPositionRectangle = new Rectangle(0 + 700, 50, controllerContainerTexture.Bounds.Width, controllerContainerTexture.Bounds.Height);
            getPointsButtonPositionRectangle = new Rectangle(16 + 700, 80, getPointsButtonTexture.Bounds.Width, getPointsButtonTexture.Bounds.Height);
            sellSoulsButtonPositionRectangle = new Rectangle(16 + 700, 160, sellSoulsButtonTexture.Bounds.Width, sellSoulsButtonTexture.Bounds.Height);
            buySoulsButtonPositionRectangle = new Rectangle(16 + 700, 240, buySoulsButtonTexture.Bounds.Width, buySoulsButtonTexture.Bounds.Height);



            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            int currentSouls = PointAndCurency.GetSouls();
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && sellSoulsButtonPositionRectangle.Contains(currentMouseState.X, currentMouseState.Y))
            {
                if (currentSouls > 0)
                {
                    Souls.sellSoul();
                }
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && getPointsButtonPositionRectangle.Contains(currentMouseState.X, currentMouseState.Y))
            {
                if (currentSouls > 0)
                {
                    Souls.scoreSoul();
                }
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && buySoulsButtonPositionRectangle.Contains(currentMouseState.X, currentMouseState.Y))
            {
                    Souls.buySoul();
            }
            pastMouseState = currentMouseState;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(controllerContainerTexture, controllerContainerPositionRectangle, controllerContainerDrawableRectangle, Color.White);
            spriteBatch.Draw(getPointsButtonTexture, getPointsButtonPositionRectangle, getPointsButtonDrawableRectangle, Color.White);
            spriteBatch.Draw(sellSoulsButtonTexture, sellSoulsButtonPositionRectangle, sellSoulsButtonDrawableRectangle, Color.White);
            spriteBatch.Draw(buySoulsButtonTexture, buySoulsButtonPositionRectangle, buySoulsButtonDrawableRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}