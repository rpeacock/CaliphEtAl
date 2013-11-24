using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluxOfSouls
{
    class Turn
    {
        private static int currentTurn = 1;
        
        private static int easyLastTurn = 30;
        private static int mediumLastTurn = 20;
        private static int hardLastTurn = 10;

        private static int lastTurn = 30;

        public static string difficulty;

        public Turn()
        {
            lastTurn = easyLastTurn;
            currentTurn = 1;
        }

        public static int getCurrentTurn()
        {
            return currentTurn;
        }
        public static void setCurrentTurn(int turn)
        {
            currentTurn = turn;
        }

        public static void setDifficulty(String chosenDifficulty)
        {
            difficulty = chosenDifficulty;
            if (difficulty == "easy")
            {
                lastTurn = easyLastTurn;
            }
            else if (difficulty == "normal")
            {
                lastTurn = mediumLastTurn;
            }
            else
            {
                lastTurn = hardLastTurn;
            }
        }

        public static int getLastTurn()
        {
            return lastTurn;
        }
    }
}
