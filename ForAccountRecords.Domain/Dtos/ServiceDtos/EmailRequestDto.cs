﻿using ForAccountRecords.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;


namespace ForAccountRecords.Domain.Dtos.ServiceDtos
{
  public class EmailRequestDto : BaseRequestDto
  {
    public EmailViewmodel EmailData { get; set; }

    [Required]
    public string SourceName { get; set; }


  }
}
