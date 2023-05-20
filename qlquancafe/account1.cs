using System;
using System.IO;

namespace qlquancafe
{
    class DangNhap
    {
        private const string UserFilePath = @"C:\Users\1010302\OneDrive\Documents\user.txt";

        public static void KiemTraDangNhap()
        {
            Console.WriteLine("Đăng nhập");
            Console.WriteLine("───────────────────────");

            Console.Write("Tài khoản: ");
            string username = Console.ReadLine();

            Console.Write("Mật khẩu: ");
            string password = Console.ReadLine();

            if (KiemTraTaiKhoan(username, password))
            {
                Console.WriteLine("Đăng nhập thành công.");
                Console.WriteLine("Chuyển đến Trang Chủ...");
                TrangChu();
            }
            else
            {
                Console.WriteLine("Tài khoản hoặc mật khẩu không đúng.");
            }

            Console.WriteLine("Nhấn phím bất kỳ để thoát.");
            Console.ReadKey();
        }

        private static bool KiemTraTaiKhoan(string username, string password)
        {
            if (File.Exists(UserFilePath))
            {
                string[] lines = File.ReadAllLines(UserFilePath);

                foreach (string line in lines)
                {
                    string[] credentials = line.Split(',');

                    if (credentials.Length >= 2)
                    {
                        string storedUsername = credentials[0].Trim();
                        string storedPassword = credentials[1].Trim();

                        if (storedUsername == username && storedPassword == password)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private static void TrangChu()
        {
            Console.WriteLine("Chào mừng bạn đến Trang Chủ!");
            // TODO: Thực hiện các công việc trên trang chủ
        }
    }
}
