using System;

// 1. Lớp cha Person
public class Person
{
    // Thuộc tính Id sử dụng 'init' để chỉ cho phép gán lúc khởi tạo
    public string Id { get; init; }
    public string FullName { get; set; }
    public int BirthYear { get; set; }

    // Constructor nhận đủ 3 tham số
    public Person(string id, string fullName, int birthYear)
    {
        Id = id;
        FullName = fullName;
        BirthYear = birthYear;
    }

    // Phương thức tính tuổi
    public int GetAge(int currentYear)
    {
        return currentYear - BirthYear;
    }
}

// 2. Lớp con Employee kế thừa từ Person
public class Employee : Person
{
    public decimal BaseSalary { get; set; }

    // Constructor dùng từ khóa 'base' để truyền tham số lên lớp cha Person
    public Employee(string id, string fullName, int birthYear, decimal baseSalary)
        : base(id, fullName, birthYear)
    {
        BaseSalary = baseSalary;
    }

    // Phương thức virtual cho phép lớp con ghi đè
    public virtual decimal CalculateIncome()
    {
        return BaseSalary;
    }
}

// 3. Lớp con Manager kế thừa từ Employee và bị khóa bởi 'sealed'
public sealed class Manager : Employee
{
    public decimal ResponsibilityAllowance { get; set; }

    // Constructor truyền tham số chung lên lớp cha Employee thông qua 'base'
    public Manager(string id, string fullName, int birthYear, decimal baseSalary, decimal allowance)
        : base(id, fullName, birthYear, baseSalary)
    {
        ResponsibilityAllowance = allowance;
    }

    // Ghi đè phương thức tính thu nhập bằng từ khóa 'override'
    public override decimal CalculateIncome() => BaseSalary + ResponsibilityAllowance;
}

/* 
 * GIẢI THÍCH (Yêu cầu kịch bản kiểm thử):
 * Tại sao không thể tạo một lớp mới kế thừa tiếp từ `Manager`?
 * Trả lời: Vì lớp `Manager` đã được khai báo với từ khóa `sealed`. 
 * Trong C#, `sealed` ngăn chặn hoàn toàn việc các lớp khác kế thừa từ nó, 
 * thường dùng để bảo vệ tính toàn vẹn của logic nghiệp vụ (không cho phép 
 * thay đổi cách tính lương hay phụ cấp của Manager ở các lớp dẫn xuất khác).
 */

// 4. Kịch bản kiểm thử
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Giả sử năm hiện tại
        int currentYear = 2026;

        // Khởi tạo đối tượng
        Employee emp = new Employee("NV01", "Nguyễn Văn A", 1998, 12_000_000m);
        Manager mgr = new Manager("QL01", "Trần Thị B", 1985, 20_000_000m, 8_000_000m);

        // In phiếu lương
        Console.WriteLine("=== PHIẾU LƯƠNG NHÂN VIÊN ===");
        Console.WriteLine($"- Tên: {emp.FullName}");
        Console.WriteLine($"- Tuổi: {emp.GetAge(currentYear)}");
        Console.WriteLine($"- Lương cơ bản: {emp.BaseSalary:N0} VNĐ");
        Console.WriteLine($"- Thu nhập thực lĩnh: {emp.CalculateIncome():N0} VNĐ\n");

        Console.WriteLine("=== PHIẾU LƯƠNG QUẢN LÝ ===");
        Console.WriteLine($"- Tên: {mgr.FullName}");
        Console.WriteLine($"- Tuổi: {mgr.GetAge(currentYear)}");
        Console.WriteLine($"- Lương cơ bản: {mgr.BaseSalary:N0} VNĐ");
        // Manager sẽ tự động gọi hàm CalculateIncome() đã được ghi đè (cộng thêm phụ cấp)
        Console.WriteLine($"- Thu nhập thực lĩnh: {mgr.CalculateIncome():N0} VNĐ");
    }
}