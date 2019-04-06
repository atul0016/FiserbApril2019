using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_ApiApp.Models;
using Core_ApiApp.Services;
namespace Core_ApiApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IRepository<Category, int> catRepository;

        public CategoryController(IRepository<Category, int> catRepository)
        {
            this.catRepository = catRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var cats = catRepository.Get();
            return Ok(cats);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var cat = catRepository.Get(id);
            if (cat == null)
            {
                return NotFound($"Category based on {id} is either not found or deleted");
            }
            return Ok(cat);
        }

        //[HttpPost("{catId}/{catName}/{basePrice}")]
        [HttpPost]
        public IActionResult Post(Category category)
        //public IActionResult Post(string catId, string catName, int basePrice)
        {

            #region Commented Code
            //Category category = new Category()
            //{
            //     CategoryId = catId,
            //     CategoryName = catName,
            //     BasePrice = basePrice
            //}; 
            #endregion
            // validate the posted model
             
                if (ModelState.IsValid)
                {
                    if (category.BasePrice <= 0)
                        throw new Exception("Please set Base Price as Positive Non-Zero Value");
                    category = catRepository.Create(category);
                    return Ok(category);
                }
                // respond with Model Vlidation Errors
                return BadRequest(ModelState);
             
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Category category)
        {
            // 1. check id id matches with CatrgoryRowId
            if (id == category.CategoryRowId)
            {
                var res = catRepository.Update(id,category);
                if (!res)
                {
                    return NotFound($"Update failed becuse result is {res} Record with {id} not found");
                }
                return Ok($"Record Updated Successfully {res}");
            }
            return BadRequest($"The URL Value {id} does not match with Body data {category.CategoryRowId}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = catRepository.Delete(id);
            if (!res)
            {
                return NotFound($"Delete failed becuse result is {res} Record with {id} not found");
            }
            return Ok($"Record Deleted Successfully {res}");
        }
    }
}