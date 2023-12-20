using System.ComponentModel.DataAnnotations;


namespace ForAccountRecords.Domain.ViewModels.UserManagementViewModels
{
  public class ForgotPasswordViewModel
  {
    [Required]
    [Display(Name = "UserName or Email Address")]
    public string UserInput { get; set; }
  }
}
