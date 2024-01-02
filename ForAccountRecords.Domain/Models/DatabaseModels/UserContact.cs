using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
    public class UserContact
    {

        [Key]
        public long Id { get; set; }

        [Required]
        public string FullName { get; set; }
        public string Address { get; set; }
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

        public string SecondPhoneNumber { get; set; }
        public string ThirdPhoneNumber { get; set; }



        //Relationships
        public virtual User User { get; set; }
        public long UserId { get; set; }

        public virtual UserContactsCategory UserContactsCategory { get; set; }
        public int UserContactsCategoryId { get; set; }
    }
}
