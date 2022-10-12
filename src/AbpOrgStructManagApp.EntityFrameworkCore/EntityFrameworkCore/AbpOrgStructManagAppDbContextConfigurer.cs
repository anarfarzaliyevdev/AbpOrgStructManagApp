using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace AbpOrgStructManagApp.EntityFrameworkCore
{
    public static class AbpOrgStructManagAppDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<AbpOrgStructManagAppDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<AbpOrgStructManagAppDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
