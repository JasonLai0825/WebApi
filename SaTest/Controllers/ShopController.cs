using SaTest.Models;
using SaTest.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SaTest.Controllers
{
    public class ShopController : ApiController
    {
        private ShopRepository repository;

        public ShopController()
        {
            repository = new ShopRepository();
        }

        [HttpGet]
        [Route("api/shop")]
        public IHttpActionResult GetAllShopInfo()
        {
            try
            {
                var items = repository.GetAllShopInfo();
                if (!items.Any())
                    return Content(HttpStatusCode.NoContent, "There's no content in database.");
                else
                    return Ok(items);

            }
            catch
            {
                return BadRequest("Failed to get data from database.Please check url again.");
            }
        }

        [HttpGet]
        [Route("api/shop/{S_Id}")]
        public IHttpActionResult GetShopInfoById(int S_Id)
        {
            try
            {
                var item = repository.GetShopInfoById(S_Id);
                if (!item.Any())
                    return Content(HttpStatusCode.NotFound, $"ID = {S_Id} is not found.Please provide a valid parameter.");
                else
                    return Ok(item);
            }
            catch
            {
                return BadRequest("Failed to get data from database.Please check url again.");
            }
        }

        [HttpPost]
        [Route("api/shop")]
        public IHttpActionResult AddNewShopInf([FromBody]Shop shop)
        {
            try
            {
                if (ModelState.IsValid && shop != null)
                {
                    var statusCode = repository.AddNewShopInfo(shop);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest("Failed to add new data into database.Please check url again.");
                    else
                        return Ok("success to add a new data.");
                }
                else
                    return BadRequest("Failed to add a new data.Please provide complete parameters."); ;
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPatch]
        [Route("api/shop/status/{S_Id}")]
        public IHttpActionResult ChangeShopStatusById(int S_Id,[FromBody]Shop shop)
        {
            try
            {
                if (ModelState.IsValid && shop != null)
                {
                    var statusCode = repository.ChangeShopStatusById(S_Id, shop.S_Status);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest($"Failed to change ID = {S_Id}'s status.Please check url again.");
                    else
                        return Ok($"success to change ID = {S_Id}'s status.");
                }
                else
                    return BadRequest($"Failed to change ID = {S_Id}'s status.Please check your parameters again.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPatch]
        [Route("api/shop/evaluation/{S_Id}")]
        public IHttpActionResult ChangeShopEvaluationById(int S_Id,[FromBody]Shop shop)
        {
            try
            {
                if(ModelState.IsValid && shop != null)
                {
                    var statusCode = repository.ChangeShopEvaluationById(S_Id, shop.S_Evaluation);
                    
                    if(statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest($"Failed to change ID = {S_Id}'s evaluation.Please check url again.");
                    else
                        return Ok($"success to change ID = {S_Id}'s evaluation.");
                }
                else
                    return BadRequest($"Failed to change ID = {S_Id}'s evaluation.Please check your parameters again.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
