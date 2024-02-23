using System.ComponentModel.DataAnnotations;

public class Issue
{
    [Key]
    public int Id { get; set; }
    [Required(ErrorMessage = "Severity is required.")]
    public int Severity { get; set; }
    [Required(ErrorMessage = "Description is required.")]
    public string Description { get; set; }
}
