using GameOfRPG.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace GameOfRPG.BL.Controller
{
    public class HeroController : ControllerBase
    {
        private const string HERO_FILE_NAME = "heroes.dat";
        public ClassHero ClassHero { get; set; }
        public bool IsNewUser { get; } = false;
        public Weapon Weapon { get; set; }
        public List<Hero> Heros { get; set; }
        public Hero CurrentHero { get; set; }
        public HeroController(string heros)
        {
            if(string.IsNullOrWhiteSpace(heros))
            {
                throw new ArgumentNullException("Name can't be a null or empty", nameof(heros));
            }

            Heros = GetHerosData();

            CurrentHero = Heros.SingleOrDefault(c => c.Name == heros);

            if(CurrentHero == null)
            {
                CurrentHero = new Hero(heros);
                Heros.Add(CurrentHero);
                IsNewUser = true;
                Save();
            }
        }
        public void SetNewHeroData(string genderName, int age, double weight = 1, double height = 1)
        {
            CurrentHero.Gender = new Gender(genderName);
            CurrentHero.Age = age;
            CurrentHero.Weight = weight;
            CurrentHero.Height = height;
            Save();
        }
        /// <summary>
        /// Получить сохраненый список пользователей.
        /// </summary>
        /// <returns>Данные пользователей или пустой обьект.</returns>
        private List<Hero> GetHerosData()
        {
            return Load<List<Hero>>(HERO_FILE_NAME) ?? new List<Hero>();
        }
        public void SomeClasses(string name, int dm, string nameClass, int HP)
        {
            Weapon = new Weapon(name, dm);
            ClassHero = new ClassHero(nameClass, HP, Weapon);

            CurrentHero.ClassHero = ClassHero;
            CurrentHero.ClassHero.Weapon = Weapon;
            Save();
        }
        /// <summary>
        /// Save data hero.
        /// </summary>
        public void Save()
        {
            Save(HERO_FILE_NAME, Heros);
        }
    }
}
