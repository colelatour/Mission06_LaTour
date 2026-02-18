using System.ComponentModel.DataAnnotations;


namespace Mission06_LaTour.Models;

public class Categories
{
    [Key]
    [Required]
    public int CategoryID { get; set; }
    
    public string CategoryName { get; set; }
}