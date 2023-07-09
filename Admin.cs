using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace doan
{
    class Admin
    {
        //
        private string username;
        private string password;
        //
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }

        public void docfile(StreamReader sR)
        {
            string line = sR.ReadLine();
            string[] arr1 = new string[] {" "}; 
            string[] arr2 = line.Split(' '); 

            Username = arr2[0];
            Password = arr2[1];

        }
        public void Ghi(StreamWriter sW)
        {
            sW.WriteLine("{0}+{1}", Username, Password);
         
        }
        public void xuat()
        {
            Console.WriteLine("\t\t\t*****************Admin****************");
            Console.WriteLine("\t\t\tTai khoan:", Username);
            Console.WriteLine("\t\t\t Mat khau:", Password);
            Console.WriteLine("\t\t\t****************************************");
        }
    }
}
