using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mission06_LaTour.Models;

[Table("Movies")]
public class Collection
{
    [Key]
    [Required]
    public int MovieId { get; set; }
    
    [Required]
    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Categories? Category { get; set; }
    
    [Required]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    public bool Edited { get; set; }

    public string? LentTo { get; set; }
    
    public int CopiedToPlex { get; set; }

    public string? Notes { get; set; }

}
