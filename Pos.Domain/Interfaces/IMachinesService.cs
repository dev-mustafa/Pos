using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Interfaces
{
    public interface IMachinesService : IInitializer
    {
        Machine GetMachineByName(string name);
    }
}