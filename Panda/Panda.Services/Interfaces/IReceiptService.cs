namespace Panda.Services.Interfaces
{
    using Panda.Models.Entities;
    using System;
    using System.Collections.Generic;

    public interface IReceiptService
    {
        void AddReceipt(Receipt receipt);

        IEnumerable<Receipt> GetUserReceipts(string username);

        Receipt GetReceiptById(Guid id);
    }
}
