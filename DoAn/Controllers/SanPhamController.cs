using DoAn.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: SanPham
        MyDataDataContext data = new MyDataDataContext();
        public ActionResult ListSPham()
        {
            var all_sanpham = from sp in data.SanPhams select sp;
            return View(all_sanpham);
        }


        public ActionResult Details(int id)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            return View(D_sanpham);
        }


        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormCollection collection, SanPham sp)
        {
            var E_tensp = collection["tensp"];
            var E_hinh = collection["hinh"];
            var E_gia = Convert.ToInt32(collection["gia"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            var E_cpu = collection["CPU"];
            var E_rom = collection["ROM"];
            var E_ram = collection["RAM"];
            var E_pin = collection["PIN"];
            var E_hdh = collection["HDH"];
            var E_thenho = collection["thenho"];
            var E_cameratruoc = collection["cameratruoc"];
            var E_camerasau = collection["camerasau"];
            var E_ngaybaohanh = collection["ngaybaohanh"];
            if (string.IsNullOrEmpty(E_tensp))
            {
                ViewData["Error"] = "Không được bỏ trống!";
            }
            else
            {
                sp.tensp = E_tensp.ToString();
                sp.hinh = E_hinh.ToString();
                sp.gia = E_gia;
                sp.soluongton = E_soluongton;
                sp.CPU = E_cpu.ToString();
                sp.ROM = E_rom.ToString();
                sp.RAM = E_ram.ToString();
                sp.PIN = E_pin.ToString();
                sp.HDH = E_hdh.ToString();
                sp.thenho = E_thenho.ToString();
                sp.cameratruoc = E_cameratruoc.ToString();
                sp.camerasau = E_camerasau.ToString();
                sp.ngaybaohanh = E_ngaybaohanh.ToString();

                data.SanPhams.InsertOnSubmit(sp);
                data.SubmitChanges();
                return RedirectToAction("ListSPham");
            }
            return this.Create();
        }

        public ActionResult Edit(int id)
        {
            var E_sanpham = data.SanPhams.First(m => m.masp == id);
            return View(E_sanpham);
        }

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            var E_sanpham = data.SanPhams.First(m => m.masp == id);
            var E_tensp = collection["tensp"];
            var E_hinh = collection["hinh"];
            var E_gia = Convert.ToInt32(collection["gia"]);
            var E_soluongton = Convert.ToInt32(collection["soluongton"]);
            var E_cpu = collection["CPU"];
            var E_rom = collection["ROM"];
            var E_ram = collection["RAM"];
            var E_pin = collection["PIN"];
            var E_hdh = collection["HDH"];
            var E_thenho = collection["thenho"];
            var E_cameratruoc = collection["cameratruoc"];
            var E_camerasau = collection["camerasau"];
            var E_ngaybaohanh = collection["ngaybaohanh"];
            E_sanpham.masp = id;
            if (string.IsNullOrEmpty(E_tensp))
            {
                ViewData["Error"] = "Không được bỏ trống!";
            }
            else
            {
                E_sanpham.tensp = E_tensp;
                E_sanpham.hinh = E_hinh;
                E_sanpham.gia = E_gia;
                E_sanpham.soluongton = E_soluongton;
                E_sanpham.CPU = E_cpu;
                E_sanpham.ROM = E_rom;
                E_sanpham.RAM = E_ram;
                E_sanpham.PIN = E_pin;
                E_sanpham.HDH = E_hdh;
                E_sanpham.thenho = E_thenho;
                E_sanpham.cameratruoc = E_cameratruoc;
                E_sanpham.camerasau = E_camerasau;
                E_sanpham.ngaybaohanh = E_ngaybaohanh;

                UpdateModel(E_sanpham);
                data.SubmitChanges();
                return RedirectToAction("ListSPham");
            }
            return this.Edit(id);
        }

        public ActionResult Delete(int id)
        {
            var D_sanpham = data.SanPhams.First(m => m.masp == id);
            return View(D_sanpham);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var D_sanpham = data.SanPhams.Where(m => m.masp == id).First();
            data.SanPhams.DeleteOnSubmit(D_sanpham);
            data.SubmitChanges();
            return RedirectToAction("ListSPham");
        }

        public string ProcessUpload(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return "";
            }
            file.SaveAs(Server.MapPath("~/Content/images/" + file.FileName));
            return "/Content/images/" + file.FileName;
        }
    }
}