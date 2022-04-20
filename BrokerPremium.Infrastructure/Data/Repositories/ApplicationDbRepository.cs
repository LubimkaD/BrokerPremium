using BrokerPremium.Infrastructure.Data;
using BrokerPremium.Infrastructure.Data.Common;

namespace BrokerPremium.Infrastructure.Data.Repositories
{
    public class ApplicationDbRepository : Repository, IApplicationDbRepository
    {
        public ApplicationDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}