using System.Threading.Tasks;
using Pos.Domain.Infrastructure;
using Pos.Domain.Models;

namespace Pos.Domain.Interfaces
{
    public interface IShiftsService: IInitializer
    {
        void CancelCloseShift(int shiftId);
        double CloseShift(int shiftId);
        Task<Result> GetUserCurrentShift(string userId, int machineId = 0);
        Task<int> OpenShift(string userId, int? machineId);
    }
}