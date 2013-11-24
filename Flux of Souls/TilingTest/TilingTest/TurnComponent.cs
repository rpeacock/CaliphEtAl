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
    public class TurnComponent : DrawableGameComponent
    {
        Turn turn;

        SpriteBatch spriteBatch;
        Texture2D turnTexture;

        //What to draw
        Rectangle turnDrawableRectangle;

        //where to draw and what size
        Rectangle turnPositionRectangle;

        //SpriteFonts to view actual currency values
        SpriteFont spriteFont;
        String turnString;

        //Vectors to position strings with currency values
        Vector2 turnStringPosition;

        public TurnComponent(Game game)
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
            turnString = Turn.getCurrentTurn().ToString();

            //setting position of string
            turnStringPosition = new Vector2(760, 26);

            //Loading textures
            turnTexture = Game.Content.Load<Texture2D>(@"sprites\turn");

            //loading Fonts
            spriteFont = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

            turnDrawableRectangle = new Rectangle(0, 0, turnTexture.Bounds.Width, turnTexture.Bounds.Height);

            //+200 is sending the whole component to the right
            turnPositionRectangle = new Rectangle(725, 0, turnTexture.Bounds.Width , turnTexture.Bounds.Height);
            

            base.LoadContent();
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            turnString = Turn.getCurrentTurn().ToString();

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(turnTexture, turnPositionRectangle, turnDrawableRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, turnString, turnStringPosition, Color.Black);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
