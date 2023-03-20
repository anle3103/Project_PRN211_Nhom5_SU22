using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211_Nhom5.Models
{
    public partial class HoaDon
    {
        public int OdId { get; set; }
        public int SpId { get; set; }
        public DateTime OdNgayMua { get; set; }
        public int OdSoLuong { get; set; }
        public decimal OdTongTien { get; set; }
        public string OdTenKhachHang { get; set; }
        public string OdDiaChi { get; set; }
        public string OdSoDienThoai { get; set; }
        public string OdEmail { get; set; }

        public virtual SanPham Sp { get; set; }
    }
}
