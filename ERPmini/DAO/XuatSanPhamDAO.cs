using HMS.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPmini.DAO
{
    class XuatSanPhamDAO
    {
        private static XuatSanPhamDAO instance;

        public static XuatSanPhamDAO Instance
        {
            get { if (instance == null) instance = new XuatSanPhamDAO(); return XuatSanPhamDAO.instance; }
            private set => XuatSanPhamDAO.instance = value;
        }

        public int insertData(string masanpham,string sl,string tennv,string ngayxuat)
        {
            int maxuatSP = 0;
            string query = "insert into tbl_xuatSp(masanpham,sl,tenNV,ngayxuat) values(" + masanpham+", "+sl+",N'"+tennv+"','"+ngayxuat+ "') SELECT SCOPE_IDENTITY() as maxuatSP";
            DataTable data =  DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                maxuatSP = int.Parse(item["maxuatSP"].ToString());
            }
            return maxuatSP;

        }

        public DataTable getSp(string id)
        {
            string query = "select tbl_sanpham.tensanpham,tbl_sanpham.dongia,tbl_xuatSP.sl from tbl_sanpham inner join tbl_xuatSP on tbl_xuatSP.masanpham = tbl_sanpham.masanpham where tbl_xuatSP.maxuatSP = "+id+"";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

    }
}
