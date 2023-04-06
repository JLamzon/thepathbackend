using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Models.DTO;
using thepathbackend.Services;
using Microsoft.AspNetCore.Mvc;

namespace thepathbackend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {

        //no logic in user controller

        //this tells usercontroller we can only read, not write
        private readonly UserService _data;

        //
        public UserController(UserService dataFromService)
        {
            _data = dataFromService;
        }


        //login endpoint
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        //add a user endpoint
        // if th user already exists
        // if they do not exist, we can have account created
        // else throw a false

        //can also be written = [HttpPost"AddUser]
        [HttpPost]
        [Route("AddUser")]

        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            return _data.AddUser(UserToAdd);
        }

        // public IEnumerable<BlogItemModel> GetAllUsers()
        // {
        //     return _data.GetAllUsers();
        // }

        //update user account
        [HttpPost]
        [Route("UpdateUser")]
        public bool UpdateUser(UserModel userToUpdate)
        {
            return _data.UpdateUser(userToUpdate);
        }

        [HttpPost]
        [Route("UpdateUser/{id}/{username}")]
        public bool UpdateUser(int id, string username)
        {
            return _data.UpdateUsername(id, username);
        }


        //delete user account
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }
    }
}