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
    public partial class DetailBill : Form
    {
        public DetailBill(string id)
        {
            InitializeComponent();
            loadDetailBill(id);
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
    }
}
