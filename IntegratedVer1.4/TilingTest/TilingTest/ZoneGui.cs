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
    public class ZoneGui : DrawableGameComponent
    {
        SpriteBatch spriteBatch;
        Texture2D zoneGuiTexture;
        Rectangle zoneGuiRectangle;
        Rectangle zoneGuiRectanglePosition;

        //cashSouls Button
        Texture2D cashSoulsTexture;
        Rectangle cashSoulsRectangle;
        Rectangle cashSoulsRectanglePosition;

        //upgrade Button
        Texture2D upgradeTexture;
        Rectangle upgradeRectangle;
        Rectangle upgradeRectanglePosition;

        //MouseStates
        MouseState currentMouseState;
        MouseState pastMouseState;

        //Selected Zone. Used to know when a zone is selected to therefore only draw the zoneGui when a zone is selected.
        Zone zoneSelected;


        //SpriteFonts to view actual zone information and values
        SpriteFont spriteFont;
        String idString;
        String typeString;
        String numberOfSoulsString;
        String upgradeCostString;

        //Vectors to position strings with currency values
        Vector2 idStringPosition;
        Vector2 typeStringPosition;
        Vector2 numberOfSoulsStringPosition;
        Vector2 upgradeCostStringPosition;

        public ZoneGui(Game game)
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
            //loading Fonts
            spriteFont = Game.Content.Load<SpriteFont>(@"fonts\CourierNew");

            //setting position of strings holding currency values
            idStringPosition = new Vector2(15, 80);
            typeStringPosition = new Vector2(15, 110);
            upgradeCostStringPosition = new Vector2(15, 140);
            numberOfSoulsStringPosition = new Vector2(620, 17);

            //Loading Textures
            spriteBatch = new SpriteBatch(GraphicsDevice);
            zoneGuiTexture = Game.Content.Load<Texture2D>(@"sprites\zoneGui");
            upgradeTexture = Game.Content.Load<Texture2D>(@"sprites\upgrade");
            cashSoulsTexture = Game.Content.Load<Texture2D>(@"sprites\cashSouls");

            //Zone rectangles
            zoneGuiRectangle = new Rectangle(0, 0, zoneGuiTexture.Width, zoneGuiTexture.Height);
            zoneGuiRectanglePosition = new Rectangle(0, 0, (int) (zoneGuiTexture.Width / 1.5), GraphicsDevice.Viewport.Bounds.Height);

            //Cash Souls button rectangles
            cashSoulsRectangle = new Rectangle(0, 0, cashSoulsTexture.Width, cashSoulsTexture.Height);
            cashSoulsRectanglePosition = new Rectangle(20, 400, cashSoulsTexture.Width, cashSoulsTexture.Height);
            
            //Upgrade Rectangles
            upgradeRectangle = new Rectangle(0, 0, upgradeTexture.Width, upgradeTexture.Height);
            upgradeRectanglePosition = new Rectangle(20, 350, upgradeTexture.Width, upgradeTexture.Height);



            

            base.LoadContent();
        }
        
        public override void Update(GameTime gameTime)
        {
            zoneSelected = Zone.GetSelectedZone();
            if (zoneSelected == null)
            {
                this.Visible = false;
                this.Enabled = true;
            }
            else
            {
                //Getting Zone Information
                idString = zoneSelected.getZoneIDString();
                typeString = zoneSelected.getZoneName(zoneSelected.GetZoneType()); //get zone type int.. give it to the GetZoneName and receive string with name of zone type
                upgradeCostString = zoneSelected.getUpgradeCost();

                this.Visible = true;
                this.Enabled = true;

                currentMouseState = Mouse.GetState();
                if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && cashSoulsRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
                {
                    CashSouls();
                }
                if (currentMouseState.LeftButton == ButtonState.Released && pastMouseState.LeftButton == ButtonState.Pressed && upgradeRectanglePosition.Contains(currentMouseState.X, currentMouseState.Y))
                {

                    Upgrade(Zone.GetSelectedZone());
                }
                pastMouseState = currentMouseState;
            }
            base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(zoneGuiTexture, zoneGuiRectanglePosition,zoneGuiRectangle, Color.White);
            spriteBatch.Draw(cashSoulsTexture, cashSoulsRectanglePosition, cashSoulsRectangle, Color.White);
            spriteBatch.Draw(upgradeTexture, upgradeRectanglePosition, upgradeRectangle, Color.White);
            spriteBatch.DrawString(spriteFont, "Zone ID: " + idString, idStringPosition, Color.Maroon);
            spriteBatch.DrawString(spriteFont, "Zone Type:" + typeString, typeStringPosition, Color.Maroon);
            spriteBatch.DrawString(spriteFont, "Upgrade Cost:" + upgradeCostString, upgradeCostStringPosition, Color.Maroon);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        //To be implemented
        public void Upgrade(Zone zoneToUpgrade)
        {
            zoneToUpgrade.Upgrade();
        }
        public void CashSouls()
        {

        }
    }
}
