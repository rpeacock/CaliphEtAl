using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace FluxOfSouls
{
    public class GameHelpComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        Texture2D helpButtonTexture;

        Rectangle helpButtonDrawableRectangle;

        Rectangle helpButtonPositionRectangle;

        MouseState currentMouseState;
        MouseState pastMouseState;

        public bool gameSessionHelp = false;

        public GameHelpComponent(Game game)
            : base(game)
        {

        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            helpButtonTexture = Game.Content.Load<Texture2D>(@"sprites\Help");

            helpButtonDrawableRectangle = new Rectangle(0, 0, helpButtonTexture.Bounds.Width, helpButtonTexture.Bounds.Height);

            helpButtonPositionRectangle = new Rectangle(16 + 700, 320, helpButtonTexture.Bounds.Width, helpButtonTexture.Bounds.Height);
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && helpButtonPositionRectangle.Contains(currentMouseState.X, currentMouseState.Y))
            {
                this.Enabled = false;
                this.Visible = false;
                gameSessionHelp = true;
            }
            pastMouseState = currentMouseState;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(helpButtonTexture, helpButtonPositionRectangle, helpButtonDrawableRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
