using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ASPCoreCRUD_DI.Entities.Models
{
    public record Item
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required]
        public string? Text { get; set; }
        [Required]
        public bool? Status { get; set; }
        [Required]
        public DateTime? Date { get; set; }
    }
}
