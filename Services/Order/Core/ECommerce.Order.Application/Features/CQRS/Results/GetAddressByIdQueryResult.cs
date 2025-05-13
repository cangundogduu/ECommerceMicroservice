namespace ECommerce.Order.Application.Features.CQRS.Results
{
    public class GetAddressByIdQueryResult
    {
        public int AddressId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string AddressLine { get; set; }
    }
}
