using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos
{
  public class BaseRequestDto<T> : BaseRequestModel where T : class 
    {

    [Required]
    public AppSettings AppSettings { get; set; }

   
    [Required]
    public T InputData { get; set; }


  }
}
