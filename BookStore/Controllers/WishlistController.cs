using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Net;

namespace BookStore.Controllers
{
    public class WishlistController : Controller
    {

        private readonly IWishlistBussiness wishlistBussiness;

        private readonly IBookBussiness bookBussiness;

        public WishlistController(IWishlistBussiness wishlistBussiness, IBookBussiness bookBussiness)
        {
            this.wishlistBussiness = wishlistBussiness;
            this.bookBussiness = bookBussiness;
        }

        [HttpGet]
        public IActionResult WishlistIndex()
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

                    var resultwish = this.wishlistBussiness.GetAllWishlist();
                    var userwish = resultwish.Where(x => x.UserId == UserId).ToList();

                    List<WishlistViewModel> Wishlist = new List<WishlistViewModel>();

                    foreach (var user in userwish)
                    {
                        var book = this.bookBussiness.GetAllBook().FirstOrDefault(x => x.BookId == user.BookId);
                        WishlistViewModel viewModel = new WishlistViewModel()
                        {
                            WishListId = user.WishListId,
                            UserId = user.UserId,
                            BookId = user.BookId,
                            BookName = book.BookName,
                            Author = book.Author,
                            Details = book.Details,
                            Price = book.Price,
                            Images = book.Images

                        };

                       Wishlist.Add(viewModel);
                    }

                    return View(Wishlist);
                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet]
        public IActionResult AddToWishlist(long BookId)
        {
            string userID = HttpContext.Session.GetString("userId");
            WishlistModel model = new WishlistModel();

            try
            {
                if (userID == null)
                {
                    return RedirectToAction("Login", "Account");

                }
                else
                {
                    model.BookId = BookId;
                    long UserId = long.Parse(userID);
                    model.UserId = UserId;

                    var resultwish = this.wishlistBussiness.AddToWishlist(model);

                    return RedirectToAction("WishlistIndex", "Wishlist");

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }



        [HttpGet]
        public IActionResult RemoveWishlist(long WishlistId)
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


                    var resultwish = this.wishlistBussiness.RemoveFromWishlist(WishlistId);

                    return RedirectToAction("WishlistIndex", "Wishlist");

                }

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
