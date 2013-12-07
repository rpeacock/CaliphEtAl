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
    public class Soul
    {
        public int soulNumber;
        public string soulName;
        public int age;
        public int maxAge;
        public int goodLevel;
        public int tileID;

    }

    public class Souls
    {
        public static List<Soul> souls = new List<Soul>();
        public static Random random = new Random();
        public static int allSoul = 0;
        public static int turn = 0;

        public static void createSoul()
        {
            allSoul++;
            souls.Add(new Soul
            {
                soulNumber = allSoul,
                soulName = "currency",
                age = 0,
                maxAge = random.Next(30, 140),
                goodLevel = random.Next(-10, 35),
                tileID = 0
            });
        }
        public static void buySoul()
        {
            int currentGold = PointAndCurency.GetGold();
            int currentSouls = PointAndCurency.GetSouls();
            if (currentGold >= 100)
            {
                currentGold = currentGold - 100;
                currentSouls = currentSouls + 1;
                PointAndCurency.SetSouls(currentSouls);
                PointAndCurency.SetGold(currentGold);
                allSoul++;
                souls.Add(new Soul
                {
                    soulNumber = allSoul,
                    soulName = "currency",
                    age = 0,
                    maxAge = random.Next(30, 140),
                    goodLevel = random.Next(-10, 35),
                    tileID = 0
                });
            }
        }
        public static void sellSoul()
        {
            int currentGold = PointAndCurency.GetGold();
            int currentSouls = PointAndCurency.GetSouls();
            int selling = 0;
            int soulID = 0;
            foreach (var soul in souls)
            {
                if (soul.soulName == "currency" && selling == 0)
                {
                    currentSouls = currentSouls - 1;
                    currentGold = currentGold + 75;
                    selling++;
                    soul.soulName = "sold";
                    PointAndCurency.SetSouls(currentSouls);
                    PointAndCurency.SetGold(currentGold);
                    soul.soulNumber = soulID;
                }
                
            }
        }
        public static void returnSoul(Zone zone)
        {

            int numSouls = Convert.ToInt32(zone.getNumberOfSouls());
            int soulsOnHand = PointAndCurency.GetSouls();

            if (zone.GetZoneType() >= 2)
            {
                zone.setNumberOfSouls(numSouls + 1);
                PointAndCurency.SetSouls(soulsOnHand - 1);
            }



            /*foreach (var soul in souls)
            {
                if (soul.soulName == "currency")
                {
                    soul.soulName = "alive";
                    soul.age = 0;
                    soul.maxAge = random.Next(30, 140);
                    soul.goodLevel = soul.goodLevel - 2;
                    
                }
            }*/
        }
        public static void scoreSoul()
        {
            int currentPoints = PointAndCurency.GetPoints();
            int currentSouls = PointAndCurency.GetSouls();
            int selling = 0;
            foreach (var soul in souls)
            {
                if (soul.soulName == "currency" && selling == 0)
                {
                    currentPoints = (currentPoints + soul.goodLevel);
                    currentSouls = currentSouls - 5;
                    selling++;
                    soul.soulName = "point";
                    PointAndCurency.SetSouls(currentSouls);
                    PointAndCurency.SetPoints(currentPoints);
                }
            }
        }

        public static void scoreSoul(int numSouls)
        {
            int currentPoints = PointAndCurency.GetPoints();
            int currentSouls = PointAndCurency.GetSouls();
            int selling = 0;
            foreach (var soul in souls)
            {
                if (soul.soulName == "currency" && selling < numSouls)
                {
                    currentPoints = (currentPoints + soul.goodLevel);
                    //currentSouls = currentSouls - 1;
                    selling++;
                    soul.soulName = "point";
                    PointAndCurency.SetSouls(currentSouls);
                    PointAndCurency.SetPoints(currentPoints);
                }
            }
        }
        public static int needCalculation()
        {
            return random.Next(0, 10) - 3;
        }
        public static string resourceMangement()
        {
            foreach (var soul in souls)
            {
                if (soul.soulName == "dead")
                {
                    soul.soulName = "currency";
                }
            }
            return null;
        }
        public static void babySoul()
        {
            int cluster = 0;
            for (int x = 1; x < 101; x++)
            {
                cluster = 0;
                foreach (var soul in souls)
                {
                    if (soul.tileID == x && soul.age >= 16)
                    {
                        cluster = cluster + 1;
                    }
                }
                cluster = cluster / 2;
                while (cluster > 2)
                {
                    if (random.Next(0, 5) == 3)
                    { 
                        allSoul++;
                        souls.Add(new Soul
                        {
                            soulNumber = allSoul,
                            soulName = "alive",
                            age = 0,
                            maxAge = random.Next(30, 140),
                            goodLevel = random.Next(10, 45),
                            tileID = x
                        });
                    }
                    cluster = cluster - 2;
                }
            }
        }
        public static void endOfTurn()
        {
            int points = PointAndCurency.GetPoints();
            int multiple = 15;
            foreach (var soul in souls)
            {
                if (soul.soulName == "alive")
                {
                    soul.age = soul.age + (1 * multiple);
                    if (soul.age >= soul.maxAge)
                    {
                        soul.soulName = "dead";
                    }
                    else
                    {
                        soul.goodLevel = soul.goodLevel + needCalculation();
                    }
                }
            }
            resourceMangement();
            babySoul();
            points = (int)(points * 1.2);
            PointAndCurency.SetPoints(points);
        }
        public static void endOfGame()
        {
            int currentGold = PointAndCurency.GetGold();
            int currentPoints = PointAndCurency.GetPoints();
            if (currentGold >= 80)
            {
                currentGold = currentGold / 80;
                currentPoints = currentPoints + currentGold;
            }
            foreach (var soul in souls)
            {
                if (soul.soulName == "alive")
                {
                    currentPoints = currentPoints + (soul.goodLevel - (soul.maxAge - soul.age));
                    PointAndCurency.SetPoints(currentPoints);
                }
                else if (soul.soulName == "currency")
                {
                    currentPoints = PointAndCurency.GetPoints();
                    currentPoints = currentPoints + (soul.goodLevel / 2);
                    PointAndCurency.SetPoints(currentPoints);
                }
            }
        }
    }
}