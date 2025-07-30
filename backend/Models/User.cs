using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;


namespace backend.Models
{
    [Table("users")]
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; set; }

        [Required(ErrorMessage = "First name is required")]
        [Column("first_name")]
        [StringLength(25, ErrorMessage = "Name cannot be longer than 25 characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last name is required")]
        [Column("last_name")]
        [StringLength(25, ErrorMessage = "Last name cannot be longer than 25 characters")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [Column("email")]
        [StringLength(100, ErrorMessage = "Email cannot be longer than 100 characteres")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [Column("phone_number")]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must be numeric and exactly 10 digits")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [Column("password")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Birthdate is required")]
        [Column("birthdate")]
        public DateTimeOffset Birthdate { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [Column("address")]
        [StringLength(150, ErrorMessage = "Address cannot be longer than 150 characters")]
        public String Address { get; set; }

        [Required(ErrorMessage = "State is required")]
        [Column("state")]
        [StringLength(30, ErrorMessage = "State cannot be longer than 30 characters")]
        public string State { get; set; }

        [Required(ErrorMessage = "Role is required")]
        [Column("role_id")]
        public int RoleId { get; set; }

        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        [Column("profile_photo")]
        public string? ProfilePhoto { get; set; }

        [Column("gender")]
        public string? Gender { get; set; }

        [Column("status")]
        public bool Status { get; set; }

        [Column("created_at")]
        public DateTimeOffset CreatedAt { get; set; } = DateTimeOffset.UtcNow;

        [Column("updated_at")]
        public DateTimeOffset UpdatedAt { get; set; } = DateTimeOffset.UtcNow;

        // Method to set password with hash ------------------ Método para establecer contraseña con hash
        public void SetPassword(string password)
        {
            if (string.IsNullOrWhiteSpace(password))
                throw new ArgumentException("Password cannot be empty");

            if (password.Length < 8)
                throw new ArgumentException("Password must be at least 8 characters long");

            if (!Regex.IsMatch(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^\da-zA-Z]).{8,}$"))
                throw new ArgumentException("Password must contain at least one uppercase letter, on e lowercase letter, one number, and one special character");

            // Using BCrypt for secure password hashing -------------- Uso de BCrypt para el hash seguro de contraseñas
            Password = BCrypt.Net.BCrypt.EnhancedHashPassword(password, 13);
        }

        // Method to verify password ----------- Método para verificar contraseña
        public bool VerifyPassword(string password)
        {
            return BCrypt.Net.BCrypt.EnhancedVerify(password, Password);
        }
        // Un usuario puede SER DUEÑO de varios equipos (relación 1 a muchos)
        public virtual ICollection<Team> OwnedTeams { get; set; }

        // Un usuario puede SER MIEMBRO de varios equipos (a través de TeamMember)
        public virtual ICollection<TeamMember> TeamMemberships { get; set; }
    }
}