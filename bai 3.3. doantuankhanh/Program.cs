using System;

class Program
{
    static void Main()
    {
        Console.Write("Nhập số nguyên dương N: ");
        int n = int.Parse(Console.ReadLine());

        if (IsPrime(n))
            Console.WriteLine($"{n} là Số nguyên tố.");
        else
            Console.WriteLine($"{n} KHÔNG là Số nguyên tố.");

        if (IsPerfectNumber(n))
            Console.WriteLine($"{n} là Số hoàn hảo!");
        else
            Console.WriteLine($"{n} KHÔNG là Số hoàn hảo.");

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
            if (n % i == 0)
            {
                sum += i;
            }
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