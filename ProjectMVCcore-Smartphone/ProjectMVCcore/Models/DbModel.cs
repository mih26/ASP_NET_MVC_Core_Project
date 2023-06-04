using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ProjectMVCcore.Models
{
        public class Smartphone
        {
            public int SmartphoneId { get; set; }
            [Required, StringLength(50)]
            public string SmartphoneModel { get; set; } = default!;
            [Required, Column(TypeName = "date")]
            public DateTime ManufactureDate { get; set; } = DateTime.Today;
            [Required, Column(TypeName = "money")]
            public decimal Price { get; set; }
            public bool Instock { get; set; }
            [Required, StringLength(30)]
            public string Picture { get; set; } = default!;
            public virtual ICollection<Configuration> Configurations { get; set; } = new List<Configuration>();
        }
        public class Configuration
        {
            public int ConfigurationId { get; set; }
            [Required, StringLength(30)]
            public string ConfigurationDetails { get; set; } = default!;
            [Required, StringLength(50)]
            public string BrandValue { get; set; } = default!;
            [Required, ForeignKey("Smartphone")]
            public int SmartphoneId { get; set; }
            public virtual Smartphone Smartphone { get; set; } = default!;
        }
    public class SmartphoneDbContext : DbContext
    {
        public SmartphoneDbContext(DbContextOptions<SmartphoneDbContext> options) : base(options) { }
        public DbSet<Smartphone> Smartphones { get; set; } = default!;
        public DbSet<Configuration> Configurations { get; set; } = default!;
    }
}
