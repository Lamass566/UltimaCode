using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    [Serializable]
    public class Activity
    {
        public string Name { get; set; }
        public int ExpPerDange { get; set; }
        public Activity(string name, int exp)
        {
            Name = name;
            ExpPerDange = exp;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
