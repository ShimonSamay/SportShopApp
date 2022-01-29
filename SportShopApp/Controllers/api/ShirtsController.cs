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
    public class ShirtsController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DataContext.Clothings.Where(clothe => clothe.ClothingType == "T-shirt").ToList());
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
                return Ok(DataContext.Clothings.First(clothe => clothe.Id == id && clothe.ClothingType == "T-shirt"));
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


        public IHttpActionResult Post([FromBody] Clothing newClothe)
        {
            try
            {
                DataContext.Clothings.InsertOnSubmit(newClothe);
                DataContext.SubmitChanges();
                return Ok(DataContext.Clothings.ToList()); ;
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



        public IHttpActionResult Put(int id, [FromBody] Clothing newClothe)
        {
            try
            {
                Clothing clotheToUpdate = DataContext.Clothings.First(clothe => clothe.Id == id);
                clotheToUpdate.Price = newClothe.Price;
                clotheToUpdate.Quantity = newClothe.Quantity;
                clotheToUpdate.IsShort = newClothe.IsShort;
                clotheToUpdate.IsDryFit = newClothe.IsDryFit;
                clotheToUpdate.Gender = newClothe.Gender;
                clotheToUpdate.Company = newClothe.Company;
                clotheToUpdate.PickLink = newClothe.PickLink;
                DataContext.SubmitChanges();
                return Ok(DataContext.Clothings.ToList()); ;
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
                DataContext.Clothings.DeleteOnSubmit(DataContext.Clothings.First(clothe => clothe.Id == id));
                DataContext.SubmitChanges();
                return Ok(DataContext.Clothings.ToList()); ;
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
