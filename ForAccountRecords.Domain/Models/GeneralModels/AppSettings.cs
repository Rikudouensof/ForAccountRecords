using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.GeneralModels
{
  public class AppSettings
  {

    public string AsymetricEncryptPrivateKey { get; set; }

    public string AsymetricEncryptPublicKey { get; set; }

    public string SymetricEncryptKey { get; set; }

    public string SymetricEncryptIV { get; set; }

    public string? SendGridEmailApiKey { get; set; }

    public string? SendGridSourceName { get; set; }
    public string? SmtpEmailAddress { get; set; }
    public string? SmtpPassword { get; set; }
  }
}
