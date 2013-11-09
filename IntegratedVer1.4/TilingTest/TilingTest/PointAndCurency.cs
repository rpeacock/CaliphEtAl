using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluxOfSouls
{
    public class PointAndCurency
    {
        static int gold;
        static int souls;
        static int points;

        public PointAndCurency()
        {
            gold = 5000;
            souls = 0;
            points = 0;
        }

        static public void SetGold(int newGold)
        {
            gold = newGold;
        }
        static public int GetGold()
        {
            return gold;
        }
        static public void SetSouls(int newSouls)
        {
            souls = newSouls;
        }
        static public int GetSouls()
        {
            return souls;
        }
        static public void SetPoints(int newPoints)
        {
            points = newPoints;
        }
        static public int GetPoints()
        {
            return points;
        }

        static public void subtractGold(int goldToSubtract)
        {
            gold = gold - goldToSubtract;
        }
        static public void addGold(int goldToAdd)
        {
            gold = gold + goldToAdd;
        }
        static public void subtractSouls(int soulsToSubtract)
        {
            souls = souls - soulsToSubtract;
        }
        static public void addSouls(int soulsToAdd)
        {
            souls = souls + soulsToAdd;
        }
        static public void subtractPoints(int pointsToSubtract)
        {
            points = points - pointsToSubtract;
        }
        static public void addPoints(int pointsToAdd)
        {
            points = points + pointsToAdd;
        }
    }
}
