using GameOfRPG.BL.Controller;
using System;

namespace GameOfRPG.CMD
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, you are welcome!");

            Console.WriteLine("Enter name hero!");
            var name = Console.ReadLine();

            //Console.WriteLine("Enter Gender hero!");
            //var gender = Console.ReadLine();

            //Console.WriteLine("Enter BirthDay hero!");
            //var birthD = DateTime.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Weight hero!");
            //var Weight = double.Parse(Console.ReadLine());

            //Console.WriteLine("Enter Height hero!");
            //var Height = double.Parse(Console.ReadLine());

            var heroContr2 = new HeroController(name);

            if(heroContr2.IsNewUser)
            {
                Console.WriteLine("Enter Gender hero!");
                var gender = Console.ReadLine();

                Console.WriteLine("Enter BirthDay hero!");
                var birthD = DateTime.Parse(Console.ReadLine());

                Console.WriteLine("Enter Weight hero!");
                var Weight = double.Parse(Console.ReadLine());

                Console.WriteLine("Enter Height hero!");
                var Height = double.Parse(Console.ReadLine());

                heroContr2.SetNewHeroData(gender, birthD, Weight, Height);
            }

             Console.WriteLine(heroContr2.CurrentHero);
            Console.ReadLine();
        }
    }
}
