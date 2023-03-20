using System;
using System.Collections.Generic;

#nullable disable

namespace Project_PRN211_Nhom5.Models
{
    public partial class SanPham
    {
        public SanPham()
        {
            HoaDons = new HashSet<HoaDon>();
        }

        public int SpId { get; set; }
        public string SpTen { get; set; }
        public int SpSoLuong { get; set; }
        public decimal SpGiaGoc { get; set; }
        public decimal SpGiaBab { get; set; }
        public DateTime SpNgayDat { get; set; }

        public virtual ICollection<HoaDon> HoaDons { get; set; }
    }
}
