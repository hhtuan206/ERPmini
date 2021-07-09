using ERPmini.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ERPmini.Sale
{
    public partial class DetailBill : Form
    {
        private string Saler = "";
        private string maHoaDon = "";
        public DetailBill(string id, string maHoaDon, string Saler)
        {
            InitializeComponent();
            loadDetailBill(id);
            this.maHoaDon = maHoaDon;
            this.Saler = Saler;
        }

        private void loadDetailBill(string id)
        {
            try {
                string[] listID = id.Split(' ');

                foreach (string sing in listID)
                {
                    if (String.IsNullOrEmpty(sing))
                    {
                        break;
                    }
                    else
                    {
                        DataTable data = XuatSanPhamDAO.Instance.getSp(sing);
                        foreach (DataRow row in data.Rows)
                        {
                            dgvDetail.Rows.Add(row.ItemArray);
                        }

                    }
                }
            } catch (Exception ex) { MessageBox.Show(ex.ToString()); }
           
        }
       
        private void btnInHD_Click(object sender, EventArgs e)
        {
            InHoaDon inhoadon = new InHoaDon(maHoaDon, Saler);
            inhoadon.ShowDialog();
        }
    }
}
