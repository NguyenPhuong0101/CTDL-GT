using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.IO;

namespace doan
{
    class Program
    {
        static void Main(string[] args)
        {
            LinkedList<Admin> ad = new LinkedList<Admin>();
            LinkedList<Employee> em = new LinkedList<Employee>();
            DocAdmin(ad);
            DocEmloyee(em);
            // Menu
            string tk = "";
            string mk = "";
            int n = 0, c = 0;
        MeNuDN:
            do
            {

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\t\t\t\t*****************************************");
                Console.Write("\t\t\t\t*");
                DangNhap();
                Console.Write("\t\t*");
                Console.WriteLine();
                Console.WriteLine("\t\t\t\t*****************************************");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("\t\t\t\tUsername:\t");
                tk = Console.ReadLine();
                Console.Write("\t\t\t\tPassword:\t");
                mk = Console.ReadLine(); 

                Console.Clear();
                n++;
            } while (n < 3 && !KtraAdmin(tk, mk, ad) && !KtraEm(tk, mk, em));
            if (KtraAdmin(tk, mk, ad))
            {

            MenuAD:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t*************** MENU***************");
                Console.WriteLine("\t\t\t1.Them employee");
                Console.WriteLine("\t\t\t2.Xoa employee");
                Console.WriteLine("\t\t\t3.Tim employee");
                Console.WriteLine("\t\t\t4.Cap nhat employee");
                Console.WriteLine("\t\t\t5.Hien thi thong tin employee");
                Console.WriteLine("\t\t\t6.Thoat chuong trinh!");
                Console.WriteLine("\t\t\t**************************************");
                Console.Write("\t\t\tChon chuc nang:\t");
                int.TryParse(Console.ReadLine(), out c);
                Console.Clear();
                do
                {
                    switch (c)
                    {
                        case 1:
                            Console.WriteLine("Them Employee:");
                            ThemEmployee(em, em.Count);
                            Console.Clear();
                            goto MenuAD;
                        case 2:
                            Console.WriteLine(" Xoa Employee:");
                            XoaEmployee(em, em.Count);
                            Console.Clear();
                            goto MenuAD;
                        case 3:
                            Console.WriteLine("Tim Employee:");
                            Console.Clear();
                            TimEmloyee(em);
                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;
                        case 4:
                            Console.WriteLine("Emloyee can cap nhat: ");
                            string user = Console.ReadLine();
                            CapNhat(user, em);
                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;
                        case 5:
                            Console.WriteLine("Hien thi thong tin: ");
                             DocFileEm();
                            Console.ReadKey();
                            Console.Clear();
                            goto MenuAD;

                        case 6:
                            goto MeNuDN;
                    }
                } while (c < 1 || c > 6);
            }
            else if (KtraEm(tk, mk, em))
            {
            menuchon:
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\t\t\t*************** MENU EM **************");
                Console.WriteLine("\t\t\t1.Xem thong tin tai khoan.");
                Console.WriteLine("\t\t\t2.Doi mat khau.");
                Console.WriteLine("\t\t\t3. Thoat!!!!");
                Console.WriteLine("\t\t\t********************************************");
                Console.Write("\t\t\tChon chuc nang:\t");
                int.TryParse(Console.ReadLine(), out c);
                Console.Clear();
                do
                {
                    switch (c)
                    {
                        case 1:
                            Console.WriteLine("\t\t\tThong tin Employee");
                           ThongTin(em, tk);
                            Console.ReadKey();
                            Console.Clear();
                            goto menuchon;
                        case 2:
                            DoiPassWord(em, tk);
                            Console.Clear();
                            goto menuchon;
                        //break;
                        case 3:
                            goto MeNuDN;
                    }
                } while (c > 3 || c < 1);
            }
            else
            {
                Console.WriteLine("Nhap sai qua 3 lan!");
            }
            Console.ReadKey();
        }
        // Cap nhat emloyee
        static void CapNhat(string user, LinkedList<Employee> em)
        {
            bool b = false;
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (i.Value.Username == user)
                {
                    b = true;
                }
            }
            if (b == false)
            {
                Console.WriteLine(" Khong ton tai!!! ");
                return;
            }
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("\t\t\t*************** MenuCapNhat**************");
            Console.WriteLine("\t\t\t1. Ho ten.  ");
            Console.WriteLine("\t\t\t2. Dia chi. ");
            Console.WriteLine("\t\t\t3. So dien thoai. ");
            Console.WriteLine("\t\t\t4. Email.");
            Console.WriteLine("\t\t\t5. Thoat!!!");
            Console.WriteLine("\t\t\t********************************************");
            int luachon;
            do
            {
                string data = "";
                Console.Write("\t\t\tChon chuc nang:");
                int.TryParse(Console.ReadLine(), out luachon);
                string[] Temp = File.ReadAllLines(user + ".txt");
                switch (luachon)
                {
                    case 1:
                        {
                            Console.WriteLine("Cap nhat ho ten ");
                            string temp = Console.ReadLine();
                            Temp[0] = temp;
                            data = "\nHo Ten: ";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 2:
                        {
                            Console.WriteLine("Cap nhat dia chi ");
                            string temp = Console.ReadLine();
                            Temp[1] = temp;
                            data = "\nDia chi: ";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 3:
                        {
                            Console.WriteLine("\nCap nhat so dien thoai ");
                            // đặt điều kiện do while here
                           string temp = Console.ReadLine();
                            Temp[2] = temp;
                            data = "So dien thoai: ";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                    case 4:
                        {
                            Console.WriteLine("\nEmail ");
                            string temp = Console.ReadLine();
                            Temp[3] = temp;
                            data = "Email: ";
                            Console.ReadKey();
                            Console.Clear();
                        }
                        break;
                }
                using (StreamWriter SW = new StreamWriter(user + ".txt"))
                {
                    for (int i = 0; i < Temp.Length; i++)
                    {
                        SW.WriteLine(Temp[i]);
                    }
                }
            } while (luachon < 1 || luachon > 5);
        }
        // Doi mat khau
        static void DoiPassWord(LinkedList<Employee> em, string tk)
        {
            Console.Write("Mat khau moi: ");
            string mkChange = Console.ReadLine();
            string[] TempAr = File.ReadAllLines("Employee.txt");
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (i.Value.Username == tk)
                {
                    i.Value.Password = mkChange;
                    using (StreamWriter Sw = new StreamWriter("Employee.txt"))
                    {
                        Sw.WriteLine(TempAr[0]);
                        for (LinkedListNode<Employee> j = em.First; j != null; j = j.Next)
                        {
                            Sw.WriteLine(j.Value.Username + ' ' + j.Value.Password);
                        }
                    }
                    break;
                }
            }
        }
        static string[] Phuong(string s)
        {
            string[] Username = s.Split(' ');
            return Username;
        }
        //Xoa emloyee
        static void XoaEmployee(LinkedList<Employee> em, int size)
        {
            string username;
            Console.Write(" Employeee can xoa : ");
            username = Console.ReadLine();
            // Xóa trong Linkedlist
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (i.Value.Username == username)
                {
                    em.Remove(i);
                    break;
                }
                else if (i == em.Last)
                {
                    Console.WriteLine("Khong ton tai !!! ");
                    return;
                }
            }
            string[] Temp = File.ReadAllLines("Employee.txt");
            string[] MangTV = new string[2];
            // Xoa file username
            File.Delete(username + ".txt");
            File.Delete("Employee.txt");
            Temp[0] = Convert.ToString(--size);
            // Xoa txt
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < Temp.Length; p++)
                {
                    MangTV = Phuong(Temp[p]);
                    if (MangTV[0] == username)
                    {
                        continue;
                    }
                    SW.WriteLine(Temp[p]);
                }
            }
            Console.WriteLine(" Da xoa !!! ");
        }
        // Them Employee:
        static void ThemEmployee(LinkedList<Employee> em, int size)
        {
            string username = "";
            do
            {
                Console.Write(" Nhap Username: ");
                username = Console.ReadLine();
                if (File.Exists(username + ".txt") == true)
                {
                    Console.WriteLine("  Da ton tai!! ! ");
                }
            } while (File.Exists(username + ".txt") == true);
            Console.Write(" Ho Ten: ");
            string hoten = Console.ReadLine();
            Console.Write(" Dia Chi:  ");
            string diachi = Console.ReadLine();
            Console.Write(" SDT: ");
            int sodienthoai; int.TryParse(Console.ReadLine(), out sodienthoai);
            Console.Write(" Email: ");
            string email = Console.ReadLine();
            Employee NewEm = new Employee(username, hoten, diachi, sodienthoai, email);
            em.AddLast(NewEm);
            size++;
            string[] temp = File.ReadAllLines("Employee.txt");
            File.Delete("Employee.txt");
            temp[0] = Convert.ToString(size);
            using (StreamWriter SW = new StreamWriter("Employee.txt"))
            {
                for (int p = 0; p < temp.Length; p++)
                {
                    SW.WriteLine(temp[p]);
                }
            }
        }
        //Đọc danh sách employee trong txt
        static void DocEmloyee(LinkedList<Employee> ListEm)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Employee.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {
                    Employee l = new Employee();
                    l.docfile(sR);
                    ListEm.AddLast(l);
                }
            }
        }
        // Đọc danh sách admin trong txt
        static void DocAdmin(LinkedList<Admin> ListAD)
        {
            int n = 0;
            using (StreamReader sR = new StreamReader("Admin.txt"))
            {
                int.TryParse(sR.ReadLine(), out n);
                for (int i = 0; i < n; i++)
                {                  
                    Admin l = new Admin();
                    l.docfile(sR);
                    ListAD.AddLast(l);
                }
            }
        }
        //Kiểm tra có trong danh sách employee hay không
        static bool KtraEm(string us, string pas, LinkedList<Employee> em)
        {
            for (LinkedListNode<Employee> i = em.First; i != null; i = i.Next)
            {
                if (us == i.Value.Username)
                {
                    if (pas == i.Value.Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        //Kiểm tra có trong danh sách admin hay không
        static bool KtraAdmin(string us, string pas, LinkedList<Admin> ad)
        {
            for (LinkedListNode<Admin> i = ad.First; i != null; i = i.Next)
            {
                if (us == i.Value.Username)
                {
                    if (pas == i.Value.Password)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        static void DangNhap()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("\t\tDang Nhap");
            Console.ForegroundColor = ConsoleColor.Green;
        }
        // Tim emlyoee
        static void TimEmloyee(LinkedList<Employee> em)
        {
            LinkedList<Employee> list1 = new LinkedList<Employee>();
            string username = null;
            Console.Write("Nhap Username: ");
            username = Console.ReadLine();
            string data = string.Empty;
            if (File.Exists(username + ".txt") == true)
            {
                using (StreamReader str = new StreamReader(username + ".txt"))
                    while ((data = str.ReadLine()) != null)
                    {
                        Console.WriteLine(data);
                    }
            }
            else
            {
                Console.WriteLine(" Khong ton tai!!!");
            }
        }
        public static void DocFileEm()
        {
            string data = string.Empty;
            using (StreamReader str = new StreamReader("Employee.txt"))
            {
                while ((data = str.ReadLine()) != null)
                {
                    Console.WriteLine(data);
                }
            }
            Console.WriteLine();
        }
        static void ThongTin(LinkedList<Employee> em, string us)
        {
            LinkedList<Employee> list = new LinkedList<Employee>();
            string data = string.Empty;
            using (StreamReader str = new StreamReader(us + ".txt"))
                do
                {

                    if (File.Exists(us + ".txt") == true)
                    {
                        while ((data = str.ReadLine()) != null)
                        {
                            Console.WriteLine(data);
                        }
                    }
                    break;
                } while (File.Exists(us + ".txt") == true);
        }

    }
}

