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
    public class ProductController : ControllerBase
    {
        IRepository<Product, int> prdRepository;

        public ProductController(IRepository<Product, int> prdRepository)
        {
            this.prdRepository = prdRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var prds = prdRepository.Get();
            return Ok(prds);
        }
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var prd = prdRepository.Get(id);
            if (prd == null)
            {
                return NotFound($"Product based on {id} is either not found or deleted");
            }
            return Ok(prd);
        }

        [HttpPost]
        public IActionResult Post(Product product)
        {
            // validate the posted model
            if (ModelState.IsValid)
            {
                product = prdRepository.Create(product);
                return Ok(product);
            }
            // respond with Model Vlidation Errors
            return BadRequest(ModelState);
        }
        [HttpPut("{id}")]
        public IActionResult Put(int id, Product product)
        {
            if (id == product.ProductRowId)
            {
                var res = prdRepository.Update(id, product);
                if (!res)
                {
                    return NotFound($"Update failed becuse result is {res} Record with {id} not found");
                }
                return Ok($"Record Updated Successfully {res}");
            }
            return BadRequest($"The URL Value {id} does not match with Body data {product.ProductRowId}");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var res = prdRepository.Delete(id);
            if (!res)
            {
                return NotFound($"Delete failed becuse result is {res} Record with {id} not found");
            }
            return Ok($"Record Deleted Successfully {res}");
        }
    }
}