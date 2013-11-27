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
    public class InstructionsGui : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D instructionsGuiTexture;
        Rectangle boundsRectangle;

        SpriteFont font;
        string text;
        Vector2 textPos = new Vector2(80,100);

        Texture2D nextInstructions;
        Rectangle nextInstructRectangle;
        Rectangle nextInstructPos;

        Texture2D prevInstructions;
        Rectangle prevInstructRectangle;
        Rectangle prevInstructPos;

        Texture2D back;
        Rectangle backRectangle;
        Rectangle backPos;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public bool returnMenu;

        public InstructionsGui(Game game)
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

            instructionsGuiTexture = Game.Content.Load<Texture2D>(@"sprites\instructions");
            font = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");
            back = Game.Content.Load<Texture2D>(@"sprites\back");
            prevInstructions = Game.Content.Load<Texture2D>(@"sprites\prev");
            nextInstructions = Game.Content.Load<Texture2D>(@"sprites\next");

            //Rectangle used to draw instructionsGuiTexture
            boundsRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height);

            prevInstructRectangle = new Rectangle(0, 0, prevInstructions.Bounds.Width, prevInstructions.Bounds.Height);
            prevInstructPos = new Rectangle(400, 400, prevInstructions.Bounds.Width, prevInstructions.Bounds.Height);

            nextInstructRectangle = new Rectangle(0, 0, nextInstructions.Bounds.Width, nextInstructions.Bounds.Height);
            nextInstructPos = new Rectangle(580, 400, nextInstructions.Bounds.Width, nextInstructions.Bounds.Height);

            backRectangle = new Rectangle(0, 0, back.Bounds.Width, back.Bounds.Height);
            backPos = new Rectangle(80, 400, back.Bounds.Width, back.Bounds.Height);

            text = "Welcome to Flux of Souls!" + 
                "\nYou are a benevolent God and have been tasked with" +
                "\nkeeping all your followers happy by ensuring their quality of" + 
                "\nlife. You will not have any control over the people themselves" + 
                "\nbut you will be able to control their environment." + 
                "\nThe game is turn based and you'll have a set amount of turns" +
                "\nto get the highest score possible. Good Luck!";

            base.LoadContent();

        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && prevInstructPos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                Previous();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && nextInstructPos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                Next();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && backPos.Contains(currentMouseState.X, currentMouseState.Y))
            {
                Back();
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(instructionsGuiTexture, boundsRectangle, Color.White);
            spriteBatch.DrawString(font, text, textPos, Color.Black);
            spriteBatch.Draw(back, backPos, backRectangle, Color.White);
            spriteBatch.Draw(prevInstructions, prevInstructPos, prevInstructRectangle, Color.White);
            spriteBatch.Draw(nextInstructions, nextInstructPos, nextInstructRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //To be implemented
        private void Previous()
        {
            text = "Welcome to Flux of Souls!" +
               "\nYou are a benevolent God and have been tasked with" +
               "\nkeeping all your followers happy by ensuring their quality of" +
               "\nlife. You will not have any control over the people themselves" +
               "\nbut you will be able to control their environment." +
               "\nThe game is turn based and you'll have a set amount of turns" +
               "\nto get the highest score possible. Good Luck!";
        }

        private void Next()
        {
            text = "Tiles" +
                "\nWater: Water tiles cannot sustain any population" +
                "\nLand: Land tiles can sustain a very small population" +
                "\nVillage: Village tiles can sustain a small population" +
                "\nTown: Town tiles can sustain an average population" +
                "\nCity: City tiles can sustain a large population";
        }

        private void Back()
        {
            returnMenu = true;
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
