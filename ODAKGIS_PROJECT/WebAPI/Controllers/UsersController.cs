using Business.Abstract;
using Entities.TABLES;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserBusService _userservice;
        public UsersController(IUserBusService userservice)
        {
            _userservice = userservice;
        }

        [HttpGet("getalluser")]
        public IActionResult GetList()
        {
            var result = _userservice.GetList();
            if(result.IsSuccess)
            {
                return Ok(result.RecordList);
            }
            return BadRequest(result.Message);

        }

        [HttpGet("getbyuserid")]
        public IActionResult GetByUserID(int id)
        {
            var result = _userservice.GetByID(id);
            if (result.IsSuccess)
            {
                return Ok(result.RecordSingle);
            }
            return BadRequest(result.Message);
        }
        [HttpPost("addnewuser")]
        public IActionResult AddUser(User user)
        {

            var result = _userservice.Add(user);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("updateuser")]
        public IActionResult UpdateUser(User user)
        {
            var result = _userservice.Update(user);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [HttpPost("changepassword")]
        public IActionResult ChangePassword(int userID,string newpassword)
        {
            var result = _userservice.ChangePassword(userID,newpassword);
            if (result.IsSuccess)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

    }
}
