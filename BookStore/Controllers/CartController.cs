using Bussiness.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using System;
using Common.Model;
using System.Linq;
using System.Collections.Generic;
using System.Net;

namespace BookStore.Controllers
{
    public class CartController : Controller
    {

        private readonly ICartBussiness cartBussiness;

        private readonly IBookBussiness bookBussiness;

        public CartController(ICartBussiness cartBussiness, IBookBussiness bookBussiness)
        {
             this.cartBussiness = cartBussiness;
             this.bookBussiness = bookBussiness;
        }

        [HttpGet]
        public IActionResult IndexCart()
        {
            string userID = HttpContext.Session.GetString("userId");
            

            try
            {
                if (userID == null)
                {
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    long UserId = long.Parse(userID);

                    var resultCart = this.cartBussiness.GetAllUsers();
                    var userCart = resultCart.Where(x => x.UserId == UserId).ToList();

                    List<CartViewModel> Cartlist = new List<CartViewModel>();

                    foreach (var user in resultCart)
                    {
                        var book = this.bookBussiness.GetAllBook().FirstOrDefault(x => x.BookId == user.BookId);
                        CartViewModel viewModel = new CartViewModel()
                        {
                            CartId = user.CartId,
                            UserId = user.UserId,
                            BookId = user.BookId,
                            BookName = book.BookName,
                            Author = book.Author,
                            Details = book.Details,
                            Price = book.Price,
                            Images = book.Images

                        };

                        Cartlist.Add(viewModel);

                    }




                    return View(Cartlist);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpPost]
        public IActionResult AddToCart(long BookId)
        {
            string userID = HttpContext.Session.GetString("userId");
            CartModel model = new CartModel();
            try
            {
                if (userID != null)
                {
                   return RedirectToAction("Login", "Account");

                }

                model.UserId = long.Parse(userID);
                model.BookId = BookId;

                var result = this.cartBussiness.AddToCart(model);

                return RedirectToAction("IndexCart", "Cart");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
    
        }

        [HttpGet]
        public IActionResult DeleteCart(long CartId)
        {
            try
            {
                string userID = HttpContext.Session.GetString("userId");

                if (userID == null)
                {
                    return RedirectToAction("Login", "Account");

                }

                var result = this.cartBussiness.DeleteFromCart(CartId);

                return RedirectToAction("IndexCart", "Cart");

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }


      

       


    }
}
