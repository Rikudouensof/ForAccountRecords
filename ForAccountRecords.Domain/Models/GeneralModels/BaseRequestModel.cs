using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.GeneralModels
{
    public class BaseRequestModel
    {
        [Required]
        public string RequestId { get; set; }


        [Required]
        public string Ip { get; set; }
    }
}
