﻿namespace ECommerce.WebUI.DTOs.CatalogDtos.ProductDtos
{
    public class CreateProductDto
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string CategoryId { get; set; }
        public string ImageUrl { get; set; }
    }
}
