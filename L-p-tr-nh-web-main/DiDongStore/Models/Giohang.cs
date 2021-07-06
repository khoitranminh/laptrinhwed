using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DiDongStore.Models;
namespace DiDongStore.Models
{
    public class Giohang
    {
        
        dbDiDongStoreDataContext data = new dbDiDongStoreDataContext();
        public int iMaDienThoai { set; get; }
        public string sTenDienThoai { set; get; }
        public string sAnhbia { set; get; }
        public Double dDongia { set; get; }
        public int iSoluong { set; get; }
        public Double dThanhtien
        {
            get { return iSoluong * dDongia; }

        }
     
        public Giohang(int MaDienThoai)
        {
            iMaDienThoai = MaDienThoai;
            DIENTHOAI dt = data.DIENTHOAIs.Single(n => n.MaDienThoai == iMaDienThoai);
            sTenDienThoai = dt.TenDienThoai;
            sAnhbia = dt.AnhBia;
            dDongia = double.Parse(dt.GiaBan.ToString());
            iSoluong = 1;
        }
    }
}