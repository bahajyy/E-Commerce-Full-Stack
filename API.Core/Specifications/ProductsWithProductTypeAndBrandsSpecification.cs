using System;
using System.Linq.Expressions;
using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification(ProductSpecParams productSpecParams)
            :base(x =>
            (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.BrandId.HasValue || x.productBrandId == productSpecParams.BrandId)
            &&
            (!productSpecParams.TypeId.HasValue || x.productTypeId == productSpecParams.TypeId)
            )
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
            // AddOrderBy(x => x.name);
            
            ApplyPaging(productSpecParams.PageSize * (productSpecParams.PageIndex - 1), productSpecParams.PageSize);

            if (!string.IsNullOrWhiteSpace(productSpecParams.Sort))
            {
                switch (productSpecParams.Sort)
                {
                    case "priceAsc":
                        AddOrderBy(p => p.price);
                        break;
                    case "priceDesc":
                        AddOrderByDescending(p => p.price);
                        break;
                    default:
                        AddOrderBy(x => x.name);
                        break;
                }
            }
        }

        public ProductsWithProductTypeAndBrandsSpecification(int id)
            :base(x=>x.id==id)
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);

        }
    }
}

