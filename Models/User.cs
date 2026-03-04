using System.ComponentModel.DataAnnotations;

namespace Comp2154_System_Development_Project.Models;

//1ST PART--
public class User
{
    //Unique identifier for each user,
    //primary key in the database
    public int Id { get; set; }

    [Required]
    [EmailAddress]
    //stores the users email,must be filled and properly formatted
    public string Email { get; set; } = null; //3RD PArt

    [Required]
    //stores the users password, required to log in
    public string Password { get; set; } = null; //3RD PART
    
 //2ND PART---
    public string? FullName { get; set; }
    
    public DateTime? Birthday { get; set; }
    
    public string? PhoneNumber { get; set; }
}