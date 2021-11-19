using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{

    /// <summary>
    /// Герой.
    /// </summary>
    [Serializable]
    public class Hero
    {
        /// <summary>
        /// Имя героя.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Пол героя.
        /// </summary>
        public Gender Gender { get; set; }
        /// <summary>
        /// Возраст героя.
        /// </summary>
        public int Age { get; set; }
        /// <summary>
        /// Вес.
        /// </summary>
        public double Weight { get; set; }
        /// <summary>
        /// Рост.
        /// </summary>
        public double Height { get; set; }
        /// <summary>
        /// Класс героя.
        /// </summary>
        public ClassHero ClassHero { get; set; }
        /// <summary>
        /// Создание нового героя.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="gender"></param>
        /// <param name="dateBirth"></param>
        /// <param name="weight"></param>
        /// <param name="height"></param>
        /// <param name="classHero"></param>
        public Hero(string name, Gender gender, int age, double weight, double height, ClassHero classHero)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name can't be a null or empty", nameof(name));
            }
            if(gender == null)
            {
                throw new ArgumentNullException("Gender is can't be a null", nameof(gender));
            }
            if(age <= 0)
            {
                throw new ArgumentException("Age can't be a bellow 0", nameof(age));
            }
            if(weight <= 0)
            {
                throw new ArgumentException("Weight can not be below 0", nameof(weight));
            }
            if(height <= 0)
            {
                throw new ArgumentException("Height can not be below 0", nameof(height));
            }
            if(classHero == null)
            {
                throw new ArgumentNullException("Class Hero can not be a null", nameof(classHero));
            }
            Name = name;
            Gender = gender;
            Age = age;
            Weight = weight;
            Height = height;
            ClassHero = classHero;
        }
        public Hero(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым или null", nameof(name));
            }
            Name = name;
        }
        public override string ToString()
        {
            return Name + " - " + ClassHero.Weapon.Name;
        }
    }
}
