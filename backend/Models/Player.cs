using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace backend.Models
{
    [Table("players")]
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Player number is required")]
        [Column("number")]
        [StringLength(50, ErrorMessage = "Player number cannot be longer than 50 characters")]
        public string Number { get; set; }

        [Required(ErrorMessage = "Team member is required")]
        [Column("team_member_id")]
        public int TeamMemberId { get; set; }

        [ForeignKey("TeamMemberId")]
        public virtual TeamMember TeamMember { get; set; }

        [Required(ErrorMessage = "Position is required")]
        [Column("position_id")]
        public int PositionId { get; set; }

        [ForeignKey("PositionId")]
        public virtual Position Position { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
    }
}
