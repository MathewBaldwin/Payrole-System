using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayroleSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Staff> myStaff = new List<Staff>();
            FileReader fr = new FileReader();
            int month = 0, year = 0;

            while(year == 0)
            {
                Console.WriteLine("\nPlease enter the year: ");

                try
                {
                    year = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message + "Please try again.");
                }
            }

            while(month == 0)
            {
                Console.WriteLine("\nPlease enter a month: ");

                try
                {
                    month = Convert.ToInt32(Console.ReadLine());
                    if (month <1 || month > 12)
                    {
                        Console.WriteLine("Month must be from 1 to 12. Please try again.");
                    }
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message + "Please Try Again.");
                }
            }

            myStaff = fr.Readfile();

            for(int i = 0; i < myStaff.Count; i++)
            {
                try
                {
                    Console.Write("\nEnter Hours Worked for {myStaff[i].NameOfStaff}: ");
                    myStaff[i].HoursWorked = Convert.ToInt32(Console.ReadLine());
                    myStaff[i].CalculatePay();

                    Console.WriteLine(myStaff[i].ToString());
                }
                catch (Exception e)
                {

                    Console.WriteLine(e.Message);
                    i--;
                }
            }

            PaySlip ps = new PaySlip(month, year);
            ps.GeneratePaySlip(myStaff);
            ps.GenerateSummary(myStaff);

            Console.Read();
        }
    }
}
