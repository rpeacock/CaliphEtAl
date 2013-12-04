//Book - An Introduction to Object Oriented Programming was used for feed back on File IO.
//Also used: letter only regular expressions from www.stackoverflow.com

using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System.Text.RegularExpressions;


namespace FluxOfSouls
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class ScoreSubmissionBoxComponent : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D submissionBoxTexture;
        Rectangle submissionBoxDrawableRectangle;
        Rectangle submissionBoxPositionRectangle;

        //Return Button
        Texture2D submitButtonTexture;
        Rectangle submitButtonRectangle;
        Rectangle submitButtonRectanglePosition;

        //Text Box Rectangles
        Texture2D textBoxTexture;
        Rectangle textBoxRectangle;
        Rectangle textBoxRectanglePosition;

        //For Text
        SpriteFont spriteFont;
        String name = "";
        Vector2 namePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        //Keyboard states
        KeyboardState keyboardState;
        KeyboardState prevKeyboardState;

        public ScoreSubmissionBoxComponent(Game game)
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
            submissionBoxTexture = Game.Content.Load<Texture2D>(@"sprites\submitHighscoreBox");
            submitButtonTexture = Game.Content.Load<Texture2D>(@"sprites\submit");
            textBoxTexture = Game.Content.Load<Texture2D>(@"sprites\textBox");

            //loading Fonts
            spriteFont = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

            //rectangles
            submissionBoxDrawableRectangle = new Rectangle(0, 0, submissionBoxTexture.Width, submissionBoxTexture.Height);
            submissionBoxPositionRectangle = new Rectangle(165, 10, submissionBoxTexture.Width, submissionBoxTexture.Height);

            submitButtonRectangle = new Rectangle(0, 0, submitButtonTexture.Width, submitButtonTexture.Height);
            submitButtonRectanglePosition = new Rectangle(320, 140, submitButtonTexture.Width, submitButtonTexture.Height);

            textBoxRectangle = new Rectangle(0, 0, textBoxTexture.Width, textBoxTexture.Height);
            textBoxRectanglePosition = new Rectangle(327, 90, textBoxTexture.Width, textBoxTexture.Height);

            namePosition = new Vector2(373, 93);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            //Get the current keyboard state and keys that are pressed
            keyboardState = Keyboard.GetState();
            Keys[] keys = keyboardState.GetPressedKeys();

            foreach (Keys key in keys)
            {
                if (key == Keys.Back)
                {
                    if (prevKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key))// && keyboardState.IsKeyDown(key))
                    {
                        if (name.Length > 0)
                        {
                            name = name.Remove(name.Length - 1);
                        }
                    }
                }
                else
                {
                    if (prevKeyboardState.IsKeyUp(key) && keyboardState.IsKeyDown(key))// && keyboardState.IsKeyDown(key))
                    {
                        if (key == Keys.A || key == Keys.B || key == Keys.C || key == Keys.D || key == Keys.E || key == Keys.F || key == Keys.G || key == Keys.H || key == Keys.I || key == Keys.J || key == Keys.K || key == Keys.L || key == Keys.M || key == Keys.N || key == Keys.O || key == Keys.P || key == Keys.Q || key == Keys.R || key == Keys.S || key == Keys.T || key == Keys.U || key == Keys.V || key == Keys.W || key == Keys.X || key == Keys.Y || key == Keys.Z)
                        {
                            if (name.Length < 7)
                            {
                                name = name + key;
                            }
                        }
                    }
                }
            }
            prevKeyboardState = keyboardState;

            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && submitButtonRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                saveHighScore(name, PointAndCurency.GetPoints()); //this must pull out the info from elsewhere.
                ResetGameStats();
                name = "";
                this.Visible = false;
                this.Enabled = false;
            }
            pastMouseState = currentMouseState;

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(submissionBoxTexture, submissionBoxPositionRectangle, submissionBoxDrawableRectangle, Color.White);
            spriteBatch.Draw(submitButtonTexture, submitButtonRectanglePosition, submitButtonRectangle, Color.White);
            spriteBatch.Draw(textBoxTexture, textBoxRectanglePosition, textBoxRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, name, namePosition, Color.Maroon);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ResetGameStats()
        {
            List<Zone> zones = MapComponent.GetZones();
            foreach (Zone zone in zones)
            {
                zone.setUpgradeCost(300);
                zone.setTileType(1);
                zone.setNumberOfSouls(0);
            }
            Turn.setCurrentTurn(1);
            PointAndCurency.SetSouls(0);
            PointAndCurency.SetPoints(0);
            PointAndCurency.SetGold(0);
            Souls.souls = new List<Soul>();
        }

        public void saveHighScore(String name, int points)
        {
            //First save to a list of Highscores for sorting
            List<Highscore> highscoreList = new List<Highscore>();
            Highscore newHighscore = new Highscore(name, points);//points);
            highscoreList.Add(newHighscore);

            //write to txt file

            //Delimeter
            const string DELIM = ",";
            string totalString = "";
            const string personDelim = "_";
            if (File.Exists("highscores.txt"))
            {
                //read and store highscores in string;
                FileStream inFile = new FileStream("highscores.txt", FileMode.Open, FileAccess.Read);
                StreamReader reader = new StreamReader(inFile);
                string recordIn = reader.ReadLine();
                //totalString = totalString + recordIn;
                while (recordIn != null)
                {
                    //totalString = reader.ReadLine();
                    totalString = totalString + recordIn;
                    recordIn = reader.ReadLine();
                }
                reader.Close();
                inFile.Close();



                String totalStringForSorting = totalString.Remove(totalString.Length - 1);
                String[] highscoreSplitIntoHighscores = totalStringForSorting.Split('_');
                String[] highscoreSplitIntoRecords = null;
                for (int i = 0; i < highscoreSplitIntoHighscores.Length; i++)
                {
                    highscoreSplitIntoRecords = highscoreSplitIntoHighscores[i].Split(',');
                    //highscoreSplitIntoRecordsPU
                    String highscoreName = highscoreSplitIntoRecords[0];
                    int highscoreScore = Int32.Parse(highscoreSplitIntoRecords[1]);
                    Highscore highscoreNew = new Highscore(highscoreName, highscoreScore);
                    highscoreList.Add(highscoreNew);
                }

                highscoreList.Sort();
                highscoreList.Reverse();

                FileStream outFile = new FileStream("highscores.txt", FileMode.Open, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                foreach (Highscore h in highscoreList)
                {
                    writer.WriteLine(h.GetScoreName() + DELIM + h.GetScoreTotal() + personDelim);
                }
                writer.Close();
                outFile.Close();


                ////write old highscores + new highscore
                //FileStream outFile = new FileStream("highscores.txt", FileMode.Open, FileAccess.Write);
                //StreamWriter writer = new StreamWriter(outFile);
                //writer.WriteLine(totalString);
                //writer.WriteLine(name + DELIM + points + personDelim);
                //writer.Close();
                //outFile.Close();
            }
            else
            {
                FileStream outFile = new FileStream("highscores.txt", FileMode.Create, FileAccess.Write);
                StreamWriter writer = new StreamWriter(outFile);
                writer.WriteLine(name + DELIM + points + personDelim);
                writer.Close();
                outFile.Close();
            }
        }
    }
}
