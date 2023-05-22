using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using thepathbackend.Models;
using thepathbackend.Models.DTO;
using thepathbackend.Services.Context;
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace thepathbackend.Services
{
    public class UserService : ControllerBase
    {
        private readonly DataContext _context;
        public UserService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<UserModel> GetAllUsers()
        {
            return _context.UserInfo;
        }


        public bool DoesUserExist(string? Username)
        {
            //check the database table if username exists
            //if 1 item matches the condition, return the item
            //if no item matches the condition, retull null
            //if multiple item matches, an error will occur

            return _context.UserInfo.SingleOrDefault(user => user.Username == Username) != null;
            // returns an object, it check if null or not.  explanation below:
            // object !null; true
            // null != null; false
        }


        public bool AddUser(CreateAccountDTO UserToAdd)
        {
            // if the user already exists
            // if they do not exist, we can have account created
            bool result = false;
            if (!DoesUserExist(UserToAdd.Username))
            {
                // if the user does nto exist
                // calling the UserModel and create a new instance of user model (empty object)
                UserModel newUser = new UserModel();
                //create our salt and hash password
                var hashPassword = HashPassword(UserToAdd.Password);
                newUser.Id = UserToAdd.Id;
                newUser.Username = UserToAdd.Username;
                newUser.salt = hashPassword.Salt;
                newUser.Hash = hashPassword.Hash;

                _context.Add(newUser);
                //this saves to our database and return the number of entries that was written to our database
                // _context.SaveChanges();
                result = _context.SaveChanges() != 0;
            }
            return result;
            // else throw a false
        }

        public bool UpdatePassword(CreateAccountDTO newPassword)
        {
            bool result = false;
            if (DoesUserExist(newPassword.Username))
            {
                UserModel userToUpdate = GetUserByUsername(newPassword.Username);
                var hashPassword = HashPassword(newPassword.Password);
                userToUpdate.salt = hashPassword.Salt;
                userToUpdate.Hash = hashPassword.Hash;

                result = _context.SaveChanges() != 0;
            }

            return result;
        }


        //this also checks the password
        public PasswordDTO HashPassword(string? password)
        {
            PasswordDTO newHashPassword = new PasswordDTO();
            byte[] SaltByte = new byte[64];
            var provider = new RNGCryptoServiceProvider();
            // enhance rng of numbers without using zero
            provider.GetNonZeroBytes(SaltByte);

            //encoding the 64 digits to string
            //salt makes the hash unique to the user
            //if we only have a hash password, if people have the same password, the hash woul dbe the same
            var Salt = Convert.ToBase64String(SaltByte);

            //takes the password created, using salt, and goes through 10000 iterations to create a hash
            Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, SaltByte, 10000);

            //encoding our password with our salt
            //if anyone would brute force, it would take a decade
            var Hash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            newHashPassword.Salt = Salt;
            newHashPassword.Hash = Hash;

            return newHashPassword;
        }

        public bool VerifyUserPassword(string? Password, string? storedHash, string? storedSalt)
        {
            //get existing salt and change it to base 64 string
            var SaltBytes = Convert.FromBase64String(storedSalt);

            //making the password that the user inputed and using the stored salt
            var rfc2898DeriveBytes = new Rfc2898DeriveBytes(Password, SaltBytes, 10000);

            //created the new hash
            var newHash = Convert.ToBase64String(rfc2898DeriveBytes.GetBytes(256));

            return newHash == storedHash;
        }


        public IActionResult Login(LoginDTO User)
        {
            //Want to return an error code if the user does not have a valid username or password
            IActionResult Result = Unauthorized();

            //check to see if the user exists
            if (DoesUserExist(User.Username))
            {
                //true
                //we want to store the user object
                //To create another helper function
                UserModel foundUser = GetUserByUsername(User.Username);
                //check if the possword is correct
                if (VerifyUserPassword(User.Password, foundUser.Hash, foundUser.salt))
                {
                    var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                    var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                    var tokeOptions = new JwtSecurityToken(
                        issuer: "http://localhost:5000",
                        audience: "http://localhost:5000",
                        claims: new List<Claim>(),
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signinCredentials
                    );
                    var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);
                    Result = Ok(new { Token = tokenString });
                }
            }
            return Result;
        }

        public UserModel GetUserByUsername(string? username)
        {
            return _context.UserInfo.SingleOrDefault(user => user.Username == username);
        }

        public bool UpdateUser(UserModel userToUpdate)
        {
            //This one is sending over the whole object to be updated
            _context.Update<UserModel>(userToUpdate);
            return _context.SaveChanges() != 0;
        }


        public bool UpdateUser(int id, string username)
        {
            //This one is sending over just the id and username
            //we have to get the object to then be updated
            UserModel foundUser = GetUserById(id);
            bool result = false;
            //helper function
            if (foundUser != null)
            {
                //A user was found
                foundUser.Username = username;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }


                public bool UpdateUserPassword(int id, string username, string Hash, string salt)
        {
            //This one is sending over just the id and username
            //we have to get the object to then be updated
            UserModel foundUser = GetUserById(id);
            bool result = false;
            //helper function
            if (foundUser != null)
            {
                //A user was found
                foundUser.Username = username;
                foundUser.Hash = Hash;
                foundUser.salt = salt;
                _context.Update<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }


        public UserModel? GetUserById(int id)
        {
            return _context.UserInfo.SingleOrDefault(UserModel => UserModel.Id == id);
        }

        public bool DeleteUser(string userToDelete)
        {
            //this one is just sending over the username
            //we have to get the object to be deleted
            UserModel foundUser = GetUserByUsername(userToDelete);
            bool result = false;
            if (foundUser != null)
            {
                //A user was found
                _context.Remove<UserModel>(foundUser);
                result = _context.SaveChanges() != 0;
            }
            return result;
        }

        public bool UpdateUsername(int id, string userName, string firstName, string lastName, string aboutMe, string image, string academyName, string belt)
        {
            bool result = false;

            // Get the user from the database
            UserModel foundUser = GetUserById(id);

            if (foundUser != null)
            {
                // Update the user's properties
                foundUser.Username = userName;
                foundUser.FirstName = firstName;
                foundUser.LastName = lastName;
                foundUser.AboutMe = aboutMe;
                foundUser.image = image;
                foundUser.AcademyName = academyName;
                foundUser.Belt = belt;

                // Mark the user as modified and exclude the Hash and salt properties
                _context.Entry(foundUser).State = EntityState.Modified;
                _context.Entry(foundUser).Property(u => u.Hash).IsModified = false;
                _context.Entry(foundUser).Property(u => u.salt).IsModified = false;
                _context.Entry(foundUser).Property(u => u.Username).IsModified = true;
                _context.Entry(foundUser).Property(u => u.FirstName).IsModified = true;
                _context.Entry(foundUser).Property(u => u.LastName).IsModified = true;
                _context.Entry(foundUser).Property(u => u.AboutMe).IsModified = true;
                _context.Entry(foundUser).Property(u => u.image).IsModified = true;
                _context.Entry(foundUser).Property(u => u.AcademyName).IsModified = true;
                _context.Entry(foundUser).Property(u => u.Belt).IsModified = true;

                // Save changes to the database

                result = _context.SaveChanges() != 0;
            }
            return result;
        }


        public UserIdDTO GetUserIdDTOByUsername(string username)
        {
            var UserInfo = new UserIdDTO();
            var foundUser = _context.UserInfo.SingleOrDefault(user => user.Username == username);
            UserInfo.UserId = foundUser.Id;
            UserInfo.PublisherName = foundUser.Username;
            return UserInfo;
        }
    }
}

