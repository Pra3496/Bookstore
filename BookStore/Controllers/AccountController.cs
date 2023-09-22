using Bussiness.Interface;
using Bussiness.Service;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace BookStore.Controllers
{
    public class AccountController : Controller
    {

        private readonly IAccountBussiness accountBussiness;

        public AccountController(IAccountBussiness accountBussiness)
        {
            this.accountBussiness = accountBussiness;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {
                var result = this.accountBussiness.GetAllUsers();

                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
  

        }




        [HttpGet]
        public IActionResult SignUp()
        {
          
                return View();
            
        }



        [HttpPost]
        public IActionResult SignUp(RegisterModel model)
        {
            try
            {
                var result = this.accountBussiness.RegisterUser(model);
                if (result == null) 
                {
                    return View(result);
                }
                else
                {
                    return NotFound();
                }

               
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }



        [HttpGet]
        public IActionResult UserDetails(long UserId)
        {
            try
            {
                var result = this.accountBussiness.GetAllUsers().FirstOrDefault(x => x.UserId == UserId);

                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }




        [HttpGet]
        public IActionResult UpdateUser(long UserId)
        {
            try
            {
                var result = this.accountBussiness.GetAllUsers().FirstOrDefault(x=> x.UserId == UserId);

                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


        [HttpPost]
        public IActionResult UpdateUser(RegisterModel model)
        {
            try
            {
                var result = this.accountBussiness.UpdateUserDetails(model);

                if (result != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        [HttpGet]
        public IActionResult DeleteUser(long UserId)
        {
            try
            {
                var result = this.accountBussiness.GetAllUsers().FirstOrDefault(x => x.UserId == UserId);

                if (result != null)
                {
                    return View(result);
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }



        [HttpDelete]
        public IActionResult DeleteUserById(long UserId)
        {
            try
            {
                var result = this.accountBussiness.DeleteUser(UserId);
                if (result != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}
