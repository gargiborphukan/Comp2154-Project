using System.ComponentModel.DataAnnotations;

namespace Comp2154_System_Development_Project.Models;


public class User
{
    //Unique identifier for each user,
    //primary key in the database
    public int Id { get; set; } 
    
    [Required]
    [EmailAddress]
    //stores the users email,must be filled and properly formatted
    public string Email { get; set; }
    
    [Required]
    //stores the users password, required to log in
    public string Password { get; set; }
}