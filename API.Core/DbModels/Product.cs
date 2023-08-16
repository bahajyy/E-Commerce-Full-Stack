using System;
namespace API.Core.DbModels
{
	public class Product : BaseEntity
	{
		public string? name { get; set; }
        public string? description { get; set; }
        public decimal? price  { get; set; }
        public string? pictureUrl { get; set; }

        public ProductType? productType { get; set; }
        public int? productTypeId{ get; set; }

        public ProductBrand? productBrand{ get; set; }
        public int? productBrandId { get; set; }


    }
}

