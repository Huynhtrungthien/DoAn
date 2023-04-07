using DoAn.Models;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace DoAn.Controllers
{
    public class TimKiemController : Controller
    {
        // GET: TimKiem
        MyDataDataContext data = new MyDataDataContext();
        [HttpGet]
        public ActionResult Search(string search, int? page)
        {
            //if (page == null) page = 1;
            //var all_sanpham = (from sp in data.SanPhams select sp).OrderBy(m => m.masp);
            if (Request.HttpMethod != "GET")
            {
                page = 1;
            }
            int pageSize = 3;
            int pageNum = (page ?? 1);
            //return View(all_sanpham.ToPagedList(pageNum, pageSize));

            ViewBag.Search = search;
            var lstSP = data.SanPhams.Where(n => n.tensp.Contains(search));
            return View(lstSP.OrderBy(n => n.tensp).ToPagedList(pageNum, pageSize));
        }

        [HttpPost]
        //public ActionResult Search(string search, int? page,FormCollection collection)
        //{
        //    if (page == null) page = 1;
        //    var all_sanpham = (from sp in data.SanPhams select sp).OrderBy(m => m.masp);
        //    int pageSize = 3;
        //    int pageNum = page ?? 1;

        //    ViewBag.Search = search;
        //    var lstSP = data.SanPhams.Where(n => n.tensp.Contains(search));
        //    return View(lstSP.OrderBy(n => n.tensp).ToPagedList(pageNum, pageSize));
        //}

        public ActionResult SearchResult(string search)
        {

            return RedirectToAction("Search", new { @search = search });

        }
    }
}