using System.Linq;
using API.Core.DbModels;
using API.Core.Interfaces;
using API.Core.Specifications;
using API.Data.DataContext;
using API.Dtos;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    
    public class HomeController : BaseApiController
    {
        // private readonly StoreContext _context;
        //  private readonly IProductRepository _productRepository;

        private readonly IGenericRepository<Product> _productRepository;
        private readonly IGenericRepository<ProductBrand> _productBrandRepository;
        private readonly IGenericRepository<ProductType> _productTypeRepository;
        private readonly IMapper _mapper;

        public HomeController(IGenericRepository<Product> productRepository,
            IGenericRepository<ProductBrand> productBrandRepository,
            IGenericRepository<ProductType> productTypeRepository,
            IMapper mapper )
        {
           _productRepository = productRepository;
            _productBrandRepository = productBrandRepository;
            _productTypeRepository = productTypeRepository;
            _mapper = mapper;
        }



       

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<ProductToReturnDto>>> GetProducts()
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification();
            var data = await _productRepository.ListAsync(spec);
            // return Ok(data);
            //return data.Select(pro => new ProductToReturnDto
            //{
            //    id = pro.id,
            //    name = pro.name,
            //    description = pro.description,
            //    pictureUrl = pro.pictureUrl,
            //    price = pro.price,
            //    productBrand = pro.productBrand != null ? pro.productBrand.name : string.Empty,
            //    productType = pro.productType != null ? pro.productType.name : string.Empty

            //}).ToList();

            return Ok(_mapper.Map<IReadOnlyList<Product>,IReadOnlyList<ProductToReturnDto>>(data));
         }





        [HttpGet("{id}")]
        public  async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithProductTypeAndBrandsSpecification(id);

           // return await _productRepository.GetEntityWithSpec(spec);

            var product = await _productRepository.GetEntityWithSpec(spec);

            //return new ProductToReturnDto
            //{
            //    id = product.id,name = product.name,description = product.description,
            //    pictureUrl = product.pictureUrl,
            //    price = product.price,
            //    productBrand = product.productBrand!=null? product.productBrand.name:string.Empty,
            //    productType = product.productType!=null? product.productType.name:string.Empty
            //};

            return _mapper.Map<Product, ProductToReturnDto>(product);
        }




        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await _productBrandRepository.ListAllAsync());
        }





        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await _productTypeRepository.ListAllAsync());
        }

    }
}

