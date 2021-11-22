using GameOfRPG.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Controller
{
    public class DungeonController : ControllerBase
    {
        private const string DUNGEON_FILE_NAME = "dungeons.dat";
        private const string ACTIVITY_FILE_NAME = "activity.dat";
        private readonly Hero hero;
        public List<Dangeon> Dangeons { get; set; }
        public List<Activity> Activities { get; set; }
        public DungeonController(Hero hero)
        {
            this.hero = hero ?? throw new ArgumentNullException(nameof(hero));
            Dangeons = GetAllDungeons();
            Activities = GetAllActivities();
        }

        public void Add(Activity act, DateTime begin, DateTime end, int killedMonster)
        {
            var a = Activities.SingleOrDefault(f => f.Name == act.Name);
            if(a == null)
            {
                Activities.Add(act);

                var dang = new Dangeon(begin, end, act, killedMonster, hero);
                Dangeons.Add(dang);
            }
            else
            {
                var dang = new Dangeon(begin, end, act, killedMonster, hero);
                Dangeons.Add(dang);
            }
            Save();
        }

        private List<Dangeon> GetAllDungeons()
        {
            return Load<List<Dangeon>>(DUNGEON_FILE_NAME) ?? new List<Dangeon>();
        }
        private List<Activity> GetAllActivities()
        {
            return Load<List<Activity>>(ACTIVITY_FILE_NAME) ?? new List<Activity>();
        }
        private void Save()
        {
            Save(DUNGEON_FILE_NAME, Dangeons);
            Save(ACTIVITY_FILE_NAME, Activities);
        }
    }
}
