using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using SportShopApp.Models;

namespace SportShopApp.Controllers.api
{
    public class ShoesController : ApiController
    {
        static string stringConnection = "Data Source=SHIMONSAMAY;Initial Catalog=SportShopDB;Integrated Security=True;Pooling=False";
        public SportShoesDBDataContext DataContext = new SportShoesDBDataContext(stringConnection);

        public IHttpActionResult Get()
        {
            try
            {
                return Ok(DataContext.Shoes.ToList()); ;
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
                return Ok(DataContext.Shoes.First(shoe => shoe.Id == id)); 
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

        
        public IHttpActionResult Post([FromBody]Shoe newShow )
        {
            try
            {
                DataContext.Shoes.InsertOnSubmit(newShow);
                DataContext.SubmitChanges();
                return Ok(DataContext.Shoes.ToList()); ;
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
    

        
        public IHttpActionResult Put(int id, [FromBody] Shoe newShow)
        {
            try
            {
                Shoe shoeToUpdate = DataContext.Shoes.First(shoe => shoe.Id == id);
                shoeToUpdate.ShoeType = newShow.ShoeType;
                shoeToUpdate.Price = newShow.Price;
                shoeToUpdate.Company = newShow.Company;
                shoeToUpdate.OnSale = newShow.OnSale;
                shoeToUpdate.Model = newShow.Model;
                shoeToUpdate.PickLink = newShow.PickLink;
                DataContext.SubmitChanges();
                return Ok(DataContext.Shoes.ToList()); ;
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
                DataContext.Shoes.DeleteOnSubmit(DataContext.Shoes.First(shoe => shoe.Id == id));
                DataContext.SubmitChanges();
                return Ok(DataContext.Shoes.ToList()); ;
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
