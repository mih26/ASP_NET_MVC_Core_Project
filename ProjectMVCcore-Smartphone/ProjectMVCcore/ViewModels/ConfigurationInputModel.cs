using ProjectMVCcore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVCcore.ViewModels
{
    public class ConfigurationInputModel
    {
        public int ConfigurationId { get; set; }
        [Required, StringLength(30)]
        public string ConfigurationDetails { get; set; } = default!;
        [Required, StringLength(50)]
        public string BrandValue { get; set; } = default!;
        [Required, ForeignKey("Smartphone")]
        public int SmartphoneId { get; set; }
    }
}
