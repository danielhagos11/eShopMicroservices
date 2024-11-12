using Catalog.API.Products.Command;
using Catalog.API.Products.Endpoints;
using Catalog.API.Products.Queries;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger _logger;
        private TelemetryClient telemetry = new TelemetryClient();
        public ProductsController(IMediator mediator, ILogger<ProductsController> logger)
        {
            this._logger = logger;
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
            _logger.LogInformation("This endpoint visited at {DT}",
            DateTime.UtcNow.ToLongTimeString());
            var query = new GetProductQuery(id);
            if (query.productId != id) 
            {
                var dictionary = new Dictionary<string, Guid>();
                dictionary.Add("id",id);
                telemetry.TrackEvent("FilteredOnStatus", (IDictionary<string, string>)dictionary);
                _logger.LogWarning(ProductLogEvent.GetItemNotFound, "Get({Id}) NOT FOUND", id);
            }
            _logger.LogInformation(ProductLogEvent.GetItem, "Getting item {Id}", id);

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
