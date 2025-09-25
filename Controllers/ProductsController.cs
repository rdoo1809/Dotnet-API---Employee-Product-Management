using Assignment1_PROG3340.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Assignment1_PROG3340
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController: ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET /api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(_unitOfWork.Products.GetAll());
        }

        // GET: /api/products/{id}
        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null) return NotFound();
            return product;
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> Product(Product product)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            _unitOfWork.Products.Add(product);
            _unitOfWork.Complete();
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        // Put: api/products/{id}
        [HttpPut("{id}")]
        public ActionResult<Product> UpdateProduct(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            _unitOfWork.Products.Update(product);
            _unitOfWork.Complete();
            return Ok(product);
        }

        // Delete: api/products/{id}
        [HttpDelete("{id}")]
        public ActionResult<Product> DeleteProduct(int id)
        {
            var product = _unitOfWork.Products.GetById(id);
            if (product == null) return NotFound();
            _unitOfWork.Products.Delete(product);
            _unitOfWork.Complete();
            return product;
        }
    }
}