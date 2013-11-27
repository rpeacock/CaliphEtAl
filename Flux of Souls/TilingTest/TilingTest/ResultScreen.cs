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
    public class ResultScreen : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D resultscreen;
        Rectangle resultRectangle;
        Rectangle resultRectanglePosition;

        SpriteFont spriteFont1;

        public ResultScreen(Game game)
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

            resultscreen = Game.Content.Load<Texture2D>(@"sprites\resultscreen");
            resultRectangle = new Rectangle(0, 0, resultscreen.Width, resultscreen.Height);
            resultRectanglePosition = new Rectangle(0, 0, (int)(resultscreen.Width), GraphicsDevice.Viewport.Bounds.Height);

            //pointRectangle = new Rectangle(0, 0, instructionsButton.Bounds.Width, quitbutton.Bounds.Height);
            //instructionbuttonrectanglepos = new Rectangle(115, 230, instructionsButton.Bounds.Width, instructionsButton.Bounds.Height);


            spriteFont1 = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

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
            spriteBatch.Draw(resultscreen, resultRectanglePosition, resultRectangle, Color.White);
            spriteBatch.DrawString(spriteFont1, "Congratulations you're done the game, your final score is: " + PointAndCurency.GetPoints(), new Vector2 (65,400), Color.White); 
    
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
