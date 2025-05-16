namespace ECommerce.Order.Application.Features.CQRS.Commands
{
    public record CreateAddressCommand
    {
        public string UserId { get; init; }
        public string Name { get; init; }
        public string Surname { get; init; }
        public string City { get; init; }
        public string District { get; init; }
        public string AddressLine { get; init; }
    }
}
