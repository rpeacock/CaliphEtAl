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
    public class SplashScreenGameComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D introImage;
        Rectangle titleRectanglePosition;
        Rectangle titleRectangle;
        KeyboardState kb;
        KeyboardState prevKb;
        int boundsHeight;
        int boundsWidth;
        bool startReady = false;
        double milliSeconds = 0;
        double milliSecondsPerTime = 10;

        public SplashScreenGameComponent(Game game)
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
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            introImage = Game.Content.Load<Texture2D>(@"sprites\title");
            boundsWidth = GraphicsDevice.Viewport.Bounds.Width;
            boundsHeight = GraphicsDevice.Viewport.Bounds.Height;


            titleRectanglePosition = new Rectangle((boundsWidth - introImage.Width) / 2, -200, introImage.Width, introImage.Height);
            titleRectangle = new Rectangle(0, 0, introImage.Width, introImage.Height);

            base.LoadContent();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            milliSeconds += gameTime.ElapsedGameTime.TotalMilliseconds;
            if (milliSeconds > milliSecondsPerTime)
            {
                milliSeconds = 0;

                if (titleRectanglePosition.Y < (boundsHeight - introImage.Height) / 2)
                {
                    titleRectanglePosition.Y++;
                }
                else
                {
                    startReady = true;
                }
                if (startReady == true)
                {
                    HandleInput();
                }
            }
            //Title falls from above slowly and stops at the center
            if (titleRectanglePosition.Y < (boundsHeight - introImage.Height) / 2)
            {
                titleRectanglePosition.Y++;
            }
            else
            {
                startReady = true;
            }
            if (startReady == true)
            {
                HandleInput();
            }
            base.Update(gameTime);        
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(introImage, titleRectanglePosition, titleRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
        private void HandleInput()
        {
            kb = Keyboard.GetState();
            
            
            if (kb.IsKeyUp(Keys.Space) && prevKb.IsKeyDown(Keys.Space))
            {
                this.Visible = false;
                this.Enabled = false;
            }
            prevKb = kb;
        }
    }
}
