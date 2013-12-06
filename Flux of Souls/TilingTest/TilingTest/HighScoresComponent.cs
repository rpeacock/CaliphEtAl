//Book - An Introduction to Object Oriented Programming was used for feed back on File IO.
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
using System.IO;


namespace FluxOfSouls
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class HighScoresComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D highscoreBackGroundTexture;
        Rectangle highscoreGuiDrawableRectangle;
        Rectangle highscoreGuiPositionRectangle;

        //Return Button
        Texture2D returnTexture;
        Rectangle returnRectangle;
        Rectangle returnRectanglePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        //For Text
        SpriteFont spriteFont;
        String highScoreString;
        Vector2 highScoreStringPosition = new Vector2(350, 90);

        //string that temporarily stores highscores read from highscores.txt file
        string totalString = "";
        string[] splitScores;

        public HighScoresComponent(Game game)
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
            highscoreBackGroundTexture = Game.Content.Load<Texture2D>(@"sprites\highscoreGUI");
            returnTexture = Game.Content.Load<Texture2D>(@"sprites\menu");

            //loading Fonts
            spriteFont = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

            //rectangles
            highscoreGuiDrawableRectangle = new Rectangle(0, 0, highscoreBackGroundTexture.Width, highscoreBackGroundTexture.Height);
            highscoreGuiPositionRectangle = new Rectangle(165, 20, highscoreBackGroundTexture.Width, highscoreBackGroundTexture.Height);

            returnRectangle = new Rectangle(0, 0, returnTexture.Width, returnTexture.Height);
            returnRectanglePosition = new Rectangle(320, 390, returnTexture.Width, returnTexture.Height);
        }

        public override void Update(GameTime gameTime)
        {
            totalString = "";
            splitScores = null;
            //Reading HighScores

            if (File.Exists("highscores.txt"))
            {
                //read and store highscores in string;
                FileStream inFile = new FileStream("highscores.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string recordIn = reader.ReadLine();
                //totalString = totalString + recordIn;
                while (recordIn != null)
                {
                    totalString = totalString + recordIn;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();
            }

            splitScores = totalString.Split('_');


            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && returnRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                this.Visible = false;
                this.Enabled = false;
            }
            pastMouseState = currentMouseState;

            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(highscoreBackGroundTexture, highscoreGuiPositionRectangle, highscoreGuiDrawableRectangle, Color.White);
            spriteBatch.Draw(returnTexture, returnRectanglePosition, returnRectangle, Color.White);
            for (int i = 0; i < splitScores.Length && i < 10; i++)
            {
                spriteBatch.DrawString(spriteFont, splitScores[i], new Vector2(highScoreStringPosition.X, highScoreStringPosition.Y + (i * 30)), Color.Maroon);
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
