using System;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.InputEncoding = System.Text.Encoding.UTF8;

        int choice;

        do
        {
            Console.Clear();
            Console.WriteLine("==============================================");
            Console.WriteLine("             CHƯƠNG TRÌNH BÀI TẬP             ");
            Console.WriteLine("==============================================");
            Console.WriteLine("1. Chạy Bài tập 1 (Calculator - Switch Pattern)");
            Console.WriteLine("2. Chạy Bài tập 2 (Phương trình bậc 2)");
            Console.WriteLine("3. Chạy Bài tập 3 (Số nguyên tố & Fibonacci)");
            Console.WriteLine("0. Thoát chương trình");
            Console.WriteLine("==============================================");
            Console.Write("Nhập lựa chọn của bạn (0-3): ");

            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                choice = -1;
            }

            Console.WriteLine();

            switch (choice)
            {
                case 1:
                    RunBaiTap1();
                    Pause();
                    break;
                case 2:
                    RunBaiTap2();
                    Pause();
                    break;
                case 3:
                    RunBaiTap3();
                    Pause();
                    break;
                case 0:
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ! Vui lòng chọn lại.");
                    Pause();
                    break;
            }

        } while (choice != 0);
    }
    static void Pause()
    {
        Console.WriteLine("\n----------------------------------------------");
        Console.WriteLine("Nhấn phím bất kỳ để quay lại menu chính...");
        Console.ReadKey();
    }

    static void RunBaiTap1()
    {
        Console.WriteLine("=== BÀI TẬP 1: CALCULATOR ===");

        Console.Write("Nhập số thứ nhất (a): ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập số thứ hai (b): ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập phép toán (+, -, *, /, %): ");
        char op = Console.ReadLine()[0];

        string result = (op, b) switch
        {
            ('+', _) => $"{a + b:F2}",
            ('-', _) => $"{a - b:F2}",
            ('*', _) => $"{a * b:F2}",
            ('/', 0) => "Lỗi: Không thể chia cho 0!",
            ('/', _) => $"{a / b:F2}",
            ('%', 0) => "Lỗi: Không thể chia lấy dư cho 0!",
            ('%', _) => $"{a % b:F2}",
            _ => "Lỗi: Phép toán không hợp lệ!"
        };

        Console.WriteLine($"Kết quả: {result}");
    }

    static void RunBaiTap2()
    {
        Console.WriteLine("=== BÀI TẬP 2: GIẢI PHƯƠNG TRÌNH BẬC 2 ===");

        Console.Write("Nhập a: ");
        double a = double.Parse(Console.ReadLine());

        Console.Write("Nhập b: ");
        double b = double.Parse(Console.ReadLine());

        Console.Write("Nhập c: ");
        double c = double.Parse(Console.ReadLine());

        if (a == 0)
        {
            if (b == 0)
            {
                if (c == 0)
                    Console.WriteLine("Phương trình có vô số nghiệm.");
                else
                    Console.WriteLine("Vô nghiệm.");
            }
            else
            {
                double x = -c / b;
                Console.WriteLine($"Nghiệm x = {x:F2}");
            }
        }
        else
        {
            double delta = b * b - 4 * a * c;

            if (delta < 0)
            {
                Console.WriteLine("Vô nghiệm.");
            }
            else if (delta == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine($"Nghiệm kép x = {x:F2}");
            }
            else
            {
                double x1 = (-b + Math.Sqrt(delta)) / (2 * a);
                Console.WriteLine($"x1 = {x1:F2}, x2 = {x2:F2}");
            }
        }
    }

    static void RunBaiTap3()
    {
        Console.WriteLine("=== BÀI TẬP 3: SỐ NGUYÊN TỐ, SỐ HOÀN HẢO & FIBONACCI ===");

        Console.Write("Nhập số nguyên dương N: ");
        int n = int.Parse(Console.ReadLine());

        // Kiểm tra Số Nguyên Tố
        if (IsPrime(n))
            Console.WriteLine($"{n} là Số nguyên tố.");
        else
            Console.WriteLine($"{n} KHÔNG là Số nguyên tố.");

        // Kiểm tra Số Hoàn Hảo
        if (IsPerfectNumber(n))
            Console.WriteLine($"{n} là Số hoàn hảo!");
        else
            Console.WriteLine($"{n} KHÔNG là Số hoàn hảo.");

        // In Dãy Fibonacci
        PrintFibonacci(n);
    }

    static bool IsPrime(int n)
    {
        if (n < 2) return false;
        int i = 2;
        while (i <= Math.Sqrt(n))
        {
            if (n % i == 0) return false;
            i++;
        }
        return true;
    }

    static bool IsPerfectNumber(int n)
    {
        if (n <= 0) return false;
        int sum = 0;
        for (int i = 1; i <= n / 2; i++)
        {
            if (n % i == 0) sum += i;
        }
        return sum == n;
    }

    static void PrintFibonacci(int n)
    {
        Console.Write($"Dãy Fibonacci {n} số: ");
        if (n <= 0) return;

        long a = 0, b = 1;
        for (int i = 0; i < n; i++)
        {
            Console.Write(a + (i < n - 1 ? ", " : ""));
            long temp = a + b;
            a = b;
            b = temp;
        }
        Console.WriteLine();
    }
}