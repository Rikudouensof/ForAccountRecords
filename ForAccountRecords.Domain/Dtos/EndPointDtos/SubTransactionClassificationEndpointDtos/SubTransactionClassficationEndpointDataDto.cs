﻿using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.EndPointDtos.SubTransactionClassificationEndpointDtos
{
    public class SubTransactionClassficationEndpointDataDto
    {


        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int TransactionClassificationId { get; set; }

    }
}
