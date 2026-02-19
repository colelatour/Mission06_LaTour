using System.ComponentModel.DataAnnotations;


namespace Mission06_LaTour.Models;

public class Categories
{
    [Key]
    [Required]
    public int CategoryId { get; set; }
    
    [Required]
    public string CategoryName { get; set; } = string.Empty;
}
