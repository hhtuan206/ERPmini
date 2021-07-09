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

namespace ERPmini.Storage
{
    public partial class HomeStorage : Form
    {
        public static string Storager = "";
        BindingSource bindingSource = new BindingSource();
        public HomeStorage(string name,string manv)
        {
            InitializeComponent();
            loadProduct();
            bind();
            Storager = name;
            txtStorager.Text = name;
            loadInfoStaff(manv);
            cbGt.SelectedIndex = 0;
    
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

        void bind()
        {
            txtId.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "masanpham"));
            txtNameProduct.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "tensanpham"));
            txtPrice.DataBindings.Add(new Binding("Text", dgvProduct.DataSource, "dongia"));
            nudQty.DataBindings.Add("Value", dgvProduct.DataSource,"soluong");
        }

        void loadProduct()
        {
            bindingSource.DataSource = SanPhamDAO.Instance.getAllProduct();
            dgvProduct.DataSource = bindingSource;
            dgvProduct.Refresh();
            dgvSanpham.DataSource = bindingSource;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int masp = SanPhamDAO.Instance.insertProduct(txtNameProduct.Text.ToString(),nudQty.Value.ToString(),txtPrice.Text.ToString(),dtpNsx.Value.ToString(),dtpHsd.Value.ToString());
            NhapSanPhamDAO.Instance.insertData(masp.ToString(),"0",Storager);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            SanPhamDAO.Instance.updateProduct(txtId.Text.ToString(),txtNameProduct.Text.ToString(),txtPrice.Text.ToString(),dtpNsx.Value.ToString(), dtpHsd.Value.ToString());
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            SanPhamDAO.Instance.deleteProduct(txtId.Text.ToString());
        }

        private void btnUpdateQty_Click(object sender, EventArgs e)
        {
            NhapSanPhamDAO.Instance.insertData(txtId.Text.ToString(), nudQty.Value.ToString(), Storager);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            loadProduct();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            bindingSource.DataSource = SanPhamDAO.Instance.getAllProductByName(txtSearch.Text.ToString());
            dgvProduct.DataSource = bindingSource;
            dgvProduct.Refresh();
        }

        private void txtKeyWord_TextChanged(object sender, EventArgs e)
        {
            DataTable data = SanPhamDAO.Instance.getAllProductByName(txtKeyWord.Text.ToString());
            dgvSanpham.DataSource = data;
            dgvSanpham.Refresh();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string maxuatSP = "";
            for (int i = 0; i < dgvTempProduct.Rows.Count; i++)
            {
                if (dgvTempProduct.Rows.Count - 1 == i)
                {
                    maxuatSP += XuatSanPhamDAO.Instance.insertData(dgvTempProduct.Rows[i].Cells["id"].Value.ToString(), dgvTempProduct.Rows[i].Cells["soluong"].Value.ToString(), txtStorager.Text.ToString(), DateTime.Today.ToString("yyyy-MM-dd")) + "";
                }
                else
                {
                    maxuatSP += XuatSanPhamDAO.Instance.insertData(dgvTempProduct.Rows[i].Cells["id"].Value.ToString(), dgvTempProduct.Rows[i].Cells["soluong"].Value.ToString(), txtStorager.Text.ToString(), DateTime.Today.ToString("yyyy-MM-dd")) + " ";

                }
            }
            MessageBox.Show("Thành công");
            loadProduct();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            dgvTempProduct.Rows.Clear();
        }

        private void btnAddProduct_Click(object sender, EventArgs e)
        {
            getTempProduct();
        }

        void getTempProduct()
        {
            foreach (DataGridViewRow row in dgvSanpham.SelectedRows)
            {
                if (nudQtyTemp.Value > 0)
                {
                    String[] row1 = { row.Cells[0].Value.ToString(), row.Cells[1].Value.ToString(), nudQtyTemp.Value.ToString(), row.Cells[3].Value.ToString() };
                    dgvTempProduct.Rows.Add(row1);
                }
                else
                {
                    MessageBox.Show("Số lượng phải lớn hơn 00", "Thông báo");
                }


            }
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
                NhanVienDAO.Instance.updateInfo(txtManv.Text.ToString(),txtHoten.Text.ToString(),cbGt.Text.ToString(),dtpNgaysinh.Value.ToString(),txtDiachi.Text.ToString(),txtMail.Text.ToString(),txtSdt.Text.ToString());
                MessageBox.Show("Thành công");
            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
        }

        private void btnNhap_Click(object sender, EventArgs e)
        {
            if (!pnlThongKe.Controls.Contains(ucNhapSP.Instance))
            {
                ucNhapSP ucnhapSP = new ucNhapSP(Storager);
                pnlThongKe.Controls.Add(ucnhapSP);
                ucnhapSP.Dock = DockStyle.Fill;
                ucnhapSP.BringToFront();
            }
            else
            {
                ucNhapSP ucGD = new ucNhapSP(Storager);
                ucGD.BringToFront();
            }
        }

        private void btnXuat_Click(object sender, EventArgs e)
        {
            if (!pnlThongKe.Controls.Contains(ucXuatSP.Instance))
            {
                ucXuatSP ucnhapSP = new ucXuatSP(Storager);
                pnlThongKe.Controls.Add(ucnhapSP);
                ucnhapSP.Dock = DockStyle.Fill;
                ucnhapSP.BringToFront();
            }
            else
            {
                ucXuatSP ucGD = new ucXuatSP(Storager);
                ucGD.BringToFront();
            }
        }

        private void btnSPKho_Click(object sender, EventArgs e)
        {
            if (!pnlThongKe.Controls.Contains(ucKhoSP.Instance))
            {
                ucKhoSP ucnhapSP = new ucKhoSP(Storager);
                pnlThongKe.Controls.Add(ucnhapSP);
                ucnhapSP.Dock = DockStyle.Fill;
                ucnhapSP.BringToFront();
            }
            else
            {
                ucKhoSP ucGD = new ucKhoSP(Storager);
                ucGD.BringToFront();
            }
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
