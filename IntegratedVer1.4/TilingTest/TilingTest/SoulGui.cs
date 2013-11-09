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
    public class SoulGui : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D soulGuiTexture;
        Rectangle soulGuiRectangle;
        Rectangle soulGuiRectanglePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;



        public SoulGui(Game game)
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
            soulGuiTexture = Game.Content.Load<Texture2D>(@"sprites\soulGui");
          
            //Soul rectangles
            soulGuiRectangle = new Rectangle(0, 0, soulGuiTexture.Width, soulGuiTexture.Height);
            soulGuiRectanglePosition = new Rectangle(0, 0, (int)(soulGuiTexture.Width / 1.5), GraphicsDevice.Viewport.Bounds.Height);


            base.LoadContent();
        }
        
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(soulGuiTexture, soulGuiRectanglePosition, soulGuiRectangle, Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    
        
    }
}
