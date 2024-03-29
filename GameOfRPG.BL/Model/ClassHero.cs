﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    /// <summary>
    /// Класс героя.
    /// </summary>

    [Serializable]
    public class ClassHero
    {
        /// <summary>
        /// Название класса.
        /// </summary>
        public string Name { get; }
        /// <summary>
        /// Жизни класса.
        /// </summary>
        public int HP { get; set; }
        /// <summary>
        /// Оружие класса.
        /// </summary>
        public Weapon Weapon { get; set; }
        /// <summary>
        /// Создание нового класса.
        /// </summary>
        /// <param name="name"> Имя класса.</param>
        /// <param name="hp"> ХП класса.</param>
        /// <param name="weapon"> Оружие класса.</param>
        public ClassHero(string name, int hp, Weapon weapon)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Имя не может быть пустым null!!!", nameof(name));
            }
            if(hp <= 0)
            {
                throw new ArgumentException("HP не может быть меньше 0", nameof(hp));
            }
            if(weapon == null)
            {
                throw new ArgumentNullException("Оружие не может быть null!", nameof(weapon));
            }

            Name = name;
            HP = hp;
            Weapon = weapon;
        }
        public override string ToString()
        {
            return $"Класс: {Name}\nHP = {HP}\nОружие: {Weapon}";
        }
    }
}
