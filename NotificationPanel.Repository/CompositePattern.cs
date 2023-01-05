using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace NotificationPanel.Repository
{
    internal class CompositePattern
    {
        

    }

    public class employee
    {
        public string name;
        public string dept;
        public int salary;
        public List<employee> mylist;
        public employee(string name, string dept, int salary)
        {


            this.name = name;
            this.dept = dept;

            this.salary = salary;
            mylist = new List<employee>();

        }
        public void add(employee e)
        {

            mylist.Add(e);
        }
        public void remove(employee e)
        {

            mylist.Remove(e);
        }
        public List<employee> getEmployee()
        {
            return mylist;
        }

        public String toString()
        {

            return ("Employee:[Name:" + name + "depT" + dept + "SALARY" + salary + "]");
        }

        class program
        {

            public static void main()
            {
                //compostie pattern

                employee marking = new employee("nimrah", "sales", 5000);
                employee digitalmarkting = new employee("asad", "sales", 5000);
                employee socialmediamarkting = new employee("asad", "sales", 5000);

                marking.add(digitalmarkting);
                marking.add(socialmediamarkting);


                employee HeadSales = new employee("shariq", "headofmarketing", 10000);
                employee saleExcutive1 = new employee("hasan", "sales", 5000);
                employee saleExcutive2 = new employee("ZARLISH", "sales", 5000);


                marking.add(saleExcutive1);
                marking.add(saleExcutive2);

                marking.remove(saleExcutive1);



            }

        }


        // Factory Builder

            abstract class AbstractFactory
            {
            public abstract employee getEmployee(string type);

            }

        
        public interface employee
        { 
            void create();
        }

        public class SrContentWriter:employee
        {
        
        public void create()
            {
                Console.WriteLine("digital marketing");

            }
        }
        public class MediaManager : employee
        {

            public void create()
            {
                Console.WriteLine("social media marketing");

            }
        }





        // end



    }
}

