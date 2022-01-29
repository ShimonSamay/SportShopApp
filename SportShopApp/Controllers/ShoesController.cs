using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShopApp.Models;

namespace SportShopApp.Controllers
{
    public class ShoesController : Controller
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);

        public ActionResult GetAllShoes()
        {
            return View(DataContext.Shoes.ToList());
        }


        public ActionResult GetShoesOnSale()
        {
            return View(DataContext.Shoes.Where(shoe => shoe.OnSale == true).ToList());
        }


        public ActionResult ShoesTable ()
        {
            return View(DataContext.Shoes.ToList());
        }
    }
}