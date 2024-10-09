namespace BaiKiemTra03_03.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }  // Mã khách hàng
        public string CustomerName { get; set; }  // Tên khách hàng
        public string Address { get; set; }  // Địa chỉ
        public string PhoneNumber { get; set; }  // Số điện thoại
        public string Email { get; set; }  // Email
        public ICollection<Contract> Contracts { get; set; }  // Quan hệ một-nhiều với hợp đồng
    }
}
