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

namespace ERPmini.Storage
{
    public partial class ucXuatSP : UserControl
    {
        private string Storager;
        private static ucXuatSP _instance;
        public ucXuatSP()
        {
            InitializeComponent();
        }
        public ucXuatSP(string Storager)
        {
            InitializeComponent();
            this.Storager = Storager;
        }
        public static ucXuatSP Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucXuatSP();
                return _instance;
            }
        }
        #region VARIABLE
        public static string connectionString = "Data Source=DESKTOP-F58T0SR\\SQLEXPRESS;Initial Catalog=db_qlsxduoc;User ID=sa;Integrated Security=True";
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
                string query = "BAOCAO_xuatSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@TGIAN_BDAU", dtpTGBD.Value);
                cmd.Parameters.AddWithValue("@TGIAN_KTHUC", dtpTGKT.Value);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new System.Data.DataSet();
                da.Fill(ds);

                CRXuatSP crs = new CRXuatSP();
                crs.SetDataSource(ds.Tables[0]);

                crs.SetParameterValue("NGAYBD", dtpTGBD.Value);
                crs.SetParameterValue("NGAYKT", dtpTGKT.Value);
                crs.SetParameterValue("NGUOITAO", Storager);
                cRVXuatSP.ReportSource = crs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
