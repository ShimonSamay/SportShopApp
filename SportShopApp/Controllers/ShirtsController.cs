using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShopApp.Models;

namespace SportShopApp.Controllers
{
    public class ShirtsController : Controller
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);


        public ActionResult ShirtsTable ()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt").ToList());
        }
        public ActionResult GetAllShirts()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt").ToList());
        }

       public ActionResult GetLongShirts ()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt" && clothe.IsShort == false).ToList());
        }

        public ActionResult GetShirts ()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt" && clothe.IsShort == true).ToList());
        }

        public ActionResult GetDryFit()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt" && clothe.IsDryFit == true).ToList());
        }
        public ActionResult OrderByPrice ()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-Shirt").OrderBy(clothe => clothe.Price).ToList());
                
        }

    }
}