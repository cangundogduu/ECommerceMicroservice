namespace ECommerce.Basket.Services.UserServices
{
    public class UserService(IHttpContextAccessor _contextAccessor) : IUserService
    {
        public string GetUserId => _contextAccessor.HttpContext.User.FindFirst("sub").Value;
    }
}
