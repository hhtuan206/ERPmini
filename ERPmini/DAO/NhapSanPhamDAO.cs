using HMS.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPmini.DAO
{
    class NhapSanPhamDAO
    {
        private static NhapSanPhamDAO instance;

        public static NhapSanPhamDAO Instance
        {
            get { if (instance == null) instance = new NhapSanPhamDAO(); return NhapSanPhamDAO.instance; }
            private set => NhapSanPhamDAO.instance = value;
        }

        public void insertData(string masanpham,string soluong,string tenNV)
        {
            
            string query = "insert into tbl_nhapSP(masanpham,sl,tenNV,ngaynhap) values("+masanpham+","+soluong+",N'"+tenNV+"',getdate())";
            DataProvider.Instance.ExecuteNonQuery(query);

            
        }
    }
}
