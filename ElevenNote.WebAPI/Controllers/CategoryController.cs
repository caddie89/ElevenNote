using ElevenNote.Models;
using ElevenNote.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ElevenNote.WebAPI.Controllers
{
    public class CategoryController : ApiController
    {
        //// GET all notes
        //[HttpGet]
        //public IHttpActionResult Get()
        //{
        //    CategoryService categoryService = CreateCategoryService();
        //    var notes = categoryService.GetCategories();
        //    return Ok(notes);
        //}

        ////GET notes by Id (needs a corresponding service method)
        //[HttpGet]
        //public IHttpActionResult Get(int id)
        //{
        //    CategoryService categoryService = CreateCategoryService();
        //    var category = categoryService.GetNoteById(id);
        //    return Ok(note);
        //}

        // POST
        [HttpPost]
        public IHttpActionResult Post(CategoryCreate category)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateCategoryService();

            if (!service.CreateCategory(category))
                return InternalServerError();

            return Ok();
        }

        private CategoryService CreateCategoryService()
        {
            var categoryService = new CategoryService();
            return categoryService;
        }
    }
}
