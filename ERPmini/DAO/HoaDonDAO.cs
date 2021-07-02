using HMS.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPmini.DAO
{
    class HoaDonDAO
    {
        private static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            private set => HoaDonDAO.instance = value;
        }

        public void insertData(string maxuatSP, string tenKH,string tenNV, string ngaytao)
        {
            string query = "insert into tbl_hoadon(maxuatSP,tenKH,tenNV,ngaytao) values('" + maxuatSP + "', N'" + tenKH + "',N'" + tenNV + "','" + ngaytao + "')";
            DataProvider.Instance.ExecuteNonQuery(query);

        }

        public DataTable getAllBill()
        {
            string query = "select mahoadon,maxuatSP,tenKH,tenNV,ngaytao from tbl_hoadon";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable getAllBillbyCustomer(string customer)
        {
            string query = "select mahoadon,maxuatSP,tenKH,tenNV,ngaytao from tbl_hoadon where tenKH like N'%" + customer + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }

        public DataTable getAllBillbySaler(string saler)
        {
            string query = "select mahoadon,maxuatSP,tenKH,tenNV,ngaytao from tbl_hoadon where tenNV like N'%" + saler + "%'";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data;
        }
    }
}
