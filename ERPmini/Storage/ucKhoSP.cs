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
    public partial class ucKhoSP : UserControl
    {
        private string Storager;
        private static ucKhoSP _instance;
        public ucKhoSP()
        {
            InitializeComponent();
        }
        public ucKhoSP(string Storager)
        {
            InitializeComponent();
            this.Storager = Storager;
            load_khoSP();
        }
        public static ucKhoSP Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new ucKhoSP();
                return _instance;
            }
        }
        #region VARIABLE
        public static string connectionString = "Data Source=.;Initial Catalog=db_qlsxduoc;User ID=sa;Integrated Security=True";
        System.Data.DataSet ds;
        SqlConnection conn;
        #endregion
        public void load_khoSP()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "BAOCAO_khoSP";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new System.Data.DataSet();
                da.Fill(ds);

                CRKhoSP crs = new CRKhoSP();
                crs.SetDataSource(ds.Tables[0]);
                crs.SetParameterValue("NGUOITAO", Storager);
                cRVKhoSP.ReportSource = crs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
