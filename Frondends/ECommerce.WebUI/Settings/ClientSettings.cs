namespace ECommerce.WebUI.Settings
{
    public class ClientSettings
    {
        public Client AdminClient { get; set; }
        public Client VisitorClient { get; set; }




        public class Client
        {
            public string ClientId { get; set; }
            public string ClientSecret { get; set; }

        }
    }
}
