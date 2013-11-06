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
    public class PointSystemComponent : DrawableGameComponent
    {
        PointAndCurency pointAndCurency;
        
        SpriteBatch spriteBatch;
        Texture2D pointCurrencyTexture;
        Texture2D goldCurrencyTexture;
        Texture2D soulCurrencyTexture;
        Texture2D currencyContainterTexture;

        //What to draw
        Rectangle currencyContainerDrawableRectangle;
        Rectangle goldCurrencyDrawableRectangle;
        Rectangle soulCurrencyDrawableRectangle;
        Rectangle pointCurrencyDrawableRectangle;

        //where to draw and what size
        Rectangle currencyContainerPositionRectangle;
        Rectangle goldCurrencyPositionRectangle;
        Rectangle soulCurrencyPositionRectangle;
        Rectangle pointCurrencyPositionRectangle;
        
        //SpriteFonts to view actual currency values
        SpriteFont spriteFont;
        String goldAmount;
        String soulAmount;
        String pointAmount;

        //Vectors to position strings with currency values
        Vector2 goldStringPosition;
        Vector2 soulStringPosition;
        Vector2 pointStringPosition;

        public PointSystemComponent(Game game)
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
            pointAndCurency = new PointAndCurency();
            goldAmount = PointAndCurency.GetGold().ToString();
            soulAmount = PointAndCurency.GetSouls().ToString();
            pointAmount = PointAndCurency.GetPoints().ToString();

            //setting position of strings holding currency values
            goldStringPosition = new Vector2(330, 17);
            soulStringPosition = new Vector2(440, 17);
            pointStringPosition = new Vector2(620, 17);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Loading textures
            goldCurrencyTexture = Game.Content.Load<Texture2D>(@"sprites\goldCurrency");
            soulCurrencyTexture = Game.Content.Load<Texture2D>(@"sprites\soulCurrency");
            pointCurrencyTexture = Game.Content.Load<Texture2D>(@"sprites\pointCurrency");
            currencyContainterTexture = Game.Content.Load<Texture2D>(@"sprites\currencyContainer");

            //loading Fonts
            spriteFont = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

            currencyContainerDrawableRectangle = new Rectangle(0,0, currencyContainterTexture.Bounds.Width, currencyContainterTexture.Bounds.Height);
            goldCurrencyDrawableRectangle = new Rectangle(0, 0, goldCurrencyTexture.Bounds.Width, goldCurrencyTexture.Bounds.Height);
            soulCurrencyDrawableRectangle = new Rectangle(0, 0, soulCurrencyTexture.Bounds.Width, soulCurrencyTexture.Bounds.Height);
            pointCurrencyDrawableRectangle = new Rectangle(0, 0, pointCurrencyTexture.Bounds.Width, pointCurrencyTexture.Bounds.Height);

            //+200 is sending the whole component to the right
            currencyContainerPositionRectangle = new Rectangle(0 + 250, 0, currencyContainterTexture.Bounds.Width /2, currencyContainterTexture.Bounds.Height /2);
            goldCurrencyPositionRectangle = new Rectangle(10 + 250, 10, goldCurrencyTexture.Bounds.Width / 2, goldCurrencyTexture.Bounds.Height / 2);
            soulCurrencyPositionRectangle = new Rectangle(130 + 250, 10, soulCurrencyTexture.Bounds.Width / 2, soulCurrencyTexture.Bounds.Height / 2);
            pointCurrencyPositionRectangle = new Rectangle(250 + 250, 15, pointCurrencyTexture.Bounds.Width / 2, pointCurrencyTexture.Bounds.Height / 2);
            
            //Loading Fonts


            base.LoadContent();
        }
        public PointAndCurency GetPointAndCurrency()
        {
            return pointAndCurency;
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            goldAmount = PointAndCurency.GetGold().ToString();
            soulAmount = PointAndCurency.GetSouls().ToString();
            pointAmount = PointAndCurency.GetPoints().ToString();

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            
            //Drawing Textures
            spriteBatch.Draw(currencyContainterTexture, currencyContainerPositionRectangle, currencyContainerDrawableRectangle, Color.White);
            spriteBatch.Draw(goldCurrencyTexture, goldCurrencyPositionRectangle, goldCurrencyDrawableRectangle, Color.White);
            spriteBatch.Draw(soulCurrencyTexture, soulCurrencyPositionRectangle, soulCurrencyDrawableRectangle, Color.White);
            spriteBatch.Draw(pointCurrencyTexture, pointCurrencyPositionRectangle, pointCurrencyDrawableRectangle, Color.White);
            
            //Drawing Strings with spriteFont
            spriteBatch.DrawString(spriteFont, goldAmount, goldStringPosition, Color.Maroon);
            spriteBatch.DrawString(spriteFont, soulAmount, soulStringPosition, Color.Maroon);
            spriteBatch.DrawString(spriteFont, pointAmount, pointStringPosition, Color.Maroon);
            spriteBatch.End();
            
            base.Draw(gameTime);
        }
    }
}
