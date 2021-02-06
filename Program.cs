using System;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FightClub
{
    //FIGHTER / БОЕЦ
    class Fighter {
        internal string Name { get; set; }
        internal int Power { get; set; } //сила
        //internal int Agility { get; set; } //ловкость
        //internal int Intellect { get; set; } //интелект
        //internal int Stamina { get; set; } //стамина
        internal int Resistance { get; set; } //стойкость
        internal int Health = 150;
        internal bool BlockOrNot() {
            var rnd = new Random();
            int res = rnd.Next(-2, 2);
            return res < 0 ? false : true;
        }

    }

    //PLAYER / ИГРОК



    class Program
    {

        static void Main(string[] args)
        {


            string spriteAttack = "(c ▀ ▀ )r▀██)";
            string spriteBlock = "(▀█p(▀'▀,)";
            string spriteDead = "(^︵^,)";

            int AbilityPoints = 100;

            Console.WriteLine("Назовите бойца слева: ");
            string username1 = Console.ReadLine();

            Console.WriteLine("Назовите бойца справа: ");
            string username2 = Console.ReadLine();

            Console.WriteLine("Назовите бойца по центру: ");
            string username3 = Console.ReadLine();

            var rnd = new Random();
            Fighter PlayerRight = new Fighter { Power = 20 + rnd.Next(15, 30), Name = username1 };
            Fighter PlayerLeft = new Fighter { Power = 20 + rnd.Next(15, 30), Name = username2 };
            Fighter PlayerMid = new Fighter { Power = 20 + rnd.Next(15, 30), Name = username3 };

        
            do
            {
                int randomAttack = rnd.Next(0, 4);

                switch (randomAttack)
                {
                    case 1:
                        Thread.Sleep(1000);
                        Console.WriteLine($"{PlayerLeft.Name} {spriteAttack} {PlayerRight.Name}");
                        Thread.Sleep(700);
                        if (PlayerLeft.BlockOrNot() == true)
                        {
                            Console.WriteLine($"{spriteBlock} блок от {PlayerRight.Name}");
                        }
                        else {
                            PlayerRight.Health -= PlayerLeft.Power;
                        }

                        if (PlayerRight.Health <= 0) {
                            Console.WriteLine($"{PlayerRight.Name} лежит без пульса! {spriteDead}");
                        }
                        break;


                    case 2:
                        Thread.Sleep(1000);
                        Console.WriteLine($"{PlayerRight.Name}  {spriteAttack} {PlayerMid.Name}");
                        Thread.Sleep(700);
                        if (PlayerRight.BlockOrNot() == true)
                        {
                            Console.WriteLine($"{spriteBlock} блок от {PlayerMid.Name}");
                        }
                        else
                        {
                            PlayerMid.Health -= PlayerRight.Power;
                        }

                        if (PlayerMid.Health <= 0)
                        {
                            Console.WriteLine($"{PlayerMid.Name} лежит без пульса! {spriteDead}");
                        }
                        break;


                    case 3:
                        Thread.Sleep(700);
                        Console.WriteLine($"{PlayerMid.Name}  {spriteAttack} {PlayerLeft.Name}");

                        Thread.Sleep(1000);
                        if (PlayerMid.BlockOrNot() == true)
                        {
                            Console.WriteLine($"{spriteBlock} блок от {PlayerLeft.Name}");
                        }
                        else
                        {
                            PlayerLeft.Health -= PlayerMid.Power;
                        }

                        if (PlayerLeft.Health <= 0)
                        {
                            Console.WriteLine($"{PlayerLeft.Name} лежит без пульса! {spriteDead}");
                        }
                        break;
                        
                };
                Console.WriteLine(" ");

            } while (PlayerLeft.Health > 0 && PlayerMid.Health > 0 && PlayerRight.Health > 0) ;

        }
    }
}
