using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Text;

namespace CTGLDT_BTVNbuoi3
{
    // Lớp cơ bản đại diện cho một khách hàng
    class KhachHang
    {
        public int Sothutu;
        public long Thoidiemden;
        public long Thoigianphucvu;
    }
    internal class Bai2
    {
        static void Main2()
        {
            // Đọc n và k
             for (int i = 0; i < 5; i++)
             {
                 string[] nk = Console.ReadLine().Split();
                 int n = int.Parse(nk[0]);
                 int k = int.Parse(nk[1]);
                 mophongdv(n, k);
             }
            //int n = 100000;
            //int k = 10;
        }
        static void mophongdv(int n, int k)
        {
            // Tạo Hàng đợi Queue để xếp hàng khách (Vào trước ra trước - FIFO)
            Queue<KhachHang> hangdoi = new Queue<KhachHang>();
            for (int i = 1; i <= n; i++)
            {
                string[] line = Console.ReadLine().Split();
                KhachHang kh = new KhachHang();
                kh.Sothutu = i;
                kh.Thoidiemden = long.Parse(line[0]);
                kh.Thoigianphucvu = long.Parse(line[1]);
                // Khách mới đến thì đưa vào cuối hàng đợi
                hangdoi.Enqueue(kh);
            }
            /* TỰ ĐỘNG SINH 100.000 KHÁCH HÀNG
            Queue<KhachHang> hangDoi = new Queue<KhachHang>();
            for (int i = 1; i <= n; i++)
            {
                KhachHang kh = new KhachHang();
                kh.Sothutu = i;
                kh.Thoidiemden = i - 1; // Khách i đến lúc i - 1
                kh.Thoigianphucvu = 10; // Thời gian phục vụ s = 10

                hangDoi.Enqueue(kh);
            }
               BẤM GIỜ BẮT ĐẦU CHẠY THUẬT TOÁN
            Stopwatch dongHo = new Stopwatch();
            dongHo.Start();*/
            // Mảng lưu thời gian rảnh của k quầy, ban đầu các quầy rảnh ở mốc 0
            long[] thoiGianRanh = new long[k];
            long tongThoiGianCho = 0;
            long choLauNhat = 0;
            long hoanThanhLuc = 0;
            // Vòng lặp lấy khách ra phục vụ
            while (hangdoi.Count > 0)
            {
                int quayTotNhat = 0;
                // Lấy người đứng đầu hàng đợi ra (O(1))
                KhachHang khach = hangdoi.Dequeue();
                // Quét qua k quầy để tìm quầy rảnh sớm nhất
                for (int i = 1; i < k; i++)
                {
                    if (thoiGianRanh[i] < thoiGianRanh[quayTotNhat])
                    {
                        quayTotNhat = i;
                    }
                }
                // Thời gian bắt đầu là lúc quầy rảnh. 
                // Nếu khách đến trễ hơn thì phải đợi khách đến mới bắt đầu.
                long thoiGianBatDau = thoiGianRanh[quayTotNhat];
                if (khach.Thoidiemden > thoiGianBatDau)
                {
                    thoiGianBatDau = khach.Thoidiemden;
                }
                // Tính toán thời gian
                long thoiGianCho = thoiGianBatDau - khach.Thoidiemden;
                long thoiGianXong = thoiGianBatDau + khach.Thoigianphucvu;
                // Cập nhật lại thời gian rảnh của quầy đó
                thoiGianRanh[quayTotNhat] = thoiGianXong;
                // Thống kê
                tongThoiGianCho = tongThoiGianCho + thoiGianCho;
                if (thoiGianCho > choLauNhat)
                    choLauNhat = thoiGianCho;
                if (thoiGianXong > hoanThanhLuc)
                    hoanThanhLuc = thoiGianXong;
                Console.WriteLine("KH " + khach.Sothutu +
                                  ": den " + khach.Thoidiemden +
                                  ", quay " + (quayTotNhat + 1) +
                                  ", bat dau " + thoiGianBatDau +
                                  ", cho " + thoiGianCho +
                                  ", xong " + thoiGianXong);
            }
            // DỪNG ĐỒNG HỒ
            //dongHo.Stop();
            // Tính trung bình và in theo chuẩn InvariantCulture (dấu chấm)
            double trungBinhCho = (double)tongThoiGianCho / n;
            Console.WriteLine("Cho trung binh: " + trungBinhCho.ToString("0.00", CultureInfo.InvariantCulture));
            Console.WriteLine("Cho lau nhat: " + choLauNhat);
            Console.WriteLine("Hoan thanh luc: " + hoanThanhLuc);
            //Console.WriteLine("Thoi gian chay: " + dongHo.Elapsed.TotalMilliseconds + " ms");
        }
    }
}
