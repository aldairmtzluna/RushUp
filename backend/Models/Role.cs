using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace backend.Models
{
    [Table("roles")]
    public class Role
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Role name is required")]
        [Column("name")]
        [StringLength(50, ErrorMessage = "Role name cannot be longer than 50 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Role description is required")]
        [Column("description")]
        [StringLength(255, ErrorMessage = "Role description cannot be longer than 255 characters")]
        public string Description { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;
        
        public virtual ICollection<User> Users { get; set; }
    }
}