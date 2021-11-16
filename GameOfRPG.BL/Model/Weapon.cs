using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfRPG.BL.Model
{
    /// <summary>
    /// Оружие.
    /// </summary>
    [Serializable]
    public class Weapon
    {
        /// <summary>
        /// Название оружия.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Дамаг оружия.
        /// </summary>
        public int Damage { get; set; }
        /// <summary>
        /// Создание нового оружия.
        /// </summary>
        /// <param name="name">Имя оружия</param>
        /// <param name="damage"> Урон оружия</param>
        public Weapon(string name, int damage)
        {
            if(string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException("Name is can't be a null or empty!!!", nameof(name));
            }
            if(damage < 0 )
            {
                throw new ArgumentException("Damage is can't be an below 0", nameof(damage));
            }
            Name = name;
            Damage = damage;
        }
        public override string ToString()
        {
            return $"Оружие: {Name}\nУрон: {Damage}";
        }
    }
}
