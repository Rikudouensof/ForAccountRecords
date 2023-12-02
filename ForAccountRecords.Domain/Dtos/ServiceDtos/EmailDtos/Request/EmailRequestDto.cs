using ForAccountRecords.Domain.ViewModels;
using System.ComponentModel.DataAnnotations;


namespace ForAccountRecords.Domain.Dtos.ServiceDtos.EmailDtos.Request
{
    public class EmailRequestDto : BaseRequestDto<string>
    {
        public EmailViewmodel EmailData { get; set; }

        [Required]
        public string SourceName { get; set; }


    }
}
