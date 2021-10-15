using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using SisHack.Infrastructure.Mappings;

namespace SisHack.Infrastructure.Context
{
    public class SisHackContext : DbContext
    {
        #region Public Fields

        public static readonly ILoggerFactory _loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddConsole();
        });

        #endregion Public Fields

        #region Public Constructors

        public SisHackContext(DbContextOptions options) : base(options)
        {
        }

        #endregion Public Constructors

        #region Protected Methods

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(_loggerFactory);
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PeopleMapping());
        }

        #endregion Protected Methods
    }
}