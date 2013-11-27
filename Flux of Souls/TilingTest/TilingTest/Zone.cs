using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace FluxOfSouls
{

    public class Zone
    {
        public enum ZoneStates { Water = 1, Earth, Village, Town, City }; //2,3,4,5)

        public static PointAndCurency pointAndCurrency;

        //Getting selection component that will later be used to hide and show the selection component
        static SelectionComponent selectionComponent;
        
        private int id;
        private int zoneType;
        private int upgradeCost;
        private int numberOfSouls;

        private static Zone selectedZone;

        Rectangle positionRectangle;

        public static int idCounter = 1;
        
        public Zone(int row, int col)
        {
            selectedZone = null;
            zoneType = 1;
            zoneType = (int)ZoneStates.Water;
            positionRectangle = new Rectangle((40 * col) + 300, (30 * row) + 55, 40, 30); //+300 and +55 are positioning the whole map to the right and south     
            this.id = idCounter;
            upgradeCost = 300;
            numberOfSouls = 100;
            idCounter++;
        }
        public String getUpgradeCost()
        {
            return upgradeCost.ToString();
        }
        public void setUpgradeCost(int cost)
        {
            upgradeCost = cost;
        }
        public void setTileType(int zoneType)
        {
            this.zoneType = zoneType;
        }
        public String getNumberOfSouls()
        {
            return numberOfSouls.ToString();
        }
        public void setNumberOfSouls(int numberOfSouls)
        {
            this.numberOfSouls = numberOfSouls;
        }
        public String getZoneIDString()
        {
            return id.ToString();
        }
        public String getZoneName(int zoneType)
        {
            if (zoneType == 1)
            {
                return "Water";
            }
            else if (zoneType == 2)
            {
                return "Land";
            }
            else if (zoneType == 3)
            {
                return "Village";
            }
            else if (zoneType == 4)
            {
                return "Town";
            }
            else
            {
                return "City";
            }
        }
        public int GetZoneType()
        {
            return zoneType;
        }
        public static Zone GetSelectedZone()
        {
            return selectedZone;
        }
        public static void SetSelectedZone(Zone zone)
        {
            selectedZone = zone;
        }

        public Rectangle GetPosition()
        {
            return positionRectangle;
        }
        public void Upgrade()
        {
            if (zoneType == 1)
            {
                if (PointAndCurency.GetGold() >= 300) //cost 300
                {
                    PointAndCurency.subtractGold(300);
                    zoneType = zoneType + 1;
                    upgradeCost = 500; //new cost
                }
            }
            else if (zoneType == 2)
            {
                if (PointAndCurency.GetGold() >= 500) //cost 500
                {
                    PointAndCurency.subtractGold(500);
                    zoneType = zoneType + 1;
                    upgradeCost = 700; //new cost
                }
            }
            else if (zoneType == 3)
            {
                if (PointAndCurency.GetGold() >= 700) //cost 700
                {
                    PointAndCurency.subtractGold(700);
                    zoneType = zoneType + 1;
                    upgradeCost = 1000; //new cost
                }
            }
            else if (zoneType == 4)
            {
                if (PointAndCurency.GetGold() >= 1000) //cost 1000
                {
                    PointAndCurency.subtractGold(1000);
                    zoneType = zoneType + 1;
                    upgradeCost = 0; //new cost
                }
            }
            
            //if (zoneType == (int)ZoneStates.Water)
            //{
            //    //(If player has enough money resources) then do rest        // To be implemented 
            //    //{
            //    zoneType = (int)ZoneStates.Earth;
            //    //}
            //}
            //if (zoneType == (int)ZoneStates.Earth)
            //{
            //    //(If player has enough money resources) then do rest        // To be implemented 
            //    //{
            //    zoneType = (int)ZoneStates.Village;
            //    //}
            //}
            //if (zoneType == (int)ZoneStates.Village)
            //{
            //    //(If player has enough money resources) then do rest        // To be implemented 
            //    //{
            //    zoneType = (int)ZoneStates.Town;
            //    //}
            //}
            //if (zoneType == (int)ZoneStates.Town)
            //{
            //    //(If player has enough money resources) then do rest        // To be implemented 
            //    //{
            //    zoneType = (int)ZoneStates.City;
            //    //}
            //}
            //if (zoneType == (int)ZoneStates.City)
            //{
            //    //Message that zone is not upgradable any further
            //}
        }
    }
}
