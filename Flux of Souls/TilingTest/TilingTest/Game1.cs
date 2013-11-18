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


/*Edited Version of Tutorial http://www.xnaresources.com/default.asp?page=Tutorial:TileEngineSeries:3 */

namespace FluxOfSouls
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Components
        SplashScreenGameComponent splashScreen;
        EndOfTurnGui endOfTurnGui;
        ZoneGui zoneGui;
        SoulGui soulGui;
        EndTurnButtonComponent endTurnButton;
        MapComponent mapComponent;
        PointSystemComponent pointSystemComponent;
        SelectionComponent selectionComponent;
        NewGame newgame;
        Difficulty difficulty; 
        Song mozart;

        //PointAndCurrency System class
        PointAndCurency pointAndCurency; //data class with only static methods for currency values


        //Map Components - 3 lines below belong together
        TileMap tileMap;
        public Soul soulsList = new Soul();
        static public Vector2 Location = Vector2.Zero;
        
        //Game Manager Class
        GameManager gameManager;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            
            splashScreen = new SplashScreenGameComponent(this);
            endOfTurnGui = new EndOfTurnGui(this);
            zoneGui = new ZoneGui(this);
            soulGui = new SoulGui(this);
            endTurnButton = new EndTurnButtonComponent(this);
            mapComponent = new MapComponent(this);
            pointSystemComponent = new PointSystemComponent(this);
            newgame = new NewGame(this);
            selectionComponent = new SelectionComponent(this);
            difficulty = new Difficulty(this); 
            //pointAndCurrency is instantiated 
            pointAndCurency = new PointAndCurency();
            
            //tileMap = new TileMap(this);

            gameManager = new GameManager(this, splashScreen, endTurnButton, zoneGui, soulGui, endOfTurnGui, tileMap, mapComponent, pointSystemComponent, selectionComponent,newgame, difficulty);

            //tileMap.Visible = false;
            //tileMap.Enabled = false;
            //Components.Add(tileMap);
            

            pointSystemComponent.Visible = false;
            pointSystemComponent.Enabled = false;
            Components.Add(pointSystemComponent);

            mapComponent.Visible = false;
            mapComponent.Enabled = false;
            Components.Add(mapComponent);

            endTurnButton.Visible = false;
            endTurnButton.Enabled = false;
            Components.Add(endTurnButton); //drawn first to be covered by splash screen since hiding it calls the event handler for endTurn button clicked

            Components.Add(splashScreen);

            endOfTurnGui.Visible = false;
            endOfTurnGui.Enabled = false;
            Components.Add(endOfTurnGui);

            zoneGui.Visible = false;
            zoneGui.Enabled = false;
            Components.Add(zoneGui);

            soulGui.Visible = false;
            soulGui.Enabled = false;
            Components.Add(soulGui);

            selectionComponent.Visible = false;
            selectionComponent.Enabled = false;
            Components.Add(selectionComponent);

            newgame.Visible = false;
            newgame.Enabled = false;
            Components.Add(newgame);

            difficulty.Visible = false;
            difficulty.Enabled = false;
            Components.Add(difficulty);
        }
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Tile.TileSetTexture = Content.Load<Texture2D>(@"images\TileSets\part3_tileset");
            // TODO: use this.Content to load your game content here

            mozart = Content.Load<Song>(@"Sounds\mozart");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(mozart);
        }

        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {  
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }
        public void Quit()
        {
            this.Exit();
        }
    }
}
