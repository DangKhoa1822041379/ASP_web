using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaiKiemTra02.Models
{
    public class LopHoc
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Không được để trống Lớp Học!")]
        [StringLength(10, ErrorMessage = "{0} phải có độ dài phải từ {2} đến {1} ký tự.", MinimumLength = 8)]
        [Display(Name = "Lớp học")]
        public string TenLopHoc { get; set; }
        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Năm Nhập Học")]
        public DateTime NamNhapHoc { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Không đúng định dạng ngày!")]
        [Display(Name = "Năm Ra Trường")]
        public DateTime NamRaTruong { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Không được để trống")]
        [Display(Name = "Số Lượng Sinh Viên")]

        public int SoLuongSinhVIen { get; set; }
    }
}
