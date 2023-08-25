using System;
using API.Core.DbModels;

namespace API.Core.Specifications
{
	public class ProductWithFilterForCountSpecification :BaseSpecification<Product>
	{
		public ProductWithFilterForCountSpecification(ProductSpecParams productSpecParams)
            : base(x =>
             (string.IsNullOrWhiteSpace(productSpecParams.Search) || x.name.ToLower().Contains(productSpecParams.Search))
            &&
            (!productSpecParams.BrandId.HasValue || x.productBrandId == productSpecParams.BrandId)
            &&
            (!productSpecParams.TypeId.HasValue || x.productTypeId == productSpecParams.TypeId)
            )
        {
		}
	}
}

