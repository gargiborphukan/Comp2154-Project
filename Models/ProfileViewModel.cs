using System.ComponentModel.DataAnnotations;

namespace Comp2154_System_Development_Project.Models;

//2ND PART
public class ProfileViewModel
{
    [Required]
    public string? FullName { get; set; }
    
    [DataType(DataType.Date)]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    public DateTime? Birthday { get; set; }
    
    [Phone]
    public string? PhoneNumber { get; set; }
    
}