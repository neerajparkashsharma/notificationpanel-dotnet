using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NotificationPanel.Controllers
{
    public class ExController : Controller
    {
        // GET: Exp
        public ActionResult Index()
        {
            return View();
        }

        //public abstract class EmployeeFac
        // {

            
        // }



        //public abstract class Employee
        //{
        //   public abstract void display();
        //}
        //public class admin: Employee
        //{
        //    public override void display()
        //    {
        //        Console.WriteLine("I'm Admin");
        //    }
        //}
        //public class Sale: Employee
        //{
        //    public override void display()
        //    {
        //        Console.WriteLine("I'm Admin");
        //    }
        //}

        //public class  HR: Employee
        //{
        //    public override void display()
        //    {
        //        Console.WriteLine("I'm Admin");
        //    }
        //}



        public class Employee
        {
            public int Age;
            
            public string Name;
            public IdInfo IdInfo;

            public Employee ShallowCopy()
            {
                return (Employee)this.MemberwiseClone();
            }

            public Employee DeepCopy()
            {
                Employee clone = (Employee)this.MemberwiseClone();
                clone.IdInfo = new IdInfo(IdInfo.IdNumber);
                clone.Name = String.Copy(Name);
                return clone;
            }
        }

        public class IdInfo
        {
            public int IdNumber;

            public IdInfo(int idNumber)
            {
                this.IdNumber = idNumber;
            }
        }
        // Prototype
        class Program
        {
            static void Main(string[] args)
            {
                Employee p1 = new Employee();
                p1.Age = 42;
               
                p1.Name = "Nimrah mehboob-++++++++++";
                p1.IdInfo = new IdInfo(666);

                // shallow 
                Employee p2 = p1.ShallowCopy();
               //deep
                Employee p3 = p1.DeepCopy();

            //display
                Console.WriteLine("Original values of p1, p2, p3:");
                Console.WriteLine("   p1 instance values: ");
                DisplayValues(p1);
                Console.WriteLine("   p2 instance values:");
                DisplayValues(p2);
                Console.WriteLine("   p3 instance values:");
                DisplayValues(p3);

                // Change 
                p1.Age = 32;
               
                p1.Name = "Frank";
                p1.IdInfo.IdNumber = 7878;
                Console.WriteLine("\nValues of p1, p2 and p3 after changes to p1:");
                Console.WriteLine("   p1 instance values: ");
                DisplayValues(p1);
                Console.WriteLine("   p2 instance values (reference values have changed):");
                DisplayValues(p2);
                Console.WriteLine("   p3 instance values (everything was kept the same):");
                DisplayValues(p3);
            }

            public static void DisplayValues(Employee p)
            {
                Console.WriteLine("      Name: {0:s}, Age: {1:d}, BirthDate: {2:MM/dd/yy}",
                    p.Name, p.Age);
                Console.WriteLine("      ID#: {0:d}", p.IdInfo.IdNumber);
            }
        }
    


}
}