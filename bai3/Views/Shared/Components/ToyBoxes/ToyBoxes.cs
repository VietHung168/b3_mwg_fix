using bai3.Models;

using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace bai3
{
    public class ToyBoxes : ViewComponent
    {
      //  DataHelper dataHelper = new DataHelper();


        public IViewComponentResult Invoke(List<Product> list)
        {

            return View<List<Product>> (list); //mặc định sẽ chạy Default.cshtml
        }
    }
}
