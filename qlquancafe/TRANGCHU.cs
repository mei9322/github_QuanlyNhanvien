using System;
using System.Text;
using System.IO;
namespace qlquancafe
{
    class TRANGCHU
    {
       

        public static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.CursorVisible = false; // Ẩn con trỏ chuột

            while (true)
            {
                if (DangNhap())
                {
                    MenuTrangChu();
                    break;
                }
                else
                {
                   
                    Console.WriteLine("\n\t\t\t\tTài khoản hoặc mật khẩu không đúng. Vui lòng thử lại.");
                    Console.WriteLine("\t\t\t\t\tNhấn phím bất kỳ để tiếp tục đăng nhập...");
                    Console.ReadKey();
                }

                Console.Clear();
            }

            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }

        static bool DangNhap()
        {
            Console.Clear();
            int consoleWidth = Console.WindowWidth;
            int consoleHeight = Console.WindowHeight;
            int startX = (consoleWidth - 40) / 2;
            int startY = (consoleHeight - 10) / 2;

            Console.SetCursorPosition(startX, startY);
            Console.WriteLine("╔══════════════════════════════════════╗");
           // Console.SetCursorPosition(startX, startY + 1);
            //Console.WriteLine("║                                      ║");
            Console.SetCursorPosition(startX, startY + 1);
            Console.WriteLine("║          ĐĂNG NHẬP QUÁN CAFE         ║");
          //  Console.SetCursorPosition(startX, startY + 3);
          //  Console.WriteLine("║                                      ║");
            Console.SetCursorPosition(startX, startY + 2);
            Console.WriteLine("╚══════════════════════════════════════╝");

            Console.SetCursorPosition(startX + 3, startY + 5);
            Console.Write("Tài khoản: ");
            string username = Console.ReadLine();

            Console.SetCursorPosition(startX + 3, startY + 7);
            Console.Write("Mật khẩu: ");
            string password = ReadPassword();

            // Kiểm tra tài khoản và mật khẩu
            string filePath = @"C:\Users\1010302\OneDrive\Documents\user.txt";
            string[] lines = File.ReadAllLines(filePath);
            foreach (string line in lines)
            {
                string[] values = line.Split(',');
                if (values.Length > 1 && values[0] == username && values[1] == password)
                {
                    return true; // Đăng nhập thành công
                }
            }

            return false; // Đăng nhập không thành công
        }
        static string ReadPassword()
        {
            string password = "";
            ConsoleKeyInfo keyInfo;

            do
            {
                keyInfo = Console.ReadKey(true);

                if (keyInfo.Key != ConsoleKey.Enter && keyInfo.Key != ConsoleKey.Backspace)
                {
                    password += keyInfo.KeyChar;
                    Console.Write("*");
                }
                else if (keyInfo.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password = password.Remove(password.Length - 1);
                    Console.Write("\b \b");
                }
            }
            while (keyInfo.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password;
        }
        static void MenuTrangChu()
        {
            string[] menuItems = { "Quản lý khách hàng", "Quản lý đồ uống", "Quản lý thanh toán", "Quản lý nhân viên", "Quản lý doanh thu" };
            int selectedItemIndex = 0;

            while (true)
            {
                Console.Clear();
                DrawMenu(menuItems, selectedItemIndex);

                // Đọc phím đang được nhấn
                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (keyInfo.Key == ConsoleKey.UpArrow && selectedItemIndex > 0)
                {
                    selectedItemIndex--;
                }
                else if (keyInfo.Key == ConsoleKey.DownArrow && selectedItemIndex < menuItems.Length - 1)
                {
                    selectedItemIndex++;
                }
                else if (keyInfo.Key == ConsoleKey.Enter)
                {
                    // Xử lý chọn mục được chọn
                    HandleSelection(selectedItemIndex);
                }
            }
        }

        static void DrawMenu(string[] menuItems, int selectedItemIndex)
        {
            int menuWidth = 30;
            int menuHeight = menuItems.Length;
            int startRow = Console.WindowHeight / 2 - menuHeight / 2;
            int startCol = Console.WindowWidth / 2 - menuWidth / 2;

            Console.Clear();


            Console.SetCursorPosition(startCol, startRow - 2);
            Console.WriteLine("CHƯƠNG TRÌNH QUẢN LÝ QUÁN CAFE");
            // Vẽ đường viền trên cùng

            Console.SetCursorPosition(startCol, startRow);
            Console.WriteLine("┌" + new string('─', menuWidth - 2) + "┐");

            // Vẽ các mục trong menu và đường viền bên trái và bên phải
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(startCol, startRow + i + 1);

                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("│-> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("│   ");
                }

                Console.Write(menuItems[i]);

                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" <-");
                }

                Console.SetCursorPosition(startCol + menuWidth - 1, startRow + i + 1);
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine("│");
            }

            // Vẽ đường viền dưới cùng
            Console.SetCursorPosition(startCol, startRow + menuHeight + 1);
            Console.WriteLine("└" + new string('─', menuWidth - 2) + "┘");

            // Đặt con trỏ chuột trở lại vị trí ban đầu
            Console.SetCursorPosition(startCol + 5, startRow + selectedItemIndex + 1);
        }

        static void HandleSelection(int selectedItemIndex)
        {
            Console.Clear();

            switch (selectedItemIndex)
            {
                case 0:
                    // Quản lý khách hàng
                    Console.WriteLine("Chức năng quản lý khách hàng");
                    qlKhachHang.QuanLyKhachHangMenu();
                    // TODO: Thêm code để xử lý chức năng quản lý khách hàng
                    break;
                case 1:
                    // Quản lý đồ uống
                    Console.WriteLine("Chức năng quản lý đồ uống");
                    QL_menu.QuanLyMenuSP();
                    // TODO: Thêm code để xử lý chức năng quản lý đồ uống
                    break;
                case 2:
                    // Quản lý thanh toán
                    Console.WriteLine("Chức năng thanh toán");
                    ThanhToan.ThucHienThanhToan();
                    // TODO: Thêm code để xử lý chức năng quản lý thanh toán
                    break;
                case 3:
                    // Quản lý nhân viên
                    Console.WriteLine("Chức năng quản lý nhân viên");
                    QlNhanvien.QuanLyNhanVienMenu();
                    // TODO: Thêm code để xử lý chức năng quản lý nhân viên
                    break;
                case 4:
                    // Quản lý doanh thu
                    Console.WriteLine("Chức năng quản lý doanh thu");
                    ThongKeDoanhThu.HienThiThongTinDoanhThu();
                // TODO: Thêm code để xử lý chức n
                break;
              /*  case 5:
                    // Quản lý bàn
                    Console.WriteLine("Chức năng quản lý bàn");
                    // TODO: Thêm code để xử lý chức năng quản lý bàn
                    break;*/
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về");
            Console.ReadKey();
        }
    }
}
////test