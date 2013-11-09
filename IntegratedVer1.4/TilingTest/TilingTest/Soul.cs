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
        //public int lawLevel;
        public int goodLevel;
        public int posX;
        public int posY;
        
    }

    public class Souls
    {
        public static List<Soul> souls = new List<Soul>();
        Random random = new Random();
        public int allSoul = 0;
        public int turn = 0;

        public void createSoul ()
        {
            allSoul++;
            souls.Add(new Soul
            {
                soulNumber = allSoul,
                soulName = "alive",
                age = 0,
                maxAge = random.Next(30, 140),
                //lawLevel = random.Next(-25, 25),
                goodLevel = random.Next(-25, 25),
                posX = 0,
                posY = 0
            });
        }
        public int needCalculation()
        {
            return 1;//null;
            //Population: Most common field for the first 4 turns only this field is active; its level is the tiles population divided by the max population multiply by 100  (CP/TP *100). If the amount is above 100 then the number is decreased by 100 and changed to a negative.
            //Food: Second field active at turn 4
            //Entertainment:  active after turn 4 
            //Fresh Water:  Third field active at turn 4 
            //Security:  active after turn 8
            //Education:  active after turn 8
            //Economy: active after turn 8

        }
        public string resourceMangement()
        {
            return null;
        }
        public void endOfTurn(int multiple)
        {
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
                        //soul.lawLevel = soul.lawLevel + (random.Next(-3, 3));
                        soul.goodLevel = soul.goodLevel + needCalculation();
                    }
                }
            }
            turn++;
            resourceMangement();
        }

    }
}