using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    [Serializable]
    public class Dangeon
    {
        public DateTime Start { get; set; }
        public DateTime Finish { get; set; }
        public int KilledMonster { get; set; }
        public Activity Activity { get; set; }
        public Hero Hero { get; set; }
        public Dangeon(DateTime start, DateTime finish, Activity activity, int monster, Hero hero)
        {
            Start = start;
            Finish = finish;
            Activity = activity;
            KilledMonster = monster;
            Hero = hero;
        }
    }
}
