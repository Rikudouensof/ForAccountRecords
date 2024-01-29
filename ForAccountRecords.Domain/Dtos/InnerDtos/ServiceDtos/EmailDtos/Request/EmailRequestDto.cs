using ForAccountRecords.Domain.ViewModels.InternalViewModels;
using System.ComponentModel.DataAnnotations;


namespace ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.EmailDtos.Request
{
    public class EmailRequestDto : BaseRequestDto<string>
    {
        public EmailViewmodel EmailData { get; set; }

        [Required]
        public string SourceName { get; set; }


    }
}
