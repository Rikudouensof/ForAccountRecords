using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.EndPointDtos.UserEndpointDto
{
    public class UserDetailEndpointOutputDto
    {



        [Key]
        public long Id { get; set; }

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
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "Accepts News Letter")]
        public bool IsNewsLetter { get; set; }

        [Required]
        public bool IsEmailConfirmed { get; set; }

        public DateTime LastOnline { get; set; }

        public string Role { get; set; }
    }
}
