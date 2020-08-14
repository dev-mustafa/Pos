using System;

namespace Pos.Domain.Infrastructure
{
    public interface IInitializer : IDisposable
    {
        void Initialize(PosContext context);
        void SaveChanges();
    }
}
