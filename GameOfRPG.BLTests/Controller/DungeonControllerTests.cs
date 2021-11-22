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
    public class DungeonControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            //Arrange
            var nameHero = Guid.NewGuid().ToString();
            var activityName = Guid.NewGuid().ToString();
            int exp = 15;

            var heroConstroller = new HeroController(nameHero);
            var activity = new Activity(activityName, exp);
            var dungContr = new DungeonController(heroConstroller.CurrentHero);

            //Act
            dungContr.Add(activity, DateTime.Now, DateTime.Now.AddHours(1), 3);

            //Assert
            Assert.AreEqual(activity.Name, dungContr.Activities.First().Name);
        }
    }
}