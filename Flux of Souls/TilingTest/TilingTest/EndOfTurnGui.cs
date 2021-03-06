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
    public class EndOfTurnGui : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D endOfTurnGuiTexture;
        Rectangle boundsRectangle;

        //Quit Button
        Texture2D quit;
        Rectangle quitRectangle;
        Rectangle quitRectanglePosition;
        //Next Turn Button
        Texture2D nextTurn;
        Rectangle nextTurnRectangle;
        Rectangle nextTurnRectanglePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        public bool quitSession = false;

        public EndOfTurnGui(Game game)
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

            //Loading Textures
            endOfTurnGuiTexture = Game.Content.Load<Texture2D>(@"sprites\endOfTurn");
            quit = Game.Content.Load<Texture2D>(@"sprites\quit");
            nextTurn = Game.Content.Load<Texture2D>(@"sprites\nextTurn");

            //Rectangle used to draw endOfTurnGuiTexture
            boundsRectangle = new Rectangle(0, 0, GraphicsDevice.Viewport.Bounds.Width, GraphicsDevice.Viewport.Bounds.Height);
            base.LoadContent();

            //Quit rectangles
            quitRectangle = new Rectangle(0, 0, quit.Bounds.Width, quit.Bounds.Height);
            quitRectanglePosition = new Rectangle(600, 400, quit.Bounds.Width, quit.Bounds.Height);

            //NextTurn rectangles
            nextTurnRectangle = new Rectangle(0, 0, nextTurn.Bounds.Width, nextTurn.Bounds.Height);
            nextTurnRectanglePosition = new Rectangle(600, 350, nextTurn.Bounds.Width, nextTurn.Bounds.Height);
        }
        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {

            currentMouseState = Mouse.GetState();
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && quitRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                Quit();
            }
            if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && nextTurnRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
            {
                int currentTurn = Turn.getCurrentTurn();
                if (currentTurn == Turn.getLastTurn())
                {
                    //End Game Component 
                    this.Visible = false;
                    //Score saved
                }
                else
                {
                    Turn.setCurrentTurn(currentTurn + 1);
                    Souls.endOfTurn();
                    NextTurn();
                }
            }
            pastMouseState = currentMouseState;
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(endOfTurnGuiTexture, boundsRectangle, Color.White);
            spriteBatch.Draw(quit, quitRectanglePosition, quitRectangle, Color.White);
            spriteBatch.Draw(nextTurn, nextTurnRectanglePosition, nextTurnRectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //To be implemented
        public void NextTurn()
        {
            PointAndCurency.addGold(500);

            List<Zone> zones = new List<Zone>();
            zones = MapComponent.GetZones();

            foreach (Zone zone in zones)
            {
                if (Int32.Parse(zone.getNumberOfSouls()) > 3)
                {
                    if (zone.GetZoneType() == 2)
                    {
                        int oldNumberOfSouls = Int32.Parse(zone.getNumberOfSouls());
                        zone.setNumberOfSouls(oldNumberOfSouls + 2);
                    }
                    if (zone.GetZoneType() == 3)
                    {
                        int oldNumberOfSouls = Int32.Parse(zone.getNumberOfSouls());
                        zone.setNumberOfSouls(oldNumberOfSouls + 4);
                    }
                    if (zone.GetZoneType() == 4)
                    {
                        int oldNumberOfSouls = Int32.Parse(zone.getNumberOfSouls());
                        zone.setNumberOfSouls(oldNumberOfSouls + 7);
                    }
                    if (zone.GetZoneType() == 5)
                    {
                        int oldNumberOfSouls = Int32.Parse(zone.getNumberOfSouls());
                        zone.setNumberOfSouls(oldNumberOfSouls + 10);
                    }

                }
                else
                {
                    if(zone.GetZoneType() != 1)
                    {
                        int oldNumberOfSouls = Int32.Parse(zone.getNumberOfSouls());
                        zone.setNumberOfSouls(oldNumberOfSouls + 1);
                    }                
                }
            }    


            quitSession = false;
            this.Visible = false;
            this.Enabled = false;
        }

        public void Quit()
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



            quitSession = true;
            this.Visible = false;
            this.Enabled = false;
        }
    }
}
