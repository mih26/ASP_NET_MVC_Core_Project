using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectMVCcore.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ProjectMVCcore.ViewModels
{
    public class SmartphoneInputModel
    {
        public int SmartphoneId { get; set; }
        [Required, StringLength(50)]
        public string SmartphoneModel { get; set; } = default!;
        [Required, Column(TypeName = "date")]
        public DateTime ManufactureDate { get; set; } = DateTime.Today;
        [Required, Column(TypeName = "money")]
        public decimal Price { get; set; }
        public bool Instock { get; set; }
        [StringLength(30)]
        public string Picture { get; set; } = default!;
        public List<ConfigurationInputModel> configurations { get; set; } = new List<ConfigurationInputModel>();
    }
}
