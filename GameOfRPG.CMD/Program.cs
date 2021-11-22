using GameOfRPG.BL;
using GameOfRPG.BL.Controller;
using GameOfRPG.BL.Model;
using System;
using System.Globalization;
using System.Resources;

namespace GameOfRPG.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            var cultura = CultureInfo.CreateSpecificCulture("en-us");
            var resourceManager = new ResourceManager("GameOfRPG.CMD.Languages.Message", typeof(Program).Assembly);

            ParseHelper parseHelper = new ParseHelper();

            Console.WriteLine(resourceManager.GetString("Hello", cultura));

            Console.Write(resourceManager.GetString("EnterHeroName", cultura));
            var name = Console.ReadLine();

            var heroContr2 = new HeroController(name);
            var dict = new DictionarySpellController(heroContr2.CurrentHero);
            var dung = new DungeonController(heroContr2.CurrentHero);

            if(heroContr2.IsNewUser)
            {
                Console.Write(Languages.Message_ru_ru.EnterHeroGender);
                var gender = Console.ReadLine();

                var age = parseHelper.ParseInt("Возраст");
                var Weight = parseHelper.ParseDouble("Вес");
                var Height = parseHelper.ParseDouble("Рост");

                Console.WriteLine("----------------------------");
                Console.Write(Languages.Message_ru_ru.EnterWeaponName);
                var nameWeapon = Console.ReadLine();

                var dm = parseHelper.ParseInt("Урон");

                Console.Write(Languages.Message_ru_ru.EnterClassHeroName);
                var nameClass = Console.ReadLine();

                var HP = parseHelper.ParseInt("HP");

                heroContr2.SomeClasses(nameWeapon, dm, nameClass, HP);
                heroContr2.SetNewHeroData(gender, age, Weight, Height);
            }

            Console.WriteLine(heroContr2.CurrentHero);



            while (true)
            {
                Console.WriteLine("Что вы хотите сделать?");
                Console.WriteLine("W - ввести заклинания");
                Console.WriteLine("A - ввести данж");
                Console.WriteLine("N - выход");
                var key = Console.ReadKey();
                switch (key.Key)
                {
                    case ConsoleKey.W:
                        var spells = EnterDict();
                        dict.Add(spells.Spell, spells.Quentity);

                        foreach (var item in dict.DictionarySpell.Spells)
                        {
                            Console.WriteLine($"\t{item.Key.Name} - {item.Value}");
                        }
                        break;

                    case ConsoleKey.A:
                        var dan = EnterDungeon();
                        dung.Add(dan.activity, dan.begin, dan.end, dan.kill);

                        foreach (var item in dung.Dangeons)
                        {
                            Console.WriteLine($"\t{item.Activity} - {item.Start.ToShortTimeString()} - {item.Finish.ToShortTimeString()}");
                        }
                        break;
                    case ConsoleKey.N:
                        Environment.Exit(0);
                        break;
                }

                Console.ReadLine();
            }
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
        private static (DateTime begin, DateTime end, Activity activity, int kill) EnterDungeon()
        {
            ParseHelper parseHelper = new ParseHelper();

            Console.Write("Введите имя данжа: ");
            var name = Console.ReadLine();

            int kill = 15;
            int exp = 5;
            var activity = new Activity(name, exp);
            Console.Write("Введите Вход данжа: ");
            var begin = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Введите Выход данжа: ");
            var end = Convert.ToDateTime(Console.ReadLine());

            return (begin, end, activity, kill);
        }
    }
}
