using System;
using API.Core.DbModels;
using API.Dtos;
using AutoMapper;

namespace API.Helpers
{
	public class MappingProfiles : Profile
	{
		public MappingProfiles()
		{
			CreateMap<Product, ProductToReturnDto>()
				.ForMember(x => x.productBrand, o => o.MapFrom(s => s.productBrand.name))
				.ForMember(x => x.productType, o => o.MapFrom(s => s.productType.name))
				.ForMember(x => x.pictureUrl, o => o.MapFrom<ProductUrlResolver>());


        }
	}
}

