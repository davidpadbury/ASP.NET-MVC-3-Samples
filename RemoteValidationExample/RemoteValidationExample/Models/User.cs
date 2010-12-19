
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace RemoteValidationExample.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [Remote("IsUserNameUnique", "User", ErrorMessage = "UserName already taken")]
        public string UserName { get; set; }
    }
}