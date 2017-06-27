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
    public class PostController : ApiController
    {
        private PostRepository repository;

        public PostController()
        {
            repository = new PostRepository();
        }

        [HttpGet]
        [Route("api/post")]
        public IHttpActionResult GetAllPostInfo()
        {
            try
            {
                var items = repository.GetAllPostsInfo();

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
        [Route("api/post/{P_Id}")]
        public IHttpActionResult GetPostInfoById(int P_Id)
        {
            try
            {
                var item = repository.GetPostInfoById(P_Id);

                if (!item.Any())
                    return Content(HttpStatusCode.NotFound, $"ID = {P_Id} is not found.Please provide a valid parameter.");
                else
                    return Ok(item);
            }
            catch
            {
                return BadRequest("Failed to get data from database.Please check your parameters again.");
            }
        }

        [HttpPost]
        [Route("api/post")]
        public IHttpActionResult AddNewPostInfo([FromBody]Post post)
        {
            try
            {
                if(ModelState.IsValid && post != null)
                {
                    var statusCode = repository.AddNewPostInfo(post);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest("Failed to add a new data into database.Please check your parameters again.");
                    else
                        return Ok("success to add a new data.");
                }
                else
                    return BadRequest("Failed to add a new data.Please check your url again.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpDelete]
        [Route("api/post/{P_Id}")]
        public IHttpActionResult DeletePostInfoById(int P_Id)
        {
            try
            {
                var statusCode = repository.DeletePostById(P_Id);

                if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest($"Failed to delete ID = {P_Id}'s data.Please check url again.");
                else
                    return Ok($"success to delete ID = {P_Id}'s data.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}
