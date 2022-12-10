using System;
using System.Security.Cryptography.X509Certificates;
using DAL;
using DAL.Models;

namespace Work.UI
{
    class Program

    {
        private readonly StudentDataContext _context;
        Repository repo;

        public Program(StudentDataContext context)
        {
            _context = context;
            repo = new Repository(_context);

        }
            static void Main(string[] args)
            {
                //   Console.WriteLine("Hello World!");


                /*      bool result = repo.AddMarks("M104", 32022,90, 90, 90, 90, 90, 2018,"A");
                      if (result == true)
                      {
                          Console.WriteLine("Entry success");

                      }
                      else
                      {
                          Console.WriteLine("FUCK YOU");
                      }



                 /*    bool result1 = repo.LoginUser("abc@email.com", "abcc@ggg");
                     if (result1 == true)
                     {
                         Console.WriteLine("Login Success");
                     }
                     else
                     {
                         Console.WriteLine("");
                  */

                /* bool result = repo.DeleteStd(22022);
                 Console.WriteLine(result);
                 if (result == true)
                 {
                     Console.WriteLine("Margya");
                 }
                 else
                 {
                     Console.WriteLine("nhi ");
                 } */

                var max = repository.Mathsmax();
                Console.WriteLine(max.ToString());
                /*  var marks = repo.GetList();
                  foreach (var mark in marks.Item1)
                  { 
                      Console.WriteLine("{0}\t\t{1}\t\t{2}", mark.RollNo, mark.Yr, mark.SmAverage);
                  }
                  foreach (var mark in marks.Item2)
                  {
                      Console.WriteLine("{0}\t\t{1}\t\t{2}", mark.RollNo, mark.Yr, mark.SmAverage);
                  }*/
            }
        }
    }

