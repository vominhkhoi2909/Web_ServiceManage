# Web_ServiceManage

Mô tả dự án:
- Dự sẽ chia làm 2 phần:
  + Website khách hàng để người dùng có thể lựa chọn đặt các dịch vụ sữa chữa liên quan đến 2 dịch vụ chính là sửa máy lạnh và nệm.
  + Website quản trị để người quản lý có thể cập nhật các thông tin về dịch vụ, đơn hàng, quản lý nhân viên, phân quyền, đánh giá, ...
 
Dự án:
- Nhóm 4 người:
  + Nguyễn Quang Minh (leader): Phụ trách front end của trang quản trị.
  + Nguyễn Hoàng Long: Phụ trách front end của trang người dùng.
  + Võ Minh Khôi: Phụ trách Model, quản lý các API comment, config, contact, job order, job order detail, log, note, notification, option, permission, role, review, slider.
  + Nguyễn Thanh Tú: Phụ trách Model, quản lý các API về tài khoản và identity customer, admin, staff, promotion, service, van.
 
Ngôn ngữ sử dụng:
- C#, HTML, LINQ, CSS, JS.

Công nghệ sử dụng:
- API.
- Bootstrap.
- .NET Core 6.
- SQL Server.
- Entity Framework Core.
- SignalR.
- Azure.
- Jira.

Quản lý csdl:
- Migration kết nối tới SQL Server để khởi tạo DB.

Mô hình:
- MVC.
- Repository Pattern.

Hướng dẫn chạy project:
- Yêu cầu phải cài SQL Server tối thiếu 2007.
- Yêu cầu phải cài Visual Studio tối thiểu 2022.
- Mở Visual -> Bật Package Manage Console -> Gõ lệnh "Update-Database" để khởi tạo DB từ Migration.
- Run project để chạy dự án.

Các tính năng đang hoạt động:
- Khách hàng:
  + Đăng ký.
  + Đăng nhập.
  + Quên mật khẩu.
  + Quản lý profile đơn hàng của tài khoản.
  + Đánh giá.
  + Đặt dịch vụ.
  + Cập nhật lịch hẹn dịch vụ.
  + Gửi mail liên hệ.
  + Nhận các thông báo tình trạng đơn hàng.
- Quản trị:
  + Đăng nhập.
  + Quên mật khẩu.
  + Dashboard.
  + Quản lý tài khoản quản trị.
  + Quản trị tài khoản người dùng.
  + Thêm người dùng sl với excel.
  + Quản lý slider.
  + Quản lý config.
  + Quản lý đơn hàng.
  + Phân công đơn hàng.
  + Cập nhật tình trạng đơn hàng.
  + Quản lý các đánh giá.
  + Quản lý các dịch vụ.
  + Quản lý liên hệ.
  + Quản lý các thông tin về hãng hoặc size của dịch vụ.
  + Doanh số của nhân viên.
  + Note.
  + Nhận các thông báo về tình trạng đơn hàng.

Các tính năng phát triền trong tương lai:
- Phân công VAN.
- Calender lịch trình nhân viên.
- Khuyến mãi.
- Deploy dự án lên host (đã từng deloy lên Azure test).
