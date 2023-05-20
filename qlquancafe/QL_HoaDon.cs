using System;
using System.IO;

namespace qlquancafe
{
    class ThanhToan
    {
        public static void ThucHienThanhToan()
        {
            Console.WriteLine("Nhập ID hoặc tên sản phẩm: ");
            string searchValue = Console.ReadLine();

            string filePath = @"C:\Users\1010302\OneDrive\Documents\file_menuSP.txt";
            string receiptPath = @"C:\Users\1010302\OneDrive\Documents\QL_DoanhThu.txt";

            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                bool isFound = false;

                foreach (string line in lines)
                {
                    string[] fields = line.Split(',');

                    if (fields.Length >= 3)
                    {
                        string id = fields[0].Trim();
                        string name = fields[1].Trim();
                        int price;

                        if (int.TryParse(fields[2].Trim(), out price))
                        {
                            if (id.Equals(searchValue, StringComparison.OrdinalIgnoreCase) || name.Equals(searchValue, StringComparison.OrdinalIgnoreCase))
                            {
                                isFound = true;
                                Console.WriteLine();
                                Console.WriteLine("───────────────────────────────");
                                Console.WriteLine("Thông tin sản phẩm:");
                                Console.WriteLine("───────────────────────────────");
                                Console.WriteLine($"ID:   {id}");
                                Console.WriteLine($"Tên:  {name}");
                                Console.WriteLine($"Đơn giá: {price} VNĐ");
                                Console.WriteLine("───────────────────────────────");

                                Console.WriteLine("Nhập số lượng:");
                                int quantity = Convert.ToInt32(Console.ReadLine());

                                int totalPrice = price * quantity;
                                Console.WriteLine();
                                Console.WriteLine("───────────────────────────────");
                                Console.WriteLine("Thông tin thanh toán:");
                                Console.WriteLine("───────────────────────────────");
                                Console.WriteLine($"Tên sản phẩm:   {name}");
                                Console.WriteLine($"Số lượng:   {quantity}");
                                Console.WriteLine($"Tổng tiền: {totalPrice} VNĐ");
                                Console.WriteLine("───────────────────────────────");

                                // Ghi thông tin vào file QL_DoanhThu.txt
                                using (StreamWriter writer = new StreamWriter(receiptPath, true))
                                {
                                    writer.Write(id + ",");
                                    writer.Write(name + ",");
                                    writer.Write(quantity + ",");
                                    writer.Write(totalPrice + ",");
                                    writer.WriteLine(DateTime.Now);
                                }
                                break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Lỗi định dạng giá sản phẩm.");
                        }
                    }
                }

                if (!isFound)
                {
                    Console.WriteLine("Không tìm thấy sản phẩm phù hợp.");
                }
            }
            else
            {
                Console.WriteLine("File menu sản phẩm không tồn tại.");
            }

            Console.WriteLine("\nNhấn phím bất kỳ để trở về");
            Console.ReadKey();
        }
    }
}
