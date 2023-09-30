using CFMDomainModel;
using CFMServices.Config;
using CFMServices.Helper;
using CFMServices.Interface;
using CFMServices.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CFMServices.Implementation
{
    public class UserService : IUserService
    {
        private readonly CFMContext _context; 
        public UserService(CFMContext context)
        {
            _context = context;            
        }

        public async Task<Validation> ValidateUser(string usermailid)
        {
            Validation validation = new Validation();
            User result = await _context.Users.Where(u => u.UserMail == usermailid).FirstOrDefaultAsync();
            if (result != null)
            {
                validation.IsError = true;
                validation.Message = "User mail id already exists.";
                return validation;
            }
            return validation;
        }

        public async Task<bool> AddUser(User user, string password)
        {
            user.HashSalt= PasswordHasher.GenerateSalt();
            user.PasswordSalt = PasswordHasher.ComputeHMAC_SHA256(Encoding.ASCII.GetBytes(password), user.HashSalt);

            _context.Users.Add(user);
            return await _context.SaveChangesAsync()>0?true:false;

        }

        public Task<bool> DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<ValidationModel<User>> Login(string usermaildid, string password)
        {
            ValidationModel<User> validationModel = new ValidationModel<User>();
            User user = await _context.Users.Where(u => u.UserMail == usermaildid).FirstOrDefaultAsync();

        

            if (user == null)
            {
                validationModel.IsError= true;
                validationModel.Message = "User does not exists";      
                return validationModel;
            }

            byte[] passwordhash = PasswordHasher.ComputeHMAC_SHA256(Encoding.ASCII.GetBytes(password), user.HashSalt);
            //byte[] userPasswordHash = PasswordHasher.ComputeHMAC_SHA256(user.PasswordSalt, user.HashSalt);
            if (user.IsLocked)
            {
                validationModel.IsError = true;
                validationModel.Message = "User is locked, please contact administrator.";
                return validationModel;
            }
            if(!passwordhash.SequenceEqual(user.PasswordSalt))
            {
                user.NoOfFailedAttempts = user.NoOfFailedAttempts++;

                if(user.NoOfFailedAttempts>3)
                {
                    validationModel.IsError = true;
                    validationModel.Message = "You have entered incorrect passowrd for more than three times. Your account is locked. Please contact administrator.";
                    user.IsLocked= true;
                }
                _context.Users.Update(user);
                await _context.SaveChangesAsync();

                if(validationModel.IsError == false)
                {
                    validationModel.IsError = true;
                    validationModel.Message = "Incorrect password.";
                }              
            }
            validationModel.Model = user;
            return validationModel;
        }

        public Task<bool> Logout(string usermaildid)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
