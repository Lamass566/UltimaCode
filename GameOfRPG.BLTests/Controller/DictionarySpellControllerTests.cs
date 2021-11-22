using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfRPG.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameOfRPG.BL.Model;

namespace GameOfRPG.BL.Controller.Tests
{
    [TestClass()]
    public class DictionarySpellControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var nameHero = Guid.NewGuid().ToString();
            var nameSpell = Guid.NewGuid().ToString();
            var rndQ = 1;
            var rndMo = new Random().Next(1, 10);
            var rndMa = new Random().Next(1, 10);

            var heal = new Random().Next(1, 10);
            var buffATK = new Random().Next(1, 10);
            var critic = new Random().Next(1, 10);
            var Effect = new Effect(heal, buffATK, critic);

            var heroConstroller = new HeroController(nameHero);
            var dictSpellContr = new DictionarySpellController(heroConstroller.CurrentHero);
            var spell = new Spell(nameSpell, rndQ, rndMo, rndMa, Effect);

            //Act
            dictSpellContr.Add(spell, 3);

            //Assert
            //Assert.AreEqual(spell.Name, dictSpellContr.DictionarySpell.Spells.First().Key.Name);
        }
    }
}