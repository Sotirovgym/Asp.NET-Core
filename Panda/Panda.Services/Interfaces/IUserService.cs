﻿namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using Panda.Models.Enums;
    using System;
    using System.Collections.Generic;

    public interface IUserService
    {
        IEnumerable<Package> GetPackages(string username);

        IEnumerable<Package> GetPackagesByStatus(Status status);

        MyIdentityUser GetUserById(string id);
    }
}