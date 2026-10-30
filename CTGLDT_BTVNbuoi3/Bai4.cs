using System;
using System.Collections.Generic;
using System.Text;

namespace CTGLDT_BTVNbuoi3
{
    class Bai4
    {
        private Stack<int> stackchinh = new Stack<int>();
        private Stack<int> stackphu = new Stack<int>();
        public void Push(int giatri)
        {
            stackchinh.Push(giatri); // Luôn nhét vào stack chính

            // Nếu stack phụ rỗng, hoặc giá trị mới NHỎ HƠN HOẶC BẰNG min hiện tại thì nhét vào stack phụ
            if (stackphu.Count == 0 || giatri <= stackphu.Peek())
            {
                stackphu.Push(giatri);
            }
        }
        public void Pop()
        {
            if (stackchinh.Count == 0)
            {
                throw new InvalidOperationException("InvalidOperationException: Stack dang rong!");
            }
            int giatrirut = stackchinh.Pop(); // Rút từ stack chính ra
            // Nếu số bị rút trùng đúng với số nhỏ nhất hiện tại, thì stack phụ cũng phải rút ra để lùi lịch sử
            if (giatrirut == stackphu.Peek())
            {
                stackphu.Pop();
            }
        }
        public int GetMin()
        {
            if (stackphu.Count == 0)
            {
                throw new InvalidOperationException("InvalidOperationException: Stack dang rong!");
            }
            return stackphu.Peek(); // Chỉ nhìn trộm đỉnh stack phụ, không rút ra
        }
        static void Main()
        {
            Bai4 b4 = new Bai4();
            Console.WriteLine("--- GIAI DOAN PUSH ---");
            int[] dauvao = { 5, 3, 7, 3, 8 };
            foreach (int x in dauvao)
            {
                b4.Push(x);
                Console.WriteLine("Push " + x + " -> GetMin hien tai: " + b4.GetMin());
            }
            Console.WriteLine("\n--- GIAI DOAN POP ---");
            for (int i = 1; i <= 4; i++)
            {
                b4.Pop();
                Console.WriteLine("Pop lan " + i + " -> GetMin hien tai: " + b4.GetMin());
            }
            Console.WriteLine("\n--- CA KIEM THU NGOAI LE ---");
            b4.Pop(); // Pop nốt số 5 cuối cùng để stack rỗng
            try { b4.GetMin(); }
            catch (InvalidOperationException ex) { Console.WriteLine("Loi GetMin: " + ex.Message); }
            try { b4.Pop(); }
            catch (InvalidOperationException ex) { Console.WriteLine("Loi Pop: " + ex.Message); }
        }
    }
}
