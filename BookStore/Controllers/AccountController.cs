using Bussiness.Interface;
using Bussiness.Service;
using Common.Model;
using Microsoft.AspNetCore.Mvc;
using System;

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
          
                return View();
            
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Index(RegisterModel model)
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
    }
}
