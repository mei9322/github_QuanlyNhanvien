using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace qlquancafe
{
    class Program
    {
        static void MainProgram()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.CursorVisible = false; // Ẩn con trỏ chuột

            TRANGCHU.Main();

            // Thêm các công việc khác vào đây nếu cần

            Console.WriteLine("Nhấn phím bất kỳ để thoát...");
            Console.ReadKey();
        }
    }
}
