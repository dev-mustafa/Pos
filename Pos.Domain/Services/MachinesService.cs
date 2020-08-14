using System.Linq;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;
using Pos.Domain.Interfaces;

namespace Pos.Domain.Services
{
    public class MachinesService : ServicesBase, IMachinesService
    {
        Machine IMachinesService.GetMachineByName(string name)
        {
            return Context.Machines.FirstOrDefault(m => m.Name == name);
        }
    }
}
