using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Project_PRN211_Nhom5.Models;

namespace Project_PRN211_Nhom5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }


        //Nhà Kho
        private void Form1_Load(object sender, EventArgs e)
        {
            btnDat.Enabled = false;
            LoadData();
            LoadData1();
        }

        Project_PRNContext context = new Project_PRNContext();

        private void LoadData1()
        {
            var data = (from item in context.HoaDons join item1 in context.SanPhams on item.SpId equals item1.SpId
                        select new { item.OdId, item1.SpTen, item.OdNgayMua, item.OdSoLuong, item.OdTenKhachHang, item.OdDiaChi, item.OdSoDienThoai, item.OdEmail, item.OdTongTien }).ToList();
            dgvHoaDon.DataSource = data;

            txtIDHoaDon.DataBindings.Clear();
            txtIDHoaDon.DataBindings.Add("Text", data, "OdId", true);

            txtTenSanPham3.DataBindings.Clear();
            txtTenSanPham3.DataBindings.Add("Text", data, "SpTen", true);

            txtTenKhachHang3.DataBindings.Clear();
            txtTenKhachHang3.DataBindings.Add("Text", data, "OdTenKhachHang", true);

            txtDiaChi3.DataBindings.Clear();
            txtDiaChi3.DataBindings.Add("Text", data, "OdDiaChi", true);

            dtpNgayMua.DataBindings.Clear();
            dtpNgayMua.DataBindings.Add("Text", data, "OdNgayMua", true);

            txtSoDienThoai3.DataBindings.Clear();
            txtSoDienThoai3.DataBindings.Add("Text", data, "OdSoDienThoai", true);

            txtSoLuong3.DataBindings.Clear();
            txtSoLuong3.DataBindings.Add("Text", data, "OdSoLuong", true);

            txtEmail3.DataBindings.Clear();
            txtEmail3.DataBindings.Add("Text", data, "OdEmail", true);

            txtTongTien3.DataBindings.Clear();
            txtTongTien3.DataBindings.Add("Text", data, "OdTongTien", true);

        }

        private void LoadData()
        {
            var data = (from item in context.SanPhams
                        select new { item.SpId, item.SpTen, item.SpSoLuong, item.SpGiaGoc, item.SpGiaBab, item.SpNgayDat }).ToList();
            dgvKho.DataSource = data;

            txtID.DataBindings.Clear();
            txtID.DataBindings.Add("text", data, "SpId");

            txtTenSanPham.DataBindings.Clear();
            txtTenSanPham.DataBindings.Add("text", data, "SpTen");

            txtSoLuong.DataBindings.Clear();
            txtSoLuong.DataBindings.Add("text", data, "SpSoLuong");

            txtGiaGoc.DataBindings.Clear();
            txtGiaGoc.DataBindings.Add("text", data, "SpGiaGoc");

            txtGiaBan.DataBindings.Clear();
            txtGiaBan.DataBindings.Add("text", data, "SpGiaBab");

            txtNgayNhap.DataBindings.Clear();
            txtNgayNhap.DataBindings.Add("text", data, "SpNgayDat");

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                SanPham sp = new SanPham { SpTen = txtTenSanPham.Text };
                sp.SpGiaGoc = decimal.Parse(txtGiaGoc.Text);
                sp.SpGiaBab = decimal.Parse(txtGiaBan.Text);
                sp.SpSoLuong = int.Parse(txtSoLuong.Text);
                sp.SpNgayDat = DateTime.Parse(txtNgayNhap.Text);
                if (decimal.Parse(txtGiaGoc.Text) >= decimal.Parse(txtGiaBan.Text))
                {
                    MessageBox.Show("Giá gốc phải nhỏ hơn giá bán");
                    return;
                }
                if (txtID.Text.Equals("") || txtTenSanPham.Text.Equals("") || txtGiaGoc.Text.Equals("") || txtGiaBan.Text.Equals("")
                    || txtSoLuong.Text.Equals("") || txtNgayNhap.Text.Equals(""))
                {
                    MessageBox.Show("Không được để trống dữ liệu");
                    return;
                }
                if (decimal.Parse(txtGiaGoc.Text) <= 0 || int.Parse(txtSoLuong.Text) <= 0)
                {
                    MessageBox.Show("Giá trị phải lớn hơn 0");
                    return;
                }
                for(int i = 0; i < dgvKho.Rows.Count; i++)
                {
                    if (txtTenSanPham.Text.Equals(dgvKho[1, i].Value))
                    {
                        MessageBox.Show("Sản phẩm này có rồi");
                        return;
                    }
                }
                
                context.SanPhams.Add(sp);
                int count = context.SaveChanges();
                if (count > 0)
                {
                    MessageBox.Show("Thêm sản phẩm thành công.");
                    LoadData();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm sản phẩm thất bại: " + ex.Message);
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var sp = context.SanPhams.SingleOrDefault(item => item.SpId == int.Parse(txtID.Text));

                if (sp != null)
                {
                    sp.SpTen = txtTenSanPham.Text;
                    sp.SpGiaGoc = decimal.Parse(txtGiaGoc.Text);
                    sp.SpGiaBab = decimal.Parse(txtGiaBan.Text);
                    sp.SpSoLuong = int.Parse(txtSoLuong.Text);
                    sp.SpNgayDat = DateTime.Parse(txtNgayNhap.Text);
                    if (decimal.Parse(txtGiaGoc.Text) >= decimal.Parse(txtGiaBan.Text))
                    {
                        MessageBox.Show("Giá gốc phải nhỏ hơn giá bán");
                        return;
                    }
                    if (txtID.Text.Equals("") || txtTenSanPham.Text.Equals("") || txtGiaGoc.Text.Equals("") || txtGiaBan.Text.Equals("")
                    || txtSoLuong.Text.Equals("") || txtNgayNhap.Text.Equals(""))
                    {
                        MessageBox.Show("Không để trống dữ liệu");
                        return;
                    }
                    if (decimal.Parse(txtGiaGoc.Text) <= 0 || int.Parse(txtSoLuong.Text) <= 0)
                    {
                        MessageBox.Show("Giá trị phải lớn hơn 0");
                        return;
                    }

                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Cập nhật sản phẩm thành công !");
                        LoadData();
                    }


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Cập nhật sản phẩm thất bại: " + ex.Message);
            }


        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var sp = context.SanPhams.SingleOrDefault(item => item.SpId == int.Parse(txtID.Text));

                //xóa dữ liệu từ context
                if (sp != null)
                {
                    context.SanPhams.Remove(sp);
                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Xóa sản phẩm thành công.");
                        LoadData();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa sản phẩm thất bại: " + ex.Message);
            }
        }

        //======================================================================================
        //Quầy Bán
        private void btnKiemTra1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvKho.Rows.Count; i++)
            {
                try
                {
                    int ktraSoLuong = Convert.ToInt32(dgvKho[2, i].Value) - Convert.ToInt32(txtSoLuong1.Text);
                    if (txtTenSanPham1.Text == dgvKho[1, i].Value.ToString())
                    {
                        if (ktraSoLuong >= 0)
                        {
                            btnDat.Enabled = true;
                            MessageBox.Show("Sản phẩm hợp lệ");
                            break;
                        }
                        if (Convert.ToInt32(dgvKho[2,i].Value) == 0)
                        {
                            MessageBox.Show("Sản phẩm đã hết hàng");
                            break;
                        }
                        else
                        {
                            MessageBox.Show("Sản phẩm " + Convert.ToString(dgvKho[1, i].Value) + " còn " + Convert.ToString(dgvKho[2, i].Value + " sản phẩm"));
                            break;
                        }
                    }
                    btnDat.Enabled = true;
                }
                catch
                {
                    MessageBox.Show("Dữ liệu nhập sai");
                    break;
                }
            }
        }

        private void btnDat_Click(object sender, EventArgs e)
        {
            if (txtTenKhachHang1.Text != "" && txtDiachi1.Text != "" && txtSoDienThoai1.Text != "" && dtpNgayMua1.Text != "")
            {
                for (int i = 0; i < dgvKho.Rows.Count; i++)
                {
                    try
                    {
                        int ktraSoLuong = Convert.ToInt32(dgvKho[2, i].Value) - Convert.ToInt32(txtSoLuong1.Text);
                        decimal gia = Convert.ToDecimal(dgvKho[4, i].Value);
                        decimal tong = gia * Convert.ToInt32(txtSoLuong1.Text);
                        if (txtTenSanPham1.Text == dgvKho[1, i].Value.ToString())
                        {
                            if (ktraSoLuong >= 0)
                            {
                                if (txtSoDienThoai1.Text.Length != 10)
                                {
                                    MessageBox.Show("Số điện thoại không hợp lệ");
                                    break;
                                }
                                else
                                {
                                    try
                                    {
                                        HoaDon hd = hd = new HoaDon()
                                        {
                                            SpId = Convert.ToInt32(dgvKho[0, i].Value),
                                            OdNgayMua = DateTime.Parse(dtpNgayMua1.Text),
                                            OdSoLuong = Int32.Parse(txtSoLuong1.Text),
                                            OdTongTien = tong,
                                            OdTenKhachHang = txtTenKhachHang1.Text,
                                            OdDiaChi = txtDiachi1.Text,
                                            OdSoDienThoai = txtSoDienThoai1.Text,
                                            OdEmail = txtEmail1.Text

                                        };
                                        context.HoaDons.Add(hd);
                                        int count = context.SaveChanges();
                                        if (count > 0)
                                        {
                                            MessageBox.Show("Đặt hàng thành công");
                                            dgvQuayBan.Rows.Add(txtTenKhachHang1.Text, txtTenSanPham1.Text, txtSoLuong1.Text, txtDiachi1.Text, txtEmail1.Text, txtSoDienThoai1.Text, dtpNgayMua1.Text, tong);
                                            var pro = context.SanPhams.SingleOrDefault(item => item.SpId == Convert.ToInt32(dgvKho[0, i].Value));
                                            if (pro != null)
                                            {
                                                pro.SpSoLuong = ktraSoLuong;
                                                int count1 = context.SaveChanges();
                                                if (count1 > 0)
                                                {
                                                    LoadData();
                                                    LoadData1();
                                                }
                                            }

                                            break;
                                        }
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Đặt hàng không thành công");
                                    }
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Nhập sai dữ liệu" + i);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng kiểm tra lại thông tin");
            }
        }

        //======================================================================================
        //Thống Kê
        private void btnThongKe_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                if (txtTenSanPham2.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập tên sản phẩm");
                }
                else
                {
                    dgvThongKe.Rows.Clear();
                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        if (txtTenSanPham2.Text.Equals(dgvHoaDon[1, i].Value.ToString()))
                        {
                            int soLuong = Convert.ToInt32(dgvHoaDon[3, i].Value.ToString());
                            for(int j = 0; j < dgvKho.Rows.Count; j++)
                            {
                                if (txtTenSanPham2.Text.Equals(dgvKho[1, j].Value.ToString()))
                                {
                                    decimal tien1 = Convert.ToDecimal(dgvKho[4, j].Value.ToString())*soLuong;
                                    decimal tien2 = Convert.ToDecimal(dgvKho[3, j].Value.ToString())*soLuong;
                                    decimal tienlai = tien1 - tien2;
                                    dgvThongKe.Rows.Add(dgvHoaDon[1, i].Value, dgvHoaDon[4, i].Value, dgvHoaDon[3, i].Value, tienlai, dgvHoaDon[2, i].FormattedValue.ToString());
                                }
                            }
                        }
                            
                    }
                }
            }
            else if (radioButton2.Checked)
            {
                if (dtpNgayBan2.Text == "")
                {
                    MessageBox.Show("Vui lòng nhập dữ liệu ngày/tháng/năm");
                }
                else
                {
                    dgvThongKe.Rows.Clear();
                    for (int i = 0; i < dgvHoaDon.Rows.Count; i++)
                    {
                        if (dtpNgayBan2.Text == dgvHoaDon[2, i].FormattedValue.ToString())
                        {
                            int soLuong = Convert.ToInt32(dgvHoaDon[3, i].Value.ToString());
                            for (int j = 0; j < dgvKho.Rows.Count; j++)
                            {
                                if (dgvHoaDon[1,i].Value.ToString() == dgvKho[1, j].Value.ToString())
                                {
                                    decimal tien1 = Convert.ToDecimal(dgvKho[4, j].Value.ToString()) * soLuong;
                                    decimal tien2 = Convert.ToDecimal(dgvKho[3, j].Value.ToString()) * soLuong;
                                    decimal tienlai = tien1 - tien2;
                                    dgvThongKe.Rows.Add(dgvHoaDon[1, i].Value, dgvHoaDon[4, i].Value, dgvHoaDon[3, i].Value, tienlai, dgvHoaDon[2, i].FormattedValue.ToString());
                                }
                            } 
                        }
                    }
                    
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại bạn muốn thống kê");
            }
        }
       
        private void dtpNgayMua1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void tabQuanLy_Click(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        //======================================================================================
        //Hóa Đơn

        private void btnXoaHoaDon_Click(object sender, EventArgs e)
        {
            try
            {
                var hd = context.HoaDons.SingleOrDefault(item => item.OdId == int.Parse(txtIDHoaDon.Text));
                if(hd != null)
                {
                    context.HoaDons.Remove(hd);
                    int count = context.SaveChanges();
                    if(count > 0)
                    {
                        MessageBox.Show("Xóa thành công");
                        LoadData1();
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Xóa không thành công");
            }
        }

        private void btnChinhSua_Click(object sender, EventArgs e)
        {
            try
            {
                var od = context.HoaDons.SingleOrDefault(item => item.OdId == int.Parse(txtIDHoaDon.Text));
                if (od != null)
                {
                    od.SpId = int.Parse(txtIDHoaDon.Text);
                    od.OdTenKhachHang = txtTenKhachHang3.Text;
                    od.OdDiaChi = txtDiaChi3.Text;
                    od.OdNgayMua = DateTime.Parse(dtpNgayMua.Text);
                    od.OdSoDienThoai = txtSoDienThoai3.Text;
                    od.OdSoLuong = int.Parse(txtSoLuong3.Text);
                    od.OdEmail = txtEmail3.Text;
                    od.OdTongTien = decimal.Parse(txtTongTien3.Text);

                    if (txtTenSanPham3.Text.Equals("") || txtTenKhachHang3.Text.Equals("") || txtDiaChi3.Text.Equals("") || dtpNgayMua.Text.Equals("")
                    || txtSoDienThoai3.Text.Equals("") || txtSoLuong3.Text.Equals("") || txtTongTien3.Text.Equals(""))
                    {
                        MessageBox.Show("Không để trống dữ liệu");
                        return;
                    }
                    if (decimal.Parse(txtGiaGoc.Text) <= 0 || int.Parse(txtSoLuong3.Text) <= 0)
                    {
                        MessageBox.Show("Giá trị phải lớn hơn 0");
                        return;
                    }


                    int count = context.SaveChanges();
                    if (count > 0)
                    {
                        MessageBox.Show("Sửa thành công.");
                        LoadData1();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại: " + ex.Message);
            }
        }
    }
}
