namespace BaiKiemTra03_03.Models
{
    public class Contract
    {
        public int ContractId { get; set; }  // Mã hợp đồng
        public string ContractName { get; set; }  // Tên hợp đồng
        public DateTime SigningDate { get; set; }  // Ngày ký kết
        public int CustomerId { get; set; }  // Mã khách hàng (Khóa ngoại)
        public Customer Customer { get; set; }  // Thuộc tính điều hướng đến Khách hàng
        public decimal ContractValue { get; set; }  // Giá trị hợp đồng
    }
}
