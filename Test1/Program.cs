using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test1
{
    class Program
    {
        public static void Main(string[] args)
        {
            Game mathGame = new Game(1,0);
            Console.WriteLine("This is a math game...");

                 

            
            while (true)
            {
                mathGame.Display_Score_Bar();
                mathGame.Display_Exp_Bar(mathGame.Score);

                int first = mathGame.Roll(mathGame.Level);
                int second = mathGame.Roll(mathGame.Level);
                int ope = mathGame.Roll(0);

                Console.WriteLine("");
                Console.WriteLine($"  {first}");
                Console.WriteLine($"{mathGame.Get_Op(ope)} {second}");
                Console.WriteLine("-----");
                Console.Write(" ");
                int answer = Convert.ToInt32(Console.ReadLine());
                int solution = mathGame.Generate_Solution(first, second, ope);
                

                if (answer == solution)
                {
                    Console.WriteLine("Your answer is Correct!\n");
                    mathGame.Score += 10;
                }
                else
                {
                    Console.WriteLine($"Wrong! The correct answer is {solution}");
                    mathGame.Score -= 1;
                }
            }

            //Console.WriteLine("Thank you for playing this game");

        }
    }

    public class Game
    {
        Random rand = new Random();
        string[] op = { "+", "-", "*", "/" };
        //int exp_per_level = 10;

        public int Score { get; set; }
        public int Level { get; set; }
        

        

        public Game (int level, int score)
        {
            Score = score;
            Level = level;          
        }

        public string Get_Op(int num)
        {
            return op[num];
        }

        public void Display_Score_Bar()
        {          
            Console.WriteLine($"Score = {Score}, Level = {Level}");       
        }

        public void Display_Exp_Bar(int score)
        {
            Console.Write($"[##### : {score}/100]");
        }



        public int Roll(int level)
        {
            if (level == 0)
            {
                return rand.Next(4);
            }
            else if (level == 1)
            {
                return rand.Next(10);
            }
            else if (level == 2)
            {
                return rand.Next(20);              
            }
            else 
            {
                return rand.Next(100);
            }


            
            
        }

        public int Generate_Solution(int first, int second, int op)
        {
            
            if (op == 0)
            {
                return first + second;
            }
            else if (op == 1)
            {
                return first - second;
            }
            else if (op == 2)
            {
                return first * second; 
            }
            else if(op == 3)
            {
                return first / second;
            }

            return first + second;

        }

    }
}
        
