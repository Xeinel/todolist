using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace TODOLIST
{
    class Program
    {
        static void Main(string[] args)
        {
            TODO t = new TODO();
            if (!File.Exists(TODO.path))
            {
                Console.WriteLine("Hi, what's your name ?");
                TODO.name = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Creation of the current file...");
                Console.ForegroundColor = ConsoleColor.Green;
                StreamWriter sw = new StreamWriter(TODO.path);
                using (sw)
                {
                    sw.WriteLine("#Welcome on your TODO Lists {0} !", TODO.name);
                    Console.WriteLine("File created successfully.");
                    Console.ForegroundColor = ConsoleColor.White;
                }
                sw.Close();
            }
            
            t.Init();
            
            Console.WriteLine("What do you want to do ?");
            Console.WriteLine("(1) Add something | (2) Modify a status | (3) See ALL ");
            string answer = Console.ReadLine();
            Regex rg = new Regex("^[a-zA-Z]+$");
            while (rg.Match(answer).Success)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING : Invalid entry. There are letters");
                Console.WriteLine("(1) Add something | (2) Modify a status | (3) See ALL ");
                Console.ForegroundColor = ConsoleColor.White;
                answer = Console.ReadLine();
            }
            int a = Int32.Parse(answer);
            while (a < 1 || a > 3)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("WARNING : Invalid entry");
                Console.WriteLine("(1) Add something | (2) Modify a status | (3) See ALL ");
                answer = Console.ReadLine();
                a = Int32.Parse(answer);
            }
            
            if (a == 1)
            {
                bool test = false;
                do
                {
                    Console.WriteLine("What do you want to add ?");
                    string things = Console.ReadLine();
                    t.Add(things);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("{0} had been added to your todo list !", things);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Do you want to add one more thing ? (y/n)");
                    string answ = Console.ReadLine();
                    if (answ == "y")
                        test = true;
                    else
                        test = false;

                } while (test);
            }
            else if (a == 2)
                Console.WriteLine("Which status do you want to modify ?");
            else if (a == 3)
                t.checkList();
        }
    }
}