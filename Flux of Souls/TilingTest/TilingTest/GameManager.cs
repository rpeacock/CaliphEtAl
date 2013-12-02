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
        CurrencyControllerComponent currencyController;
        TurnComponent turnComponent;
        InstructionsGui instructions;
        ResultScreen resultscreen;

        public GameManager(Game1 game, SplashScreenGameComponent splashScreen, EndTurnButtonComponent endTurnButton, ZoneGui zoneGui, SoulGui soulGui, EndOfTurnGui endOfTurnGui, TileMap tileMap, MapComponent mapComponent, PointSystemComponent pointSystemComponent, SelectionComponent selectionComponent, NewGame newgame, Difficulty difficulty, CurrencyControllerComponent currencyController, TurnComponent turnComponent, InstructionsGui instructions, ResultScreen resultScreen)
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
            this.currencyController = currencyController;
            this.turnComponent = turnComponent;
            this.instructions = instructions;
            this.resultscreen = resultScreen;

            //Handlers
            splashScreen.VisibleChanged += new EventHandler<EventArgs>(splashScreen_VisibleChanged);
            endOfTurnGui.VisibleChanged += new EventHandler<EventArgs>(endOfTurnGui_VisibleChanged);
            endTurnButton.VisibleChanged += new EventHandler<EventArgs>(endTurnButton_VisibleChanged);
            selectionComponent.VisibleChanged += new EventHandler<EventArgs>(selectionComponent_VisibleChanged);
            newgame.VisibleChanged += new EventHandler<EventArgs>(newgame_VisibleChanged);
            difficulty.VisibleChanged += new EventHandler<EventArgs>(difficulty_VisibleChanged);
            instructions.VisibleChanged += new EventHandler<EventArgs>(instructions_VisibleChanged);
            resultscreen.VisibleChanged += new EventHandler<EventArgs>(resultscreen_VisibleChanged);
        }

        void resultscreen_VisibleChanged(object sender, EventArgs e)
        {

        }

        void endOfTurnGui_VisibleChanged(object sender, EventArgs e)
        {
            if (endOfTurnGui.Visible == false && splashScreen.Visible == false)
            {
                if (endOfTurnGui.quitSession == false && Turn.getCurrentTurn() < Turn.getLastTurn())
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

                    //Turn Component made visible
                    turnComponent.Visible = true;
                    turnComponent.Enabled = true;


                    //Allows the zoneGui thread to run
                    zoneGui.Visible = true;
                    zoneGui.Enabled = true;

                    currencyController.Visible = true;
                    currencyController.Enabled = true;
                }

                if (endOfTurnGui.quitSession == true)
                {


                    //Add end turn button component
                    endTurnButton.Visible = false;
                    endTurnButton.Enabled = false;

                    //Map is made visible
                    mapComponent.Visible = false;
                    mapComponent.Enabled = false;

                    //PointSystem is visible
                    pointSystemComponent.Visible = false;
                    pointSystemComponent.Enabled = false;

                    //Selection - green square made visible
                    selectionComponent.Visible = false;
                    selectionComponent.Enabled = false;

                    //CurrencyController made visible
                    currencyController.Visible = false;
                    currencyController.Enabled = false;

                    //Turn Component made visible
                    turnComponent.Visible = false;
                    turnComponent.Enabled = false;

                    //Allows the zoneGui thread to run
                    zoneGui.Visible = false;
                    zoneGui.Enabled = false;

                    mapComponent.Visible = false;
                    mapComponent.Enabled = false;

                    newgame.Visible = true;
                    newgame.Enabled = true;
                }

                if (Turn.getCurrentTurn() == Turn.getLastTurn())
                {
                    Souls.endOfGame();
                    endOfTurnGui.Enabled = false;
                    endOfTurnGui.Visible = false;
                    mapComponent.Visible = false;
                    resultscreen.Visible = true;
                    pointSystemComponent.Visible = false;

                }


            }
        }

        void difficulty_VisibleChanged(object sender, EventArgs e)
        {
            if (difficulty.Visible == false && splashScreen.Visible == false && newgame.Visible == false)
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

                //CurrencyController made visible
                currencyController.Visible = true;
                currencyController.Enabled = true;

                //Turn Component made visible
                turnComponent.Visible = true;
                turnComponent.Enabled = true;

                //Allows the zoneGui thread to run
                zoneGui.Visible = true;
                zoneGui.Enabled = true;

            }

            
        }

        void newgame_VisibleChanged(object sender, EventArgs e)
        {
            if (newgame.Visible == false && splashScreen.Visible == false)
            {
                if (newgame.newGameSession == true)
                {
                    difficulty.Visible = true;
                    difficulty.Enabled = true;
                }

                if (newgame.newGameSession == false)
                {
                    instructions.Visible = true;
                    instructions.Enabled = true;
                }
            }
        }

        void selectionComponent_VisibleChanged(object sender, EventArgs e)
        {
            if (selectionComponent.Visible == true)
            {
                zoneGui.Visible = true;
                zoneGui.Enabled = true;
            }
        }

        

        void endTurnButton_VisibleChanged(object sender, EventArgs e)
        {
            if (endTurnButton.Visible == false)
            {
                //End turn button is hidden
                endTurnButton.Visible = false;
                endTurnButton.Enabled = false;

                //Turn Component made visible
                turnComponent.Visible = false;
                turnComponent.Enabled = false;

                //Map is hidden to be implemented

                //Selection gets hidden
                selectionComponent.Visible = false;
                selectionComponent.Enabled = false;
                
                //Currency controller hidden
                currencyController.Visible = false;
                currencyController.Enabled = false;
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

        void instructions_VisibleChanged(object sender, EventArgs e)
        {
            if (instructions.Visible == false && instructions.returnMenu == true)
            {
                newgame.Visible = true;
                newgame.Enabled = true;
            }
        }
    }
}
