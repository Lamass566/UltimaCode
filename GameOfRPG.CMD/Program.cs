using GameOfRPG.BL;
using GameOfRPG.BL.Controller;
using GameOfRPG.BL.Model;
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
            var dict = new DictionarySpellController(heroContr2.CurrentHero);

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

            Console.WriteLine("Что вы хотите сделать?");
            Console.WriteLine("W - ввести заклинания");
            var key = Console.ReadKey();

            if(key.Key == ConsoleKey.W)
            {
                var spells = EnterDict();
                dict.Add(spells.Spell, spells.Quentity);

                foreach(var item in dict.DictionarySpell.Spells)
                {
                    Console.WriteLine($"\t{item.Key.Name} - {item.Value}");
                }
            }

            Console.ReadLine();
        }

        private static (Spell Spell, int Quentity) EnterDict()
        {
            ParseHelper parseHelper = new ParseHelper();

            Console.Write("Введите имя заклинания: ");
            var spell = Console.ReadLine();

            var heal = parseHelper.ParseInt("хил");
            var ATK = parseHelper.ParseInt("ATK");
            var critic = parseHelper.ParseInt("chance critic");
            var Effect = new Effect(heal, ATK, critic);

            var mana = parseHelper.ParseInt("стоимость маны");
            var money = parseHelper.ParseInt("стоимость в деньгах");
            var quentity = parseHelper.ParseInt("количевство заклинаний");

            var pr = new Spell(spell, quentity, money, mana, Effect);

            return (Spell: pr, Quentity: quentity);
        }
    }
}
