using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SportShopApp.Models;

namespace SportShopApp.Controllers
{
    public class EquipmentController : Controller
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);
        public ActionResult GetAllEquip()
        {
            return View(DataContext.Equipments.ToList());
        }

        public ActionResult GetFootballItems()
        {
            return View(DataContext.Equipments.Where(item => item.SportType == "Football").ToList());
        }

        public ActionResult GetBasketballItems()
        {
            return View(DataContext.Equipments.Where(item => item.SportType == "basketball").ToList());
        }

        public ActionResult OrderByPrice()
        {
            return View(DataContext.Equipments.OrderBy(item => item.Price).ToList());
        }

        public ActionResult EquipTable()
        {
            return View(DataContext.Equipments.ToList());
        }



    }
}