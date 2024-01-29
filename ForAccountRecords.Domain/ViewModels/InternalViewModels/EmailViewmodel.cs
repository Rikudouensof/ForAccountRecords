using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.InternalViewModels
{
    public class EmailViewmodel
    {


        [EmailAddress, Required]
        public string RecipeientEmailAddress { get; set; }


        [Required]
        public string Subject { get; set; }

        [Required]
        public string Body { get; set; }

        public byte[]? Attachment { get; set; }

        public string? CC { get; set; }
        public string? BCC { get; set; }


    }

}
