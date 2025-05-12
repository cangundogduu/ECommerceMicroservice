namespace ECommerce.Discount.Entities
{
    public class Coupon
    {
        public int CouponId { get; set; }
        public string Code { get; set; }
        public int DiscountRate { get; set; }
        public DateTime ExpireDate { get; set; }
        public string ProductId { get; set; }
        public bool IsActive { get; set; }

    }
}
