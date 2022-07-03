using KamasutraAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace KamasutraAPI.Context
{
    public partial class KamasutraContext : DbContext
    {
        public KamasutraContext(DbContextOptions<KamasutraContext> options) : base(options) { }

        public virtual DbSet<KamasutraAction>? KamasutraAction { get; set; }
        public virtual DbSet<BodyPart>? BodyPart { get; set; }
        public virtual DbSet<Position>? Position { get; set; }
    }
}
