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
    public class Difficulty : DrawableGameComponent
    {
        SpriteBatch spriteBatch;

        Texture2D newgametexture;
        Rectangle newgameRectangle;
        Rectangle newgameRectanglePosition;

        Texture2D easybutton;
        Rectangle easybuttonbuttonrectangle;
        Rectangle easybuttonbuttonrectanglepos;

        Texture2D normalButton;
        Rectangle normalbuttonrectangle;
        Rectangle normalbuttonrectanglepos;

        Texture2D expertbutton;
        Rectangle expertbuttonrectangle;
        Rectangle expertbuttonrectanglepos;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public Difficulty(Game game)
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
            easybutton = Game.Content.Load<Texture2D>(@"sprites\easybutton");
            expertbutton = Game.Content.Load<Texture2D>(@"sprites\expertbutton");
            normalButton = Game.Content.Load<Texture2D>(@"sprites\normalbutton");

            newgameRectangle = new Rectangle(0, 0, newgametexture.Width, newgametexture.Height);
            newgameRectanglePosition = new Rectangle(0, 0, (int)(newgametexture.Width), GraphicsDevice.Viewport.Bounds.Height);

            easybuttonbuttonrectangle = new Rectangle(0, 0, easybutton.Bounds.Width, easybutton.Bounds.Height);
            easybuttonbuttonrectanglepos = new Rectangle(115, 115, easybutton.Bounds.Width, easybutton.Bounds.Height);

            normalbuttonrectangle = new Rectangle(0, 0, normalButton.Bounds.Width, normalButton.Bounds.Height);
            normalbuttonrectanglepos = new Rectangle(115, 230, normalButton.Bounds.Width, normalButton.Bounds.Height);

            expertbuttonrectangle = new Rectangle(0, 0, expertbutton.Bounds.Width, expertbutton.Bounds.Height);
            expertbuttonrectanglepos = new Rectangle(115, 345, expertbutton.Bounds.Width, expertbutton.Bounds.Height);

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here
            currentMouseState = Mouse.GetState();

            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && easybuttonbuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                StartNewGame();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && normalbuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && expertbuttonrectanglepos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }


        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(newgametexture, newgameRectanglePosition, newgameRectangle, Color.White);
            spriteBatch.Draw(easybutton, easybuttonbuttonrectanglepos, easybuttonbuttonrectangle, Color.White);
            spriteBatch.Draw(normalButton, normalbuttonrectanglepos, normalbuttonrectangle, Color.White);
            spriteBatch.Draw(expertbutton, expertbuttonrectanglepos, expertbuttonrectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void StartNewGame()
        {
            this.Enabled = false;
            this.Visible = false;
        }
    }
}
