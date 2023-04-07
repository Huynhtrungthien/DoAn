using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class LoaiSPController : Controller
    {
        // GET: LoaiSP
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult Index()
        {
            var all_loaisp = from tt in data.LoaiSPs select tt;
            return View(all_loaisp);
        }

        public ActionResult Details(int id)
        {
            var d_loaisp = data.LoaiSPs.Where(m => m.maloai == id).First();
            return View(d_loaisp);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, LoaiSP lsp)
        {
            var ten = collection["tenloai"];
            if (string.IsNullOrEmpty(ten))
            {
                ViewData["Error"] = "Không được để trống!";
            }
            else
            {
                lsp.tenloai = ten;
                data.LoaiSPs.InsertOnSubmit(lsp);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var E_category = data.LoaiSPs.First(m => m.maloai == id);
            return View(E_category);
        }
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var loaisp = data.LoaiSPs.First(m => m.maloai == id);
            var E_tenloai = collection["tenloai"];
            loaisp.maloai = id;
            if (string.IsNullOrEmpty(E_tenloai))
            {
                ViewData["Error"] = "Không được để trống!";
            }
            else
            {
                loaisp.tenloai = E_tenloai;
                UpdateModel(loaisp);
                data.SubmitChanges();
                return RedirectToAction("Index");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_loaisp = data.LoaiSPs.First(m => m.maloai == id);
            return View(D_loaisp);
        }
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_loaisp = data.LoaiSPs.Where(m => m.maloai == id).First();
            data.LoaiSPs.DeleteOnSubmit(D_loaisp);
            data.SubmitChanges();
            return RedirectToAction("Index");
        }
    }
}