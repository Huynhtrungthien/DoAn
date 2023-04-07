using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using System.Xml.Schema;

namespace DoAn.Controllers
{
    public class HomeController : Controller
    {
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult PageListSP(int? page)
        {
            if (page == null) page = 1;
            var all_sanpham = (from sp in data.SanPhams select sp).OrderBy(m => m.masp);
            int pageSize = 3;
            int pageNum = page ?? 1;
            return View(all_sanpham.ToPagedList(pageNum, pageSize));
        }
    }
}