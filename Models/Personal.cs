using System.ComponentModel.DataAnnotations;

namespace apiRest.Models;

public class Personal
{
    [Key]
    public int Usr_id {get; set; }

    [Required]
    [MaxLength(20)]
    public string? Usr_name {get; set; }

    [Required]
    [MaxLength(20)]
    public string? First_name {get; set; }
    
    [Required]
    [MaxLength(20)]
    public string? Last_name {get; set; }
}