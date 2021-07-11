using ERPmini.DAO;
using ERPmini.Sale;
using ERPmini.Storage;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPmini
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsn.Text.ToString();
                string password = txtPwd.Text.ToString();

                List<string> role = TaiKhoanDAO.Instance.Login(username, password);

                if (role[0].Equals("Nhân viên kho"))
                {

                    HomeStorage storage = new HomeStorage(role[1], role[2]);
                    this.Hide();
                    storage.ShowDialog();
                    this.Show();
                }
                else if (role[0].Equals("Nhân viên bán hàng"))
                {
                    HomeSale sale = new HomeSale(role[1], role[2]);
                    this.Hide();
                    sale.ShowDialog();
                    this.Show();
                }

                else
                {
                    MessageBox.Show("Sai tên tài khoản hoặc mật khẩu!");
                }

            }
            catch (Exception ex) { MessageBox.Show(ex.ToString()); }
            
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
