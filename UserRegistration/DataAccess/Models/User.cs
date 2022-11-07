using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.DataAccess.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }

        [Required(ErrorMessage = "Field can not be blank")]
        public int UserRoleId { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Forenames { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Surname { get; set; }
        
        [Column(TypeName = "nvarchar(20)")]
        public string? Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Email { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "Field can not be blank")]
        public string Password { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [ForeignKey("UserRoleId")]
        public virtual UserRole UserRole { get; set; }

    }
}
