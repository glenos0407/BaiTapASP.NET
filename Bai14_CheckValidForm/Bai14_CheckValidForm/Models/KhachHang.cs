using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Bai14_CheckValidForm.Models
{
    public class KhachHang
    {
        [Required(ErrorMessage = "Truong Bat Buoc")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Co It Nhat 6 Ki Tu")]
        public string TenDangNhap { get; set; }

        [Required(ErrorMessage = "Truong Bat Buoc")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Co It Nhat 6 Ki Tu")]
        public string MatKhau { get; set; }

        [Required(ErrorMessage = "Truong Bat Buoc")]
        public string HoVaTen { get; set; }


        public string GioiTinh { get; set; }

        [Required(ErrorMessage = "Truong Bat Buoc")]
        [EmailAddress]
        public string Email { get; set; }

        [Required(ErrorMessage = "Truong Bat Buoc")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Truong Bat Buoc")]
        public DateTime NgaySinh { get; set; }
        public string DiaChi { get; set; }
        public string Image { get; set; }
    }
}