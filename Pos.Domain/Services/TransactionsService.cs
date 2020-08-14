using System.Threading.Tasks;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Services
{
    public interface ITransactionsService : IInitializer
    {
        Task<bool> AddTransaction(Transaction transaction);
    }
    public class TransactionsService : ServicesBase, ITransactionsService
    {
        async Task<bool> ITransactionsService.AddTransaction(Transaction transaction)
        {
            return await CrudService.Add(transaction, p => p.Number == transaction.Number && p.PersonId == transaction.PersonId && p.TransactionType != transaction.TransactionType);
        }    
    }
}
