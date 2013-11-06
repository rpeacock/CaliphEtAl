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
        

        public GameManager(Game1 game, SplashScreenGameComponent splashScreen, EndTurnButtonComponent endTurnButton, ZoneGui zoneGui, SoulGui soulGui, EndOfTurnGui endOfTurnGui, TileMap tileMap, MapComponent mapComponent, PointSystemComponent pointSystemComponent, SelectionComponent selectionComponent, NewGame newgame)
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
            //this.tileMap = tileMap;

            //Handlers
            splashScreen.VisibleChanged += new EventHandler<EventArgs>(splashScreen_VisibleChanged);
            
            endTurnButton.VisibleChanged += new EventHandler<EventArgs>(endTurnButton_VisibleChanged);
            selectionComponent.VisibleChanged += new EventHandler<EventArgs>(selectionComponent_VisibleChanged);
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
            //make sure splash screen is gone
            splashScreen.Visible = false;
            splashScreen.Enabled = false;

            newgame.Visible = true;
            newgame.Enabled = true;

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

            //Map visible
            //tileMap.Visible = true;
            //tileMap.Enabled = true;

            //make map enabled and visible //to be implemented

            //test - this should not be here
            zoneGui.Visible = true;
            zoneGui.Enabled = true;

            
        }
    }
}
