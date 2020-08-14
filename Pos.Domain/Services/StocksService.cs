using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Pos.Domain.Enums;

namespace Pos.Domain.Services
{
    public interface IStockService : IInitializer
    {
        Task<bool> UpdateStock(Stock stock, Operation operation, bool saveChanges = false);
        Task<double> GetStock(int productId, int pointId);
    }

  

    public class StockService : ServicesBase, IStockService
    {
        async Task<double> IStockService.GetStock(int productId, int pointId)
        {
            var stock = await Context.Stocks.SingleOrDefaultAsync(s => s.PointId == pointId && s.ProductId == productId);
            return stock?.Amount ?? 0;
        }

        async Task<bool> IStockService.UpdateStock(Stock stock,Operation operation, bool saveChanges)
        {
            var amount = stock.Amount * (operation == Operation.Put ? 1 : -1);
            var oldStock = await Context.Stocks.SingleOrDefaultAsync(s => s.PointId == stock.PointId && s.ProductId == stock.ProductId);
            if (oldStock != null)
                oldStock.Amount += amount;
            else
            {
                stock.Amount = amount;
                Context.Stocks.Add(stock);
            }

            return !saveChanges || await Context.SaveChangesAsync() > 0;
        }
    }

}

