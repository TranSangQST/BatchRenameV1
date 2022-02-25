LẬP TRÌNH WINDOWS - 19_3 - ĐỒ ÁN 1 - BATCH RENAME


======================================= Báo cáo ====================================================

1. Thông tin cá nhân
MSSV: 19120347
Họ Tên: Trần Ngọc Sang
Email sinh viên: 19120347@student.hcmus.edu.vn
Email cá nhân: ngocsang30032001@gmail.com


2. Mức độ hoàn thành:
    a. Core requirements
    *  Các phần đã làm được:
        - Nộp động các đối tượng 
        - Chọn tất cả file, folder muối rename
        - Tạo ra danh sách luật chỉnh sửa tên
            + Mỗi luật được thêm vào từ menu
            + Có thể chỉnh sửa tham số
        - Áp dụng đổi thên thêm thứ tự luật được thêm  vào
        - Lưu các luật thêm dưới dạng preset và có thể sử dụng lại


    b. Các luật đã làm:
        - (1) Trim: Có 2 lựa chọn
            + Xóa tất cả khoảng trắng ở đầu cuối
            + Xóa tất cả khoảng trắng
        - (2) Add word:
            + Add prefix: thêm ở đầu 
            + Add suffix: Thêm ở cuối
        - (3) New Case:
            + To Upper: In hoa tất cả
            + To Lower: viết thường tất cả
            + Pascal: chuyển về dạng PascalCase
        - (4) Replace:
            + Thay đổi 1 chuỗi trong tên thành chuỗi khác
    
        => Áp dụng luật được với cả tên file, extension của file (lựa chọn 1 trong 2), folder

    c. Renaming rules        
    * Đã làm được
        - Thay đổi extension (sử dụng (1), (2), (3), (4)) đều được
        - Xóa tất cả khoảng trắng đầu cuối (Áp dụng (1))
        - THay thế "-", "_" thành khoảng trắng; " " thành "."
        (áp dụng (4))
        - Thêm prefix (Áp dụng (2))
        - Thêm suffix (Áp dụng (2))
        - Chuyển thành viết thường và xóa tất cả khoảng trắn
        (kết hợp (1) và (3))
        - Chuyển thành PascalCase
            
    * Chưa làm được
        - Thêm số đếm cuối file
        (Có thể thêm thủ công bằng add prefix)


    d. Improvements:
    * Đã làm được:
    - Kéo thả file vào danh sách
    - Sử dụng regular expressions
    - Cho phép xem preview trước khi đổi tên
    - Hiển thị kết quả/ lỗi của quá trình đổi tên




3. Tự đánh giá
    a. Ưu điểm:
        + Giao diện ổn, dễ sử dụng
        + Thực hiện chỉ thiếu 1 core requirement
        + Làm thêm được 3 improvement
        + Sử dụng Design pattern: Singleton, Factory, prototype
        + Sử dụng Delegate & event
        + Thêm, sửa, xóa các luật thêm vào
        
    b. Nhược điểm:
        + Giao diện đơn giản chứ chưa đẹp
        + Chưa làm được phần add counter

    c. Thời gian thực hiện: 28 tiếng
    e. Điểm tự đánh giá: 9.5/10


4. Hướng dẫn sử dụng:
    - Thêm các file dll của luật vào thư mục Release;
    - Chạy file BatchRename.exe để chạy chương trình

    - Các file dll đã được đã được thêm sẵn vào thư mục 19120347/Dll_Files. Chỉ cần copy vào thư mục Release (Nếu chưa có)

5. Video Demo:
    Youtube:
        https://youtu.be/_NkiUNfxvTo
    Drive: (dự phòng)
        https://drive.google.com/drive/folders/1zw0XQA7wUeO-wimIETWN5j6ly8YoRw94?usp=sharing        


6. Tài liệu tham khảo:

https://github.com/qttq23/BatchRename
https://github.com/DucMinhCao/Batch-Rename



======================================= DEMO ====================================================    

* Sau khi chạy file BatchRename.exe trong thư mục Release
1. chọn các file muốn đổi tên
2. Áp dụng các luật:
        - (1) Trim: Có 2 lựa chọn
            + Xóa tất cả khoảng trắng ở đầu cuối
            + Xóa tất cả khoảng trắng
        - (2) Add word:
            + Add prefix: thêm ở đầu 
            + Add suffix: Thêm ở cuối
        - (3) New Case:
            + To Upper: In hoa tất cả
            + To Lower: viết thường tất cả
            + Pascal: chuyển về dạng PascalCase
        - (4) Replace:
            + Thay đổi 1 chuỗi trong tên thành chuỗi khác

3. Chọn luật áp dụng và bấm Add Method để thêm vào

4. Nhấy phải chọn Edit để hiển thị dialog chỉnh sửa

5. Nhấy phải chọn Remove để xóa.

6. Nhấn preview để xem preview

7. Nhấn Start để bắt đầu

8. Nếu có lỗi sẽ in ra ở status

9. Save preset

10. Save as

11. Clear các luật

12. Clear các file

13. Load lại các luật đã lưu

14. Chọn Extension để đổi extension

15. Kéo thả file vào

16. Folder

17. Chọn folder cha

18. Xem preview

19. Start để đổi tên

"# BatchRenameV1" 
