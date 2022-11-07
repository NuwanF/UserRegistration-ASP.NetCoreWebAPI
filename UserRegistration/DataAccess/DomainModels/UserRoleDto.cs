using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace UserRegistration.DataAccess.DomainModels
{
    public class UserRoleDto
    {
        public int UserRoleId { get; set; }

        public string UserRoleName { get; set; }
    }
}
