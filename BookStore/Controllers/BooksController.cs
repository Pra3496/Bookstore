using Bussiness.Interface;
using Common.Model;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Reflection;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {

        private readonly IBookBussiness bookBussiness;

        private readonly IWebHostEnvironment webHostEnvironment;

        public BooksController(IBookBussiness bookBussiness, IWebHostEnvironment webHostEnvironment)
        {
            this.bookBussiness = bookBussiness;
            this.webHostEnvironment = webHostEnvironment;
        }


        [HttpGet]
        public IActionResult Index()
        {
            try
            {

                var result = this.bookBussiness.GetAllBook();

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
        public IActionResult AddBook()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddBook(BookModel model)
        {

            try
            {
                string imageURL = ProcessUploadedFile(model.UploadImages);

               

                model.Images = imageURL;

                if (ModelState.IsValid)
                {
                    var result = this.bookBussiness.AddBook(model);

                    if (result != null)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return NotFound();
                    }
                }
                else
                {
                    return NotFound();
                }
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
       
        }


        [HttpGet]
        public IActionResult BookDetails(long BookId)
        {
            try
            {

                var result = this.bookBussiness.GetAllBook().FirstOrDefault(x => x.BookId == BookId);

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
        public IActionResult BookEdit(long BookId)
        {
            try
            {

                var result = this.bookBussiness.GetAllBook().FirstOrDefault(x => x.BookId == BookId);

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
        public IActionResult BookEdit(BookModel model)
        {
            try
            {
                if(model.UploadImages != null)
                {
                    model.Images = ProcessUploadedFile(model.UploadImages);
                }

                var result = this.bookBussiness.UpdateBook(model);

                if (result != false)
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
        public IActionResult BookDelete(long BookId)
        {
            try
            {

                var result = this.bookBussiness.GetAllBook().FirstOrDefault(x => x.BookId == BookId);

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
        public IActionResult BookDeleteById(long BookId)
        {
            try
            {

                var result = this.bookBussiness.DeleteBook(BookId);

                if (result != false)
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


        private string ProcessUploadedFile(IFormFile SpeakerPicture)
        {
            string uniqueFileName = null;

            if (SpeakerPicture != null)
            {
                string uploadsFolder = Path.Combine(webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + SpeakerPicture.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    SpeakerPicture.CopyTo(fileStream);
                }
            }

            return uniqueFileName;
        }





    }
}
