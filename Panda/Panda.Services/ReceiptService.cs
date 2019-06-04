namespace Panda.Services
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Panda.Data;
    using Panda.Models.Entities;
    using Panda.Services.Interfaces;

    public class ReceiptService : IReceiptService
    {
        private PandaDbContext _dbContext;

        public ReceiptService(PandaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<Receipt> GetUserReceipts(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == username);

            if (user == null)
            {
                throw new InvalidOperationException("There is no such user!");
            }

            var receipts = _dbContext.Receipts.Where(r => r.RecipientId == user.Id).ToArray();

            return receipts;
        }
    }
}
