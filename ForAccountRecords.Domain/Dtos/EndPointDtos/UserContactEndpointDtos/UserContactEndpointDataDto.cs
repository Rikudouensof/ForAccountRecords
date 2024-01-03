using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.EndPointDtos.UserContactEndpointDtos
{
    public class UserContactEndpointDataDto
    {

        
        public long Id { get; set; }

        [Required]
        public string FullName { get; set; }


        public string Address { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [EmailAddress]
        public string EmailAddress { get; set; }

        [Url]
        public string facbookUrl { get; set; }

        [Url]
        public string XUrl { get; set; }

        [Url]
        public string linkedInUrl { get; set; }

        [Url]
        public string Website { get; set; }


        [Phone]
        public string SecondPhoneNumber { get; set; }

        [Phone]
        public string ThirdPhoneNumber { get; set; }




        [Required]
        public long UserId { get; set; }

        [Required]
        public int UserContactsCategoryId { get; set; }
    }
}
