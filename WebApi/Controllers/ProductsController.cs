using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [Authorize()]
        [HttpGet("getall")]

        public IActionResult GetAll()
        {
            var result=_productService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [Authorize()]
        [HttpGet("getbyid")]

        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles ="admin")]
        [HttpPost("add")]

        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.Success) 
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles = "admin")]
        [HttpPost("delete")]

        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }

        [Authorize(Roles ="admin")]
        [HttpPost("update")]

        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.Success)
            {
                return Ok(result.Message);
            }
            return BadRequest(result.Message);
        }
    }
}
