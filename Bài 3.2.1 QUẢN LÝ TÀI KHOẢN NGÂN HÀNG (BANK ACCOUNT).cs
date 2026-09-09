using System;

public class BankAccount
{
    // 1. Trường dữ liệu tĩnh (Static field) dùng chung cho tất cả các đối tượng
    private static long _nextAccountNumber = 1000000001;

    // 2. Thuộc tính (Properties)
    // AccountNumber: Chỉ cho phép gán một lần duy nhất lúc khởi tạo (init)
    public long AccountNumber { get; init; }
    private string _accountHolder;
    public string AccountHolder
    {
        get => _accountHolder;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                throw new ArgumentException("Tên chủ tài khoản không hợp lệ (không được để trống hoặc null).");
            }
            _accountHolder = value;
        }
    }

    // Balance: Đóng gói với private backing field, chỉ cho phép đọc từ bên ngoài
    private decimal _balance;
    public decimal Balance
    {
        get => _balance;
        private set => _balance = value;
    }

    // 3. Constructor
    public BankAccount(string accountHolder, decimal initialBalance)
    {
        // Kiểm tra số dư ban đầu
        if (initialBalance < 50_000m)
        {
            throw new ArgumentException("Số dư ban đầu không được nhỏ hơn 50,000 VNĐ.");
        }

        // Gán dữ liệu (sẽ kích hoạt validation ở property AccountHolder)
        AccountHolder = accountHolder;
        _balance = initialBalance;

        // Tự động sinh AccountNumber và tăng biến đếm tĩnh
        AccountNumber = _nextAccountNumber;
        _nextAccountNumber++;
    }

    // 4. Các phương thức (Methods)
    public void Deposit(decimal amount)
    {
        if (amount > 0)
        {
            _balance += amount;
            Console.WriteLine($"[+] Nạp thành công {amount:N0} VNĐ vào tài khoản {AccountNumber}.");
        }
        else
        {
            Console.WriteLine("[-] Số tiền nạp phải lớn hơn 0.");
        }
    }

    public bool Withdraw(decimal amount)
    {
        if (amount <= 0)
        {
            Console.WriteLine("[-] Số tiền rút phải lớn hơn 0.");
            return false;
        }

        // Kiểm tra hạn mức duy trì tối thiểu 50,000 VNĐ
        if (_balance - amount < 50_000m)
        {
            Console.WriteLine($"[-] Rút tiền thất bại. Số dư sau khi rút không được dưới 50,000 VNĐ (Số dư hiện tại: {_balance:N0} VNĐ).");
            return false;
        }

        _balance -= amount;
        Console.WriteLine($"[-] Rút thành công {amount:N0} VNĐ từ tài khoản {AccountNumber}.");
        return true;
    }

    public void DisplayInfo()
    {
        Console.WriteLine("\n--- THÔNG TIN TÀI KHOẢN ---");
        Console.WriteLine($"- Số tài khoản: {AccountNumber}");
        Console.WriteLine($"- Chủ tài khoản: {AccountHolder}");
        Console.WriteLine($"- Số dư hiện tại: {Balance:N0} VNĐ");
        Console.WriteLine("---------------------------\n");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Hỗ trợ hiển thị tiếng Việt có dấu trên Console
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        try
        {
            // 1. Khởi tạo 2 tài khoản hợp lệ
            Console.WriteLine("=> KHỞI TẠO TÀI KHOẢN:");
            BankAccount acc1 = new BankAccount("Nguyễn Văn A", 100000m);
            BankAccount acc2 = new BankAccount("Trần Thị B", 500000m);

            acc1.DisplayInfo();
            acc2.DisplayInfo();

            // 2. Thử nghiệm các thao tác nghiệp vụ
            Console.WriteLine("=> THỰC HIỆN GIAO DỊCH:");

            // Nạp tiền hợp lệ
            acc1.Deposit(50000m);

            // Rút tiền hợp lệ
            acc2.Withdraw(150000m);

            // Rút tiền vi phạm hạn mức (Tài khoản 1 hiện có 150k, nếu rút 120k thì còn 30k < 50k -> Lỗi)
            acc1.Withdraw(120000m);

            // In lại thông tin sau giao dịch
            acc1.DisplayInfo();

            // 3. Cố tình khởi tạo tài khoản không hợp lệ để kiểm tra try-catch
            Console.WriteLine("=> KIỂM TRA BẮT LỖI KHỞI TẠO:");
            BankAccount acc3 = new BankAccount("Lê Văn C", 30000m); // Số dư < 50k
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"\n[!] BẮT ĐƯỢC NGOẠI LỆ: {ex.Message}");
        }
    }
}