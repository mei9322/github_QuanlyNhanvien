using System;
using System.IO;
using System.Globalization;

namespace qlquancafe
{
    class ThongKeDoanhThu
    {
        public static void HienThiThongTinDoanhThu()
        {
            string receiptPath = @"C:\Users\1010302\OneDrive\Documents\QL_DoanhThu.txt";

            if (File.Exists(receiptPath))
            {
                string[] lines = File.ReadAllLines(receiptPath);

                if (lines.Length == 0)
                {
                    Console.WriteLine("Không có thông tin doanh thu.");
                }
                else
                {
                    Console.WriteLine("┌──────────────────────────────────────────────────────────────────────────────────────────────────────────────────┐");
                    Console.WriteLine("│                                        THÔNG TIN DOANH THU                                                       │");
                    Console.WriteLine("├──────────────────────────────────────────────────────────────────────────────────────────────────────────────────┤");
                    Console.WriteLine("│        ID         │ Tên sản phẩm         │       Số lượng       │      Thành Tiền     │        Ngày lập          │");
                    Console.WriteLine("├───────────────────┼──────────────────────┼──────────────────────┼─────────────────────┼──────────────────────────┤");

                    // Hiển thị thông tin từ file
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');

                        if (fields.Length >= 5)
                        {
                            string id = fields[0].Trim();
                            string name = fields[1].Trim();
                            int quantity = Convert.ToInt32(fields[2].Trim());
                            int totalPrice = Convert.ToInt32(fields[3].Trim());

                            DateTime dateTime;
                            if (DateTime.TryParseExact(fields[4].Trim(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                            {
                                Console.WriteLine("│{0,-19}│{1,-22}│{2,-22}│{3,-16:N0} VNĐ │{4,-26}│", id, name, quantity, totalPrice, dateTime.ToString("dd/MM/yyyy hh:mm:ss tt"));
                                Console.WriteLine("└───────────────────└──────────────────────└──────────────────────┘─────────────────────┘──────────────────────────┘");
                            }
                            else
                            {
                                Console.WriteLine("Lỗi định dạng ngày.");
                            }
                        }
                    }

                    // Nhập năm để tính tổng thành tiền
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("Nhập năm để tính tổng thành tiền (nhập 0 để thoát):");
                    int year = 0;
                    bool isValidYear = int.TryParse(Console.ReadLine(), out year);
                    if (!isValidYear)
                    {
                        Console.WriteLine("Năm không hợp lệ.");
                        return;
                    }
                    else if (year == 0)
                    {
                        return;
                    }

                    double totalRevenue = 0;
                    bool hasDataForYear = false;

                    // Tính tổng doanh thu theo năm
                    foreach (string line in lines)
                    {
                        string[] fields = line.Split(',');

                        if (fields.Length >= 5)
                        {
                            DateTime dateTime;
                            if (DateTime.TryParseExact(fields[4].Trim(), "M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dateTime))
                            {
                                if (dateTime.Year == year)
                                {
                                    int totalPrice = Convert.ToInt32(fields[3].Trim());
                                    totalRevenue += totalPrice;
                                    hasDataForYear = true;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Lỗi định dạng ngày.");
                            }
                        }
                    }

                    if (hasDataForYear)
                    {
                        Console.WriteLine("-----------------------------");
                        Console.WriteLine("Tổng doanh thu trong năm {0}: {1} VNĐ", year, totalRevenue);
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Không có dữ liệu doanh thu cho năm {0}.", year);
                        Console.ResetColor();
                    }
                }
            }
            else
            {
                Console.WriteLine("File doanh thu không tồn tại.");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về");
            Console.ReadKey();
        }
    }
}
