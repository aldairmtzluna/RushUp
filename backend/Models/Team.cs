using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace backend.Models
{
    [Table("teams")]
    public class Team
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "The team name is required")]
        [Column("name")]
        [StringLength(50, ErrorMessage = "The team name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "The team coty is required")]
        [Column("city")]
        [StringLength(20, ErrorMessage = "The team city cannot be longer than 20 characters")]
        public string City { get; set; }

        [Column("logo")]
        public string? Logo { get; set; }

        [Column("description")] 
        public string? Description { get; set; }

        [Required(ErrorMessage = "User is required")]
        [Column("owner_id")]
        public int OwnerId { get; set; }

        [ForeignKey("Owner")]
        public virtual User Owner { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        public virtual ICollection<TeamMember> TeamMembers { get; set; }
        
    }
}
