using System;
using System.Security.Principal;

namespace AspPanda.Models.ViewModels
{
    public class SessionUser
    {
        public SessionUser(Guid id, string username, IIdentity identity)
        {
            this.Id = Id;
            this.Username = username;
            this.Identity = new GenericIdentity(username);
        }

        public Guid Id { get; set; }

        public string Username { get; set; }

        public IIdentity Identity { get; set; }
    }
}
