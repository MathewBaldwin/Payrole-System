using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayroleSystem
{
    class PaySlip
    {
        private int month;

        private int year;

        enum MonthsOfTheYear { Jan = 1, Feb = 2, Mar, Arp, May, Jun, July, Aug, Sep, Oct, Nov, Dec };

        public PaySlip(int payMonth, int payYear)
        {
            month = payMonth;

            year = payYear;
        }

        public void GeneratePaySlip(List<Staff> myStaff)
        {
            string path;

            foreach (Staff member in myStaff)
            {
                path = member.NameOfStaff + ".txt";

                using (StreamWriter sw = new StreamWriter(path))
                {
                    sw.WriteLine("PAYSLIP FOR {0} {1}", (MonthsOfTheYear)month, year);
                    sw.WriteLine("================================");
                    sw.WriteLine("Name Of Staff: {member.NameOfStaff}");
                    sw.WriteLine("Hours Worked: {member.HoursWorked}{0}");
                    sw.WriteLine("");
                    sw.WriteLine("Basic Pay: {member.BasicPay:C}");

                    if (member.GetType() == typeof(Manager))
                        sw.WriteLine("Allowance: {(Manager)member).Allowance:C}");
                    else if (member.GetType() == typeof(Admin))
                        sw.WriteLine("Overtime: {(Admin)member).Overtime:C}");

                    sw.WriteLine("");
                    sw.WriteLine("================================");
                    sw.WriteLine("Total Pay: {member.TotalPay:C}");
                    sw.WriteLine("================================");
                    sw.Close();
                }
            }
        }

        public void GenerateSummary(List<Staff> myStaff)
        {
            var result
                = from f in myStaff
                  where f.HoursWorked < 10
                  orderby f.NameOfStaff ascending
                  select new { f.NameOfStaff, f.HoursWorked };

            string path = "summary.txt";
            using (StreamWriter sw = new StreamWriter(path))
            {
                sw.WriteLine("Staff with less than to working hours");
                sw.WriteLine("");

                foreach (var f in result)
                    sw.WriteLine("Name Of Staff: {f.NameOfStaff}, Hours Worked: {f.HoursWorked}");
                sw.Close();
            }
        }

        public override string ToString()
        {
            return "Month = " + month + ", Year = " + year;
        }
    }
}

