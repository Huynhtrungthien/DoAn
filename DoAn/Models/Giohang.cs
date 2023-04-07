using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace DoAn.Models
{
    public class Giohang
    {
        MyDataDataContext data = new MyDataDataContext();
        public int masp { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string tensanpham { get; set; }

        [Display(Name = "Hình ảnh")]
        public string hinh { get; set; }

        [Display(Name = "Giá tiền")]
        public double giatien { get; set; }

        [Display(Name = "Số lượng")]
        public int iSoLuong { get; set; }

        [Display(Name = "Thành tiền")]
        public double dThanhtien
        {
            get { return iSoLuong * giatien; }
        }

        public Giohang(int id)
        {
            masp = id;
            SanPham sp = data.SanPhams.Single(n => n.masp == masp);
            tensanpham = sp.tensp;
            hinh = sp.hinh;
            giatien = double.Parse(sp.gia.ToString());
            iSoLuong = 1;
        }
    }
}