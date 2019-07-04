namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using System.Collections.Generic;

    public interface IUserService
    {
        MyIdentityUser GetUserById(string id);

        IEnumerable<MyIdentityUser> GetUsers();
    }
}
