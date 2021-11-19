using GameOfRPG.BL;
using GameOfRPG.BL.Controller;
using System;

namespace GameOfRPG.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            ParseHelper parseHelper = new ParseHelper();

            Console.WriteLine("Привет, это Ultima!");

            Console.Write("Введите имя героя: ");
            var name = Console.ReadLine();

            var heroContr2 = new HeroController(name);

            if(heroContr2.IsNewUser)
            {
                Console.Write("Введите Пол: ");
                var gender = Console.ReadLine();

                var age = parseHelper.ParseInt("Возраст");
                var Weight = parseHelper.ParseDouble("Вес");
                var Height = parseHelper.ParseDouble("Рост");

                Console.WriteLine("----------------------------");
                Console.Write("Введите Оружие: ");
                var nameWeapon = Console.ReadLine();

                var dm = parseHelper.ParseInt("Урон");

                Console.Write("Введите Класс: ");
                var nameClass = Console.ReadLine();

                var HP = parseHelper.ParseInt("HP");

                heroContr2.SomeClasses(nameWeapon, dm, nameClass, HP);
                heroContr2.SetNewHeroData(gender, age, Weight, Height);
            }

            Console.WriteLine(heroContr2.CurrentHero);
            Console.ReadLine();
        }
    }
}
