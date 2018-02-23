using Microsoft.EntityFrameworkCore;

namespace DataLogic.Entities
{
    public class BaseContext:DbContext
    {
        private static bool _create = false;

        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            if (!_create)
            {
                _create = true;
                Database.EnsureCreated();
            }
        }

        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<State> State { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<City>()
                   .Property(e => e.nameCity)
                   .IsUnicode(false);

            builder.Entity<Country>()
                .Property(e => e.nameCountry)
                .IsUnicode(false);

            builder.Entity<State>()
                .Property(e => e.nameState)
                .IsUnicode(false);

            base.OnModelCreating(builder);
        }
    }
}
