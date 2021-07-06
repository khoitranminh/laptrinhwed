using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DiDongStore.Models;

namespace DiDongStore.Controllers
{
    public class DiDongStoreController : Controller
    {
        // Tao 1 doi tuong chua toan bo CSDL tu dbDiDongStore
        dbDiDongStoreDataContext data = new dbDiDongStoreDataContext();

        private List<DIENTHOAI> Laydienthoaimoi(int count)
        {
            // sap xep giam dan theo ID, lay count dong dau
            return data.DIENTHOAIs.OrderByDescending(a => a.MaDienThoai).Take(count).ToList();
        }

        // GET: DiDongStore
        public ActionResult Index()
        {
            var dienthoaimoi = Laydienthoaimoi(6);
            return View(dienthoaimoi);
        }
        public ActionResult Hang()
        {
            var hang = from h in data.HANGs select h;
            return PartialView(hang);
        }
        public ActionResult SPTheoHang(int id)
        {
            var phone = from p in data.DIENTHOAIs where p.MaHang == id select p;
            return View(phone);
        }
        public ActionResult Chitietphone(int id)
        {
            var phone = from p in data.DIENTHOAIs where p.MaDienThoai == id select p;
            return View(phone.Single());
        }

    }
}