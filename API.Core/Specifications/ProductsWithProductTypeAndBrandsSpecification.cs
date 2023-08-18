using System;
using System.Linq.Expressions;
using API.Core.DbModels;

namespace API.Core.Specifications
{
    public class ProductsWithProductTypeAndBrandsSpecification : BaseSpecification<Product>
    {
        public ProductsWithProductTypeAndBrandsSpecification()
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);
        }

        public ProductsWithProductTypeAndBrandsSpecification(int id)
            :base(x=>x.id==id)
        {
            AddInclude(x => x.productBrand);
            AddInclude(x => x.productType);

        }
    }
}

