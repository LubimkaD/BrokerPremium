using BrokerPremium.Infrastructure.Data;
using BrokerPremium.Infrastructure.Data.Common;

namespace Warehouse.Infrastructure.Data.Repositories
{
    public class ApplicatioDbRepository : Repository, IApplicatioDbRepository
    {
        public ApplicatioDbRepository(ApplicationDbContext context)
        {
            this.Context = context;
        }
    }
}