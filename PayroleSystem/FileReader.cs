using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PayroleSystem
{
    class FileReader
    {
        public List<Staff> Readfile()
        {
            List<Staff> myStaff = new List<Staff>();

            string[] result = new string[2];

            string path = @"C:\Users\honda\Documents\Visual Studio 2017\Projects\PayroleSystem\PayroleSystem\bin\Debug\Staff.txt";

            string[] seperator = { ", " };

            if(File.Exists(path))
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    while (!sr.EndOfStream)
                    {
                        result = sr.ReadLine().Split(seperator, StringSplitOptions.RemoveEmptyEntries);

                        if (result[1] == "Manager")
                            myStaff.Add(new Manager(result[0]));
                        else if (result[1] == "Admin")
                            myStaff.Add(new Admin(result[0]));
                    }
                    sr.Close();
                }
            }
            else
            {
                Console.WriteLine("Error: File does not exist!");
            }
            return myStaff;
        }
    }
}
