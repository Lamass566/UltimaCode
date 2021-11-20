using GameOfRPG.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Controller
{
    public class DictionarySpellController : ControllerBase
    {
        private const string SPELL_FILE_NAME = "spells.dat";
        private const string DICTIONARYSPELL_FILE_NAME = "dictionarySpell.dat";
        private readonly Hero hero;
        public List<Spell> Spells { get; set; }
        public DictionarySpell DictionarySpell { get; set; }
        public DictionarySpellController(Hero hero)
        {
            this.hero = hero ?? throw new ArgumentNullException("Пользователь не может быть пустым.", nameof(hero));
            Spells = GetAllSpell();
            DictionarySpell = GetDictionarySpell();
        }

        public void Add(Spell spell, int quantity)
        {
            var c = Spells.SingleOrDefault(f => f.Name == spell.Name);
            if(c == null)
            {
                Spells.Add(spell);
                DictionarySpell.Add(spell, quantity);
                Save();
            }
            else
            {
                DictionarySpell.Add(c, quantity);
                Save();
            }
        }

        private DictionarySpell GetDictionarySpell()
        {
            return Load<DictionarySpell>(DICTIONARYSPELL_FILE_NAME) ?? new DictionarySpell(hero);
        }

        private List<Spell> GetAllSpell()
        {
            return Load<List<Spell>>(SPELL_FILE_NAME) ?? new List<Spell>();
        }
        private void Save()
        {
            Save(SPELL_FILE_NAME, Spells);
            Save(DICTIONARYSPELL_FILE_NAME, DictionarySpell);
        }
    }
}
