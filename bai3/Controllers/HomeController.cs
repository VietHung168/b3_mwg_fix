using bai3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace bai3.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
       // public FakeData fdt1 = new FakeData();
        List<Product> loctheogia(List<Product> l, List<int> gia )
        {
            if (gia.Count == 0) return l;
            List<Product> tem = new List<Product>();
            foreach (Product pr in l)
            {
                foreach (int lo in gia)
                {
                    if (Program.fdt.listPriceLimit[lo].checkpri(pr.Price-pr.Promotion*pr.Price/100)==true)
                    {
                        tem.Add(pr);
                    }
                }
            }
         //   if (tem.Count == 0) return l;
            return tem;
        }
        List<Product> loctheoloai(List<Product> l, List<int> loai)
        {
            if (loai.Count == 0) return l;
            List<Product> tem = new List<Product>();
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < loai.Count; j++)
                {
                    if (loai[j]== l[i].id_Type)
                        tem.Add(l[i]);
                }
            }

          //  if (tem == null) return l;
            return tem;
        }
        List<Product> loctheohang(List<Product> l, List<int> hang)
        {
            if (hang.Count == 0) return l;
            List<Product> tem = new List<Product>();
            foreach (Product pr in l)
            {
                foreach (int lo in hang)
                {
                    if (lo == pr.id_Firm)
                    {
                        tem.Add(pr);
                    }
                }
            }
         //   if (tem.Count==0) return l;
            return tem;
            
        }
        List<Product> loctheocanngan(List<Product> l, List<int> can)
        {
            if (can.Count == 0) return l;
            List<Product> tem = new List<Product>();
            foreach (Product pr in l)
            {
                foreach (int lo in can)
                {
                    if (pr.weightLimit== Program.fdt.listWeight[lo])
                    {
                        tem.Add(pr);
                    }
                }
            }
         //   if (tem.Count==0) return l;
            return tem;
        }
        List<Product> loctheosize(List<Product> l, List<int> size)
        {
            if (size.Count == 0) return l;
            List<Product> tem = new List<Product>();
            for (int i = 0; i < l.Count; i++)
            {
                for (int j = 0; j < size.Count; j++)
                {

                    if (Program.fdt.ListSize[size[j]] == l[i].Size)
                        tem.Add(l[i]);
                }
            }

         //   if (tem.Count == 0) return l;
            return tem;

        }
        List<Product> phantrang( int trang, List<Product> l)
        {
            //10*trang +i
            List<Product> tem = new List<Product>();
            for (int i = 0; i <l.Count; i++)
            {
              if(i>= 10 *(trang-1)  && i<10*(trang))
                {
                    tem.Add(l[i]);
                }
            }

           
            return tem;

        }
        List<Product> sortgiathapdencao(List<Product> l)
        {

            l.Sort(delegate (Product x, Product y) {
                return x.Price.CompareTo(y.Price);
            });

            return l;
           

        }

        List<Product> sortgiacaodenthap(List<Product> l)
        {

            l.Sort(delegate (Product x, Product y) {
                return y.Price.CompareTo(x.Price);
            });

            return l;


        }
        List<Product> sortkhuyenmai(List<Product> l)
        {

            l.Sort(delegate (Product x, Product y) {
                return y.Promotion.CompareTo(x.Promotion);
            });

            return l;


        }
        List<Product> sortnoibat(List<Product> l)
        {

            l.Sort(delegate (Product x, Product y) {
                return y.num.CompareTo(x.num);
            });

            return l;


        }
        List<Product> sortbanchay(List<Product> l)
        {

            l.Sort(delegate (Product x, Product y) {
                return y.buynum.CompareTo(x.buynum);
            });

            return l;


        }


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            return View(Program.fdt);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        [HttpGet]
        public IActionResult getProducts(List<int> Hang, List<int> gia, List<int> Loai, List<int> cannag, List<int> size, int sort, int page)
        { 
            

            List<Product> list = new List<Product>();
            list = Program.fdt.listProduct;
               list = sortkhuyenmai(list);
              list = sortgiacaodenthap(list);
             list = sortgiathapdencao(list);
            list = loctheosize(list, size);
             list = loctheocanngan(list, cannag);
             list = loctheohang(list,Hang);
            list = loctheogia(list, gia);
             list = loctheoloai(list, Loai);
            switch (sort)
            {
                case 1:
                    {
                        list = sortnoibat(list);

                        break;
                    }
                case 2:
                    {
                        list = sortbanchay(list);
                        break;
                    }
                case 3:
                    {
                        list = sortkhuyenmai(list);
                        break;
                    }
                case 4:
                    {
                        list = sortgiacaodenthap(list);
                        break;
                    }
                case 5:
                    {
                        list = sortgiathapdencao(list);
                        break;
                    }
            }

             list = phantrang(page, list);



            string value = string.Empty;
            value = JsonConvert.SerializeObject(list, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value);
        }
        public IActionResult listproduct(List<Product> list)
        {
            return View(list);
           
        }
    }
}

