# THÔNG TIN SINH VIÊN

* **Họ và tên:** Nguyễn Gia Bảo Tường
* **Mã số sinh viên:** 31251020414
* **Lớp học phần:** Cấu trúc dữ liệu và giải thuật

---

# MÔ TẢ GIẢI PHÁP, ĐỘ PHỨC TẠP & KIỂM THỬ

### Bài 1: Kiểm tra biểu thức ngoặc hợp lệ
* **Giải pháp:** Sử dụng cấu trúc dữ liệu Ngăn xếp (Stack). Duyệt qua từng ký tự của chuỗi, nếu là ngoặc mở `(`, `[`, `{` thì đẩy (Push) vào Stack. Nếu gặp ngoặc đóng `)`, `]`, `}` thì lấy phần tử trên đỉnh Stack ra (Pop) để đối chiếu xem có khớp đúng cặp hay không. Nếu duyệt hết chuỗi mà Stack rỗng thì biểu thức hợp lệ.
* **Độ phức tạp:** Thời gian $O(n)$ vì duyệt qua chuỗi độ dài $n$ đúng một lần. Không gian $O(n)$ trong trường hợp xấu nhất phải đẩy toàn bộ ký tự vào Stack.
* **Kiểm thử:** Thử nghiệm thành công với các chuỗi đúng (VD: `{[()]}`) và các trường hợp sai lệch: sai cặp `([)]`, thừa ngoặc mở `((()`, hoặc thừa ngoặc đóng `())`.

### Bài 2: Thống kê thời gian đợi của khách hàng
* **Giải pháp:** Kết hợp Hàng đợi (Queue) để xử lý khách hàng theo nguyên tắc "đến trước phục vụ trước" (FIFO) và Ngăn xếp (Stack) để lưu trữ lịch sử hoặc xử lý các sự kiện đặc thù. Thời gian chờ được tính bằng hiệu số giữa thời điểm bắt đầu được phục vụ và thời điểm khách hàng đến xếp hàng.
* **Độ phức tạp:** Thời gian $O(n)$ để duyệt và xử lý luồng sự kiện của $n$ khách hàng. Không gian $O(n)$ để lưu trữ dữ liệu tập khách hàng vào trong Queue và Stack.
* **Kiểm thử:** Chạy mô phỏng với danh sách khách hàng có thời điểm đến và thời lượng phục vụ khác nhau. Kết quả in ra thống kê chính xác tổng thời gian chờ và thời gian chờ trung bình.

### Bài 3: Hàng đợi vòng tự mở rộng (Generic Circular Queue)
* **Giải pháp:** Cài đặt bằng mảng tổng quát `T[]`. Sử dụng chỉ số `front` và `rear` áp dụng công thức xoay vòng `(index + 1) % Capacity` để tái sử dụng không gian. Khi biến đếm `count` chạm trần sức chứa, tiến hành nhân đôi mảng và dùng vòng lặp `for` nắn thẳng lại dữ liệu (bắt đầu từ vị trí `front`) đưa sang mảng mới. 
* **Độ phức tạp:** Không gian $O(n)$. Thời gian `Dequeue` luôn là $O(1)$. Thời gian `Enqueue` trung bình là $O(1)$ khấu hao (Amortized), dù có tốn $O(n)$ ở các nhịp mở rộng mảng.
* **Kiểm thử:** Đã duyệt qua 7 ca kiểm thử chặt chẽ. Ở ca số 7, đẩy 100.000 phần tử liên tục: mảng tự động nhân đôi sức chứa lên mốc 131.072 mà không bị tràn RAM. Thời gian thực thi chớp nhoáng (đo bằng Stopwatch), thứ tự xuất ra chuẩn xác 100%.

### Bài 4: Cấu trúc Stack lấy phần tử nhỏ nhất trong O(1) (MinStack)
* **Giải pháp:** Sử dụng 2 Stack song song. `stackchinh` lưu mọi dữ liệu đầu vào. `stackphu` đóng vai trò lưu "lịch sử" phần tử nhỏ nhất. Khi `Push`, nếu số mới $\le$ đỉnh `stackphu`, số đó được đẩy vào cả 2 stack để lưu lại các giá trị trùng nhau. Khi `Pop`, nếu giá trị lấy ra bằng với đỉnh của `stackphu`, bốc luôn đỉnh `stackphu` ra để lùi mức Min về lịch sử trước đó.
* **Độ phức tạp:** Thời gian cho mọi thao tác (`Push`, `Pop`, `GetMin`) đều được tối ưu xuống $O(1)$ tuyệt đối. Độ phức tạp không gian tăng lên thành $O(n)$ do phải phân bổ thêm bộ nhớ cho `stackphu`.
* **Kiểm thử:** Thực hiện chuỗi lệnh `Push 5, 3, 7, 3, 8` cho kết quả GetMin lần lượt `5, 3, 3, 3, 3`. Lặp 4 lệnh `Pop` cho kết quả GetMin lùi về `3, 3, 3, 5`. Ném ngoại lệ `InvalidOperationException` chuẩn xác khi cố gắng thao tác trên Stack rỗng.

---

# CÔNG CỤ AI ĐÃ SỬ DỤNG
* **Gemini pro, Claude:** 
  * Hỗ trợ làm rõ cơ chế xoay vòng (`(front + i) % capacity`) và phương pháp "trải phẳng" mảng khi tự động mở rộng sức chứa (Bài 3).
  * Cung cấp ý tưởng luồng thuật toán 2 Stack và cách xử lý lưu phần tử trùng lặp cho hàm GetMin $O(1)$ (Bài 4).
  * Viết mã tích hợp thư viện Stopwatch để tự động đo lường hiệu năng và kiểm chứng thứ tự xuất dữ liệu ở ca kiểm thử cường độ cao (100.000 phần tử).
