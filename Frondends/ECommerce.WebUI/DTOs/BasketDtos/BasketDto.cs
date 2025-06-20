﻿namespace ECommerce.WebUI.DTOs.BasketDtos
{
    public class BasketDto
    {
        public string UserId { get; set; }
        public string? DiscountCode { get; set; }
        public int DiscountRate { get; set; }
        public List<BasketItemDto> BasketItems { get; set; }

        public decimal TotalPrice 
        { 
            get => BasketItems.Sum(x => x.Price * x.Quantity); 
        }
    }
}
