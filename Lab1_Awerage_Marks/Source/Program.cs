using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab1_Awerage_Marks
{
    class Program
    {
        static void Main(string[] args)
        {
            Group g = new Group();
            if (g.Equals(null))
                Console.WriteLine("g is null!");
            g = new Group();
            if (g.Equals(null))
                Console.WriteLine("g is null!");
            for(;;)
            {
                Console.WriteLine("Please, tap:\n\t1 — Adding student/mark to stident;\n\t2 — Counting average;");
                switch (Console.ReadLine())
                {
                    case "1":
                        Console.WriteLine("Please, tap:\n\t1 — Adding student;\n\t2 — Adding mark to student;");
                        switch(Console.ReadLine())
                        {
                            case "1":                               
                                int n = g.GetStudents() == null ? 0 : g.GetStudents().Count;
                                Student s = new Student((n+1).ToString());
                                g.AddStudent(s);
                                Console.WriteLine("Student {0} added!", s.FullName);
                                break;
                            case "2":
                                if(g.GetStudents().Equals(null))
                                {
                                    Console.WriteLine("There are no students in group");
                                    break;
                                }
                                Console.WriteLine("Please, select student number:");
                                foreach(Student ss in g.GetStudents())
                                {
                                    Console.WriteLine("\t{0}", ss.FullName);
                                }
                                string c = Console.ReadLine();                                
                                Student selectedS = g.GetStudents().First(ss => ss.FullName == c);
                                if (selectedS.Equals(null))
                                    Console.WriteLine("No such student)))");
                                else
                                {
                                    Console.WriteLine("Enter mark value (>=0 and <= 10);");
                                    string mark = Console.ReadLine();
                                    if (Int32.TryParse(mark, out int m))
                                        selectedS.AddMark(m);
                                    else
                                        Console.WriteLine("Not number!");
                                }
                                break;
                            default:
                                Console.WriteLine("Oh-Oh...");
                                break;
                        } 
                        break;
                    case "2":
                        Console.WriteLine("Please, tap:\n\t1 — Counting average mark for group;\n\t2 — Counting average mar for student;");
                        switch(Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine(g.CalculateAverageMark());
                                break;
                            case "2":
                                if(g.GetStudents().Equals(null))
                                    {
                                        Console.WriteLine("There are no students in group");
                                        break;
                                    }
                                Console.WriteLine("Please, select student number:");
                                foreach(Student s in g.GetStudents())
                                {
                                    Console.WriteLine("\t{0}", s.FullName);
                                }
                                string c = Console.ReadLine();
                                Student selectedS = g.GetStudents().First(ss => ss.FullName == c);
                                if (selectedS.Equals(null))
                                    Console.WriteLine("No such student)))");
                                else 
                                {
                                    Console.WriteLine(selectedS.CalculateAverageMark());
                                }   
                                break;
                            default:
                                break;
                        }
                        break;   
                    default:
                        Console.WriteLine("Nice try, friend!");
                        break;                     
                }
            }
         }
    }
}
