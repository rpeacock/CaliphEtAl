using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluxOfSouls
{
    class GameManager
    {
        SplashScreenGameComponent splashScreen;
        EndTurnButtonComponent endTurnButton;
        ZoneGui zoneGui;
        SoulGui soulGui;
        EndOfTurnGui endOfTurnGui;
        TileMap tileMap;
        MapComponent mapComponent;
        PointSystemComponent pointSystemComponent;
        SelectionComponent selectionComponent;
        NewGame newgame;
        Difficulty difficulty;

        public GameManager(Game1 game, SplashScreenGameComponent splashScreen, EndTurnButtonComponent endTurnButton, ZoneGui zoneGui, SoulGui soulGui, EndOfTurnGui endOfTurnGui, TileMap tileMap, MapComponent mapComponent, PointSystemComponent pointSystemComponent, SelectionComponent selectionComponent, NewGame newgame, Difficulty difficulty)
        {
            this.splashScreen = splashScreen;
            this.endTurnButton = endTurnButton;
            this.zoneGui = zoneGui;
            this.soulGui = soulGui;
            this.endOfTurnGui = endOfTurnGui;
            this.mapComponent = mapComponent;
            this.pointSystemComponent = pointSystemComponent;
            this.selectionComponent = selectionComponent;
            this.newgame = newgame;
            this.difficulty = difficulty;
            //Handlers
            splashScreen.VisibleChanged += new EventHandler<EventArgs>(splashScreen_VisibleChanged);
            
            endTurnButton.VisibleChanged += new EventHandler<EventArgs>(endTurnButton_VisibleChanged);
            selectionComponent.VisibleChanged += new EventHandler<EventArgs>(selectionComponent_VisibleChanged);
            newgame.VisibleChanged += new EventHandler<EventArgs>(newgame_VisibleChanged);
            difficulty.VisibleChanged += new EventHandler<EventArgs>(difficulty_VisibleChanged);
        }

        void difficulty_VisibleChanged(object sender, EventArgs e)
        {
            if (newgame.Visible == false && splashScreen.Visible == false)
            {

                //Add end turn button component
                endTurnButton.Visible = true;
                endTurnButton.Enabled = true;

                //Map is made visible
                mapComponent.Visible = true;
                mapComponent.Enabled = true;

                //PointSystem is visible
                pointSystemComponent.Visible = true;
                pointSystemComponent.Enabled = true;

                //Selection - green square made visible
                selectionComponent.Visible = true;
                selectionComponent.Enabled = true;


                //Allows the zoneGui thread to run
                zoneGui.Visible = false;
                zoneGui.Enabled = true;

            }
        }

        void newgame_VisibleChanged(object sender, EventArgs e)
        {
            if (newgame.Visible == false && splashScreen.Visible == false)
            {

                difficulty.Visible = true;
                difficulty.Enabled = true;

            }
        }

        void selectionComponent_VisibleChanged(object sender, EventArgs e)
        {
            if (selectionComponent.Visible == true)
            {
                //zoneGui.Visible = true;
                //zoneGui.Enabled = true;
            }
        }

        void endTurnButton_VisibleChanged(object sender, EventArgs e)
        {
            if (endTurnButton.Visible == false)
            {
                //End turn button is hidden
                endTurnButton.Visible = false;
                endTurnButton.Enabled = false;

                //Map is hidden to be implemented

                //Selection gets hidden
                selectionComponent.Visible = false;
                selectionComponent.Enabled = false;

                //zone or soul guis are hidden.
                if (zoneGui.Visible == true)
                {
                    zoneGui.Visible = false;
                    zoneGui.Enabled = false;
                }
                if (soulGui.Visible == true)
                {
                    soulGui.Visible = false;
                    soulGui.Enabled = false;
                }

                //if(true)//Hide any menu options if there are any
                //{ 
                //}

                //end of Turn GUI is enabled and made visible
                endOfTurnGui.Visible = true;
                endOfTurnGui.Enabled = true;
            }
        }

        void splashScreen_VisibleChanged(object sender, EventArgs e)
        {
            if (splashScreen.Visible == false)
            {
                newgame.Visible = true;
                newgame.Enabled = true;
            }
        }
    }
}
