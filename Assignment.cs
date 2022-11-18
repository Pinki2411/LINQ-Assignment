using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace Assignment
{
    public class EmployeeDetails
    {
        public int Empid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateOnly DOJ { get; set; } 
        public DateOnly DOB { get; set; }
        public string City { get; set; }

        public EmployeeDetails(int Empid, string FirstName, string LastName, string Title, int DOJ, int DOB, string City)
        {
            this.Empid = Empid;
            this.FirstName = FirstName;
            this.LastName = LastName;
            this.Title = Title;
            this.DOJ = DOJ;
            this.DOB = DOB;
            this.City = City;
        }
        public override string ToString()
        {
            return Empid + " " + FirstName + "   " + LastName + "  " + Title + "   " + DOJ + "  " + DOB + "  " + City;
        }


        public class Program
        {
            public static void Main(string[] args)
            {
                List<EmployeeDetails> list = new List<EmployeeDetails>
                {
                   new EmployeeDetails(1001,"Malcolm"," Daruwala"," Manager ", new DateOnly(16,11,1984), new DateOnly(06,08,2011)," Mumbai "),
                   new EmployeeDetails(1002,"Asdin"," Dahila","AsstManager",new DateOnly(20,08,1984),new DateOnly(07,07,2011)," Mumbai "),
                   new EmployeeDetails(1003,"Madhavi"," Oza ", " Consultant ",new DateOnly(14,11,1984), new DateOnly(12,10,2011)," Pune "),
                   new EmployeeDetails(1004,"Saba"," Shaikh "," SE ",new DateOnly(03,06,1990),new DateOnly(02,02,2016),"Pune"),
                   new EmployeeDetails(1005,"Nazia"," Shaikh","SE",new DateOnly(08,03,1991),new DateOnly(02,02,2016),"Mumbai"),
                   new EmployeeDetails(1006,"Amit"," Pathak","Consultant",new DateOnly(08,03,1991),new DateOnly(02,02,2016),"Chennai"),
                   new EmployeeDetails(1007,"Vijay","Natrajan","Consultant",new DateOnly(02,12,1989),new DateOnly(01,06,2015),"Mumbai"),
                   new EmployeeDetails(1008,"Rahul"," Dubey","Associate",new DateOnly(16,11,1984),new DateOnly(08,06,2011),"Chennai"),
                   new EmployeeDetails(1009,"Suresh"," Mistry","Associate",new DateOnly(12,08,1992),new DateOnly(06,11,2014),"Chennai"),
                   new EmployeeDetails(1010,"Sumit"," Shah","Manager",new DateOnly(12,04,1991),new DateOnly(02,01,2016),"Pune")

                  
               };

                Console.WriteLine("1. Displaying the details of Employee Details:");
                IEnumerable<EmployeeDetails> result = from emp in list select emp;
                foreach (EmployeeDetails e0 in result)
                {
                    Console.WriteLine(e0);
                }

                Console.WriteLine("--------------------------------------------------------");
                Console.WriteLine(" 2.Display the details of employee whose city is not Mumbai");
                var a = from emp1 in list where emp1.City != ("Mumbai") select emp1;
                foreach (EmployeeDetails e1 in a)
                {
                    Console.WriteLine(e1);
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine("3. Display the details of Employee whose title is AsstManager");
                var b = from emp2 in list where emp2.Title.Equals("AsstManager") select emp2;
                foreach (EmployeeDetails e2 in b)
                {
                    Console.WriteLine(e2);
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 4. Display the details of Employee whose name starts with S");
                var c = from emp3 in list where emp3.FirstName.StartsWith("S") select emp3;
                foreach (EmployeeDetails e3 in c)
                {
                    Console.WriteLine(e3);
                }



                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 5 .Display the details of Employee who have joined before 1/1/2015");
                var d= from emp4 in list where emp4.DateOnly.DOJ < (01,01,2015) select emp4;
                foreach (EmployeeDetails e4 in d)
                {
                    Console.WriteLine(e4);
                }
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 6.Display the details of Employee whose DateOf Birth is after 1/1/1990 ");
                var d1= from emp12 in list where emp12.DateOnly.DOB < (01,01,1990) select emp12;
                foreach (EmployeeDetails e12 in d1)
                {
                    Console.WriteLine(e12);
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 7. Display the details of Employee whose title is  Consultant and Associate");
                var e = from emp5 in list where emp5.Title.Contains( "Consultant" ) || emp5.Title.Contains(" Associate ") select emp5;
                foreach (EmployeeDetails e5 in e)
                {
                    Console.WriteLine(e5);
                }


                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 8Display the number of Employee");
                int No_of_Employee = list.Count();
                int No_of_Employee1 = (from emp6 in list select emp6).Count();

                {
                    Console.WriteLine(No_of_Employee);
                    Console.WriteLine(No_of_Employee1);
                }


                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 9 Display the  Total number of Employeee belonging to Chennai");
                int f = list.Where(x1 => x1.City.Equals("Chennai")).Count();

                {
                    Console.WriteLine(f);
                }
                int g = (from x2 in list where x2.City.Equals("Chennai") select x2).Count();
                { 
                Console.WriteLine(g);
                  }
                
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 10 Display the  Highest employee Id in List");

                var h = list.Max(emp7 => emp7.Empid);
                
                {
                    Console.WriteLine(h);
                }
                int i = (from x3 in list select x3.Empid).Max();
                {
                    Console.WriteLine(i);
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 11 Display the details of Employee who joined after 1/1/2015");
                var l = from emp11 in list where emp11.DateOnly.DOJ > ( 01,01,2015) select emp11;
                foreach (EmployeeDetails e11 in l)
                {
                    Console.WriteLine(e11);
                }
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 12.  Display the details of Employee  whose designation is not Associate");
                var j = (from emp8 in list where emp8.Title !="Associate" select emp8).Count();
                foreach (EmployeeDetails e8 in e)
                {
                    Console.WriteLine(e8);
                }

                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(" 13. Display the total number of Employee based on city and Title");
                var k = from emp9 in list
                        group emp9 by new { emp9.City, emp9.Title } into emp10
                        orderby emp10.Key.City
                        select new { City = emp10.Key.City, Title = emp10.Key.Title, TotalCount = emp10.Count() };
                foreach(var  p in k)
                {
                    if(p.TotalCount > 1 )
                    {
                        Console.WriteLine("Total no of Employee based on City and Title :{0}    {1}     {2}  ", p.City, p.Title, p.TotalCount);
                    }
                }
                Console.ReadLine();







            }
        }
        }

    }
