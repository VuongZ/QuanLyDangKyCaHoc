# **HỆ THỐNG QUẢN LÝ ĐĂNG KÝ CA HỌC SINH VIÊN**

## **1. Giới thiệu**

Đây là một dự án nhỏ nhằm xây dựng hệ thống quản lý đăng ký ca học cho sinh viên. Hệ thống được thiết kế để cung cấp một API hiệu quả cho sinh viên đăng ký các ca học, đồng thời hỗ trợ quản lý các thông tin liên quan đến khóa học, giảng viên và thời khóa biểu. Dự án này tập trung vào việc áp dụng các công nghệ hiện đại và kiến trúc phần mềm tiên tiến để đảm bảo tính mở rộng, bảo trì và hiệu suất cao.

## **2. Công nghệ sử dụng**

### **2.1. Backend**

*   **ASP.NET Core 8**: Framework mã nguồn mở, đa nền tảng của Microsoft để xây dựng các ứng dụng web và API hiệu suất cao.
*   **Linq (Language Integrated Query)**: Cung cấp một cú pháp thống nhất để truy vấn dữ liệu từ các nguồn khác nhau trong .NET.
*   **EF Core (Entity Framework Core) - DB First**: Một ORM (Object-Relational Mapper) cho phép làm việc với cơ sở dữ liệu bằng các đối tượng .NET, với cách tiếp cận DB First để tạo các lớp mô hình từ cơ sở dữ liệu hiện có.
*   **SQL Server**: Hệ quản trị cơ sở dữ liệu quan hệ được sử dụng để lưu trữ dữ liệu chính của hệ thống.
*   **Mediator in C#**: Một mẫu thiết kế hành vi giúp giảm sự phụ thuộc trực tiếp giữa các đối tượng bằng cách giới thiệu một đối tượng trung gian (mediator).
*   **Clean Architecture**: Một kiến trúc phần mềm tập trung vào việc tách biệt các mối quan tâm, giúp mã nguồn dễ kiểm thử, bảo trì và mở rộng.
*   **CQRS (Command Query Responsibility Segregation)**: Một mẫu kiến trúc tách biệt các hoạt động đọc (queries) và ghi (commands) dữ liệu, giúp tối ưu hóa hiệu suất và khả năng mở rộng.
*   **RabbitMQ**: Một message broker mã nguồn mở, được sử dụng để xử lý các tác vụ bất đồng bộ và giao tiếp giữa các dịch vụ.
*   **Validator in C#**: Thư viện hoặc cơ chế để xác thực dữ liệu đầu vào, đảm bảo tính toàn vẹn và hợp lệ của dữ liệu.
*   **API GRPC**: Một framework RPC (Remote Procedure Call) hiệu suất cao, đa ngôn ngữ, được sử dụng để giao tiếp giữa các dịch vụ.

## **3. Kiến trúc hệ thống**

Dự án tuân thủ theo **Clean Architecture** và áp dụng mẫu **CQRS** để quản lý luồng dữ liệu và logic nghiệp vụ. Điều này giúp hệ thống có cấu trúc rõ ràng, dễ dàng phát triển, kiểm thử và bảo trì. RabbitMQ được sử dụng để xử lý các sự kiện và tác vụ bất đồng bộ, đảm bảo tính nhất quán và khả năng mở rộng của hệ thống.

## **4. Cài đặt và chạy dự án**

### **4.1. Yêu cầu hệ thống**

*   .NET SDK 8.0 trở lên
*   SQL Server
*   RabbitMQ
*   Postman (để kiểm thử API)

### **4.2. Cài đặt Backend**

1.  Clone repository:
    ```bash
    git clone <URL_REPOSITORY_BACKEND>
    cd <TEN_THU_MUC_BACKEND>
    ```
2.  Cập nhật chuỗi kết nối cơ sở dữ liệu trong `appsettings.json`:
    ```json
    "ConnectionStrings": {
      "DefaultConnection": "Server=<SERVER>;Database=<DATABASE>;User Id=<USER>;Password=<PASSWORD>;"
    }
    ```
3.  Chạy migration và cập nhật cơ sở dữ liệu:
    ```bash
    dotnet ef database update
    ```
4.  Chạy ứng dụng backend:
    ```bash
    dotnet run
    ```

    Sau khi khởi động, backend sẽ lắng nghe tại địa chỉ: `http://localhost:5052`

## **5. Kiểm thử API với Postman**

Sau khi backend đang chạy, sử dụng **Postman** để kiểm thử các endpoint.

### **5.1. Cấu hình Postman**

1. Mở Postman và tạo một **Collection** mới (ví dụ: `Student Schedule API`).
2. Đặt **Base URL** là: `http://localhost:5052`

### **5.2. Cách gửi request**

*   **GET** — Lấy dữ liệu:
    ```
    GET http://localhost:5052/api/<endpoint>
    ```
*   **POST** — Tạo mới dữ liệu (chọn `Body > raw > JSON`):
    ```
    POST http://localhost:5052/api/<endpoint>
    Content-Type: application/json
    ```
*   **PUT** — Cập nhật dữ liệu:
    ```
    PUT http://localhost:5052/api/<endpoint>/{id}
    ```
*   **DELETE** — Xóa dữ liệu:
    ```
    DELETE http://localhost:5052/api/<endpoint>/{id}
    ```

### **5.3. Swagger UI (tùy chọn)**

Nếu dự án đã tích hợp Swagger, bạn có thể truy cập giao diện kiểm thử trực tiếp trên trình duyệt tại:

```
http://localhost:5052/swagger
```

## **6. Đóng góp**

Mọi đóng góp đều được hoan nghênh! Vui lòng tạo một pull request hoặc mở một issue nếu bạn có bất kỳ đề xuất hoặc phát hiện lỗi nào.

## **7. Giấy phép**

Dự án này được cấp phép theo Giấy phép MIT. Xem file `LICENSE` để biết thêm chi tiết.
