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
    public partial class InHoaDon : Form
    {
        private string Saler = "";
        private string maHoaDon = "";
        public InHoaDon(string maHoaDon, string Saler)
        {
            InitializeComponent();
            this.maHoaDon = maHoaDon;
            this.Saler = Saler;
            load_form();
        }
        #region VARIABLE
        public static string connectionString = "Data Source=.;Initial Catalog=db_qlsxduoc;User ID=sa;Integrated Security=True";
        System.Data.DataSet ds;
        SqlConnection conn;
        #endregion
        public void load_form()
        {
            try
            {
                conn = new SqlConnection(connectionString);
                if (conn.State == ConnectionState.Closed)
                {
                    conn.Open();
                }
                string query = "PROCE_CTHoaDon";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@ID", maHoaDon);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                ds = new System.Data.DataSet();
                da.Fill(ds);
                CRCTHoaDon crs = new CRCTHoaDon();
                crs.SetDataSource(ds.Tables[0]);
                crs.SetParameterValue("NGUOIBAN", Saler);
                cRVInHoaDon.ReportSource = crs;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
