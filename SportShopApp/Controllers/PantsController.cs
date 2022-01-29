using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShopApp.Models;

namespace SportShopApp.Controllers
{
    public class PantsController : Controller
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);

        public ActionResult PantsTable()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants").ToList());
        }


        public ActionResult GetAllPants()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants").ToList());
        }


        public ActionResult GetLongPants()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants" && clothe.IsShort == false).ToList());
        }


        public ActionResult GetShorts()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants" && clothe.IsShort == true).ToList());
        }


        public ActionResult GetDryFit ()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants" && clothe.IsDryFit == true).ToList());
        }


        public ActionResult OrderByPrice()
        {
            return View(DataContext.Clothings.Where(clothe => clothe.ClothingType == "Pants").OrderBy(clothe => clothe.Price).ToList());
        }
    }
}