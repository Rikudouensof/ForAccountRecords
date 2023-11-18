using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos
{
  public class BaseResponseDto<T> where T : class
  {

    public string ResponseCode { get; set; }

    public string ResponseMessage { get; set; }

    public T Response { get; set; }
  }
}
