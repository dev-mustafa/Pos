using System.Linq;
using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;
using Pos.Domain.Interfaces;

namespace Pos.Domain.Services
{
    public class SettingsService : ServicesBase, ISettingsService
    {
        Setting ISettingsService.GetSettings()
        {
            return Context.Settings.FirstOrDefault();
        }     
    }
}
