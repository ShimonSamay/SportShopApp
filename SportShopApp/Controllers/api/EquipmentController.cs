using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SportShopApp.Models;

namespace SportShopApp.Controllers.api
{
    public class EquipmentController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DataContext.Equipments.ToList()); ;
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        public IHttpActionResult Get(int id)
        {
            try
            {
                return Ok(DataContext.Equipments.First(equip => equip.Id == id));
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        public IHttpActionResult Post([FromBody] Equipment newEquip)
        {
            try
            {
                DataContext.Equipments.InsertOnSubmit(newEquip);
                DataContext.SubmitChanges();
                return Ok(DataContext.Equipments.ToList()); ;
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }



        public IHttpActionResult Put(int id, [FromBody] Equipment newEquip)
        {
            try
            {
                Equipment equipToUpdate = DataContext.Equipments.First(equip => equip.Id == id);
                equipToUpdate.Price = newEquip.Price;
                equipToUpdate.Quantity = newEquip.Quantity;
                equipToUpdate.Company = newEquip.Company;
                equipToUpdate.PickLink = newEquip.PickLink;
                equipToUpdate.Product = newEquip.Product;
                equipToUpdate.SportType = newEquip.SportType;
                equipToUpdate.TeamId = newEquip.TeamId;
                DataContext.SubmitChanges();
                return Ok(DataContext.Equipments.ToList()); ;
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }


        public IHttpActionResult Delete(int id)
        {
            try
            {
                DataContext.Equipments.DeleteOnSubmit(DataContext.Equipments.First(equip => equip.Id == id));
                DataContext.SubmitChanges();
                return Ok(DataContext.Equipments.ToList()); ;
            }
            catch (SqlException sqlErr)
            {
                return BadRequest(sqlErr.Message);
            }
            catch (Exception err)
            {
                return BadRequest(err.Message);
            }
        }
    }
}

