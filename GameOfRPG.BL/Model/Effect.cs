using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    /// <summary>
    /// Еффект от заклинания.
    /// </summary>
    [Serializable]
    public class Effect
    {
        public int HealingHP { get; set; }
        public int BuffATK { get; set; }
        public int CriticalChance { get; set; }
        public Effect(int heal, int buff, int ctitic)
        {
            HealingHP = heal;
            BuffATK = buff;
            CriticalChance = ctitic;
        }
    }
}
