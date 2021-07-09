using ERPmini.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPmini.Sale
{
    public partial class HomeSale : Form
    {
        public static string maHoaDon = "";
        public static string Saler = "";
        string list = null;
        public HomeSale(string name,String manv)
        {
            InitializeComponent();
            txtSaler.Text = name;
            loadProduct();
            loadBill();
            loadInfoStaff(manv);
            cbGt.SelectedIndex = 0;
            Saler = name;
        }


        private void loadInfoStaff(string manv)
        {
            DataTable data = NhanVienDAO.Instance.getInfo(manv);
            txtManv.Text = manv;
            foreach (DataRow row in data.Rows)
            {
                txtHoten.Text = row["tennhanvien"].ToString();
                txtDiachi.Text = row["diachi"].ToString();
                txtSdt.Text = row["sdt"].ToString();
                dtpNgaysinh.Value = Convert.ToDateTime(row["ngaysinh"].ToString());
                cbGt.Text = row["gioitinh"].ToString();
                txtMail.Text = row["email"].ToString();
                txtUsn.Text = row["tentaikhoan"].ToString();
                txtPwd.Text = row["matkhau"].ToString();
            }
        }

        void loadProduct()
        {
            DataTable data = SanPhamDAO.Instance.getAllProduct();
            dgvSanPham.DataSource = data;
            dgvSanPham.Refresh();
            dgvProduct.DataSource = data;
            dgvProduct.Refresh();
        }

        void getTempProduct()
        {
            foreach (DataGridViewRow row in dgvProduct.SelectedRows)
            {
                if (numQty.Value > 0)
                {
                    String[] row1 = { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), numQty.Value.ToString(), row.Cells[3].Value.ToString() };
                    dgvTempProduct.Rows.Add(row1);
                }
                else
                {
                    MessageBox.Show("Số lượng phải lớn hơn 0", "Thông báo");
                }


            }
        }

        private void btnAddTempProduct_Click(object sender, EventArgs e)
        {
            getTempProduct();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvTempProduct.Rows.Clear();
        }

        void xuatSp()
        {
            string maxuatSP = "";
            for (int i = 0; i < dgvTempProduct.Rows.Count; i++)
            {
                if (dgvTempProduct.Rows.Count - 1 == i)
                {
                    maxuatSP += XuatSanPhamDAO.Instance.insertData(dgvTempProduct.Rows[i].Cells["id"].Value.ToString(), dgvTempProduct.Rows[i].Cells["soluong"].Value.ToString(), txtSaler.Text.ToString(), DateTime.Today.ToString("yyyy-MM-dd")) + "";
                }
                else
                {
                    maxuatSP += XuatSanPhamDAO.Instance.insertData(dgvTempProduct.Rows[i].Cells["id"].Value.ToString(), dgvTempProduct.Rows[i].Cells["soluong"].Value.ToString(), txtSaler.Text.ToString(), DateTime.Today.ToString("yyyy-MM-dd")) + " ";

                }

            }
            HoaDonDAO.Instance.insertData(maxuatSP, txtCustomer.Text.ToString(), txtSaler.Text.ToString(), DateTime.Today.ToString("yyyy-MM-dd"));

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                xuatSp();
                MessageBox.Show("Thành công", "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString(), "Thông báo");
            }

        }

        void loadBill()
        {
            DataTable data = HoaDonDAO.Instance.getAllBill();
            dgvBill.DataSource = data;
            dgvBill.Refresh();

        }

        private void btnDetailBill_Click(object sender, EventArgs e)
        {
           
            DetailBill detailBill = new DetailBill(list, maHoaDon, Saler);
            detailBill.ShowDialog();

        }

        private void dgvBill_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dgvBill.Rows[e.RowIndex];
                list = row.Cells["maxuatSP"].Value.ToString();
                maHoaDon = row.Cells["mahoadon"].Value.ToString();
               
            }
        }

        private void btnRefesh_Click(object sender, EventArgs e)
        {
            loadBill();
        }

      
        private void btnSearchCustomer_Click(object sender, EventArgs e)
        {
            DataTable data = HoaDonDAO.Instance.getAllBillbyCustomer(txtSearchCustomer.Text.ToString());
            dgvBill.DataSource = data;
            dgvBill.Refresh();
        }

        private void btnSearchSaler_Click(object sender, EventArgs e)
        {
            DataTable data = HoaDonDAO.Instance.getAllBillbySaler(txtSearchSaler.Text.ToString());
            dgvBill.DataSource = data;
            dgvBill.Refresh();
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            DataTable data = SanPhamDAO.Instance.getAllProductByName(txtKeyWord.Text.ToString());
            dgvProduct.DataSource = data;
            dgvProduct.Refresh();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            DataTable data = SanPhamDAO.Instance.getAllProductByName(txtTimKiem.Text.ToString());
            dgvSanPham.DataSource = data;
            dgvSanPham.Refresh();
        }

        private void btnUpdateAcc_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanDAO.Instance.updateAccount(txtManv.Text.ToString(), txtUsn.Text.ToString(), txtPwd.Text.ToString());
                MessageBox.Show("Thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            try
            {
                TaiKhoanDAO.Instance.updateAccount(txtManv.Text.ToString(), txtUsn.Text.ToString(), txtPwd.Text.ToString());
                MessageBox.Show("Thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnHoaDonDate_Click(object sender, EventArgs e)
        {
            if (!pnlSale.Controls.Contains(ucHoaDonDate.Instance))
            {
                ucHoaDonDate uchoadondate = new ucHoaDonDate(Saler);
                pnlSale.Controls.Add(uchoadondate);
                uchoadondate.Dock = DockStyle.Fill;
                uchoadondate.BringToFront();
            }
            else
            {
                ucHoaDonDate uchoadondate = new ucHoaDonDate(Saler);
                uchoadondate.BringToFront();
            }
        }

        private void btnChiTietHD_Click(object sender, EventArgs e)
        {
            
        }
    }
}
