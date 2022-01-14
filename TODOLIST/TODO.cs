using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

namespace TODOLIST
{
    public class TODO
    {
        public Dictionary<string, string> todo;

        public static string path = Directory.GetCurrentDirectory() + "/TODO.txt";
        public static string name = "Unknown";
        public void Init()
        {
            todo = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(path);
            string line;
            string[] tabl = { };
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] != '#' && line.Contains(","))
                {
                     tabl = line.Split(',');
                     todo.Add(tabl[0],tabl[1]);
                }
                   
            }
            sr.Close();
        }

        public void Add()
        {
            bool test = false;
            string things;
            string status = "NOT DONE";
            do
            {
                Console.WriteLine("What do you want to add ?");
                things = Console.ReadLine();
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
            todo.Add(things, status);
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("Adding {0} to the todo list with the status : {1}...", things, status);
            StreamWriter sw = new StreamWriter(path,true);
            sw.WriteLine("{0},{1}", things, status);
            sw.Close();
        }

        public void checkList()
        {
            Dictionary<string,string> ndone = new Dictionary<string, string>();
            Dictionary<string,string> done = new Dictionary<string, string>();
            StreamReader sr = new StreamReader(path);
            string line;
            string[] tabl = { };
            while ((line = sr.ReadLine()) != null)
            {
                if (line[0] != '#' && line.Contains(","))
                {
                    tabl = line.Split(',');
                    if(tabl[1] == "NOT DONE")
                        ndone.Add(tabl[0],"NOT DONE");
                    else
                    {
                        done.Add(tabl[0], "DONE");
                    }
                }
            }
            sr.Close();
            
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Things that had been done");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (KeyValuePair<string,string> d in done)
            {
                Console.WriteLine("{0}", d.Key);
            }
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Things that had not been done");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (KeyValuePair<string,string> nd in ndone)
            {
                Console.WriteLine("{0}", nd.Key);
            }
        }

        public void ModifyStatus()
        {
            Console.WriteLine("What status do you want to modify ? (Write the name of the things that you had registered in your todo list");
            string things = Console.ReadLine();
            if(things == null)
                Console.Error.WriteLine("Error");
            bool found = false;
            foreach (KeyValuePair<string,string> status in todo)
            {
                if (status.Key == things && status.Value == "NOT DONE")
                {
                    string v = status.Value;
                    todo.Remove(status.Key);
                    todo.Add(v,"DONE");
                    StreamWriter sw = new StreamWriter(path,true);
                    sw.WriteLine("{0},{1}", things, status);
                    sw.Close();
                    found = true;
                }
            }

            if (!found)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Unfoundable elements !");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Status had been modified successfuly");
                Console.ForegroundColor = ConsoleColor.White;
            }
        }
    }
}