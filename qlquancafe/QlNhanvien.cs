using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace qlquancafe
{
    class QlNhanvien
    {
        public static void QuanLyNhanVienMenu()
        {
            Console.Clear();
            Console.WriteLine("Chức năng quản lý khách hàng");

            string[] menuItems = { "Xem thông tin nhân viên", "Thêm nhân viên mới", "Xóa nhân viên", "Tìm kiếm nhân viên", "Trở về trang chủ" };
            int selectedItemIndex = 0;
            bool isShowingCustomers = false;
            while (true)
            {
                Console.Clear();

                if (isShowingCustomers)
                {
                    XemThongTinNhanVien();
                }
                else
                {
                    DrawMenu(menuItems, selectedItemIndex);
                }

                ConsoleKeyInfo keyInfo = Console.ReadKey();

                if (isShowingCustomers)
                {
                    if (keyInfo.Key == ConsoleKey.Escape)
                    {
                        isShowingCustomers = false;
                    }
                }
                else
                {
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
                        Console.Clear();

                        switch (selectedItemIndex)
                        {
                            case 0:
                                XemThongTinNhanVien();
                                break;
                            case 1:
                                ThemNhanVien();
                                break;
                            /*case 2:
                                SuaThongTinKhachHang();
                                break;*/
                            case 2:
                                XoaNhanVien();
                                break;
                            case 3:

                                TimKiemnNhanVien();
                                break;
                            case 4:

                                return; // Trở về trang chủ

                        }

                        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                    }
                }
            }
        }


        static void DrawMenu(string[] menuItems, int selectedItemIndex)
        {
            int menuWidth = 35;
            int menuHeight = menuItems.Length;
            int startRow = Console.WindowHeight / 2 - menuHeight / 2;
            int startCol = Console.WindowWidth / 2 - menuWidth / 2;

            Console.Clear();

            //  Console.SetCursorPosition(startCol, startRow - 2);
            Console.WriteLine("CHỨC NĂNG QUẢN LÝ NHÂN VIÊN");
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
                    Console.Write("│--> ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("│    "); // Thêm khoảng trống ở đây để tạo khoảng cách
                }

                Console.Write(menuItems[i]);

                if (i == selectedItemIndex)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write(" <--");
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

        private static void XemThongTinNhanVien()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_QlNhanVien.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {

                    Console.WriteLine("┌───────────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             THÔNG TIN KHÁCH HÀNG                                  │");

                    Console.WriteLine("├───────────────────────────────────────────────────────────────────────────────────┤");
                    Console.WriteLine("│        Tên        │ Số điện thoại │       Chức vụ     │ Lịch làm viêc             │");
                    Console.WriteLine("├───────────────────┼───────────────┼───────────────────┼───────────────────────────┤");

                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] values = line.Split(',');

                        if (values.Length == 4)
                        {
                            string name = values[0].Trim();
                            string phoneNumber = values[1].Trim();
                            string position = values[2].Trim();
                            string working_time = values[3].Trim();

                            Console.WriteLine("│{0,-19}│{1,-15}│{2,-19}│{3,-27 }│", name, phoneNumber, position, working_time);

                            if (i < lines.Length - 1)
                            {

                                Console.WriteLine("└───────────────────└───────────────└───────────────────└───────────────────────────┘");
                            }
                        }
                    }

                    Console.WriteLine("└───────────────────┴───────────────┴───────────────────┴───────────────────────────┘");
                }
                else
                {
                    Console.WriteLine("Không có thông tin khách hàng.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp file_khachhang.txt");
            }

            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
            Console.ReadKey();
        }

        private static void ThemNhanVien()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_QlNhanVien.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Thêm khách hàng mới:\n");

            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Nhập tên khách hàng: ");
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Tên khách hàng không được bỏ trống. Vui lòng nhập lại.");
                }
            }

            string phoneNumber = "";
            while (string.IsNullOrWhiteSpace(phoneNumber))
            {
                Console.Write("Nhập số điện thoại: ");
                phoneNumber = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(phoneNumber))
                {
                    Console.WriteLine("Số điện thoại không được bỏ trống. Vui lòng nhập lại.");
                }
            }

            string address = "";
            while (string.IsNullOrWhiteSpace(address))
            {
                Console.Write("Nhập địa chỉ: ");
                address = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(address))
                {
                    Console.WriteLine("Địa chỉ không được bỏ trống. Vui lòng nhập lại.");
                }
            }

            string history = "";
            while (string.IsNullOrWhiteSpace(history))
            {
                Console.Write("Nhập lịch sử mua: ");
                history = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(history))
                {
                    Console.WriteLine("Lịch sử mua không được bỏ trống. Vui lòng nhập lại.");
                }
            }

            // Tiếp tục với mã ghi dữ liệu vào file



            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    writer.WriteLine($"{name},{phoneNumber},{address},{history}");
                }

                Console.WriteLine("\nThêm khách hàng thành công!");

                Console.WriteLine("\nDanh sách khách hàng sau khi thêm:\n");
                XemThongTinNhanVien();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

        }

        // Tiếp tục với mã ghi dữ liệu vào file




    
        
        private static void XoaNhanVien()
        {
            //C:\Users\1010302\OneDrive\Documents\file_QlNhanVien.txt
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_QlNhanVien.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Xóa thông tin khách hàng:\n");

            Console.Write("Nhập tên khách hàng cần xóa: ");
            string name = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool khachHangDaXoa = false;

                List<string> updatedLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    if (values.Length == 4)
                    {
                        string khachHangName = values[0].Trim();

                        if (khachHangName.Equals(name, StringComparison.OrdinalIgnoreCase))
                        {
                            // Khách hàng được tìm thấy, không thêm dòng này vào danh sách
                            khachHangDaXoa = true;
                            continue;
                        }
                    }

                    updatedLines.Add(line);
                }

                if (khachHangDaXoa)
                {
                    File.WriteAllLines(filePath, updatedLines);
                    Console.WriteLine("\nThông tin khách hàng đã được xóa thành công!");
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy nhân viên có tên \"{0}\" trong danh sách.", name);
                }

                Console.WriteLine("\nNhấn phím bất kỳ để trở về trang chủ...");
                Console.ReadKey();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp file_khachhang.txt");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }
        }
        private static void  TimKiemnNhanVien()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_QlNhanVien.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    Console.Write("Nhập kí tự tìm kiếm: ");
                    string keyword = Console.ReadLine();

                    Console.WriteLine("┌────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                             THÔNG TIN KHÁCH HÀNG                           │");
                    Console.WriteLine("├────────────────────────────────────────────────────────────────────────────┤");
                    Console.WriteLine("│        Tên        │ Số điện thoại │       Địa chỉ     │ Lịch sử mua        │");
                    Console.WriteLine("├───────────────────┼───────────────┼───────────────────┼────────────────────┤");

                    bool foundAny = false;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] values = line.Split(',');

                        if (values.Length == 4)
                        {
                            string name = values[0].Trim();
                            string phoneNumber = values[1].Trim();
                            string address = values[2].Trim();
                            string history = values[3].Trim();

                            if (name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || phoneNumber.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || address.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || history.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0)
                            {

                                Console.WriteLine("│{0,-19}│{1,-15}│{2,-19}│{3,-20}│", name, phoneNumber, address, history);
                                foundAny = true;
                                if (i < lines.Length - 1)
                                {

                                    Console.WriteLine("└───────────────────└───────────────└───────────────────└────────────────────┘");
                                }
                            }

                        }

                    }

                   // Console.WriteLine("└───────────────────┴───────────────┴───────────────────┴───────────────┘");

                    if (!foundAny)
                    {
                        Console.WriteLine("Không tìm thấy khách hàng phù hợp.");
                    }
                }
                else
                {
                    Console.WriteLine("Không có thông tin khách hàng.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp tin khách hàng.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về trang quản lý khách hàng.");
            Console.ReadKey();
        }

    }
   
}

    

