namespace AspPanda.Data.Managers
{
    using AspPanda.Data.Interfaces;
    using AspPanda.Data.Repositories;
    using AspPanda.Models.ViewModels;

    public class UserManager
    {
        private IUserRepository userRepository;

        public UserManager()
        {
            this.userRepository = new UserRepository();
        }

        public UserManager(IUserRepository userRepository)
        {
            this.userRepository = new UserRepository();
        }

        public void CreateUser(RegisterViewModel user)
        {
            this.userRepository.CreateUser(user);
        }
    }
}
