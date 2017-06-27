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
    public class SubscriptionController : ApiController
    {
        private SubscriptionRepository repository;

        public SubscriptionController()
        {
            repository = new SubscriptionRepository();
        }

        [HttpGet]
        [Route("api/subscription")]
        public IHttpActionResult GetAllSubscriptions()
        {
            try
            {
                var items = repository.GetAllSubscription();

                if (!items.Any())
                    return Content(HttpStatusCode.NoContent, "There's no content in database.");
                else
                    return Ok(items);
            }
            catch
            {
                return BadRequest("Failed to get data from database.Please check your parameters again.");
            }
        }

        [HttpGet]
        [Route("api/subscription/{MId}")]
        public IHttpActionResult GetSubscriptionById(int MId)
        {
            try
            {
                var items = repository.GetSubscriptionById(MId);

                if (!items.Any())
                    return Content(HttpStatusCode.NoContent, "There's no content in database.");
                else
                    return Ok(items);
            }
            catch
            {
                return BadRequest("Failed to get data from database.Please check your parameters again.");
            }
        }

        [HttpPost]
        [Route("api/subscription")]
        public IHttpActionResult AddNewSubscription([FromBody]Subscription sub)
        {
            try
            {
                if (ModelState.IsValid && sub != null)
                {
                    var statusCode = repository.AddNewSubscription(sub);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest("Failed to add a new data into database.Please check parameters again.");
                    else
                        return Ok("success to add a new data into database.");
                }
                else
                    return BadRequest("Failed to add a new data into database.Please provide valid parameters.");

            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        [HttpDelete]
        [Route("api/subscription/{MId}")]
        public IHttpActionResult DeleteSubscriptionById(int MId)
        {
            try
            {
                var statusCode = repository.DeleteSubscriptionById(MId);

                if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest($"Failed to delete ID = {MId}'s data.PLease check url again.");
                else
                    return Ok($"success to delete ID = {MId}'s data.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

    }
}
