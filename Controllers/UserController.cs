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

        [HttpGet]
        [Route("GetAllUsers")]

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _data.GetAllUsers();
        }



        [HttpGet]
        [Route("UserByUserName/{username}")]
        public UserIdDTO GetUserByUsername(string username)
        {
            return _data.GetUserIdDTOByUsername(username);
        }


        //login endpoint
        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO User)
        {
            return _data.Login(User);
        }

        [HttpGet]
        [Route("GetUserById/{id}")]
        public UserModel GetUserById(int id)
        {
            return _data.GetUserById(id);
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
            return _data.UpdateUser(id, username);
        }

        [HttpPut]
        [Route("UpdateUser/{id}")]
        public bool UpdateUser(int id, [FromBody] UserProfile UserProfile)
        {
            return _data.UpdateUsername(id, UserProfile.Username, UserProfile.FirstName, UserProfile.LastName, UserProfile.AboutMe, UserProfile.image, UserProfile.AcademyName, UserProfile.Belt);
        }


        //delete user account
        [HttpDelete]
        [Route("DeleteUser/{userToDelete}")]
        public bool DeleteUser(string userToDelete)
        {
            return _data.DeleteUser(userToDelete);
        }

        // [HttpPut]
        // public IActionResult UpdateUser(int id, string username){
        //     var updatedBook = _data.
        // }
    }
}