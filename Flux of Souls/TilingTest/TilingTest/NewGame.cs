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
    public class NewGame : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        
        Texture2D newgametexture;
        Rectangle newgameRectangle;
        Rectangle newgameRectanglePosition;
        
        Texture2D newgamebutton;
        Rectangle newgamebuttonrectangle;
        Rectangle newgamebuttonrectanglepos;

        Texture2D instructionsButton;
        Rectangle instructionbuttonrectangle;
        Rectangle instructionbuttonrectanglepos;
        
        Texture2D quitbutton;
        Rectangle quitbuttonrectangle;
        Rectangle quitbuttonrectanglepos;

        Texture2D highscoreButton;
        Rectangle highscoreButtonRectangle;
        Rectangle highscoreButtonRectanglepos;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public bool newGameSession;
        public bool isViewingHighScores;
        public bool isViewingInstructions;

        public NewGame(Game game)
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
            newgametexture = Game.Content.Load<Texture2D>(@"sprites\newgame");
            instructionsButton = Game.Content.Load<Texture2D>(@"sprites\viewinstructionsbutton");
            quitbutton = Game.Content.Load<Texture2D>(@"sprites\quit");
            newgamebutton = Game.Content.Load<Texture2D>(@"sprites\newgamebutton");
            highscoreButton = Game.Content.Load<Texture2D>(@"sprites\highscores");

            newgameRectangle = new Rectangle(0, 0, newgametexture.Width, newgametexture.Height);
            newgameRectanglePosition = new Rectangle(0, 0, (int)(newgametexture.Width), GraphicsDevice.Viewport.Bounds.Height);

            newgamebuttonrectangle = new Rectangle(0, 0, newgamebutton.Bounds.Width, newgamebutton.Bounds.Height);
            newgamebuttonrectanglepos = new Rectangle(115, 150, newgamebutton.Bounds.Width, newgamebutton.Bounds.Height);

            instructionbuttonrectangle = new Rectangle(0, 0, instructionsButton.Bounds.Width, quitbutton.Bounds.Height);
            instructionbuttonrectanglepos = new Rectangle(115, 210, instructionsButton.Bounds.Width, instructionsButton.Bounds.Height);

            highscoreButtonRectangle = new Rectangle(0, 0, highscoreButton.Width, highscoreButton.Height);
            highscoreButtonRectanglepos = new Rectangle(115, 270, highscoreButton.Width, highscoreButton.Height);

            quitbuttonrectangle = new Rectangle(0, 0, quitbutton.Bounds.Width, quitbutton.Bounds.Height);
            quitbuttonrectanglepos = new Rectangle(115, 330, quitbutton.Bounds.Width, quitbutton.Bounds.Height);

            base.LoadContent();
        } 

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && newgamebuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                StartNewGame();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && quitbuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
               Game.Exit();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && instructionbuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                ViewInstructions();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && highscoreButtonRectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                ViewHighscores();
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }

     
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(newgametexture, newgameRectanglePosition, newgameRectangle, Color.White);
            spriteBatch.Draw(newgamebutton, newgamebuttonrectanglepos,quitbuttonrectangle, Color.White);
            spriteBatch.Draw(quitbutton, quitbuttonrectanglepos, quitbuttonrectangle, Color.White);
            spriteBatch.Draw(instructionsButton, instructionbuttonrectanglepos, instructionbuttonrectangle, Color.White);
            spriteBatch.Draw(highscoreButton, highscoreButtonRectanglepos, highscoreButtonRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void ViewInstructions()
        {
            isViewingInstructions = true;
            newGameSession = false;
            isViewingHighScores = false;
            this.Enabled = false;
            this.Visible = false;
        }

       public void StartNewGame()
        {
            newGameSession = true;
            isViewingHighScores = false;
            isViewingInstructions = false;
            this.Enabled = false;
            this.Visible = false;
        }
       public void ViewHighscores()
       {
           isViewingHighScores = true;
           newGameSession = false;
           isViewingInstructions = false;
           this.Enabled = false;
           this.Visible = false;
       }

    }
}
