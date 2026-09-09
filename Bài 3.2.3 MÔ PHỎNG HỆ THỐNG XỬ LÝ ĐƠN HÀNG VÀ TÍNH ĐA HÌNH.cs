using System;
using System.Collections.Generic;

// 1. Cài đặt Method Overloading (Đa hình lúc biên dịch)
public class DiscountCalculator
{
    // Kịch bản 1: Giảm mặc định 5%
    public decimal ApplyDiscount(decimal totalAmount)
    {
        return totalAmount - (totalAmount * 0.05m);
    }

    // Kịch bản 2: Giảm theo phần trăm tùy biến
    public decimal ApplyDiscount(decimal totalAmount, double percentage)
    {
        // Cần ép kiểu percentage sang decimal để tính toán với m (decimal)
        return totalAmount - (totalAmount * (decimal)(percentage / 100.0));
    }

    // Kịch bản 3: Áp dụng mã giảm tiền mặt nếu đạt điều kiện đơn tối thiểu
    public decimal ApplyDiscount(decimal totalAmount, decimal fixedVoucher, decimal minimumOrder)
    {
        if (totalAmount >= minimumOrder)
        {
            return totalAmount - fixedVoucher;
        }
        return totalAmount; // Không thỏa mãn điều kiện thì giữ nguyên giá
    }
}

// 2. Cài đặt Method Overriding (Đa hình lúc thực thi)
// Lớp cha
public class DeliveryService
{
    public string OrderId { get; set; }
    public double DistanceKm { get; set; }

    public DeliveryService(string orderId, double distanceKm)
    {
        OrderId = orderId;
        DistanceKm = distanceKm;
    }

    // Phương thức đánh dấu virtual để cho phép lớp con ghi đè
    public virtual decimal CalculateShippingFee()
    {
        return (decimal)DistanceKm * 5000m;
    }
}

// Lớp con: Giao siêu tốc
public class ExpressDelivery : DeliveryService
{
    public ExpressDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }

    // Ghi đè bằng override
    public override decimal CalculateShippingFee()
    {
        // Gọi lại logic tính phí cơ bản của lớp cha bằng từ khóa 'base'
        decimal baseFee = base.CalculateShippingFee();
        return (baseFee * 1.5m) + 20_000m;
    }
}

// Lớp con: Giao tiết kiệm
public class EcoDelivery : DeliveryService
{
    public EcoDelivery(string orderId, double distanceKm) : base(orderId, distanceKm) { }

    // Ghi đè bằng override
    public override decimal CalculateShippingFee()
    {
        decimal baseFee = base.CalculateShippingFee();
        if (DistanceKm > 10)
        {
            // Giảm 10% nếu quãng đường lớn hơn 10km
            return baseFee * 0.9m;
        }
        return baseFee;
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Hỗ trợ in tiếng Việt có dấu
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // --- 3. KỊCH BẢN KIỂM THỬ ---

        // Khối 1: Thử nghiệm Method Overloading
        Console.WriteLine("=== 1. KIỂM THỬ METHOD OVERLOADING (TÍNH TOÁN GIẢM GIÁ) ===");
        DiscountCalculator calculator = new DiscountCalculator();
        decimal orderTotal = 1_000_000m; // Đơn hàng 1 triệu VNĐ

        Console.WriteLine($"Tổng giá trị đơn hàng gốc: {orderTotal:N0} VNĐ");
        Console.WriteLine($"- Giảm mặc định (5%): {calculator.ApplyDiscount(orderTotal):N0} VNĐ");
        Console.WriteLine($"- Giảm theo phần trăm (15%): {calculator.ApplyDiscount(orderTotal, 15):N0} VNĐ");
        Console.WriteLine($"- Giảm tiền mặt (Trừ 200k, ĐK đơn >= 500k): {calculator.ApplyDiscount(orderTotal, 200_000m, 500_000m):N0} VNĐ");
        Console.WriteLine();

        // Khối 2: Thử nghiệm Method Overriding & Runtime Polymorphism
        Console.WriteLine("=== 2. KIỂM THỬ METHOD OVERRIDING (TÍNH PHÍ VẬN CHUYỂN) ===");

        // Upcasting: Tạo danh sách kiểu lớp CHÁ nhưng chứa các đối tượng lớp CON
        List<DeliveryService> deliveries = new List<DeliveryService>
        {
            new ExpressDelivery("EXP-001", 15), // Giao hỏa tốc, 15km
            new EcoDelivery("ECO-001", 12),     // Giao tiết kiệm, 12km (>10km, sẽ được giảm 10%)
            new EcoDelivery("ECO-002", 5)       // Giao tiết kiệm, 5km (Không được giảm)
        };

        // Dùng vòng lặp duyệt qua danh sách
        foreach (var delivery in deliveries)
        {
            // Tại thời điểm chạy (Runtime), C# sẽ tự động xác định kiểu thực tế của đối tượng 
            // (Express hay Eco) để gọi phương thức CalculateShippingFee() tương ứng.
            Console.WriteLine($"Mã đơn: {delivery.OrderId} | Quãng đường: {delivery.DistanceKm} km");
            Console.WriteLine($"=> Phí vận chuyển: {delivery.CalculateShippingFee():N0} VNĐ");
            Console.WriteLine("-".PadRight(40, '-'));
        }
    }
}