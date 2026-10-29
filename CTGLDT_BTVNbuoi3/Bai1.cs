using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace CTGLDT_BTVNbuoi3
{
    internal class Bai1
    {
        static void Main1()
        {
            for (int i = 1; i <= 8; i++)
            {
                Console.Write("Nhap ca " + i + ": ");
                string s = Console.ReadLine();
                ktngoac(s);
            }
            // 1. SINH DỮ LIỆU TỰ ĐỘNG
            // Ca 9: Tạo 500.000 dấu ngoặc mở, rồi cộng nối với 500.000 dấu ngoặc đóng
            string nuaDau = new string('(', 500000);
            string nuaSau = new string(')', 500000);
            string input9 = nuaDau + nuaSau;
            // Ca 10: Tạo 1.000.000 dấu ngoặc mở
            string input10 = new string('(', 1000000);
            // Khởi tạo đồng hồ bấm giờ
            Stopwatch dongHo = new Stopwatch();
            // 2. CHẠY THỬ CA 9
            Console.WriteLine("--- Kiem thu Ca 9 ---");
            dongHo.Start(); // Bấm nút bắt đầu tính giờ
            ktngoac(input9); // Đưa chuỗi 1 triệu ký tự vào hàm
            Console.WriteLine("Thoi gian chay: " + dongHo.ElapsedMilliseconds + " ms");
            // 3. CHẠY THỬ CA 10
            Console.WriteLine("--- Kiem thu Ca 10 ---");
            dongHo.Restart(); // Reset đồng hồ về 0 và tự động chạy lại luôn
            ktngoac(input10);
            Console.WriteLine("Thoi gian chay: " + dongHo.ElapsedMilliseconds + " ms");
        }
        static void ktngoac(string s)
        {
            // Khởi tạo Stack 
            Stack<(char ch, int pos)> st = new Stack<(char ch, int pos)>();
            // Xét từng ký tự trong chuỗi.
            for (int i = 0; i < s.Length; i++)
            {
                char c = s[i];
                // Đưa ngoặc mở vào Stack để chờ tìm ngoặc đóng tương ứng
                if (c == '(' || c == '[' || c == '{')
                {
                    st.Push((c, i));
                }
                else if (c == ')' || c == ']' || c == '}')
                {
                    // Gặp ngoặc đóng khi Stack rỗng: không có ngoặc mở nào để ghép, lỗi tại i
                    if (st.Count == 0)
                    {
                        Console.WriteLine("SAI tai vi tri " + i);
                        return;
                    }
                    // Lấy ngoặc mở gần nhất trên đỉnh Stack ra để đối chiếu
                    var top = st.Pop();
                    // Ngoặc đóng không cùng loại với ngoặc mở: sai cấu trúc, lỗi tại i
                    if ((c == ')' && top.ch != '(') ||
                        (c == ']' && top.ch != '[') ||
                        (c == '}' && top.ch != '{'))
                    {
                        Console.WriteLine("SAI tai vi tri " + i);
                        return;
                    }
                }
            }
            // Đã duyệt hết chuỗi mà Stack vẫn còn: có ngoặc mở chưa được đóng
            if (st.Count > 0)
            {
                int viTri = 0;
                // Duyệt Stack từ đỉnh xuống đáy để tìm vị trí ngoặc mở đứng sớm nhất
                foreach (var item in st)
                {
                    viTri = item.pos;
                }
                Console.WriteLine("SAI tai vi tri " + viTri);
                return;
            }
            // Các cặp ngoặc đều khớp và không dư thừa
            Console.WriteLine("HOP LE");
        }
    }
}
