using System;

// 1. Định nghĩa các Interface (Năng lực Can-Do)
public interface IPayable
{
    bool ProcessPayment(decimal amount);
}

public interface IRefundable
{
    bool ProcessRefund(decimal amount, string reason);
}

// 2. Lớp trừu tượng PaymentGateway (Bản chất cốt lõi Is-A)
public abstract class PaymentGateway
{
    // Sử dụng 'init' để chỉ định gán một lần lúc khởi tạo
    public string TransactionId { get; init; }
    public DateTime CreationDate { get; init; }

    // protected set: Các lớp con có quyền thay đổi trạng thái, bên ngoài chỉ được đọc
    public string Status { get; protected set; }

    protected PaymentGateway(string transactionId)
    {
        TransactionId = transactionId;
        CreationDate = DateTime.Now;
        Status = "Pending";
    }

    // Phương thức trừu tượng bắt buộc lớp con phải tự triển khai chi tiết
    public abstract void ValidateConnection();

    // Phương thức virtual cung cấp logic mặc định, lớp con có thể ghi đè nếu cần
    public virtual void LogTransaction(string message)
    {
        Console.WriteLine($"[Log - {TransactionId}]: {message}");
    }
}

// 3. Lớp cụ thể MomoPayment
public class MomoPayment : PaymentGateway, IPayable, IRefundable
{
    public string PhoneNumber { get; set; }

    // Gọi constructor của lớp cha thông qua 'base'
    public MomoPayment(string transactionId, string phoneNumber) : base(transactionId)
    {
        PhoneNumber = phoneNumber;
    }

    public override void ValidateConnection()
    {
        Console.WriteLine("Đang kiểm tra kết nối đến hệ thống API của MoMo...");
        LogTransaction("Kết nối API thành công.");
    }

    public bool ProcessPayment(decimal amount)
    {
        ValidateConnection();

        // Kiểm tra điều kiện số điện thoại bắt buộc 10 số và số tiền hợp lệ
        if (string.IsNullOrWhiteSpace(PhoneNumber) || PhoneNumber.Length != 10)
        {
            Console.WriteLine("[-] Thanh toán thất bại: Số điện thoại không hợp lệ (yêu cầu định dạng 10 số).");
            return false;
        }

        if (amount <= 0)
        {
            Console.WriteLine("[-] Thanh toán thất bại: Số tiền phải lớn hơn 0.");
            return false;
        }

        Status = "Success";
        LogTransaction($"Thanh toán thành công {amount:N0} VNĐ qua tài khoản {PhoneNumber}.");
        return true;
    }

    public bool ProcessRefund(decimal amount, string reason)
    {
        Status = "Refunded";
        LogTransaction($"Hoàn tiền {amount:N0} VNĐ thành công. Lý do: {reason}");
        return true;
    }
}

// 4. Kịch bản kiểm thử
class Program
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Console.WriteLine("=== 1. KHỞI TẠO GIAO DỊCH MOMO ===");
        MomoPayment momoTx = new MomoPayment("TX-998877", "0912345678");
        Console.WriteLine($"- Mã GD: {momoTx.TransactionId}");
        Console.WriteLine($"- Trạng thái ban đầu: {momoTx.Status}");
        Console.WriteLine($"- Thời gian tạo: {momoTx.CreationDate}\n");

        Console.WriteLine("=== 2. ÉP KIỂU SANG GIAO DIỆN THANH TOÁN (IPayable) ===");
        // Ép kiểu đối tượng sang giao diện IPayable
        IPayable payable = momoTx;
        // Lúc này đối tượng 'payable' chỉ nhìn thấy và gọi được phương thức ProcessPayment
        payable.ProcessPayment(250_000m);
        Console.WriteLine($"- Trạng thái hiện tại: {momoTx.Status}\n");

        Console.WriteLine("=== 3. ÉP KIỂU SANG GIAO DIỆN HOÀN TIỀN (IRefundable) ===");
        // Ép kiểu đối tượng sang giao diện IRefundable
        IRefundable refundable = momoTx;
        // Lúc này đối tượng 'refundable' chỉ nhìn thấy và gọi được phương thức ProcessRefund
        refundable.ProcessRefund(250_000m, "Khách hàng đổi ý, hủy đơn hàng");
        Console.WriteLine($"- Trạng thái cuối cùng: {momoTx.Status}");
    }
}