using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMS.DAO;

namespace ERPmini.DAO
{   
    class SanPhamDAO
    {
        private static SanPhamDAO instance;

        public static SanPhamDAO Instance
        {
            get { if (instance == null) instance = new SanPhamDAO(); return SanPhamDAO.instance; }
            private set => SanPhamDAO.instance = value;
        }

        private SanPhamDAO() { }


        public DataTable getAllProduct()
        {
            string query = "select * from tbl_sanpham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable getAllProductByName(string tensanpham)
        {
            string query = "select * from tbl_sanpham where tensanpham like N'%"+tensanpham+"%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public int insertProduct(string tensanpham,string soluong,string dongia, string ngaysanxuat,string hansudung)
        {
            int masanpham = 0;
            string query = "insert into tbl_sanpham(tensanpham,soluong,dongia,ngaysanxuat,hansudung) values(N'"+tensanpham+"',"+soluong+","+dongia+",'"+ngaysanxuat+"','"+hansudung+ "' ) SELECT SCOPE_IDENTITY() as masanpham";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                masanpham = int.Parse(item["masanpham"].ToString());
            }
            return masanpham;
        }

        public void updateProduct(string masp,string tensanpham,string dongia,string ngaysanxuat,string hansudung)
        {
            string query = "update tbl_sanpham set tensanpham = N'"+tensanpham+"',dongia = "+dongia+",ngaysanxuat = '"+ngaysanxuat+"',hansudung = '"+hansudung+"' where masanpham = "+masp+"";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public void deleteProduct(string masanpham)
        {
            string query = "delete tbl_sanpham where masanpham = " + masanpham + "";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
    }
}
