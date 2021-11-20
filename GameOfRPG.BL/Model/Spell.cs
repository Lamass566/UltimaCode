using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    /// <summary>
    /// Заклинание.
    /// </summary>
    [Serializable]
    public class Spell
    {
        /// <summary>
        /// Название Заклинания.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Общее количевство заклинаний.
        /// </summary>
        public int QuantitySpell { get; set; }
        /// <summary>
        /// Стоимость заклинания в монетах.
        /// </summary>
        public int CostMoney { get; set; }
        /// <summary>
        /// Стоимость маны заклинания.
        /// </summary>
        public int CostMana { get; set; }
        /// <summary>
        /// Еффект заклинания.
        /// </summary>
        public Effect Effect { get; set; }
        private int MoneyAllSpell { get { return CostMoney * QuantitySpell; } }
        public Spell(string name) : this(name, 0, 0, 0, new Effect(0, 0, 0)){}
        public Spell(string name, int qua, int costMoney, int costMana, Effect spellEff)
        {
            Name = name;
            QuantitySpell = qua;
            CostMoney = costMoney;
            CostMana = costMana;
            Effect = spellEff;
        }
    }
}
