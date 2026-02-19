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
    [Display(Name = "Title")]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [Range(1888, int.MaxValue, ErrorMessage = "Year must be 1888 or later.")]
    public int Year { get; set; }
    
    public string? Director { get; set; }
    
    public string? Rating { get; set; }

    [Required(ErrorMessage = "Edited is required.")]
    public bool? Edited { get; set; }

    public string? LentTo { get; set; }
    
    [Required(ErrorMessage = "Copied to Plex is required.")]
    public bool? CopiedToPlex { get; set; }

    public string? Notes { get; set; }

}
