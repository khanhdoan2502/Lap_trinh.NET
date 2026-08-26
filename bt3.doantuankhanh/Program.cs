using System;

class Program
{
    static void Main()
    {
        // Nhập dữ liệu
        Console.Write("Nhap so thu nhat (a): ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhap so thu hai (b): ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhap phep toan (+, -, *, /, %): ");
        char op = Console.ReadLine()[0];

        // Áp dụng switch expression kết hợp pattern matching
        string result = (op, b) switch
        {
            ('+', _) => $"{a + b:F2}",
            ('-', _) => $"{a - b:F2}",
            ('*', _) => $"{a * b:F2}",
            ('/', 0) => "Loi: Khong the chia cho 0!",
            ('/', _) => $"{a / b:F2}",
            ('%', 0) => "Loi: Khong the chia lay du cho 0!",
            ('%', _) => $"{a % b:F2}",
            _ => "Loi: Phep toan khong hop le!"
        };

        // In kết quả
        Console.WriteLine($"Ket qua: {result}");
    }
}