namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;

    public interface IUserService
    {
        MyIdentityUser GetUserById(string id);
    }
}
