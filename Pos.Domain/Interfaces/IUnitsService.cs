using System.Collections.Generic;
using System.Threading.Tasks;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Interfaces
{
    public interface IUnitsService: IInitializer
    {
        Task<bool> AddUnit(Unit unit);
        Task<bool?> UpdateUnit(Unit unit);
        Task<bool?> DeleteUnit(int unitId, bool removeRelatedEntities = false);
        Task<Unit> FindUnit(int unitId);
        Task<List<Unit>> GetAllUnits();
    }
}