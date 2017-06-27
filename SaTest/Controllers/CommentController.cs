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
    public class CommentController : ApiController
    {
        private CommentRepository repository;

        public CommentController()
        {
            repository = new CommentRepository();
        }

        [HttpGet]
        [Route("api/comment")]
        public IHttpActionResult GetAllComments()
        {
            try
            {
                var items = repository.GetAllComments();

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
        [Route("api/comment/{C_Id}")]
        public IHttpActionResult GetCommentInfoById(int C_Id)
        {
            try
            {
                var items = repository.GetCommentInfoById(C_Id);

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
        [Route("api/comment")]
        public IHttpActionResult AddNewCommentInfo([FromBody] Comment comment)
        {
            try
            {
                if(ModelState.IsValid && comment != null)
                {
                    var statusCode = repository.AddNewCommentInfo(comment);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest("Failed to add a new data into database.Please check parameters again.");
                    else
                        return Ok("success to add a new data into database.");
                }
                else
                    return BadRequest("Failed to add a new data into database.Please provide valid parameters.");

            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpDelete]
        [Route("api/comment/{C_Id}")]
        public IHttpActionResult DeleteCommentById(int C_Id)
        {
            try
            {
                var statusCode = repository.DeleteCommentById(C_Id);
                if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest($"Failed to delete ID = {C_Id}'s data.Please check your parameters again.");
                else
                    return Ok($"success to delete ID = {C_Id}'s data");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

    }
}
