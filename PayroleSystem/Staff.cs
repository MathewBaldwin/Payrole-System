using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PayroleSystem
{
    class Staff
    {
        private float hourlyRate;

        private int hWorked;

        public float BasicPay { get; private set; }

        public float TotalPay { get; protected set; }

        public string NameOfStaff { get; private set; }

        public float HoursWorked
        {
            get { return hWorked; }
            set
            {
                if (value > 0)
                    hWorked = (int)value;
                else
                    hWorked = 0;
            }
        }

        public Staff(string name, float rate)
        {
            name = NameOfStaff;

            rate = hourlyRate;
        }

        public virtual void CalculatePay()
        {
            Console.WriteLine("Calculating Pay...");

            BasicPay = hWorked * hourlyRate;

            TotalPay = BasicPay;
        }

        public override string ToString()
        {
            return "Name of Staff = " + NameOfStaff + ", hourlyRate = " + hourlyRate + ", hWorked = " + hWorked + ", BasicPay = " + BasicPay + ", TotalPay = " + TotalPay + ", HoursWorked = " + HoursWorked;
        }
    }
}
