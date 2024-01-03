using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.EndPointDtos.EntryEndpointDtos
{
    public class EntryEndpointDataDto
    {

       
        public long Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Units { get; set; }


        public string RefrenceNumber { get; set; }


        [Required]
        public int EntryTypeId { get; set; }
        

        [Required]
        public int SubTransactionClassificationId { get; set; }
      

        [Required]
        public long UserId { get; set; }
    }
}
