using BrokerPremium.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BrokerPremium.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<InsurancePolicy> InsurancePolicies { get; set; }

        public DbSet<InsuranceClaim> InsuranceClaims { get; set; }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Insurer> Insurers { get; set; }

        public DbSet<InsuredObject> InsuredObjects { get; set; }

        public DbSet<TypeOfInsurance> TypeOfInsurances { get; set; }

        public DbSet<TypeOfObject> TypeOfObjects { get; set; }

        public DbSet<ClaimStatus> ClaimStatuses { get; set; }
    }
}