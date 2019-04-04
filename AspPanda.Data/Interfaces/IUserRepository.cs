namespace AspPanda.Data.Interfaces
{
    using AspPanda.Models.ViewModels;

    public interface IUserRepository
    {
        void CreateUser(RegisterViewModel user);
    }
}
