using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace backend.Models
{
    [Table("positions")]
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Position name is required")]
        [Column("name")]
        [StringLength(50, ErrorMessage = "Position name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Abbreviation is required")]
        [Column("abbreviation")]
        [StringLength(5, ErrorMessage = "Abbreviation cannot be longer than 5 characters")]
        public string Abbreviation { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [Column("description")]
        [StringLength(200, ErrorMessage = "Description cannot be longer than 200 characters")]
        public string Description { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        public virtual ICollection<Player> Players{ get; set; }
    }
}