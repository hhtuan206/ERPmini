using HMS.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPmini.DAO
{
    class TaiKhoanDAO
    {
        private static TaiKhoanDAO instance;

        public static TaiKhoanDAO Instance {
            get { if (instance == null) instance = new TaiKhoanDAO(); return TaiKhoanDAO.instance; }
            private set => TaiKhoanDAO.instance = value; }

        private TaiKhoanDAO() { }

        public List<String> Login(string userName, string passWord)
        {
            List<String> role = new List<string>();
            string query = "select tbl_nhanvien.manhanvien,tennhanvien,tenchucvu " +
                "from tbl_taikhoan " +
                    "inner join tbl_nhanvien " +
                        "on tbl_taikhoan.manhanvien = tbl_nhanvien.manhanvien " +
                    "inner join tbl_chucvu " +
                        "on tbl_chucvu.machucvu = tbl_nhanvien.machucvu  " +
                "where tentaikhoan = N'"+userName+"' and matkhau = N'"+passWord+"'";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in result.Rows)
            {
           
                role.Add(item["tenchucvu"].ToString());
                role.Add(item["tennhanvien"].ToString());
                role.Add(item["manhanvien"].ToString());
            }
            return role;
        }

        public void updateAccount(string manv, string tentk,string mk)
        {
            string query = "update tbl_taikhoan set tentaikhoan = '"+tentk+"', matkhau= '"+mk+"' where manhanvien = "+manv+"";
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        
    }
}
