using Catalog.API.Products.Command;
using Catalog.API.Products.Endpoints;
using Catalog.API.Products.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> Index()
        {
            //specifying the query for the endpoint
            var query = new GetProductsQueries();

            var result = await _mediator.Send(query);

            return Ok(result);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProduct(Guid id)
        {
            var query = new GetProductQuery(id);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Product>> CreateProduct(Product product)
        {
            var query = new CreateProductRequest(product);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(Guid id, Product product)
        {
            var command = new UpdateProductRequest(id, product);
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpGet("category")]
        public async Task<IActionResult> GetProductByCategory(string category)
        {
            var command = new GetProductByCategoryQuery(category);
            var result = await _mediator.Send(command);
            var response = result.Adapt<GetProductByCategoryResponse>();
            return Ok(response);
      
        }

        [HttpDelete("{id}")]
        public async Task<bool> DeleteProduct(Guid id)
        {
            var command = new DeleteProductRequest(id);
            await _mediator.Send(command);
            return true;
        }
    }
}
