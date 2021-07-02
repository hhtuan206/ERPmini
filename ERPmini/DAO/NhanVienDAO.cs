using HMS.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPmini.DAO
{
    class NhanVienDAO
    {
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return NhanVienDAO.instance; }
            private set => NhanVienDAO.instance = value;
        }

        public void updateInfo(string id,string tenNv,string gioitinh,string ngaysinh,string diachi,string email,string sdt)
        {
            string query = "update tbl_nhanvien set tennhanvien = N'"+tenNv+"',gioitinh = N'"+gioitinh+"',ngaysinh = '"+ngaysinh+"',diachi = N'"+diachi+"',email = '"+email+"',sdt = "+sdt+" where manhanvien = "+id+"";
            DataProvider.Instance.ExecuteNonQuery(query);
        }

        public DataTable getInfo(string id)
        {
            string query = "select * from tbl_nhanvien inner join tbl_taikhoan on tbl_nhanvien.manhanvien = tbl_taikhoan.manhanvien where tbl_nhanvien.manhanvien = " + id+"";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

    }
}
