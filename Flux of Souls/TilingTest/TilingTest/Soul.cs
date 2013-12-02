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
        public static void buySoul(int soulLevel, int tile)
        {
            allSoul++;
            souls.Add(new Soul
            {
                soulNumber = allSoul,
                soulName = "alive",
                age = 0,
                maxAge = random.Next(30, 140),
                goodLevel = soulLevel,
                tileID = tile
            });
        }
        public static void sellSoul()
        {
            int currentGold = PointAndCurency.GetGold();
            int currentSouls = PointAndCurency.GetSouls();
            int selling = 0;
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
                }
            }
        }
        public static void returnSoul(Zone zone)
        {
            
            foreach (var soul in souls)
            {
                if (soul.soulName == "currency")
                {
                    soul.soulName = "alive";
                    soul.age = 0;
                    soul.maxAge = random.Next(30, 140);
                    soul.goodLevel = soul.goodLevel - 2;
                    soul.tileID = Convert.ToInt32(zone.getZoneIDString());
                    
                }
            }
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
                    currentSouls = currentSouls - 1;
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
            points = (int)(points * 1.2);
            PointAndCurency.SetPoints(points);
        }

    }
}