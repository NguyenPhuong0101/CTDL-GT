using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace doan
{
    class Employee
    {
        //
        private string username;
        private string password;
        private string hoTen;
        private string diaChi;
        private int soDienThoai;
        private string diaChiEmail;
        //
        public string Username { get => username; set => username = value; }
        public string Password { get => password; set => password = value; }
        public string HoTen { get => hoTen; set => hoTen = value; }
        public string DiaChi { get => diaChi; set => diaChi = value; }
        public int SoDienThoai { get => soDienThoai; set => soDienThoai = value; }
        public string DiaChiEmail { get => diaChiEmail; set => diaChiEmail = value; }
        //
        public Employee()
        {

        }

        public Employee(string username, string hoten, string diachi, int sodienthoai, string Email)
        {
            this.Username = username;
            Password = "111111";
            this.HoTen = hoten;
            this.DiaChi = diachi;
            this.SoDienThoai = sodienthoai;
            this.DiaChiEmail = Email;
            using (StreamWriter sW = new StreamWriter("Employee.txt", true))
            {
                sW.WriteLine(Username + " " + Password);
            }
            using (StreamWriter sW = new StreamWriter( username + ".txt"))
            {
                sW.WriteLine($"{ HoTen,10}");
                sW.WriteLine($"{DiaChi,10}");
                sW.WriteLine( $"{SoDienThoai,10}");
                sW.WriteLine($"{DiaChiEmail,10}");
            }
        }
        public void docfile(StreamReader sR)
        {
            string line = sR.ReadToEnd();
            string[] arr1 = new string[] { " " };
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
            Console.WriteLine("\t\t\t\t***************** Employee ****************");
            Console.WriteLine("\t\t\tTai khoan:", Username);
            Console.WriteLine("\t\t\tMat khau:", Password);
            Console.WriteLine("\t\t\t*******************************************");
        }
      

    }
}
