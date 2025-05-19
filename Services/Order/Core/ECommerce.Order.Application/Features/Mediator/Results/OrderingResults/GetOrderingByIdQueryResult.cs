namespace ECommerce.Order.Application.Features.Mediator.Results.OrderingResults
{
    public class GetOrderingByIdQueryResult
    {
        public int OrderingId { get; set; }
        public string UserId { get; set; }
        public decimal TotalPrice { get; set; } // Assuming TotalPrice is calculated in the domain entity
        public DateTime OrderDate { get; set; }
    }
}
