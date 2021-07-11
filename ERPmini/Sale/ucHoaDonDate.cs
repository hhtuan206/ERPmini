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
    public partial class ucHoaDonDate : UserControl
    {
        private string Saler;
        private static ucHoaDonDate _instance;
        public ucHoaDonDate()
        {
            InitializeComponent();
        }
        public ucHoaDonDate(string Saler)
        {
            InitializeComponent();
            this.Saler = Saler;
        }
        public static ucHoaDonDate Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucHoaDonDate();
                return _instance;
            }
        }
        #region VARIABLE
        public static string connectionString = "Data Source=.;Initial Catalog=db_qlsxduoc;User ID=sa;Integrated Security=True";
        System.Data.DataSet ds;
        SqlConnection conn;
        #endregion

        private void btnXem_Click(object sender, EventArgs e)
        {
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "BAOCAO_hoadon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TGIAN_BDAU", dtpTGBD.Value);
                cmd.Parameters.AddWithValue("@TGIAN_KTHUC", dtpTGKT.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new System.Data.DataSet();
                da.Fill(ds);

                CRHoaDonDate crs = new CRHoaDonDate();
                crs.SetDataSource(ds.Tables[0]);

                crs.SetParameterValue("NGAYBD", dtpTGBD.Value);
                crs.SetParameterValue("NGAYKT", dtpTGKT.Value);
                crs.SetParameterValue("NGUOITAO", Saler);
                cRVHoaDonDate.ReportSource = crs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
