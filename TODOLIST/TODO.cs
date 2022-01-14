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

        public void Add(string things, string status = "NOT DONE")
        {
            todo.Add(things, status);
            Console.ForegroundColor = ConsoleColor.Cyan; 
            Console.WriteLine("Adding {0} to the todo list with the status : {1}...", things, status);
            StreamWriter sw = new StreamWriter(path,true);
            sw.WriteLine("{0} , {1}", things, status);
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
                    if(tabl[1] == " NOT DONE")
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
    }
}