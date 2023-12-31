using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
  public class User
  {

    [Key]
    public int Id { get; set; }

    [Required]
    public string FirstName { get; set; }

    public string MiddleName { get; set; }

    [Required]
    public string LastName { get; set; }

    [Required] 
    public string UserName { get; set; }

    [EmailAddress]
    public string EmailAddress { get; set; }

    [Phone]
    public string PhoneNumber { get; set; } = string.Empty;

    [Required]
    public string Password { get; set; }

    [Required]
    public bool IsNewsLetter { get; set; }

    [Required]
    public bool IsEmailConfirmed { get; set; }

    [Required]
    public string ConfirmationCode { get; set; }
    public DateTime ConfirmationCodeDate { get; set; }
    public DateTime JoinedOn { get; set; }

    public DateTime LastOnline { get; set; }

    [Required]
    public bool IsDeleted { get; set; }

        public UserRole UserRolesId { get; set; }
    }
}
