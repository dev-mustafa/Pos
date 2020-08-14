using Pos.Domain.Entities;
using Pos.Domain.Infrastructure;

namespace Pos.Domain.Interfaces
{
    public interface ISettingsService : IInitializer
    {
        Setting GetSettings();

    }
}
