﻿using API.Core.DbModels;

namespace API.Dtos
{
    public class ProductToReturnDto
	{
        public int? id { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
        public string? pictureUrl { get; set; }
        public string? productType { get; set; }
        public string? productBrand { get; set; }
        
    }
}

