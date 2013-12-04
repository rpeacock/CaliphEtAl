using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FluxOfSouls
{
    class Highscore : IComparable
    {
        String name;
        int totalScore = 0;

        public Highscore(String name, int points)
        {
            this.name = name;
            this.totalScore = points;
        }

        public String GetScoreName()
        {
            return name;
        }
        public int GetScoreTotal()
        {
            return totalScore;
        }

        int IComparable.CompareTo(Object obj)
        {
            Highscore o = (Highscore)obj;
            if (this.totalScore > o.GetScoreTotal())
            {
                return 1;
            }
            else if (this.totalScore < o.GetScoreTotal())
            {
                return -1;
            }
            else
            {
                return 0;
            }
        }
    }
}
