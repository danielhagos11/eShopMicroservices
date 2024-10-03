
//using Catalog.API.Data;
//using Marten;
//using Microsoft.AspNetCore.Http.HttpResults;
//using Microsoft.Extensions.Logging;
//using static FastExpressionCompiler.ExpressionCompiler;
//using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

//namespace Catalog.API.Products.Queries
//{
//    //public record ProductByCategoryQuery(string Category)
//        //: IQuery<GetProductByCategoryResult>;
//    //public record GetProductByCategoryResult(IEnumerable<Product> products);
//    public class ProductByCategoryHandler : IRequestHandler<GetProductByCategoryQuery, IEnumerable<Product>>
//    {
//        private readonly ILogger _logger;
//        private readonly ProductCatalogDbContext _context;
//        public ProductByCategoryHandler(ILogger logger, ProductCatalogDbContext context)
//        {
//            _logger = logger;
//            _context = context;
//        }

//        public async Task<IEnumerable<Product>> Handle(GetProductByCategoryQuery request, CancellationToken cancellationToken)
//        {
//            //_logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@Query}", request);
//            var products = await _context.Products
//                      .Where(p => p.Category.Contains(request.productCategory)).ToListAsync();
//            if (products == null) return null;
//            //return new GetProductByCategoryResult(products);
//            return products;
//        }

//    }



//    //public record ProductByCategoryQuery(string Category) 
//    //    : IQuery<GetProductByCategoryResult>;
//    //public record GetProductByCategoryResult(IEnumerable<Product> products);
//    //public class GetProductByCategoryHandler(
//    //    ILogger<GetProductByCategoryHandler> logger,
//    //    ProductCatalogDbContext context
//    //    )
//    //    : IQueryHandler<GetProductByCategoryQuery, GetProductByCategoryResult>
//    //{
//    //    public async Task<GetProductByCategoryResult> Handle(GetProductByCategoryQuery query, CancellationToken cancellationToken)
//    //    {
//    //        logger.LogInformation("GetProductByCategoryQueryHandler.Handle called with {@Query}", query);
//    //        var products = await context.Products
//    //            .Where(p => p.Category.Contains(query.Category)).ToListAsync(); ;

//    //        return new GetProductByCategoryResult(products);
//    //    }
//    //}
//}
