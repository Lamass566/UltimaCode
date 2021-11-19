using Microsoft.VisualStudio.TestTools.UnitTesting;
using GameOfRPG.BL.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Controller.Tests
{
    [TestClass()]
    public class HeroControllerTests
    {
        [TestMethod()]
        public void SetNewHeroDataTest()
        {
            //Arange
            var heroName = Guid.NewGuid().ToString();
            var gender = "Men";
            var age = 18;
            var weight = 90;
            var height = 190;
            var controller = new HeroController(heroName);

            var weaponName = "Mili";
            var dm = 13;
            var nameClass = "Heal";
            var HP = 111;

            //Act
            controller.SomeClasses(weaponName, dm, nameClass, HP);
            controller.SetNewHeroData(gender, age, weight, height);
            var controller2 = new HeroController(heroName);

            //Assert
            Assert.AreEqual(heroName, controller2.CurrentHero.Name);
            Assert.AreEqual(gender, controller2.CurrentHero.Gender.Name);
            Assert.AreEqual(age, controller2.CurrentHero.Age);
            Assert.AreEqual(weight, controller2.CurrentHero.Weight);
            Assert.AreEqual(height, controller2.CurrentHero.Height);
            Assert.AreEqual(weaponName, controller2.CurrentHero.ClassHero.Weapon.Name);
            Assert.AreEqual(dm, controller2.CurrentHero.ClassHero.Weapon.Damage);
            Assert.AreEqual(nameClass, controller2.CurrentHero.ClassHero.Name);
            Assert.AreEqual(HP, controller2.CurrentHero.ClassHero.HP);
        }


        [TestMethod()]
        public void SaveTest()
        {
            //Arrange
            var heroName = Guid.NewGuid().ToString();

            //Act
            var controller = new HeroController(heroName);

            // Assert
            Assert.AreEqual(heroName, controller.CurrentHero.Name);
        }
    }
}