using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlquancafe
{
    class QL_menu
    {
        public static void QuanLyMenuSP()
        {
            Console.Clear();
            Console.WriteLine("Chức năng quản lý khách hàng");

            string[] menuItems = { "Xem thông tin sản phẩm", "Thêm sản phẩm mới","Sửa thông tin sản phẩm", "Xóa san phẩm", "Tìm kiếm sản phẩm", "Trở về trang chủ" };
            int selectedItemIndex = 0;
            bool isShowingCustomers = false;
            while (true)
            {
                Console.Clear();

                if (isShowingCustomers)
                {
                    XemThongTinSanPham();   
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
                                XemThongTinSanPham();
                                break;
                            case 1:
                               ThemSanPham();
                                break;
                            case 2:
                                SuaThongTinSanPham();
                                break;
                            case 3:
                                XoaSanPham();
                                break;
                            case 4:

                                TimKiemSanPham();
                                break;
                            case 5:

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
            Console.SetCursorPosition(startCol, startRow - 2);
            Console.WriteLine("CHỨC NĂNG QUẢN LÝ MENU SẢN PHẨM");
            // Vẽ đường viền trên cùng
            Console.SetCursorPosition(startCol, startRow);
            Console.WriteLine("┌" + new string('─', menuWidth - 2) + "┐");

            // Vẽ các mục trong menu và đường viền bên trái và bên phải
            for (int i = 0; i < menuItems.Length; i++)
            {
                Console.SetCursorPosition(startCol, startRow + i + 1);

                if (i == selectedItemIndex)
                {
                    /*Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;*/
                    Console.Write("│--> ");
                }
                else
                {
                   /* Console.ForegroundColor = ConsoleColor.Gray;
                    Console.BackgroundColor = ConsoleColor.Black;*/
                    Console.Write("│    "); // Thêm khoảng trống ở đây để tạo khoảng cách
                }

                Console.Write(menuItems[i]);

                if (i == selectedItemIndex)
                {
                   /* Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;*/
                    Console.Write(" <--");
                }

                Console.SetCursorPosition(startCol + menuWidth - 1, startRow + i + 1);
               /* Console.ForegroundColor = ConsoleColor.Gray;
                Console.BackgroundColor = ConsoleColor.Black;*/
                Console.WriteLine("│");
            }

            // Vẽ đường viền dưới cùng
            Console.SetCursorPosition(startCol, startRow + menuHeight + 1);
            Console.WriteLine("└" + new string('─', menuWidth - 2) + "┘");

            // Đặt con trỏ chuột trở lại vị trí ban đầu
            Console.SetCursorPosition(startCol + 5, startRow + selectedItemIndex + 1);
        }
        private static void XemThongTinSanPham()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {

                    Console.WriteLine("┌─────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                  THÔNG TIN SẢN PHẨM                         │");
                    Console.WriteLine("├─────────────────────────────────────────────────────────────┤");
                    Console.WriteLine("│        ID         │ Tên sản phẩm         │       Giá        │");
                    Console.WriteLine("├───────────────────┼──────────────────────┼──────────────────┤");


                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] values = line.Split(',');

                        if (values.Length == 3)
                        {
                            string id = values[0].Trim();
                            string name = values[1].Trim();
                            string price = values[2].Trim();


                            Console.WriteLine("│{0,-19}│{1,-22}│{2,-18}│", id, name, price);

                            if (i < lines.Length - 1)
                            {

                                Console.WriteLine("└───────────────────└──────────────────────└──────────────────┘");
                            }
                        }
                    }

                    //Console.WriteLine("└───────────────────└──────────────────────└──────────────────┘");
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
        private static void ThemSanPham()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Thêm sản phẩm mới:\n");

            string id = "";
            while (string.IsNullOrWhiteSpace(id))
            {
                Console.Write("Nhập ID sản phẩm: ");
                id = Console.ReadLine()?.Trim().Replace(" ", "").ToLower();

                if (string.IsNullOrWhiteSpace(id))
                {
                    Console.WriteLine("Mã sản phẩm không được bỏ trống. Vui lòng nhập lại.");
                }
                else
                {
                    if (File.Exists(filePath))
                    {
                        string[] lines = File.ReadAllLines(filePath);
                        foreach (string line in lines)
                        {
                            string[] values = line.Split(',');
                            if (values.Length > 0 && values[0].ToLower() == id)
                            {
                                Console.WriteLine("Mã sản phẩm đã tồn tại. Vui lòng nhập lại.");
                                id = "";
                                break;
                            }
                        }
                    }
                }
            }

            string name = "";
            while (string.IsNullOrWhiteSpace(name))
            {
                Console.Write("Nhập tên sản phẩm: ");
                name = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(name))
                {
                    Console.WriteLine("Tên sản phẩm không được bỏ trống. Vui lòng nhập lại.");
                }
            }

            string price = "";
            while (string.IsNullOrWhiteSpace(price))
            {
                Console.Write("Nhập giá:  ");
                price = Console.ReadLine()?.Trim();

                if (string.IsNullOrWhiteSpace(price))
                {
                    Console.WriteLine("Địa chỉ không được bỏ trống. Vui lòng nhập lại.");
                }
            }

           

            // Tiếp tục với mã ghi dữ liệu vào file



            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, true, Encoding.UTF8))
                {
                    writer.WriteLine($"{id},{name},{price}");
                }

                Console.WriteLine("\nThêm khách hàng thành công!");

                Console.WriteLine("\nDanh sách khách hàng sau khi thêm:\n");
                XemThongTinSanPham();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Đã xảy ra lỗi: " + ex.Message);
            }

        }
        private static void XoaSanPham()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            Console.WriteLine("Xóa thông tin khách hàng:\n");

            Console.Write("Nhập id sản phẩm cần xóa: ");
            string id = Console.ReadLine();

            try
            {
                string[] lines = File.ReadAllLines(filePath);
                bool delete = false;

                List<string> updatedLines = new List<string>();

                foreach (string line in lines)
                {
                    string[] values = line.Split(',');

                    if (values.Length == 3)
                    {
                        string id_SP = values[0].Trim();

                        if (id_SP.Equals(id, StringComparison.OrdinalIgnoreCase))
                        {
                            // Khách hàng được tìm thấy, không thêm dòng này vào danh sách
                            delete = true;
                            continue;
                        }
                    }

                    updatedLines.Add(line);
                }

                if (delete)
                {
                    File.WriteAllLines(filePath, updatedLines);
                    Console.WriteLine("\nThông tin sản phẩm đã được xóa thành công!");
                }
                else
                {
                    Console.WriteLine("\nKhông tìm thấy sản phẩm có id \"{0}\" trong danh sách.", id);
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

        private static void SuaThongTinSanPham()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;
            Console.Write("Nhập mã sản phẩm cần sửa: ");
            string id = Console.ReadLine();

            List<string> lines = new List<string>();

            if (File.Exists(filePath))
            {
                lines.AddRange(File.ReadAllLines(filePath));

                bool found = false;

                for (int i = 0; i < lines.Count; i++)
                {
                    string[] values = lines[i].Split(',');

                    if (values.Length > 0 && values[0] == id)
                    {
                        found = true;

                        Console.WriteLine("\nThông tin sản phẩm cần sửa:");
                        Console.WriteLine($"Mã sản phẩm: {values[0]}");
                        Console.WriteLine($"Tên sản phẩm: {values[1]}");
                        Console.WriteLine($"Giá sản phẩm: {values[2]}");
                      //  Console.WriteLine($"Mô tả: {values[3]}");

                        Console.WriteLine("\nNHẬP THÔNG TIN MỚI ");

                        Console.Write("Tên sản phẩm: ");
                        string tenSanPham = Console.ReadLine();

                        Console.Write("Giá sản phẩm: ");
                        string giaSanPham = Console.ReadLine();

                       /* Console.Write("Mô tả: ");
                        string moTa = Console.ReadLine();
*/
                        lines[i] = $"{id},{tenSanPham},{giaSanPham}";

                        Console.WriteLine("\nSửa thông tin sản phẩm thành công!");
                        break;
                    }
                }

                if (!found)
                {
                    Console.WriteLine("Mã sản phẩm không tồn tại. Không thể sửa thông tin.");
                }
                else
                {
                    File.WriteAllLines(filePath, lines);
                }
            }
            else
            {
                Console.WriteLine("File không tồn tại. Không thể sửa thông tin sản phẩm.");
            }
        }

        private static void TimKiemSanPham()
        {
            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";
            Console.InputEncoding = Encoding.Unicode;
            Console.OutputEncoding = Encoding.Unicode;

            try
            {
                string[] lines = File.ReadAllLines(filePath);

                if (lines.Length > 0)
                {
                    Console.Write("Nhập tên tìm kiếm: ");
                    string keyword = Console.ReadLine();

                    Console.WriteLine("┌─────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                  THÔNG TIN SẢN PHẨM                         │");
                    Console.WriteLine("├─────────────────────────────────────────────────────────────┤");
                    Console.WriteLine("│        ID         │ Tên sản phẩm         │       Giá        │");
                    Console.WriteLine("├───────────────────┼──────────────────────┼──────────────────┤");

                    bool foundAny = false;
                    for (int i = 0; i < lines.Length; i++)
                    {
                        string line = lines[i];
                        string[] values = line.Split(',');

                        if (values.Length == 3)
                        {
                            string id = values[0].Trim();
                            string name = values[1].Trim();
                            string price = values[2].Trim();
                          

                            if (name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 || name.IndexOf(keyword, StringComparison.OrdinalIgnoreCase) >= 0 )
                            {

                                Console.WriteLine("│{0,-19}│{1,-22}│{2,-18}│", id, name, price);
                                foundAny = true;
                                if (i < lines.Length - 1)
                                {

                                    Console.WriteLine("└───────────────────└──────────────────────└──────────────────┘");
                                }
                            }

                        }

                    }

                    // Console.WriteLine("└───────────────────┴───────────────┴───────────────────┴───────────────┘");

                    if (!foundAny)
                    {
                        Console.WriteLine("Không tìm thấy sản phẩm phù hợp.");
                    }
                }
                else
                {
                    Console.WriteLine("Không có thông tin sản phẩm.");
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Không tìm thấy tệp tin sản phẩm.");
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
