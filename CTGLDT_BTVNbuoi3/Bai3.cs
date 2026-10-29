using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace CTGLDT_BTVNbuoi3
{
    class HangDoiVong<T>
    {
        private T[] mang;       // Mảng chứa dữ liệu
        public int succhua;      
        private int front;
        private int rear;
        public int soluong;      
        public HangDoiVong() 
        {
            succhua = 4;
            mang = new T[succhua];
            front = 0;
            rear = -1;
            soluong = 0;
        }
        /* KIỂM TRA VÀ MỞ RỘNG MẢNG:
        Nếu số lượng chạm mức sức chứa, tạo một mảng mới to gấp đôi.
        Tiến hành rút lần lượt từng phần tử từ mảng cũ (theo đúng thứ tự từ front)
        để xếp phẳng phiu lại vào mảng mới bắt đầu từ vị trí 0. */
        public void Enqueue(T giatri) 
        {
            // Nếu đầy thì MỞ RỘNG MẢNG
            if (soluong == succhua)
            {
                int succhuamoi = succhua * 2;
                T[] mangmoi = new T[succhuamoi];
                // Lấy từng phần tử từ mảng cũ chép sang mảng mới bắt đầu từ index 0
                for (int i = 0; i < soluong; i++)
                {
                    mangmoi[i] = mang[(front + i) % succhua];
                }
                mang = mangmoi;
                succhua = succhuamoi;
                front = 0;
                rear = soluong - 1; // Đuôi mảng mới sẽ nằm ở vị trí (số lượng - 1)
            }
            /* THÊM DỮ LIỆU:
        Nhích đuôi (rear) lên 1 bước, áp dụng xoay vòng (modulo) nếu chạm vách cuối mảng.
        Đưa dữ liệu mới vào và tăng số lượng. */
            rear = (rear + 1) % succhua;
            mang[rear] = giatri;
            soluong++;
        }
        /* LẤY DỮ LIỆU:
        Chặn và ném lỗi nếu hàng đợi rỗng. Nếu không rỗng, lấy dữ liệu tại vị trí front, 
        nhích front lên 1 bước (có xoay vòng) và giảm số lượng. */
        public T Dequeue()
        {
            if (soluong == 0)
            {
                throw new InvalidOperationException("Hang doi rong!");
            }
            T giatri = mang[front];
            front = (front + 1) % succhua;
            soluong--;
            return giatri;
        }
        //Xem dữ liệu đầu, chỉ trả về giá trị tại vị trí front mà không làm thay đổi trạng thái hàng đợi. 
        public T Peek()
        {
            if (soluong == 0)
            {
                throw new InvalidOperationException("Hang doi rong!");
            }
            return mang[front];
        }
    }
    internal class Bai3
    {
        static void Main()
        {
            // Ca 1: Kiểm tra ngoại lệ khi lấy dữ liệu từ hàng rỗng 
            Console.WriteLine("=== KIEM THU CA 1 ===");
            try
            {
                HangDoiVong<string> q1 = new HangDoiVong<string>();
                Console.WriteLine("Count: " + q1.soluong + ", Capacity: " + q1.succhua);
                q1.Dequeue();
                q1.Peek();
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Ca 2: Thêm vừa đầy mảng sức chứa 4 
            Console.WriteLine("\n=== KIEM THU CA 2 ===");
            HangDoiVong<string> q2 = new HangDoiVong<string>();
            q2.Enqueue("A"); q2.Enqueue("B"); q2.Enqueue("C"); q2.Enqueue("D");
            Console.WriteLine("Count: " + q2.soluong + ", Capacity: " + q2.succhua);
            Console.WriteLine("Peek: " + q2.Peek());
            // Ca 3: Thêm đầy, rút bớt, rồi thêm tiếp để kích hoạt xoay vòng (chưa mở rộng) 
            Console.WriteLine("\n=== KIEM THU CA 3 ===");
            HangDoiVong<string> q3 = new HangDoiVong<string>();
            q3.Enqueue("A"); q3.Enqueue("B"); q3.Enqueue("C"); q3.Enqueue("D");
            Console.WriteLine("Lay ra: " + q3.Dequeue() + ", " + q3.Dequeue());
            q3.Enqueue("E"); q3.Enqueue("F");
            Console.Write("Lay ra not: ");
            for (int i = 0; i < 4; i++) Console.Write(q3.Dequeue() + " ");
            Console.WriteLine("\nCapacity: " + q3.succhua);
            // Ca 4: Ép mở rộng mảng khi front đang ở mốc 0 
            Console.WriteLine("\n=== KIEM THU CA 4 ===");
            HangDoiVong<int> q4 = new HangDoiVong<int>();
            q4.Enqueue(1); q4.Enqueue(2); q4.Enqueue(3); q4.Enqueue(4); q4.Enqueue(5);
            Console.WriteLine("Capacity: " + q4.succhua);
            Console.Write("Lay ra: ");
            for (int i = 0; i < 5; i++) Console.Write(q4.Dequeue() + " ");
            // Ca 5: Ép mở rộng mảng khi dữ liệu đang bị cuộn (front khác 0) 
            Console.WriteLine("\n\n=== KIEM THU CA 5 ===");
            HangDoiVong<string> q5 = new HangDoiVong<string>();
            q5.Enqueue("A"); q5.Enqueue("B"); q5.Enqueue("C"); q5.Enqueue("D");
            q5.Dequeue(); q5.Dequeue();
            q5.Enqueue("E"); q5.Enqueue("F"); q5.Enqueue("G");
            Console.WriteLine("Capacity: " + q5.succhua);
            Console.Write("Lay ra: ");
            for (int i = 0; i < 5; i++) Console.Write(q5.Dequeue() + " ");
            // Ca 6: Test độ bền với 1 triệu vòng lặp xen kẽ 
            Console.WriteLine("\n\n=== KIEM THU CA 6 ===");
            HangDoiVong<int> q6 = new HangDoiVong<int>();
            for (int i = 0; i < 1000000; i++)
            {
                q6.Enqueue(i);
                q6.Dequeue();
            }
            Console.WriteLine("Capacity cuoi: " + q6.succhua);
            Console.WriteLine("Ca 6 chay thanh cong 1 trieu vong!");
            /*Console.WriteLine("=== KIEM THU CA 7 ===");
            // Tạo hàng đợi trống với sức chứa mặc định ban đầu là 4
            HangDoiVong<int> q7 = new HangDoiVong<int>();
            // Khởi động đồng hồ bấm giờ
            Stopwatch dongHo = new Stopwatch();
            dongHo.Start();
            // 1. Nhét liên tục 100.000 phần tử (Ép mảng phải nhân đôi liên tục nhiều lần)
            for (int i = 0; i < 100000; i++)
            {
                q7.Enqueue(i);
            }
            // 2. Rút cạn 100.000 phần tử ra và kiểm tra ngầm xem thứ tự có chuẩn xác không
            bool dungThuTu = true;
            for (int i = 0; i < 100000; i++)
            {
                int giatri = q7.Dequeue();
                if (giatri != i) // Nếu rút ra mà trật thứ tự xếp hàng ban đầu
                {
                    dungThuTu = false;
                    break;     // Dừng luôn, đánh dấu là code sai
                }
            }
            // Dừng đồng hồ
            dongHo.Stop();
            // 3. In kết quả đối chiếu với bảng mong đợi của giảng viên
            if (dungThuTu)
            {
                Console.WriteLine("Trang thai: Lay ra DUNG thu tu 100%.");
            }
            else
            {
                Console.WriteLine("Trang thai: Lay ra SAI thu tu!");
            }
            Console.WriteLine("Capacity cuoi cung: " + q7.succhua + " (Ket qua mong doi: 131072)");
            Console.WriteLine("Thoi gian chay: " + dongHo.Elapsed.TotalMilliseconds + " ms");*/
        }
    }
}
