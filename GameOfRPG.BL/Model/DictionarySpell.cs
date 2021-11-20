using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    [Serializable]
    public class DictionarySpell
    {
        public DateTime Moment { get; set; }
        public Dictionary<Spell, int> Spells { get; set; }
        public Hero Hero { get; set; }
        public DictionarySpell(Hero hero)
        {
            Hero = hero ?? throw new ArgumentNullException("Пользователь не может быть пустым", nameof(hero));
            Moment = DateTime.UtcNow;
            Spells = new Dictionary<Spell, int>();
        }
        public void Add(Spell spell, int quantity)
        {
            var s = Spells.Keys.FirstOrDefault(f => f.Name.Equals(spell.Name));
            if(s == null)
            {
                Spells.Add(spell, quantity);
            }
            else
            {
                Spells[s] += quantity;
            }
        }
    }
}
