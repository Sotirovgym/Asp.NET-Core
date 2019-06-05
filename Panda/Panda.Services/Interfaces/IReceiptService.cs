namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using System;
    using System.Collections.Generic;

    public interface IReceiptService
    {
        IEnumerable<Receipt> GetUserReceipts(string username);

        Receipt GetReceiptById(Guid id);
    }
}
