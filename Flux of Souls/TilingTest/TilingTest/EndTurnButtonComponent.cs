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
    public class EndTurnButtonComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        //end turn Button Button
        Texture2D endTurnTexture;
        Rectangle endTurnRectangle;
        Rectangle endTurnRectanglePosition;

        //Bounds rectangle
        Rectangle bounds;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public EndTurnButtonComponent(Game game)
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

            endTurnTexture = Game.Content.Load<Texture2D>(@"sprites\endTurn");

            //bound rectangle setting
            bounds = new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Height);

            //end turn button rectangles
            endTurnRectangle = new Rectangle(0, 0, endTurnTexture.Width, endTurnTexture.Height);
            endTurnRectanglePosition = new Rectangle(bounds.Width - endTurnRectangle.Width - 10, bounds.Height - endTurnRectangle.Height - 10, endTurnTexture.Width, endTurnTexture.Height);



            base.LoadContent();
        }
        public override void Update(GameTime gameTime)
        {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && endTurnRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                EndTurn();
            }
            pastMouseState = currentMouseState;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(endTurnTexture, endTurnRectanglePosition, endTurnRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //To be implemented
        public void EndTurn()
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
