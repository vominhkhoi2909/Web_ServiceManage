# Web_ServiceManage

Mô tả dự án:
- Dự sẽ chia làm 2 phần:
  + Website khách hàng để người dùng có thể lựa chọn đặt các dịch vụ sữa chữa liên quan đến 2 dịch vụ chính là sửa máy lạnh và nệm.
  + Website quản trị để người quản lý có thể cập nhật các thông tin về dịch vụ, đơn hàng, quản lý nhân viên, phân quyền, đánh giá, ...
 
Dự án:
- Nhóm 4 người:
  + Nguyễn Quang Minh (leader): Phụ trách front end của trang quản trị.
  + Nguyễn Hoàng Long: Phụ trách front end của trang người dùng.
  + Võ Minh Khôi: Phụ trách Model, quản lý các API nhân viên, khách hàng, service, option, order, ...
  + Nguyễn Thanh Tú: Phụ trách Model, quản lý các API về tài khoản và identity.
 
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
