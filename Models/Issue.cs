using System.ComponentModel.DataAnnotations;

public class Issue
{
    [Key]
    public int Id { get; set; }
    public int Severity { get; set; }
    public string Description { get; set; }
}
