using System;
using API.Core.DbModels;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
	public class ProductUrlResolver :IValueResolver<Product,ProductToReturnDto,string>
	{
        private readonly IConfiguration _config;

        public ProductUrlResolver(IConfiguration config)
		{
            _config = config;
		}

        public string Resolve(Product source, ProductToReturnDto destination, string destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(source.pictureUrl))
            {
                return _config["ApiUrl"] + source.pictureUrl;
            }
            return null;
        }
    }
}

