using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TourMe.Service;
using TourMe.Model.Model;
using TourMe.ViewModel;

namespace TourMe.Controllers
{
    public class UserController : ApiController
    {
        private readonly IUserService _UserService;

        //Constructor
        public UserController (IUserService _UserService)
        {
            this._UserService = _UserService;
        }

        //Get All Users
        public IHttpActionResult Get()
        {
            var Users = _UserService.GetUsers();
            List<UserViewModel> users = new List<UserViewModel>();
            foreach (var u in Users)
            {
                UserViewModel uvm = new UserViewModel();
                uvm.DateCreate = u.DateCreate;
                uvm.DateUpdate = u.DateUpdate;
                uvm.Email = u.Email;
                uvm.Id = u.Id;
                uvm.ImageId = u.ImageId;
                uvm.Username = u.Username;
                uvm.Password = u.Password;
                uvm.Role = u.Role;
                users.Add(uvm);
            }
            return Ok(users);
        }

        //Update User
        public IHttpActionResult Update(UserViewModel UserViewModel)
        {
            var User = _UserService.GetUser(UserViewModel.Id);
            User.Password = UserViewModel.Password;
            User.isEnable = UserViewModel.isEnable;
            User.ImageId = UserViewModel.ImageId;
            User.Role = UserViewModel.Role;
            User.Email = UserViewModel.Email;
            User.DateUpdate = DateTime.Now;
            _UserService.EditUser(User);
            return Ok();
        }

        //Destroy User By Id
        public IHttpActionResult Destroy(int id)
        {
            var User = _UserService.GetUser(id);
            User.isEnable = false;
            User.DateUpdate = DateTime.Now;
            _UserService.EditUser(User);
            return Ok();
        }

        //Destroy User by ViewModel
        public IHttpActionResult Destroy(UserViewModel UserViewModel)
        {
            _UserService.RemoveUser(UserViewModel.Id);
            return Ok();
        }

        //Create User
        [HttpPost]
        public IHttpActionResult Create(UserViewModel user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            User User = new User();
            User.Username = user.Username;
            User.Password = user.Password;
            User.isEnable = user.isEnable;
            User.ImageId = user.ImageId;
            User.Role = user.Role;
            User.Email = user.Email;
            user.DateCreate = DateTime.Now;
            _UserService.CreateUser(User);
            return Ok();
        }
    }
}
