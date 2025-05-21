namespace ECommerce.Message.DTOs
{
    public class UpdateUserMessageDto
    {
        public string NameSurname { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageBody { get; set; }
        public bool IsRead { get; set; }
    }
}
