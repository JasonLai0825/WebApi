using Newtonsoft.Json;
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
    public class MemberController : ApiController
    {
        private MemberRepository repository;

        public MemberController()
        {
            repository = new MemberRepository();
        }

       [HttpGet]
       [Route("api/member")]
       public IHttpActionResult GetAllMemberInfo()
       {
            try
            {
                var items = repository.GetAllMemberInfo();

                if (!items.Any())
                    return Content(HttpStatusCode.NoContent, "There's no data in database.");
                else
                    return Ok(items);
            }
            catch
            {
                return BadRequest("Failed to get data,please check url again.");
            }
       }

        [HttpGet]
        [Route("api/member/{M_Id}")]
        public IHttpActionResult GetMemberInfoById(int M_Id)
        {
            try
            {
                var items = repository.GetMemberInfoById(M_Id);

                if (!items.Any())
                    return Content(HttpStatusCode.NotFound, $"Id {M_Id} not found.Please provide a valid id.");
                else
                    return Ok(items);
            }
            catch
            {
                return BadRequest("Failed to get data,please check url again.");
            }
        }

        [HttpPost]
        [Route("api/member")]
        public IHttpActionResult AddNewMemberInfo([FromBody] Member member)
        {
            try
            {
                if (ModelState.IsValid && member != null)
                {
                    var statusCode = repository.AddNewMemberInfo(member);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest("Failed to insert a new data into Member.Please check url again.");
                    else
                        return Ok("success to insert a new data into Member");
                }
                else
                    return BadRequest("Failed to insert a new data into Member.Please provide complete parameters.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpPatch]
        [Route("api/member/{M_Id}")]
        public IHttpActionResult ChangePassWordByMId(int M_Id,[FromBody]Member member)
        {
            try
            {
                if (ModelState.IsValid && member != null)
                {
                    var statusCode = repository.ChangePasswordByMId(M_Id, member.passWd);

                    if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                        return BadRequest($"Failed to change {M_Id}'s password.Please check your parameters again.");
                    else
                        return Ok($"success to change ID = {M_Id}'s password");
                }
                else
                    return BadRequest($"Failed to change {M_Id}'s password.Please check your parameters again.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }

        [HttpDelete]
        [Route("api/member/{M_Id}")]
        public IHttpActionResult DeleteMemberInfoById(int M_Id)
        {
            try
            {
                var statusCode = repository.DeleteMemberInfoById(M_Id);

                if (statusCode.StatusCode == HttpStatusCode.BadRequest)
                    return BadRequest($"Failed to delete ID = {M_Id}.Please check your parameters again.");
                else
                    return Ok($"success to delete ID = {M_Id}.");
            }
            catch(Exception ex)
            {
                throw (ex);
            }
        }
    }
}