using System;
using System.Collections.Generic;
using System.Text;

namespace CTGLDT_BTVNbuoi3
{
    internal class Bai1
    {
        static void Main()
        {
            string s = Console.ReadLine();
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
